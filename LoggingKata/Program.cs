using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            double distanceBetweenTacobells = 0;
            ITrackable foleyALTacoBell = null;
            ITrackable blueRidgeALTacoBell = null;

            for (int a = 0; a < locations.Length; a++)
            {
                ITrackable locA = locations[a];
                GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for (int b = 0; b < locations.Length; b++)
                {
                    ITrackable locB = locations[b];
                    GeoCoordinate corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    if (corA.GetDistanceTo(corB) > distanceBetweenTacobells)
                    {
                        distanceBetweenTacobells = corA.GetDistanceTo(corB);
                        foleyALTacoBell = locA;
                        blueRidgeALTacoBell = locB;
                    }
                }
            }
            Console.WriteLine(foleyALTacoBell.Name);
            Console.WriteLine(blueRidgeALTacoBell.Name);
            Console.ReadLine();
        }
    }
}