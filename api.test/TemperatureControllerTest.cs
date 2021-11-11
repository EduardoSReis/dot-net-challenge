using NUnit.Framework;

namespace api.test
{
    public class Tests
    TemperatureController controller = new TemperatureController();
    {

        [Test]
        public void ShouldReturnCharged()
        {
          // arrange
          temperatureServiceMock.Get(p => p.Task(It.IsAny<double>()).Returns({"id":"1","temperature":-1});

          // act
          var result = controller.Get(1);

          // assert
          shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items.AsEnumerable()), Times.Once());

          Assert.AreEqual("charged", result);
        }
    }
}