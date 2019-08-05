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
            //Mysterious logger stuff + lines variable
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            logger.LogInfo($"Lines: {lines[0]}");

            //For loop variables
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();
            double distanceBetweenTacobells = 0;
            ITrackable TacoBellA = null;
            ITrackable TacoBellB = null;

            for (int a = 0; a < locations.Length; a++)
            {   // Goes through the .csv string to find the Longitude + Latitude for the 1st Taco Bell
                ITrackable locA = locations[a];
                GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for (int b = 0; b < locations.Length; b++)
                {   // Goes through the .csv string to find the Longitude + Latitude for the 2nd Taco Bell
                    ITrackable locB = locations[b];
                    GeoCoordinate corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    double currentDistance = corA.GetDistanceTo(corB);
                    if (currentDistance >= distanceBetweenTacobells)
                    {
                        TacoBellA = locA;
                        TacoBellB = locB;
                    }
                }
            }
            Console.WriteLine(TacoBellA.Name);
            Console.WriteLine(TacoBellB.Name); 
        }
    }
}