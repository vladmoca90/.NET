var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var players = new[] { "Alcaraz", "Djokovic", "Swiatek", "Sinner", "Zverev" };

app.MapGet("/tennis", () =>
{
    return Enumerable.Range(1, 5).Select(_ =>
        new TennisPlayer(
            players[Random.Shared.Next(players.Length)],
            Random.Shared.Next(3, 18),
            Random.Shared.Next(0, 2) == 1
        ))
        .ToArray();
})
.WithName("GetTennisData");

app.MapGet("/flights", () => new[]
{
    new Flight(1, "British Airways", "Madrid", 220, 0),
    new Flight(2, "Ryanair", "Madrid", 95, 1),
    new Flight(3, "Iberia", "Madrid", 175, 0)
})
.WithName("GetFlights");

app.Run();

record TennisPlayer(string Player, int Aces, bool Winner);
record Flight(int Id, string Airline, string Destination, decimal Price, int Stops);
