var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var discounts = new[]
{
    new Discount(1, "Welcome Offer", "Save on your first purchase.", 10, "WELCOME10"),
    new Discount(2, "Spring Sale", "A seasonal discount on your order.", 15, "SPRING15"),
    new Discount(3, "Student Discount", "Save with a valid student ID.", 20, "STUDENT20"),
    new Discount(4, "Loyalty Reward", "A thank-you discount for returning customers.", 12, "LOYAL12"),
    new Discount(5, "Clearance Deal", "Big savings on selected items.", 30, "CLEARANCE30")
};

app.MapGet("/discounts", () => discounts)
    .WithName("GetDiscounts")
    .WithSummary("Get available discounts")
    .WithDescription("Returns the five available discounts with their percentage and coupon code.");

app.Run();

record Discount(
    int Id,
    string Name,
    string Description,
    int Percentage,
    string Code
);
