using System.Linq;
using System.Collections.ObjectModel;
using System.Xml.Linq;


namespace GPXConverterApp
{
    public static class GPXLoader
    {
        private static XDocument gpxDocument;
        private static XNamespace gpxNamespace;
        private static string gpxType;

        public static ObservableCollection<Waypoint> Load(string gpxFile)
        {
            ObservableCollection<Waypoint> result;

            gpxDocument = XDocument.Load(gpxFile);
            gpxNamespace = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            gpxType = GetGpxType();


            var waypoints = from waypoint in gpxDocument.Descendants(gpxNamespace + gpxType)
                            select (new Waypoint
                            {
                                Latitude = "N" + ConvertCoodinates.Convert(waypoint.Attribute("lat").Value),
                                Longitude = "E" + ConvertCoodinates.Convert(waypoint.Attribute("lon").Value),
                                Name = waypoint.Element(gpxNamespace + "name")?.Value,
                            });      

            return result = new ObservableCollection<Waypoint>(waypoints);
        }
        

        private static string GetGpxType()
        {
            string gpxType = "";

            ObservableCollection<Waypoint> result = new ObservableCollection<Waypoint>();

            if (gpxDocument.Descendants(gpxNamespace + "trkpt").Any())
                gpxType = "trkpt";
            else if (gpxDocument.Descendants(gpxNamespace + "wpt").Any())
                gpxType = "wpt";

            return gpxType;
        }
    }
}