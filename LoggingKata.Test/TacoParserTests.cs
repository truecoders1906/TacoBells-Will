using System;
using Xunit;
using System.Collections.Generic;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        { 
            Console.WriteLine("Hello Chip!");
        }

        [Theory]
        [InlineData("34.8831, -84.293899, Taco Bell Blue Ridg")]
        [InlineData("30.39371, -87.68332, Taco Bell Fole")]
        [InlineData("33.61915,-84.243415,Taco Bell Ellenwoo")]
        [InlineData("1, 2, Example")]
        public void ShouldParse(string str)
        {
            // Arrange
            var TacoParser = new TacoParser();

            // Act
            ITrackable answer = TacoParser.Parse(str);

            // Assert
            Assert.NotNull(answer);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("15Four65")]
        [InlineData("sixteen, happyBirthDayToMe, sn00pd0ggyd0g")]
        public void ShouldFailParse(string str)
        {
            if (str == null || str == "")
            {
                str = null;
            }
            else
            {
                str = null;
            }
        }
    }
}
