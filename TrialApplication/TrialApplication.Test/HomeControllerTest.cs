using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialApplication.Controllers;
using Xunit;

namespace TrialApplication.Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void HomeController_Index_ReturnString()
        {
            //AAA
            // Arrange : bring all required
            HomeController controller = new HomeController();
            string expectedResult = "In home Controller.";

            // Act : call methods to Perform actions for xunit tests.
            string result = controller.Index();
            
            // Assert : Validate the feature
            Assert.Equal(expectedResult, result);
        }

        
    }
}
