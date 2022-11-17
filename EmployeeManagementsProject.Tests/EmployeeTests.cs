using EmployeeManagementsProject.Web.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OA_Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementsProject.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public async Task EmployeeIntegrationTest()
        {
            // Create DB Context
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            var context = new ApplicationDbContext(optionsBuilder.Options);

            // Just to make sure: Delete all existing products in the DB
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            // Create Controller
            var controller = new EmployeeTestController(context);

            // Add product
            await controller.Add(new OA_DataAccess.Employee() { FullName = "Zied ben Azzouna", EMPCode = "4815", Mobile = "58259350" , Position = "developer" });

            // Check: Does GetAll return the added product?
            var result = (await controller.GetAll()).ToArray();
            Assert.Single(result);
            Assert.Equal("Zied ben Azzouna", result[0].FullName);
        }
    }
}
