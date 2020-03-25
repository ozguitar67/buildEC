using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buildEC
{
    //Class to hold the properties that make a service
    class service
    {
        //Keep a count of how many services that were created
        static private int count = 0;

        public service()
        {
            //increment the count when a service is created
            count++;
        }

        public ipAddress SourceIp { get; set; }
        public ipAddress MulticastIp { get; set; }
        public int UdpPort { get; set; }
        public int Bandwidth { get; set; }
        public int ProgramNumber { get; set; }
        public string SourceName { get; set; }
        public int SourceId { get; set; }
        
        public Qam Qam = new Qam();
    }
}
