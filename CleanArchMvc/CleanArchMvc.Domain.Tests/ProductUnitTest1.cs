using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid Parameters")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Description", 500.0m, 5, "Product Image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Negative Id Value")]
        public void CreateProduct_NegativeIdValue_DomainExcpetionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Description", 500.0m, 5, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Short Name Value")]
        public void CreateProduct_WithShortNameValue_DomainExcpetionShortName()
        {
            Action action = () => new Product(1, "Pr", "Description", 500.0m, 5, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Description Value")]
        public void CreateProduct_WithInvalidDescription_DomainExcpetionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 500.0m, 5, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required.");
        }

        [Fact(DisplayName = "Create Product With Short Description Value")]
        public void CreateProduct_ShortDescription_DomainExcpetionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "Desc", 500.0m, 5, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Price Value")]
        public void CreateProduct_InvalidPrice_DomainExcpetionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Description", -5.0m, 5, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Theory(DisplayName = "Create Product With Invalid Stock Value")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStock_DomainExcpetionInvalidStock(int value)
        {
            Action action = () => new Product(1, "Product Name", "Description", 500.0m, value, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }

        [Fact(DisplayName = "Create Product With Too Long Image Value")]
        public void CreateProduct_LongImageName_DomainExcpetionInvalidLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Description", 500.0m, 5, "Product Image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact(DisplayName = "Create Product With Null Image Name Value")]
        public void CreateProduct_WithNullImageName_DomainExcpetionInvalidLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Description", 500.0m, 5, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Empty Image Name Value")]
        public void CreateProduct_WithEmptyImageName_DomainExcpetionInvalidLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Description", 500.0m, 5, "");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
