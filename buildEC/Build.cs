using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace buildEC
{
    static class Build
    {
        //Create static variables to be used through application
        public static Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        public static Worksheet excelWkSht = new Microsoft.Office.Interop.Excel.Worksheet();
        public static Service pubSvc = new Service();
        public static OpenQA.Selenium.IWebDriver driver;
        public static List<Controller> JSON = new List<Controller>();

        //Lists to hold the controllers and their IPs
        //Second list contains EC8s that need https for the URL
        public static readonly SortedList<string, string> ECLIST = new SortedList<string,string>() { { "CPA1", "10.34.107.194" }, { "CPA2", "10.34.107.202" }, { "Pitt", "10.34.95.210" }, { "Cherry Hill", "10.35.92.58" }, { "Monmouth", "10.35.89.66" }, { "Alexandria", "10.32.230.82" }, { "Carroll", "10.32.230.42" }, { "Chesterfield", "10.33.203.50" }, { "Dale City", "10.32.230.90" }, { "Dover", "10.32.230.50" }, { "Howard", "10.32.230.66" }, { "Staunton", "10.33.203.58" }, { "Hamden", "172.21.161.130" }, { "Londonderry", "172.21.77.66" }, { "Plymouth", "172.21.77.74" } };
        public static readonly List<string> EC8 = new List<string>() { "Cherry Hill", "Chesterfield", "Hamden", "Londonderry", "Plymouth" };

        //List to keep track of windows opened and which controller they are for to switch back if needed
        public static SortedList<string, string> WindowHandles = new SortedList<string, string>();

        //Method to instantiate a browser with the correct options set to access the ECs
        public static void initBrowser()
        {
            //Set encoding to avoid "encoding 437" error
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FirefoxOptions options = new FirefoxOptions();
            FirefoxProfile profile = new FirefoxProfile();
            profile.DeleteAfterUse = true;
            //Set preferences to allow EC pages to display
            profile.SetPreference("security.ssl3.dhe_rsa_aes_128_sha", false);
            profile.SetPreference("security.ssl3.dhe_rsa_aes_256_sha", false);
            options.Profile = profile;
            //Create Firefox service to hide console window for webdriver
            FirefoxDriverService ffService = FirefoxDriverService.CreateDefaultService();
            ffService.HideCommandPromptWindow = true;
            driver = new FirefoxDriver(ffService, options);
        }

        //Method to open the chosen excel file in a hidden application
        public static void openExcelFile(string fileName)
        {
            try
            {
                //excelApp.Visible = false;
                excelApp.Workbooks.Open(fileName);
                excelWkSht = excelApp.ActiveSheet;
            }
            catch (System.InvalidCastException)
            {
                MessageBox.Show("Cannot access the workbook " + fileName);
                exitApp();
            }

        }

        //Method to close the excel application
        public static void closeExcelFile()
        {
            excelApp.Quit();
        }

        //Method to quit application and close resources
        private static void exitApp()
        {
            Build.closeExcelFile();
            Build.driver.Quit();
            System.Windows.Forms.Application.Exit();
        }

        //Method to convert created JSON to ChannelMapInfo class
        public static void getJSON()
        {
            //This URL will most likely change
            string httpJSON = new WebClient().DownloadString(@"http://10.34.107.47/NSGCHECK/sessionData.json");
            JSON = JsonConvert.DeserializeObject<List<Controller>>(httpJSON);
            /*
            foreach (Controller c in JSON)
            {
                MessageBox.Show(c.controller);
            }
            */
        }

        //Method to get the service information from the excel file 
        //and assign the values to the correct variables
        public static Service getService(int row)
        {
            Service svc = new Service();

            try
            {
                string cellName = getCell(Form1.sourceNameCol, row);
                svc.SourceName = excelWkSht.Range[cellName].Value;
                cellName = getCell(Form1.sourceIdCol, row);
                svc.SourceId = Convert.ToInt32(excelWkSht.Range[cellName].Value);
                cellName = getCell(Form1.sourceIpCol, row);
                svc.SourceIp.Ip = excelWkSht.Range[cellName].Value;
                cellName = getCell(Form1.mcastIpCol, row);
                svc.MulticastIp.Ip = excelWkSht.Range[cellName].Value;
                cellName = getCell(Form1.udpPortCol, row);
                svc.UdpPort = Convert.ToInt32(excelWkSht.Range[cellName].Value);
                cellName = getCell(Form1.mpegCol, row);
                svc.ProgramNumber = Convert.ToInt32(excelWkSht.Range[cellName].Value);
                cellName = getCell(Form1.bandwidthCol, row);
                svc.Bandwidth = Convert.ToInt32(excelWkSht.Range[cellName].Value);
                cellName = getCell(Form1.deviceNameCol, row);
                svc.Qam.Name = excelWkSht.Range[cellName].Value;
                cellName = getCell(Form1.portCol, row);
                svc.Qam.Port = Convert.ToString(excelWkSht.Range[cellName].Value);
                cellName = getCell(Form1.controllerCol, row);
                svc.ControllerName = Convert.ToString(excelWkSht.Range[cellName].Value);
                cellName = getCell(Form1.frequencyCol, row);
                svc.Frequency = Convert.ToInt32(excelWkSht.Range[cellName].Value);
                cellName = getCell(Form1.dtaServiceCol, row);
                svc.dtaServiceKa(Convert.ToString(excelWkSht.Range[cellName].Value));
            }
            //if we encounter an error, return the partial information to be skipped in the main program
            catch(Exception e)
            {
                return svc;
            }

            return svc;
        }

        //Method to convert the row count and column letter into an Excel cell value
        private static string getCell(string column, int row)
        {
            string cellName = column + Convert.ToString(row);
            return cellName;
        }

        //Method to use credentials provided to log into an EC
        public static void gotoEC(string uName, string pw)
        {
            string url;
            bool ec8 = false;

            if (!ECLIST.ContainsKey(pubSvc.ControllerName))
            {
                Form1.workList.Remove(pubSvc.ControllerName);
                Form2 window = new Form2();
                window.ShowDialog();
                Form1.workList.Add(pubSvc.ControllerName);
            }

            if (EC8.Contains(pubSvc.ControllerName))
            {
                url = @"https://" + ECLIST[pubSvc.ControllerName] + @"/dncs/src/sourceTable.do";
                ec8 = true;
            }
            else
            {
                url = @"http://" + ECLIST[pubSvc.ControllerName] + @"/dncs/src/sourceTable.do";
            }

            if(WindowHandles.ContainsKey(pubSvc.ControllerName))
            {
                driver.SwitchTo().Window(WindowHandles[pubSvc.ControllerName]);
            }
            else
            {
                if(WindowHandles.Count != 0)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript($"window.open('#','_blank')");
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                }
                try
                {
                    driver.Navigate().GoToUrl($"{url}");
                }
                //Bypass the security warning
                catch (InvalidOperationException)
                {
                    driver.FindElement(By.Id("advancedButton")).Click();
                    driver.FindElement(By.Id("exceptionDialogButton")).Click();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Failed because {e}");
                    exitApp();
                }
                if (driver.Title.Contains("Control Suite"))
                {
                    //Enter the username and password
                    if (!ec8)
                    {
                        driver.FindElement(By.Id("label_username")).SendKeys($"{uName}" + OpenQA.Selenium.Keys.Tab + $"{pw}");
                    }
                    else
                    {
                        driver.FindElement(By.Id("loginPage_username")).SendKeys($"{uName}" + OpenQA.Selenium.Keys.Tab + $"{pw}");
                    }
                    //try to click the login button
                    try
                    {
                        if (!ec8)
                        {
                            driver.FindElement(By.Id("loginPage_loginSubmit")).Click();
                        }
                        else
                        {
                            driver.FindElement(By.XPath("//*[@widgetid='loginPage_LoginButton']")).Click();
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        MessageBox.Show("Cannot find the element by Xpath value given.");
                        exitApp();
                    }
                }
                //Store value of new window handle
                string wHandle = driver.CurrentWindowHandle.ToString();
                //add the controller name and the current window handle to a list
                WindowHandles.Add(pubSvc.ControllerName, wHandle);
            }
        }

        //Method to switch to EC instance already open
        public static void gotoEC()
        {
            string url;
            bool ec8 = false;

            if (!ECLIST.ContainsKey(pubSvc.ControllerName))
            {
                Form1.workList.Remove(pubSvc.ControllerName);
                Form2 window = new Form2();
                window.ShowDialog();
                Form1.workList.Add(pubSvc.ControllerName);
            }

            if (EC8.Contains(pubSvc.ControllerName))
            {
                url = @"https://" + ECLIST[pubSvc.ControllerName] + @"/dncs/src/sourceTable.do";
                ec8 = true;
            }
            else
            {
                url = @"http://" + ECLIST[pubSvc.ControllerName] + @"/dncs/src/sourceTable.do";
            }

            if (WindowHandles.ContainsKey(pubSvc.ControllerName))
            {
                driver.SwitchTo().Window(WindowHandles[pubSvc.ControllerName]);
                driver.Navigate().GoToUrl($"{url}");
            }
            else
            {
                MessageBox.Show(@"Could not find the controller " + pubSvc.ControllerName + ".");
                exitApp();
            }

        }

        //Method to change wait time for trying to find an element on the page
        private static void changeWaitTime(int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        //Method to select the source ID in the EC
        public static void selectSourceID(int sourceID)
        {
            try
            {
                changeWaitTime(15);
                IWebElement element = driver.FindElement(By.XPath("//*[local-name()='div'][@class='action_panel']//*[local-name()='select'][@name='filterType']"));
                SelectElement select = new SelectElement(element);
                select.SelectByIndex(1);
                element = driver.FindElement(By.XPath("//*[local-name()='div'][@class='filter_panel']//*[local-name()='input'][@id='valInput']"));
                changeWaitTime(0);
                element.Clear();
                element.SendKeys(Convert.ToString(sourceID));                
                driver.FindElement(By.XPath("//*[local-name()='div'][@class='filter_panel']//*[local-name()='button']")).Click();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Element searched for not found");
                exitApp();
            }
        }

        //Method to get to the Source Definition page
        public static void gotoSourceDef()
        {
            //consider adding logic to not renavigate if the source ID is the same as previous source ID
            try
            {
                driver.FindElement(By.XPath("//*[local-name()='table'][@id='sourceTable']//*[local-name()='input'][@type='checkbox']")).Click();
                driver.FindElement(By.XPath("//*[local-name()='div'][@class='action_body']//*[contains(@onclick,'startDef')]")).Click();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Element searched for could not be found");
                exitApp();
            }
        }

        public static void buildService()
        {
            SourceDef definition = new SourceDef();
            definition.GetSourceDefs();

            if (!definition.PcgExists())
            {
                if (!definition.PCGone && definition.PCGtwo)
                {
                    buildPCG(1);
                }
                else if (definition.PCGone && !definition.PCGtwo)
                {
                    buildPCG(2);
                }
                else
                {
                    buildPCG(1);
                    buildPCG(2);
                }
                driver.FindElement(By.XPath("//*[local-name()='a'][@id='Source Definitions URL']")).Click();
            }

            if (!definition.QamSessionExists())
            {
                buildQamSession();
                driver.FindElement(By.XPath("//*[local-name()='a'][@id='Source Definitions URL']")).Click();
            }

            if (!definition.NonSaExists() && pubSvc.DtaService)
            {
                buildNonSA();
                driver.FindElement(By.XPath("//*[local-name()='a'][@id='Source Definitions URL']")).Click();
            }
        }

        //Method to build and save PCG session
        private static void buildPCG(int p)
        {
            string pcgS = Regex.Replace(pubSvc.PCGsession, "(^[0-9]{2}:F[0-9]:0)0", "${1}" + Convert.ToString(p));
            driver.FindElement(By.XPath("//*[local-name()='button'][@value='Add']")).Click();
            IWebElement element = driver.FindElement(By.XPath("//*[local-name()='select'][contains(@name,'type')]"));
            SelectElement srcDefType = new SelectElement(element);
            srcDefType.SelectByIndex(findSelectOptionIndex("//*[local-name()='select'][contains(@name,'type')]/*", "PCG"));
            enterInputData("//*[local-name()='input'][@id='mac_address'][contains(@name,'pcg')]", pcgS);
            enterInputData("//*[local-name()='input'][contains(@name,'pcgSessionNumber')]", Convert.ToString(pubSvc.SourceId));
            element = driver.FindElement(By.XPath("//*[local-name()='select'][contains(@name,'pcgName')]"));
            SelectElement pcgName = new SelectElement(element);
            int pcgIdx = ((Convert.ToInt32(Regex.Replace(pubSvc.PCGsession, "00:F([0-9]):00:00:00:00", "${1}")) - 1) * 2);
            if (p == 2)
            {
                pcgIdx++;
            }
            pcgName.SelectByIndex(pcgIdx);
            driver.FindElement(By.XPath("//*[local-name()='input'][contains(@onclick,'sourceIdAsACRef')]")).Click();
            driver.FindElement(By.XPath("//*[local-name()='button'][@value='Save']")).Click();

            while (checkToast())
            {
                Thread.Sleep(500);
            }
            Thread.Sleep(2500);
        }

        //Method to build and save QAM session
        private static void buildQamSession()
        {
            driver.FindElement(By.XPath("//*[local-name()='button'][@value='Add']")).Click();
            IWebElement element = driver.FindElement(By.XPath("//*[local-name()='select'][contains(@name,'type')]"));
            SelectElement srcDefType = new SelectElement(element);
            //srcDefType.SelectByIndex(findSelectOptionIndex("//*[local-name()='select'][contains(@name,'type')]/*", "Digital"));
            srcDefType.SelectByIndex(findSelectOptionIndex(srcDefType.Options, "Digital"));
            enterInputData("//*[local-name()='input'][@id='mac_address'][contains(@name,'sessionId')]", pubSvc.SessionID);
            enterInputData("//*[local-name()='input'][contains(@name,'sessionNumber')]", Convert.ToString(pubSvc.SourceId));
            driver.FindElement(By.XPath("//*[local-name()='a'][contains(@onclick,'GenericqamSession')]")).Click();
            System.Threading.Thread.Sleep(6000);
            enterInputData("//*[local-name()='input'][contains(@name,'bandwidth')]", Convert.ToString(pubSvc.Bandwidth));
            element = driver.FindElement(By.XPath("//*[local-name()='select'][contains(@name,'qamName')]"));
            SelectElement qName = new SelectElement(element);
            //qName.SelectByIndex(findSelectOptionIndex("//*[local-name()='select'][contains(@name,'qamName')]/*", pubSvc.Qam.Name));
            qName.SelectByIndex(findSelectOptionIndex(qName.Options, pubSvc.Qam.Name));
            //Select Output Carrier dropdown
            System.Threading.Thread.Sleep(5000);
            element = driver.FindElement(By.XPath("//*[local-name()='select'][@id='carrierSelector']"));
            SelectElement outputCarrierSelect = new SelectElement(element);
            //outputCarrierSelect.SelectByIndex(findSelectOptionIndex("//*[local-name()='select'][@id='carrierSelector']/*",pubSvc.Qam.Port));
            outputCarrierSelect.SelectByIndex(findSelectOptionIndex(outputCarrierSelect.Options, pubSvc.Qam.Port));
            enterInputData("//*[local-name()='input'][contains(@name,'programNumber')]", Convert.ToString(pubSvc.ProgramNumber));
            enterInputData("//*[local-name()='input'][@name='currentEntry.sourceIP']", pubSvc.SourceIp.ToString());
            enterInputData("//*[local-name()='input'][contains(@name,'destIP')]", pubSvc.MulticastIp.ToString());
            enterInputData("//*[local-name()='input'][contains(@name,'udpPort')]", Convert.ToString(pubSvc.UdpPort));
            MessageBox.Show("Verify!");
            driver.FindElement(By.XPath("//*[local-name()='button'][text()='Save']")).Click();
            
            while (checkToast())
            {
                Thread.Sleep(500);
            }
            Thread.Sleep(2500);
            //driver.FindElement(By.XPath("//*[local-name()='a'][@id='Source List URL']")).Click();
        }

        //Method to build and save NonSA session
        private static void buildNonSA()
        {
            driver.FindElement(By.XPath("//*[local-name()='button'][@value='Add']")).Click();
            IWebElement element = driver.FindElement(By.XPath("//*[local-name()='select'][contains(@name,'type')]"));
            SelectElement srcDefType = new SelectElement(element);
            srcDefType.SelectByIndex(findSelectOptionIndex("//*[local-name()='select'][contains(@name,'type')]/*", "NonSA"));
            driver.FindElement(By.XPath("//*[local-name()='div'][@id='distribution']//*[local-name()='input'][2]")).Click();
            element = driver.FindElement(By.XPath("//*[local-name()='select'][contains(@name,'hubId')]"));
            SelectElement hubName = new SelectElement(element);
            hubName.SelectByIndex(findSelectOptionIndex("//*[local-name()='select'][contains(@name,'hubId')]/*", pubSvc.DefaultHub));
            enterInputData("//*[local-name()='input'][contains(@name,'nonSAMpegProgNumber')]", Convert.ToString(pubSvc.ProgramNumber));
            enterInputData("//*[local-name()='input'][contains(@name,'nonSACCFrequency')]", Convert.ToString(pubSvc.Frequency));
            driver.FindElement(By.XPath("//*[local-name()='button'][text()='Save']")).Click();

            Thread.Sleep(1500);

            driver.SwitchTo().Alert().Accept();
        }

        //I believe I can't use the SelectElement object correctly to select by text because of the XMLNS on the page
        //Using this work around to find the device by name, then selecting by index value 
        //Made the workaround to a method since it is used multiple times
        private static int findSelectOptionIndex(string xpath, string option)
        {
            List<IWebElement> options = new List<IWebElement>();
            ReadOnlyCollection<IWebElement> selectOptions = new ReadOnlyCollection<IWebElement>(options);
            selectOptions = driver.FindElements(By.XPath(xpath));
            int optionIndex = 0;
            foreach (IWebElement e in selectOptions)
            {
                if (e.Text == option)
                {
                    break;
                }
                optionIndex++;
            }

            return optionIndex;
        }

        private static int findSelectOptionIndex(IList<IWebElement> options, string option)
        {
            int optionIndex = 0;
            foreach (IWebElement e in options)
            {
                if (e.Text == option)
                {
                    break;
                }
                optionIndex++;
            }

            return optionIndex;
        }

        //Method to clear input fields and enter data
        private static void enterInputData(string xpath, string data)
        {
            IWebElement e = driver.FindElement(By.XPath(xpath));
            e.Clear();
            e.SendKeys(data);
        }

            
        private static bool checkToast()
        {
            IWebElement e = driver.FindElement(By.XPath("//*[local-name()='div'][@class='xwtToasterMessageWrapper']"));
            if (e.Displayed)
            {
                return false;
            }
            return true;
        }
    }
}
