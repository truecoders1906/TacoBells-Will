namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            if(line == null)
            {
                return null;
            }
            var cells = line.Split(',');
            if (cells.Length < 3 || cells.Length > 3)
            {
                return null;
            }
            logger.LogInfo("Begin parsing");
            TacoBell newTacoBell = new TacoBell();
            string stringLatitude = cells[0];
            string stringLongitude = cells[1];
            newTacoBell.Name = cells[2];
            bool latitiude_string_to_double = double.TryParse(string_Latitude, out double Latitude);
            bool longitude_string_to_double = double.TryParse(string_Longitude, out double Longitude);
            if (longitude_string_to_double == false || latitiude_string_to_double == false)
            {
                return null;
            }
            Point locationalPoints = new Point();
            locationalPoints.Latitude = Latitude;
            locationalPoints.Longitude = Longitude;
            newTacoBell.Location = locationalPoints;
            return newTacoBell;
        }
    }
}

