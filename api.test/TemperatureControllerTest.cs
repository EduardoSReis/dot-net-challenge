using NUnit.Framework;
using System;
using Services;
using Moq;
using api.Controllers;
using System.Linq;
using System.Collections.Generic;

namespace api.test
{
    public class Tests    
    {
        private TemperatureController controller;
        private Mock<TemperatureRepository> temperatureRepositoryMock;

        [SetUp]
    public void Setup() {
        
        temperatureRepositoryMock = new Mock<TemperatureRepository>();
        
        
    }

    [Test]
        public void ShouldCallRepository()
        {
          // act
          controller.GetTemperature(1);

          // assert
          var result = temperatureRepositoryMock.Verify(s => s.GetTemperature(1), Times.Once());

          Assert.IsTrue(result);
        }
    }

        [Test]
        public void ShouldReturnTemperature()
        {
          // arrange
          var sensor = new Sensor
            {
                Id = 1,
                Temperature = -2
            };

          temperatureRepositoryMock.SetUp(p => p.GetTemperature(1).Returns(sensor));

          // act
          var result = controller.GetTemperature(1);

          // assert
        
        Assert.AreEqual(sensor, result);
        }
    
}
