using RestaurantSystem;

namespace RestaurantSystemTests
{
    [TestClass]
    public class RestaurantSystemServiceTests
    {
        [TestMethod]
        public void PickTable_Successful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();
            int visitors = 3;

            // Act
            Table table = restaurantSystem.PickTable(visitors);

            // Assert
            Assert.IsNotNull(table);
        }
        [TestMethod]
        public void PickTable_Unsuccessful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();
            int visitors = 8;

            // Act
            Table table = restaurantSystem.PickTable(visitors);

            // Assert
            Assert.IsNull(table);
        }
        [TestMethod]
        public void LoadFood_Successful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();

            // Act
            restaurantSystem.LoadFood();

            // Assert
            Assert.IsNotNull(restaurantSystem.AllItems);
        }
        [TestMethod]
        public void LoadFood_Unsuccessful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();

            // Act

            // Assert
            foreach (var item in restaurantSystem.AllItems)
            {
                Assert.IsNull(item);
            }
        }
        [TestMethod]
        public void LoadDrinks_Successful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();

            // Act
            restaurantSystem.LoadDrinks();

            // Assert
            Assert.IsNotNull(restaurantSystem.AllItems);
        }
        [TestMethod]
        public void LoadDrinks_Unsuccessful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();

            // Act

            // Assert
            foreach (var item in restaurantSystem.AllItems)
            {
                Assert.IsNull(item);
            }
        }
        [TestMethod]
        public void SendReceipt_Successful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();
            Order order = new Order();
            Table table = restaurantSystem.PickTable(2);

            // Act
            order.CreateReceipt(order, table);
            order.Email = "linute.kasperaviciute@gmail.com";
            order.OrderId = 1;

            // Assert
            Assert.IsTrue(restaurantSystem.SendReceipt(order.Email, order.OrderId));
        }
        [TestMethod]
        public void SendReceipt_Unsuccessful()
        {
            // Arrange
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();
            Order order = new Order();
            Table table = restaurantSystem.PickTable(2);

            // Act
            order.CreateReceipt(order, table);
            order.Email = "";

            // Assert
            Assert.IsFalse(restaurantSystem.SendReceipt(order.Email, order.OrderId));
        }
    }
}