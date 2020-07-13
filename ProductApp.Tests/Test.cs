using System;
using ProductApp.Domain;
using ProductApp.Exceptions;
using Xunit;

namespace ProductApp.Tests
{
    public class ProductsAppShould
    {
        [Fact]
        public void ReturnArgumentNullExceptionWhenProductIsNotSpecifiedOrNull()
        {
            //Arrange
            Products sut = new Products();

            //Act
            Product product = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.AddNew(product));
        }

        [Fact]
        public void AddNewProductOnListIfProductIsAdded()
        {
            //Arrange
            Products sut = new Products();

            //Act
            Product product = new Product()
            {
                Name = "ProductA"
            };
            sut.AddNew(product);

            //Assert
            Assert.Contains(product, sut.Items);
        }

        [Fact]
        public void ReturnErrorIfNameIsNotSpecified()
        {
            //Arrange
            Product sut = new Product();;

            //Act
            sut.Name = null;

            //Assert
            Assert.Throws<NameRequiredException>(() => sut.Validate());
        }
    }
}
