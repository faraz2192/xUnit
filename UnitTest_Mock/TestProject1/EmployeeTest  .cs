using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Mock.Controllers;
using UnitTest_Mock.Model;
using UnitTest_Mock.Services;

namespace TestProject1
{
    public class EmployeeTest
    {
        public Mock<IEmployeeService> mock = new Mock<IEmployeeService>();

        [Fact]
        public async void GetEmployeeDetail()
        {
            var employeeDTO = new Employee()
            {
                Id = 1,
                Name = "JK",
                Designation = "SDE"
            };
            mock.Setup(p => p.GetEmployeeDetails(1)).ReturnsAsync(employeeDTO);
            EmployeeController emp = new EmployeeController(mock.Object);
            var result = await emp.GetEmployeeDetails(1);
            Assert.True(employeeDTO.Equals(result));
        }

        [Fact]
        public async void GetEmployeebyId()
        {
           // mock.Setup(p => p.GetEmployeebyId(2)).ReturnsAsync("JKS");
            EmployeeController emp = new EmployeeController(mock.Object);
            string result = await emp.GetEmployeeById(2);
            Assert.Equal("JK", result);
        }

        [Fact]
        public async void GetEmployeeDetails()
        {
            var employeeDTO = new Employee()
            {
                Id = 1,
                Name = "JK",
                Designation = "SDE"
            };
            mock.Setup(p => p.GetEmployeeDetails(1)).ReturnsAsync(employeeDTO);
            EmployeeController emp = new EmployeeController(mock.Object);
            var result = await emp.GetEmployeeDetails(1);
            Assert.True(employeeDTO.Equals(result));
        }
    }
}
