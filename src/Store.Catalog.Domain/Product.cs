using Store.Core.DomainObjects;

namespace Store.Catalog.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        #region Constructor

        public Product
            (string name,
            string description,
            bool active,
            decimal price,
            Guid categoryId,
            DateTime registrationDate,
            string image,
            Dimensions dimensions
            )
        {
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            RegistrationDate = registrationDate;
            Image = image;
            Dimensions = dimensions;
            CategoryId = categoryId;
            Validate();
        }



        //string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)



        #endregion Constructor

        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Image { get; private set; }
        public int? StockQuantity { get; private set; }
        public Dimensions Dimensions { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category? Category { get; private set; }

        #endregion Properties

        #region Methods

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void ChangeCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void ChangeDescription(string description) => Description = description;

        public bool HasStock(int quantity) => StockQuantity >= quantity;

        public void ReplenishStock(int quantity) => StockQuantity += quantity;

        public void DebitStock(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            StockQuantity -= quantity;
        }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Name, "The product name field cannot be empty");
            Validations.ValidateIfEmpty(Description, "The product description field cannot be empty");
            Validations.ValidateIfEqual(CategoryId, Guid.Empty, "The product CategoryId field cannot be empty");
            Validations.ValidateIfLessThan(Price, 1, "Product Value field cannot be less than 0");
            Validations.ValidateIfEmpty(Image, "The product's Image field cannot be empty");
        }

        #endregion Methods
    }

    public class Category : Entity, IAggregateRoot
    {
        #region Constructor

        public Category(string name, int code)
        {
            Name = name;
            Code = code;
            Validate();
        }

        #endregion Constructor

        #region Properties

        public string Name { get; private set; }
        public int Code { get; private set; }

        #endregion Properties

        #region Methods

        public override string ToString() => $"{Name} - {Code}";

        public void Validate()
        {
            Validations.ValidateIfEmpty(Name, "The Name field of the category cannot be empty");
            Validations.ValidateIfEqual(Code, 0, "The Code field cannot be 0");
        }

        #endregion Methods
    }
}