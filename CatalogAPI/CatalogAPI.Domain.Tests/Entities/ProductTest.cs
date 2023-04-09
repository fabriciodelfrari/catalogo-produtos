using CatalogAPI.Domain.Model.Entities;
using CatalogAPI.Domain.Validation;
using FluentAssertions;


namespace CatalogAPI.Domain.Tests.Entities
{
    public class ProductTest
    {
        [Fact(DisplayName = "Create new Product With Valid Parameters")]
        public void Create_WithValidParameters_ResultValidState()
        {
            //Arrange & Act
            Action action = () => new Product(
               id: 1,
               name: "Product name",
               description: "Product description",
               price: 10.0m,
               stock: 10,
               urlImage: "Url Image");

            //Assert
            action.Should()
            .NotThrow<DomainExceptionValidation>();

        }

        [Theory(DisplayName = "Cannot create a Product with invalid ID.")]
        [InlineData(-1)]
        public void Create_WithInvalidId_ResultInvalidState(int id)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: id,
                name: "Product name",
                description: "Product description",
                price: 10.0m,
                stock: 10,
                urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with empty Name.")]
        [InlineData("")]
        public void Create_WithEmptyName_ResultInvalidState(string name)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: name,
                description: "Product description",
                price: 10.0m,
                stock: 10,
                urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with Name as null.")]
        [InlineData(null)]
        public void Create_WithNullName_ResultInvalidState(string name)
        {
            //Arrange & Act
            Action action = () => new Product(
              id: 1,
              name: name,
              description: "Product description",
              price: 10.0m,
              stock: 10,
              urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with Name containing only white spaces.")]
        [InlineData("   ")]
        public void Create_WithWhiteSpaceName_ResultInvalidState(string name)
        {
            //Arrange & Act
            Action action = () => new Product(
              id: 1,
              name: name,
              description: "Product description",
              price: 10.0m,
              stock: 10,
              urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with empty Description.")]
        [InlineData("")]
        public void Create_WithEmptyDescription_ResultInvalidState(string description)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: description,
                price: 10.0m,
                stock: 10,
                urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with null Description.")]
        [InlineData(null)]
        public void Create_WithNullDescription_ResultInvalidState(string description)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: description,
                price: 10.0m,
                stock: 10,
                urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with Description containing only white spaces.")]
        [InlineData("   ")]
        public void Create_WithWhiteSpaceDescription_ResultInvalidState(string description)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: description,
                price: 10.0m,
                stock: 10,
                urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with price less than 0.")]
        [InlineData("-10.0")]
        public void Create_WithPriceLessThanZero_ResultInvalidState(string price)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: "Product description",
                price: decimal.Parse(price),
                stock: 10,
                urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with stock less than 0.")]
        [InlineData(-1)]
        public void Create_WithStockLessThanZero_ResultInvalidState(int stock)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: "Product description",
                price: 10.0m,
                stock: stock,
                urlImage: "Url Image");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Create a Product with null url image.")]
        [InlineData(null)]
        public void Create_WithNullUrlImage_ResultInvalidState(string? urlImage)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: "Product description",
                price: 10.0m,
                stock: 10,
                urlImage: urlImage);

            //Assert
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product with empty url image.")]
        [InlineData("")]
        public void Create_WithEmptyUrlImage_ResultInvalidState(string urlImage)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: "Product description",
                price: 10.0m,
                stock: 10,
                urlImage: urlImage);

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Cannot create a Product that url image contains only white spaces.")]
        [InlineData("          ")]
        public void Create_WithWhiteSpaceUrlImage_ResultInvalidState(string urlImage)
        {
            //Arrange & Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: "Product description",
                price: 10.0m,
                stock: 10,
                urlImage: urlImage);

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Cannot create a Product with url image length bigger than 250.")]
        public void Create_WithUrlLengthBiggerThan250_ResultInvalidState()
        {
            //Arrange 
            var urlImage = new string('a', 251);

            //Act
            Action action = () => new Product(
                id: 1,
                name: "Product name",
                description: "Product description",
                price: 10.0m,
                stock: 10,
                urlImage: urlImage);

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
