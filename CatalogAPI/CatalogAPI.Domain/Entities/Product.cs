using CatalogAPI.Domain.Validation;

namespace CatalogAPI.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? UrlImage { get; private set; }

        #region Relational
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        #endregion

        public Product(string name, string description, decimal price, int stock, string? urlImage)
        {
            Validate(name, description, price, stock, urlImage);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            UrlImage = urlImage;
        }

        public Product(int id, string name, string description, decimal price, int stock, string urlImage)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID.");
            Id = id;

            Validate(name, description, price, stock, urlImage);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            UrlImage = urlImage;
        }

        public void Update(string name, string description, decimal price, int stock, string urlImage, int categoryId)
        {
            Validate(name, description, price, stock, urlImage);
            CategoryId = categoryId;
        }

        public void Validate(string name, string description, decimal price, int stock, string urlImage)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name) || name.Length < 3,
            "Invalid name: verify if name is empty, null or have less than 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
            "Invalid Description. Description is required.");

            DomainExceptionValidation.When(price <= 0,
            "Invalid Price value. Price need to be bigger than 0.");

            DomainExceptionValidation.When(stock < 0,
            "Invalid Stock. Stock can't have a negative value.");

            DomainExceptionValidation.When(urlImage.Trim().Length <=0 || urlImage.Trim().Length > 250,
            "Invalid image URL: url must not be empty or has more than 250 characters."); ;

        }
    }
}
