using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace buildEC
{
    public class Controller
    {
        public string controller { get; set; }
        public Channelmap[] channelMaps { get; set; }

        public class Channelmap
        {
            public string name { get; set; }
            public string defaultHub { get; set; }
            public Device[] devices { get; set; }
            public string[] sessions { get; set; }
            public string[] hubs { get; set; }
        }

        public class Device
        {
            public string name { get; set; }
            public string portCount { get; set; }
            public string[] sessions { get; set; }
            public Port[] ports { get; set; }
        }

        public class Port
        {
            public string port { get; set; }
            public string[] hubs { get; set; }
        }

    }
}
