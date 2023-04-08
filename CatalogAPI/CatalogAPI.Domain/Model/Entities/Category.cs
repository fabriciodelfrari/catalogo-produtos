using CatalogAPI.Domain.Validation;

namespace CatalogAPI.Domain.Model.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        #region Relational
        public ICollection<Product>? Products { get; set; }
        #endregion

        public Category(string name)
        {
            Validate(name);
            Name = name;
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID.");
            Id = id;

            Validate(name);
            Name = name;
        }

        public void Update(string name)
        {
            Validate(name);
        }

        private void Validate(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Name is null or empty.");
            DomainExceptionValidation.When(name.Length < 3, "Name is too short (less than 3 characters).");
        }
    }
}
