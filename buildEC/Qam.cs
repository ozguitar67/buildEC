using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace buildEC
{
    //Class to hold the properties that make a QAM
    class Qam
    {
        private string _type;
        private string _name;
        private string _port;

        //Variable for the name through which the type of the QAM can be determined
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
                //Just realized York NSG breaks the mold because it was the first...
                if (value.ToLower().StartsWith("linnsg") || value.ToLower().StartsWith("adtnsg") || value.ToLower() == "yk-nsg40g-01")
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

        //Method to determine the port value which is different for an NSG vs GQAM
        public string Port
        {
            get
            {
                //Return the port in format that can be used to select the value from the EC drop-down
                Match match = Regex.Match(this._port, @"\d+");
                string rfOut = match.Value.ToString();
                match = match.NextMatch();
                string carrier = match.Value.ToString();
                return $"RF Out {rfOut} Carrier {carrier}";
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
                //Set the port value to a generic "RF Out/Carrier" Value
                this._port = $@"{Convert.ToInt32(rfOut)}/{Convert.ToInt32(carrier)}";
            }
        }

        public int getPortNumber()
        {
            //Seperate port fields into two values to return to origial port number
            Match match = Regex.Match(this._port, @"\d+");
            string rfOut = match.Value.ToString();
            match = match.NextMatch();
            string carrier = match.Value.ToString();

            if (this._type == "NSG")
            {
                if (Convert.ToInt32(rfOut) == 1)
                {
                    return Convert.ToInt32(carrier);
                }
                else
                {
                    return ((Convert.ToInt32(rfOut) - 1) * 36) + Convert.ToInt32(carrier);
                }
            }
            else
            {
                if (Convert.ToInt32(rfOut) == 1)
                {
                    return Convert.ToInt32(carrier);
                }
                else
                {
                    return ((Convert.ToInt32(rfOut) - 1) * 4) + Convert.ToInt32(carrier);
                }
            }
        }
    }
}
