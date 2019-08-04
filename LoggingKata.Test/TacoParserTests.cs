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
            Console.WriteLine("Hello Chip! I'm not getting rid of this lol");
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
        [InlineData("")]
        [InlineData(null)]
        [InlineData("15Four65")]
        [InlineData("sixteen, happyBirthDayToMe, sn00pd0ggyd0g")]
        [InlineData("10, ten, Taco Bell")]
        [InlineData("ten, 10, Taco Bell")]
        [InlineData("10, 10")]
        [InlineData("10,,Taco Bell")]
        [InlineData(",10, Taco Bell")]
        [InlineData(", , Taco Bell")]
        [InlineData("10, Taco Bell, 10")]
        [InlineData("Taco Bell, 10, 10")]
        public void ShouldFailParse(string str)
        {
            // Arrange
            TacoParser tacoParser = new TacoParser();

            // Act
            ITrackable answer = tacoParser.Parse(str);
                      
            // Assert
            Assert.Null(answer);
        }
    }
}
