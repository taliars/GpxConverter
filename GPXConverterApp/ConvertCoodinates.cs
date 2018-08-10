using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXConverterApp
{
    public static class ConvertCoodinates
    {
        public static string Convert(string c)
        {
            float coordinate = float.Parse(c, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            int degrees = (int)coordinate;
            int minutes = (int)((coordinate - degrees) * 60);
            float sec = ((((coordinate - degrees) * 60) - minutes) * 60);
            float seconds = (float)Math.Round(sec, 2);

            return degrees + "°" + minutes.ToString("00") + "'" + seconds.ToString("00.00") + "\"";
        }
    }
}
