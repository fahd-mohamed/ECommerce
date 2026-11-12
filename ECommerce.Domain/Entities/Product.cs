
namespace ECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string ImageUrl { get; private set; } = null!;
        public decimal Price { get; private set; }

        public Guid ProductBrandId { get; private set; }
        public ProductBrand ProductBrand { get; private set; } = null!;

        public Guid ProductTypeId { get; private set; }
        public ProductType ProductType { get; private set; } = null!;

        // EF Core Constructor
        private Product() { }

        // Factory Method
        public static Product Create(
            Guid id,
            string name,
            string description,
            string imageUrl,
            decimal price,
            Guid productBrandId,
            Guid productTypeId)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Product ID is required.", nameof(id));

            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(description);
            ArgumentException.ThrowIfNullOrWhiteSpace(imageUrl);

            if (price <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(price), "Price must be greater than zero.");

            if (productBrandId == Guid.Empty)
                throw new ArgumentException(
                    "Product Brand ID is required.", nameof(productBrandId));

            if (productTypeId == Guid.Empty)
                throw new ArgumentException(
                    "Product Type ID is required.", nameof(productTypeId));

            return new Product
            {
                Id = id,
                Name = name.Trim(),
                Description = description.Trim(),
                ImageUrl = imageUrl.Trim(),
                Price = price,
                ProductBrandId = productBrandId,
                ProductTypeId = productTypeId
            };
        }

        // Update Basic Information
        public void UpdateBasicInfo(string name, string description)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(description);

            Name = name.Trim();
            Description = description.Trim();
        }

        // Update Image
        public void UpdateImage(string imageUrl)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(imageUrl);

            ImageUrl = imageUrl.Trim();
        }

        // Update Price
        public void UpdatePrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(price), "Price must be greater than zero.");

            Price = price;
        }

        // Change Brand
        public void ChangeBrand(Guid productBrandId)
        {
            if (productBrandId == Guid.Empty)
                throw new ArgumentException(
                    "Product Brand ID is required.", nameof(productBrandId));

            ProductBrandId = productBrandId;
        }

        // Change Type
        public void ChangeType(Guid productTypeId)
        {
            if (productTypeId == Guid.Empty)
                throw new ArgumentException(
                    "Product Type ID is required.", nameof(productTypeId));

            ProductTypeId = productTypeId;
        }
    }
}
