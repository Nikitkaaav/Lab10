using ClassLibraryLab10;
using Lab9;

namespace Lab10Tests

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            GeoCoordinates expected = new GeoCoordinates();
            //Act
            GeoCoordinates actual = new GeoCoordinates();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}