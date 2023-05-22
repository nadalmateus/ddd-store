using Store.Core.DomainObjects;

namespace Store.Catalog.Domain
{
    public record Dimensions
    {
        public Dimensions(decimal height, decimal width, decimal depth)
        {
            Height = height;
            Width = width;
            Depth = depth;

            Validations.ValidateIfLessThan(Height, 1, "The field Height cannot be less than 1");
            Validations.ValidateIfLessThan(Width, 1, "The field Width cannot be less than 1");
            Validations.ValidateIfLessThan(Depth, 1, "The field Depth cannot be less than 1");
        }

        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Depth { get; private set; }

        public string DescriptionFormat() => $"HxWxD: {Height} x {Width} x {Depth}";

        public override string ToString() => DescriptionFormat();
    }
}