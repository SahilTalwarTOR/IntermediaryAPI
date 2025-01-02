using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vs_iAPI
{
    public class APIObj
    {

        private string apikey = "";
        private string name = "";
        private string frequency;
        private Boolean running = false;


        public APIObj(string apikey, string name, string frequency)
        {
            this.apikey = apikey;
            this.name = name;
            this.frequency = frequency;
            this.running = false; // Always on object initialization it should not be running.
        }

        public string Apikey { get { return apikey; } 
            set { apikey = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

    }
}
