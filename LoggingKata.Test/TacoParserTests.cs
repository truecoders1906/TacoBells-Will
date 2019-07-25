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
            Console.WriteLine("Hello, World!");
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort")]
        public void ShouldParse(string str, string expected)
        {
            // Arrange
            TacoParserTests TacoParser = new TacoParserTests();

            // Act
            double answer = double.Parse(str);

            // Assert
            Assert.NotNull(answer);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            if (str == null || str == "")
            {
                str = null;
            }
        }
    }
}
