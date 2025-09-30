using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SevShop.MVC.Controllers;

public class ProductController : Controller
{
    private readonly HttpClient _http;

    public ProductController(IHttpClientFactory factory)
    {
        _http = factory.CreateClient();
        _http.BaseAddress = new Uri("https://localhost:7273/");
    }

    public async Task<IActionResult> Index()
    {
        var response = await _http.GetAsync("api/product");
        if (!response.IsSuccessStatusCode)
            return View(new List<ProductVm>());

        var json = await response.Content.ReadAsStringAsync();

        var products = JsonSerializer.Deserialize<List<ProductVm>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(products);
    }
}

public class ProductVm
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}
