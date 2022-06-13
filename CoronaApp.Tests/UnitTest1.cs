using CoronaApp.Services.Repositories;
using Location_Lesson_1.Controllers;
using Location_Lesson_1.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System.Net;

namespace CoronaApp.Tests
{
    public class UnitTest1:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;

        public UnitTest1(WebApplicationFactory<Program> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

       
        [Fact]
        public async void GetLocationByCityTestReturnError()
        {
            List<Location> listLocation = new List<Location>();
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(x => x.GetLocatinByCity(String.Empty))
                .Returns(Task.FromResult(listLocation));
            var client = new LocationController(mock.Object);
            var response = await client.Get("Jerusalem");
            Assert.True(response == null);
        }

        [Fact]
        public async void GetLocationByIdReturnOK()
        {
            List<Location> listLocation = null;
            Mock<ILocationRepository>mock=new Mock<ILocationRepository>();
            mock.Setup(x => x.GetLocationById(String.Empty))
                .Returns(Task.FromResult(listLocation));
            var client = new LocationController(mock.Object);
            var response = await client.GetById("111");
            Assert.True(response == null);
        }
    }
}