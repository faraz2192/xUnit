using Calculator;
using Xunit;
using System.Security.Cryptography.X509Certificates;

namespace xUnitTestProject1
{
    public class UnitTest1
    {
        
            MyCalculator objForMyCalculator = new MyCalculator();
            [Fact]
            public void PassingTesT()
            {
                Assert.Equal(4, objForMyCalculator.Add(2, 2));
            }

            [Fact]
            public void PassingTest()
            {
                Assert.Equal(5, objForMyCalculator.Add(2 web, 2));
            }
        
    }
}