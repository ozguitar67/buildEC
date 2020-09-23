using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace buildEC
{
    //Class to hold the properties that make a service
    class Service
    {
        //Keep a count of how many services that were created
        //Start at -1 because we create a public service in the Build class
        static private int count = -1;
        private int _frequency;
        private string _defaultHub;
        //Is this a valid service from the input given...?
        public bool isValidService
        {
            get
            {
                return this.validService();
            }
        }
        public Service()
        {
            //increment the count when a service is created
            count++;
        }

        public ipAddress SourceIp = new ipAddress();
        public ipAddress MulticastIp = new ipAddress();
        public int UdpPort { get; set; }
        public int Bandwidth { get; set; }
        public int ProgramNumber { get; set; }
        public string SourceName { get; set; }
        public int SourceId { get; set; }
        public string ControllerName { get; set; }
        public bool DtaService { get; set; }
        public string ChannelMap { get; set; }
        //Method to check if this service is a DTA service and set the value for the instance
        public void dtaServiceKa(string DTA)
        {
            if ((DTA.ToLower() == "yes") || (DTA == "1"))
                DtaService = true;
            else
                DtaService = false;
        }
        //Method to choose a default hub if one is not present
        public void chooseDefaultHub()
        {
            List<string> HubList = new List<string>();
            for (int i = 0; i < Build.JSON[JSONc].channelMaps.Length; i++)
            {
                for (int x = 0; x < Build.JSON[JSONc].channelMaps[i].hubs.Length; x++)
                {
                    HubList.Add(Build.JSON[JSONc].channelMaps[i].hubs[x]);
                }
            }
            int size = HubList.Count;
            string[] hub_list = new string[size];
            int idx = 0;
            foreach(string h in HubList)
            {
                hub_list[idx] = h;
                idx++;
            }
            //add map name to dialog window
            HubForm window = new HubForm(hub_list);
            window.ShowDialog();
        }
        //public string Frequency { get; set; }
        public int Frequency
        {
            get
            {
                return this._frequency;
            }
            set
            {
                if (value > 1000000)
                {
                    this._frequency = value / 1000000;
                }
                else
                {
                    this._frequency = value;
                }
            }
        }

        public Qam Qam = new Qam();

        //method to verify all properties of the service are valid
        private bool validService()
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(this.SourceName) || !(this.SourceId > 0) || String.IsNullOrEmpty(Convert.ToString(this.SourceIp.Ip)) || String.IsNullOrEmpty(Convert.ToString(this.MulticastIp.Ip)) || !(this.UdpPort > 0) || !(this.ProgramNumber > 0) || !(this.Bandwidth > 0) || String.IsNullOrEmpty(this.Qam.Name) || !(this.Qam.getPortNumber() > 0) || !(this.Frequency > 0))
            {
                isValid = false;
                count--;
            }

            return isValid;
        }

        //Default hub name acquisition, will be validating in Build.getService(int)
        public string DefaultHub
        {
            get
            {
                if (String.IsNullOrEmpty(this._defaultHub) || this._defaultHub.Length == 0)
                {
                    for (int x = 0; x < Build.JSON.Count(); x++)
                    {
                        if (Build.JSON[x].controller == this.ControllerName)
                        {
                            JSONc = x;
                            for (int y = 0; y < Build.JSON[x].channelMaps.Length; y++)
                            {
                                for (int z = 0; z < Build.JSON[x].channelMaps[y].devices.Length; z++)
                                {
                                    if (Build.JSON[x].channelMaps[y].devices[z].name == this.Qam.Name)
                                    {
                                        JSONm = y;
                                        JSONd = z;
                                        for (int i = 0; i < Build.JSON[x].channelMaps[y].devices[z].ports.Length; i++)
                                        {
                                            if (Convert.ToInt32(Build.JSON[x].channelMaps[y].devices[z].ports[i].port) == this.Qam.getPortNumber())
                                            {
                                                if (Build.JSON[x].channelMaps[y].defaultHub.Length == 0)
                                                {
                                                    return "0";
                                                }
                                                else
                                                {
                                                    this._defaultHub = Build.JSON[x].channelMaps[y].defaultHub;
                                                    return this._defaultHub;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                else
                    return this._defaultHub;
                //Shouldn't ever reach this
                return "0";
            }
            set
            {
                this._defaultHub = value;
            }
        }

        //Public variables set for JSON object values
        public int JSONc { get; set; }
        public int JSONm { get; set; }
        public int JSONd { get; set; }

        //PCG Session acquisition
        private string _pcgSession;
        public string PCGsession
        {
            get
            {
                if (String.IsNullOrEmpty(this._pcgSession) || this._pcgSession.Length < 17)
                {
                    List<string> result = new List<string>();
                    foreach (string s in Build.JSON[JSONc].channelMaps[JSONm].devices[JSONd].sessions)
                    {
                        string t = Regex.Replace(s, "^.{2}", "00");
                        t = Regex.Replace(t, ".{11}$", "00:00:00:00");
                        if (!result.Contains(t))
                        {
                            result.Add(t);
                        }
                    }

                    int size = result.Count;
                    if (size != 1)
                    {
                        string[] array = new string[size];
                        int idx = 0;
                        foreach (string pcg in result)
                        {
                            array[idx] = pcg;
                            idx++;
                        }
                        PCGForm window = new PCGForm(array);
                        window.ShowDialog();
                        return this._pcgSession;
                    }
                    else
                    {
                        this._pcgSession = result[0];
                        return this._pcgSession;
                    }
                }
                else
                {
                    return this._pcgSession;
                }
            }
            set
            {
                this._pcgSession = value;
            }
        }
        
        //QAM Session acquisition
        private string _sessionID;
        public string SessionID 
        {
            get
            {
                if (String.IsNullOrEmpty(this._sessionID) || this._sessionID.Length == 0)
                {
                    List<string> Sessions = new List<string>();
                    foreach (string s in Build.JSON[JSONc].channelMaps[JSONm].devices[JSONd].sessions)
                    {
                        if (this.DtaService)
                        {
                            if (s.StartsWith("02") && !Sessions.Contains(s))
                            {
                                Sessions.Add(s);
                            }
                        }
                        else
                        {
                            if (s.StartsWith("00") && !Sessions.Contains(s))
                            {
                                Sessions.Add(s);
                            }
                        }
                    }
                        int size = Sessions.Count;
                        if (size != 1)
                        {
                            string[] array = new string[size];
                            int idx = 0;
                            foreach (string sID in Sessions)
                            {
                                array[idx] = sID;
                                idx++;
                            }
                            QamSessionForm window = new QamSessionForm(array);
                            window.ShowDialog();
                            return this._sessionID;
                        }
                        else
                        {
                            this._sessionID = Sessions[0];
                            return this._sessionID;
                        }
                }
                else
                {
                    return this._sessionID;
                }
                //Shouldn't ever reach here
                return null;
            }
            set
            {
                this._sessionID = value;
            }
        }
    }
}
