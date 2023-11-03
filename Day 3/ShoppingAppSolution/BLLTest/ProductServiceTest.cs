using ShoppingBLLibrary;
using ShoppingModelLibrary;

namespace BLLTest
{
    public class ProductServiceTest
    {
        IProductService  _service;
        [SetUp]
        public void Setup()
        {
            _service = new ProductService();
        }

        [Test]
        public void AddTest()
        {
            //Arrange

            //Action
            var result = _service.AddProduct(new Product {  Name = "Raju" });
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void DeleteProductTest()
        {
            //Arrange
            var prod = _service.AddProduct(new Product { Name = "Raju" });
            //Action
            var result = _service.Delete(1);
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetProductsTest()
        {
            //Arrange
            var prod = _service.AddProduct(new Product { Name = "Raju" });
            //Action
            var result = _service.GetProducts();
            //Assert
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void GetProductTest()
        {
            //Arrange
            var prod = _service.AddProduct(new Product { Name = "Raju" });
            //Action
            var result = _service.GetProduct(1);
            //Assert
            Assert.That(result.Id,Is.EqualTo(1));
        }
    }
}