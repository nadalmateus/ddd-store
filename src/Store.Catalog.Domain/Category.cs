using Store.Core;
using Store.Core.DomainObjects;

namespace Store.Catalog.Domain
{
    public class Category : Entity, IAggregateRoot
    {
        public Category(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public string Name { get; private set; }
        public int Code { get; private set; }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }
    }
}