var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var products = new[]
{
    new FoodProduct(1, "Organic Bananas", "Fresh Produce", "Green Valley", 1.49m, 1000, "Organic bananas, sold by weight.", true),
    new FoodProduct(2, "Whole Milk", "Dairy", "Meadow Farms", 3.29m, 1890, "Whole milk, 2 L bottle.", true),
    new FoodProduct(3, "Free-Range Eggs", "Dairy", "Sunnybrook", 4.59m, 680, "One dozen large free-range eggs.", true),
    new FoodProduct(4, "Sourdough Bread", "Bakery", "Daily Loaf", 4.25m, 500, "Freshly baked artisan sourdough loaf.", true),
    new FoodProduct(5, "Rolled Oats", "Pantry", "Harvest Mill", 5.49m, 1000, "Whole-grain rolled oats, 1 kg bag.", true),
    new FoodProduct(6, "Penne Pasta", "Pantry", "Casa Italia", 2.19m, 500, "Durum wheat penne pasta.", true),
    new FoodProduct(7, "Extra Virgin Olive Oil", "Pantry", "Oliva", 11.99m, 750, "Cold-pressed extra virgin olive oil.", true),
    new FoodProduct(8, "Cheddar Cheese", "Dairy", "Clover Creamery", 6.79m, 400, "Mature cheddar cheese block.", true),
    new FoodProduct(9, "Roasted Almonds", "Snacks", "Nut Grove", 7.25m, 300, "Lightly salted roasted almonds.", false),
    new FoodProduct(10, "Orange Juice", "Drinks", "Citrus Press", 3.99m, 1500, "Not-from-concentrate orange juice.", true)
};

app.MapGet("/products", () => products)
    .WithName("GetFoodProducts")
    .WithSummary("Get food products")
    .WithDescription("Returns ten grocery products with their category, brand, price, weight, and availability.");

app.Run();

record FoodProduct(
    int Id,
    string Name,
    string Category,
    string Brand,
    decimal Price,
    int WeightGrams,
    string Description,
    bool InStock
);
