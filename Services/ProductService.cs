using FirstApi.Models;
namespace FirstApi.Services;

public static class ProductService 
{
	static List<Product> Products { get; }
	static ProductService()
	{
		Products = new List<Product>
		{
			new Product { Id = Guid.NewGuid(), Name = "Martelo", Price= 20.30 },
			new Product { Id = Guid.NewGuid(), Name = "Prego", Price= 10.15 },
			new Product { Id = Guid.NewGuid(), Name = "Tijolo", Price= 175.12 },
			new Product { Id = Guid.NewGuid(), Name = "Marreta", Price= 75.32 },
			new Product { Id = Guid.NewGuid(), Name = "Cimento", Price= 125.82 }
		};
	}

	public static List<Product> GetAll() => Products;

	public static Product? Get(Guid id) => Products.Find((product) => product.Id.Equals(id));

	public static void Add(Product product)
	{
		product.Id = Guid.NewGuid();
		Products.Add(product);
	}

	public static void Delete(Guid id)
	{
		var product = Get(id);
		if(product is null) return;

		Products.Remove(product);
	}

	public static void Update(Product product)
	{
		var index = Products.FindIndex((target) => target.Id.Equals(product.Id));
		if(index == -1) return;
		Products[index] = product;
	}
}
