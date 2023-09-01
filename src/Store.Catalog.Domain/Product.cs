using Store.Core;
using Store.Core.DomainObjects;

namespace Store.Catalog.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        public Product(
        string name,
        string description,
        bool active,
        decimal price,
        Guid categoryId,
        DateTime registrationDate,
        string image)
        {
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            CategoryId = categoryId;
            RegistrationDate = registrationDate;
            Image = image;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Image { get; private set; }
        public int StockQuantity { get; private set; }
        public Category Category { get; private set; }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void ChangeCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void DebitStock(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            StockQuantity -= quantity;
        }

        public void ReplenishStock(int quantity)
        {
            StockQuantity += quantity;
        }

        public bool HasStock(int quantity)
        {
            return StockQuantity >= quantity;
        }

        public void Validate()
        {
        }
    }
}