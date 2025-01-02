using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vs_iAPI
{
    class APIObj
    {

        internal string apikey = "";
        internal string name = "";
        internal string frequency;
        internal Boolean running = false;


        public APIObj(string apikey, string name, string frequency)
        {
            this.apikey = apikey;
            this.name = name;
            this.frequency = frequency;
            this.running = false; // Always on object initialization it should not be running.
        }

        internal string Apikey { get { return apikey; } 
            set { apikey = value; }
        }
        internal string Name
        {
            get { return name; }
            set { name = value; }
        }

        internal string Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

    }
}
