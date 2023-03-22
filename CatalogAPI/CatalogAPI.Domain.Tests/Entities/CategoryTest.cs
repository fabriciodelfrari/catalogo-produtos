using CatalogAPI.Domain.Entities;
using CatalogAPI.Domain.Validation;
using FluentAssertions;

namespace CatalogAPI.Domain.Tests.Entities
{
    public class CategoryTest
    {
        [Fact(DisplayName ="Create a Category with valid parameters")]
        public void Create_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category Name");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName ="Update a category with valid parameters.")]
        public void Update_WithValidParameters_ResultValidState()
        {
            //Arrange
            Category category = new(1, "Valid Category");

            //Act
            Action action = () => category.Update("Another Valid Category");

            //Assert
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Try to create a Category with invalid ID.")]
        public void Create_WithInvalidId_ResultInvalidState()
        {
            //Arrange & Act
            Action action = () => new Category(-1, "Invalid Category");

            //Assert
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Try to create a Category with invalid Name.")]
        public void Create_WithInvalidName_ResultInvalidState()
        {
            //Arrange & Act
            Action actionWithEmptyName = () => new Category(1, "");
            Action actionWithNullName = () => new Category(1, null);
            Action actionWithWhiteSpaces = () => new Category(1, "    ");
            Action actionWithShortName = () => new Category(1, "Ca");

            //Assert
            actionWithEmptyName.Should()
                .Throw<DomainExceptionValidation>();

            actionWithNullName.Should()
                .Throw<DomainExceptionValidation>();

            actionWithWhiteSpaces.Should()
                .Throw<DomainExceptionValidation>();
        }


    }
}
