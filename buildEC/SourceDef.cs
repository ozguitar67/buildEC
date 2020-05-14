using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace buildEC
{
    class SourceDef
    {
        public SortedList<string, int> NonSA = new SortedList<string, int>();
        public List<string> PCG = new List<string>();
        public List<string> Session = new List<string>();

        public bool PCGone { get; set; } = false;
        public bool PCGtwo { get; set; } = false;
        //Method to get sessions on Source Definition page
        public void GetSourceDefs()
        {
            List<IWebElement> Rows = new List<IWebElement>();
            ReadOnlyCollection<IWebElement> ReadOnlyType = new ReadOnlyCollection<IWebElement>(Rows);
            ReadOnlyType = Build.driver.FindElements(By.XPath("//*[local-name()='table'][@id='definitionTable']//*[local-name()='tr']//*[local-name()='td'][2]"));
            int rowCount = 1;
            foreach (IWebElement s in ReadOnlyType)
            {
                if (s.Text == "NonSA")
                {
                    string hub = Build.driver.FindElement(By.XPath($"//*[local-name()='table'][@id='definitionTable']//*[local-name()='tr'][{rowCount}]//*[local-name()='td'][8]")).Text;
                    string hubID = Build.driver.FindElement(By.XPath($"//*[local-name()='table'][@id='definitionTable']//*[local-name()='tr'][{rowCount}]//*[local-name()='td'][9]")).Text;
                    NonSA.Add(hub, Convert.ToInt32(hubID));
                }
                else if (s.Text == "PCG")
                {
                    string PCGsession = Build.driver.FindElement(By.XPath($"//*[local-name()='table'][@id='definitionTable']//*[local-name()='tr'][{rowCount}]//*[local-name()='td'][5]")).Text;
                    PCG.Add(Regex.Replace(PCGsession, " .*$", String.Empty));
                }
                else if (s.Text == "QAM")
                {
                    string QamSession = Build.driver.FindElement(By.XPath($"//*[local-name()='table'][@id='definitionTable']//*[local-name()='tr'][{rowCount}]//*[local-name()='td'][5]")).Text;
                    Session.Add(Regex.Replace(QamSession, " .*$", String.Empty));
                }
                rowCount++;
            }
        }

        public bool NonSaExists()
        {
            if (NonSA.ContainsKey(Build.pubSvc.DefaultHub) && Build.pubSvc.DefaultHub != "0")
            {
                return true;
            }

            return false;
        }
        
        //Method to determine if both PCG sessions exist
        //Sets class properties for PCGone and PCGtwo
        public bool PcgExists()
        {

            foreach(string p in PCG)
            {
                string t = p;
                string t2 = Regex.Replace(t, ".{11}$", "00:00:00:00");

                if (t2 == Build.pubSvc.PCGsession)
                {
                    if (Regex.IsMatch(t, "^.{6}01:00:00:00$"))
                    {
                        PCGone = true;
                    }
                    if (Regex.IsMatch(t, "^.{6}02:00:00:00$"))
                    {
                        PCGtwo = true;
                    }
                }

            }

            if (PCGone && PCGtwo)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool QamSessionExists()
        {
            foreach(string s in Session)
            {
                if (Build.pubSvc.DtaService)
                {
                    if (s.Equals(Build.pubSvc.SessionID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
