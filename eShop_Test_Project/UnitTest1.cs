namespace eShop_Test_Project
{
    public class UnitTest1
    {
        private readonly string _buyerId = "Test buyerId";
        private readonly IRepository<Basket> _mockBasketRepo = Substitute.For<IRepository<Basket>>();
        private readonly IAppLogger<BasketService> _mockLogger = Substitute.For<IAppLogger<BasketService>>();

        [Fact]
        public void Test1()
        {

        }
    }
}