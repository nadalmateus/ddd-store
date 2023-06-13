using Store.Core.DomainObjects;

namespace Store.Catalog.Domain;

public class Category : Entity, IAggregateRoot
{
    #region Constructor

    public Category(string name, int code)
    {
        Name = name;
        Code = code;
        Validate();
    }

    protected Category()
    {
    }

    #endregion Constructor

    #region Properties

    public string Name { get; }
    public int Code { get; }

    //EF Relation
    public ICollection<Product> Products { get; set; }

    #endregion Properties

    #region Methods

    public override string ToString()
    {
        return $"{Name} - {Code}";
    }

    public void Validate()
    {
        Validations.ValidateIfEmpty(Name, "The Name field of the category cannot be empty");
        Validations.ValidateIfEqual(Code, 0, "The Code field cannot be 0");
    }

    #endregion Methods
}