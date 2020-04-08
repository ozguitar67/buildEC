using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace buildEC
{
    static class Build
    {
        //Create static variables to be used through application
        public static Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        public static Worksheet excelWkSht = new Microsoft.Office.Interop.Excel.Worksheet();
        public static Service pubSvc = new Service();
        public static OpenQA.Selenium.IWebDriver driver;
        
        //Method to instantiate a browser with the correct options set to access the ECs
        static public void initBrowser()
        {
            //Set encoding to avoid "encoding 437" error
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FirefoxOptions options = new FirefoxOptions();
            FirefoxProfile profile = new FirefoxProfile();
            profile.DeleteAfterUse = true;
            profile.SetPreference("security.ssl3.dhe_rsa_aes_128_sha", false);
            profile.SetPreference("security.ssl3.dhe_rsa_aes_256_sha", false);
            options.Profile = profile;
            driver = new FirefoxDriver(options);
        }

        //Method to open the chosen excel file in a hidden application
        static public void openExcelFile(string fileName)
        {
            //excelApp.Visible = false;
            excelApp.Workbooks.Open(fileName);
            excelWkSht = excelApp.ActiveSheet;
        }

        //Method to close the excel application
        static public void closeExcelFile()
        {
            excelApp.Quit();
        }

        //Method to get the service information from the excel file 
        //and assign the values to the correct variables
        static public Service getService(int row)
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
        public static void gotoEC(string url, string uName, string pw)
        {
            
            try
            {
                driver.Navigate().GoToUrl($@"{url}");
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
            }
            //Enter the username and password
            driver.FindElement(By.Id("label_username")).SendKeys($"{uName}" + OpenQA.Selenium.Keys.Tab + $"{pw}");
            try
            {
                //driver.FindElement(By.XPath("//*[@id='loginForm']//input[@value='Login']")).Click();
                driver.FindElement(By.Id("loginPage_loginSubmit")).Click();
            }
            catch (NoSuchElementException)
            {
               MessageBox.Show("Cannot find the element by Xpath value given.");
            }
        }
    }
}
