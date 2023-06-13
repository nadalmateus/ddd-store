using Store.Core.DomainObjects;

namespace Store.Catalog.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void Prooduct_Validate_ValidationsShouldReturnExceptions()
    {
        DomainException ex = Assert.Throws<DomainException>(() =>
            new Product(string.Empty, "Description", false, 100, Guid.NewGuid(), DateTime.Now, "Image",
                new Dimensions(1, 1, 1))
        );

        Assert.Equal("The product name field cannot be empty", ex.Message);

        ex = Assert.Throws<DomainException>(() =>
            new Product("Name", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Image",
                new Dimensions(1, 1, 1))
        );

        Assert.Equal("The product description field cannot be empty", ex.Message);

        ex = Assert.Throws<DomainException>(() =>
            new Product("Name", "Description", false, 0, Guid.NewGuid(), DateTime.Now, "Image", new Dimensions(1, 1, 1))
        );

        Assert.Equal("Product Value field cannot be less than 0", ex.Message);

        ex = Assert.Throws<DomainException>(() =>
            new Product("Name", "Description", false, 100, Guid.Empty, DateTime.Now, "Image", new Dimensions(1, 1, 1))
        );

        Assert.Equal("The product CategoryId field cannot be empty", ex.Message);

        ex = Assert.Throws<DomainException>(() =>
            new Product("Name", "Description", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty,
                new Dimensions(1, 1, 1))
        );

        Assert.Equal("The product's Image field cannot be empty", ex.Message);

        ex = Assert.Throws<DomainException>(() =>
            new Product("Name", "Description", false, 100, Guid.NewGuid(), DateTime.Now, "Image",
                new Dimensions(0, 1, 1))
        );
        Assert.Equal("The Height field cannot be less than or equal to 0", ex.Message);
    }
}