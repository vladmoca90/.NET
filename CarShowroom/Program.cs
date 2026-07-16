var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var cars = new[]
{
    new Car("Toyota", "Corolla", 2021, 18000, "Hybrid"),
    new Car("Honda", "Civic", 2020, 22000, "Petrol"),
    new Car("Ford", "Mustang", 2022, 35000, "Petrol"),
    new Car("BMW", "X5", 2023, 48000, "Diesel"),
    new Car("Mercedes", "C-Class", 2021, 41000, "Hybrid"),
    new Car("Tesla", "Model 3", 2024, 39000, "Electric"),
    new Car("Audi", "A4", 2022, 30000, "Diesel"),
    new Car("Nissan", "Altima", 2019, 17000, "Petrol"),
    new Car("Volkswagen", "Golf", 2021, 24000, "Hybrid"),
    new Car("Chevrolet", "Camaro", 2020, 28000, "Petrol")
};

app.MapGet("/", () => Results.Text("""
<!DOCTYPE html>
<html lang=\"en\">
<head>
    <meta charset=\"utf-8\">
    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">
    <title>Car Showroom</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 40px; }
        form { margin-bottom: 20px; }
        input, button { padding: 8px; margin-right: 8px; }
        .car { border: 1px solid #ddd; padding: 12px; margin-bottom: 10px; border-radius: 6px; }
    </style>
</head>
<body>
    <h1>Car Showroom</h1>
    <form action=\"/cars\" method=\"get\">
        <label>Make</label>
        <input name=\"make\" placeholder=\"e.g. Toyota\" />
        <label>Model</label>
        <input name=\"model\" placeholder=\"e.g. Corolla\" />
        <button type=\"submit\">Filter</button>
    </form>
    <p>Use the form above to filter cars by make or model.</p>
</body>
</html>
""", "text/html"));

app.MapGet("/cars", (string? make, string? model) =>
{
    var filteredCars = cars.Where(c =>
        (string.IsNullOrWhiteSpace(make) || c.Make.Contains(make, StringComparison.OrdinalIgnoreCase)) &&
        (string.IsNullOrWhiteSpace(model) || c.Model.Contains(model, StringComparison.OrdinalIgnoreCase))
    ).ToList();

    return filteredCars;
});

app.Run();

record Car(string Make, string Model, int Year, decimal Price, string FuelType);
