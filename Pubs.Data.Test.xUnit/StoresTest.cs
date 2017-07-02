using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using Xunit.Abstractions;


namespace Pubs.Data.Test.xUnit
{
    public class StoresTest
    {

        public IConfigurationRoot Configuration { get; }
        

        public StoresTest(){
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                ;
            builder.Build();
            Configuration = builder.Build();
        }
        [Fact]
        public void PassingTest()
        {
            Console.WriteLine("\n\nRunning PassingTest\n\n");
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Console.WriteLine("\n\nRunning FailingTest\n\n");
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
