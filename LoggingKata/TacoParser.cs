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
            var cells = line.Split(',');
            if (cells.Length < 3 || cells.Length > 3)
            {
                return null;
            }
                logger.LogInfo("Begin parsing");


            TacoBell newTacoBell = new TacoBell();
            {
                double Latitude = double.Parse(cells[0]);
                double Longitude = double.Parse(cells[1]);
                newTacoBell.Name = cells[2];

                Point locationalPoints = new Point();
                {
                    locationalPoints.Latitude = Latitude;
                    locationalPoints.Longitude = Longitude;
                    newTacoBell.Location = locationalPoints;
                }
                return newTacoBell;
            }
        }
        public class TacoBell : ITrackable
        {
            public string Name { get; set; }
            public Point Location { get; set; }

        }
    }
}

