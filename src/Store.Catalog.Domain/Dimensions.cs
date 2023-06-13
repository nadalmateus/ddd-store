using Store.Core.DomainObjects;

namespace Store.Catalog.Domain;

public record Dimensions
{
    public Dimensions(decimal height, decimal width, decimal depth)
    {
        Height = height;
        Width = width;
        Depth = depth;

        Validations.ValidateIfLessThan(height, 1, "The Height field cannot be less than or equal to 0");
        Validations.ValidateIfLessThan(width, 1, "The Width field cannot be less than or equal to 0");
        Validations.ValidateIfLessThan(depth, 1, "The Depth field cannot be less than or equal to 0");
    }

    public decimal Height { get; }
    public decimal Width { get; }
    public decimal Depth { get; }

    public string DescriptionFormat()
    {
        return $"HxWxD: {Height} x {Width} x {Depth}";
    }

    public override string ToString()
    {
        return DescriptionFormat();
    }
}