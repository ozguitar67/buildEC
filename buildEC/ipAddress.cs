using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace buildEC
{
    class ipAddress
    {
        //class to store a validated IP address value
        private string _ip;

        public string Ip
        {
            get
            {
                return this._ip;
            }
            set
            {
                if (isValid(value))
                {
                    this._ip = value;
                }
            }  
        }

        public ipAddress(string v)
        {
            if (isValid(v))
            {
                this._ip = v;
            }
        }

        //this method validates the IP address with regex
        static bool isValid(string address)
        {
            return Regex.IsMatch(address, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        }
    }
}
