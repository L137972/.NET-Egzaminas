using RestaurantSystem;

namespace RestaurantSystemTests
{
    [TestClass]
    public class PersonelInputTest
    {
        [TestMethod]
        public void Visitors_Successful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();

            // Act
            int visitors = 1;

            // Assert
            Assert.IsTrue(visitors.GetType() == typeof(int));
        }
    }
}