using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShips
{
    [TestClass]
    public class InputTests
    {
        InputManager _target = new InputManager();

        [TestMethod]
        public void ValidateInput_GiveString_ReturnsTrueOrFalse()
        {
            // Arrange
            string command = "a1";
            bool expectedResult = true;

            // Act
            bool result = _target.InputValidator(command);

            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ConvertInput_ProvideString_ReturnsCoordinateObject()
        {
            // Arrange
            string command = "a0";
            Coordinate expectedResult = new Coordinate(0,0);

            // Act
            Coordinate result = _target.InputConvertor(command);

            // Assert
            Assert.AreEqual(result.X, expectedResult.X);
            Assert.AreEqual(result.Y, expectedResult.Y);

        }
    }
}
