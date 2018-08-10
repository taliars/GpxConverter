using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXConverterApp
{
    public class Waypoint
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        private string _concatenateString;
        public string ConcatenateString
        {
            get => Latitude + " " + Longitude;
            set => _concatenateString = value;
        }        
    }
}
