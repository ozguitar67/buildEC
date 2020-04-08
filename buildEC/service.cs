using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buildEC
{
    //Class to hold the properties that make a service
    class Service
    {
        //Keep a count of how many services that were created
        //Start at -1 because we create a public service in the Build class
        static private int count = -1;
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
        
        public Qam Qam = new Qam();

        //method to verify all properties of the service are valid
        private bool validService()
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(this.SourceName) || !(this.SourceId > 0) || String.IsNullOrEmpty(Convert.ToString(this.SourceIp.Ip)) || String.IsNullOrEmpty(Convert.ToString(this.MulticastIp.Ip)) || !(this.UdpPort > 0) || !(this.ProgramNumber > 0) || !(this.Bandwidth > 0) || String.IsNullOrEmpty(this.Qam.Name) || !(this.Qam.getPortNumber() > 0))
            {
                isValid = false;
                count--;
            }

            return isValid;
        }
    }
}
