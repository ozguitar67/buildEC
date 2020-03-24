using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buildEC
{
    class service
    {
        static private int count = 0;

        public service()
        {
            count++;
        }

        public ipAddress SourceIp { get; set; }
        public ipAddress MulticastIp { get; set; }
        public int UdpPort { get; set; }
        public int ProgramNumber { get; set; }
        public string SourceName { get; set; }
        public int SourceId { get; set; }
        
        public Qam Qam = new Qam();


        


    }
}
