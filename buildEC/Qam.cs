using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace buildEC
{
    class Qam
    {
        private string _type;
        private string _name;
        private string _port;

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                //Set device type based on the name
                //All NSGs start with LINNSG or ADTNSG
                if (value.ToLower().StartsWith("linnsg") || value.ToLower().StartsWith("adtnsg"))
                {
                    this._type = "NSG";
                }
                else
                {
                    this._type = "GQAM";
                }

                this._name = value;
            }
        }

        public string Port
        {
            get
            {
                Match match = Regex.Match(this._port, @"\d+");
                return $"RF Out {match.Groups[1]} Carrier {match.Groups[2]}";
            }
            set
            {
                double rfOut;
                double carrier;

                if (this._type == "NSG")
                {
                    if (Convert.ToInt32(value) < 36)
                    {
                        rfOut = 1;
                        carrier = Convert.ToInt32(value) % 36;
                    }
                    else
                    {
                        rfOut = Math.Ceiling((Convert.ToInt32(value) / 36.0));
                        if (Convert.ToInt32(value) % 36 == 0)
                            carrier = 36;
                        else
                            carrier = Convert.ToInt32(value) % 36;
                    }

                }
                else
                {
                    if (Convert.ToInt32(value) < 4)
                    {
                        rfOut = 1;
                        carrier = Convert.ToInt32(value) % 4;
                    }
                    else
                    {
                        rfOut = Math.Ceiling((Convert.ToInt32(value) / 4.0));
                        if (Convert.ToInt32(value) % 4 == 0)
                            carrier = 4;
                        else
                            carrier = Convert.ToInt32(value) % 4;
                    }
                }

                this._port = $@"{Convert.ToInt32(rfOut)}\{Convert.ToInt32(carrier)}";
            }
        }
    }
}
