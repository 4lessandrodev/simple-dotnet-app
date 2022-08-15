using Microsoft.AspNetCore.Mvc;
using FirstApi.Services;
using FirstApi.Models;

namespace FirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
   public ProductController()
   {
   }

	[HttpGet]
	public ActionResult<List<Product>> GetAll() => ProductService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Product> Get(Guid id)
    {
		var product = ProductService.Get(id);

        if(product == null) return NotFound();

		return product;
	}

    [HttpPost]
    public IActionResult Create(Product product)
    {
		ProductService.Add(product);
		return Ok();
	}

    [HttpPut]
    public IActionResult Update(Product product)
    {
		ProductService.Update(product);
		return Ok();
	}
    
    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
		ProductService.Delete(id);
		return Ok();
	}
}
