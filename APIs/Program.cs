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

var europeanCountries = new[]
{
    new Country("Albania", "Tirana", 28748, 2837744),
    new Country("Andorra", "Andorra la Vella", 468, 77281),
    new Country("Armenia", "Yerevan", 29743, 2906000),
    new Country("Austria", "Vienna", 83879, 9036000),
    new Country("Azerbaijan", "Baku", 86600, 10440000),
    new Country("Belarus", "Minsk", 207600, 9408400),
    new Country("Belgium", "Brussels", 30528, 11431000),
    new Country("Bosnia and Herzegovina", "Sarajevo", 51197, 3281000),
    new Country("Bulgaria", "Sofia", 110994, 6951482),
    new Country("Croatia", "Zagreb", 56594, 3995000),
    new Country("Cyprus", "Nicosia", 9251, 1260000),
    new Country("Czech Republic", "Prague", 78866, 10710000),
    new Country("Denmark", "Copenhagen", 43094, 5842000),
    new Country("Estonia", "Tallinn", 45227, 1331000),
    new Country("Finland", "Helsinki", 338424, 5536000),
    new Country("France", "Paris", 551695, 67390000),
    new Country("Georgia", "Tbilisi", 69700, 3989000),
    new Country("Germany", "Berlin", 357386, 83520000),
    new Country("Greece", "Athens", 131957, 10423000),
    new Country("Hungary", "Budapest", 93030, 9703000),
    new Country("Iceland", "Reykjavik", 103000, 384000),
    new Country("Ireland", "Dublin", 70273, 5214000),
    new Country("Italy", "Rome", 301338, 59550000),
    new Country("Kazakhstan", "Nur-Sultan", 2724900, 19620000),
    new Country("Kosovo", "Pristina", 10908, 1831000),
    new Country("Latvia", "Riga", 64589, 1907000),
    new Country("Liechtenstein", "Vaduz", 160, 38900),
    new Country("Lithuania", "Vilnius", 65300, 2792000),
    new Country("Luxembourg", "Luxembourg", 2586, 660000),
    new Country("Malta", "Valletta", 316, 525000),
    new Country("Moldova", "Chișinău", 33846, 2614000),
    new Country("Monaco", "Monaco", 2, 39242),
    new Country("Montenegro", "Podgorica", 13812, 619000),
    new Country("Netherlands", "Amsterdam", 41543, 17400000),
    new Country("North Macedonia", "Skopje", 25713, 2083000),
    new Country("Norway", "Oslo", 323802, 5533000),
    new Country("Poland", "Warsaw", 312679, 37850000),
    new Country("Portugal", "Lisbon", 92212, 10280000),
    new Country("Romania", "Bucharest", 238397, 19350000),
    new Country("San Marino", "San Marino", 61, 34400),
    new Country("Serbia", "Belgrade", 88361, 6825000),
    new Country("Slovakia", "Bratislava", 49035, 5459000),
    new Country("Slovenia", "Ljubljana", 20273, 2140000),
    new Country("Spain", "Madrid", 505990, 47330000),
    new Country("Sweden", "Stockholm", 450295, 10720000),
    new Country("Switzerland", "Bern", 41285, 8715000),
    new Country("Turkey", "Ankara", 783562, 85962000),
    new Country("Ukraine", "Kyiv", 603550, 41900000),
    new Country("United Kingdom", "London", 242495, 67810000)
};

app.MapGet("/countries", () => europeanCountries)
    .WithName("GetEuropeanCountries");

app.Run();

record Country(string CountryName, string CountryCapital, int CountrySize, int CountryPopulation);
