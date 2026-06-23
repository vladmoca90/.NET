var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// OpenAPI enables auto-generated API metadata and docs (Swagger UI).
builder.Services.AddOpenApi();

// Build the application from the configured services.
var app = builder.Build();

// Configure the HTTP request pipeline.
// Only expose OpenAPI docs when the app is running in development.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Redirect incoming HTTP traffic to HTTPS for better security.
app.UseHttpsRedirection();

// Static in-memory list of people with diverse backgrounds.
var people = new[]
{
    new Person("Anna Müller", 28, "Software Engineer", "Germany"),
    new Person("Jean Dupont", 34, "Product Manager", "France"),
    new Person("Marco Rossi", 45, "Senior Developer", "Italy"),
    new Person("Elena Kowalski", 31, "Data Analyst", "Poland"),
    new Person("Carlos García", 29, "UX Designer", "Spain"),
    new Person("Sofia Petrov", 26, "DevOps Engineer", "Bulgaria"),
    new Person("Niels Jensen", 38, "CEO", "Denmark"),
    new Person("Lucia Novák", 33, "HR Manager", "Czech Republic"),
    new Person("Olaf Larsen", 42, "Sales Director", "Norway"),
    new Person("Isabella Rossi", 27, "Marketing Specialist", "Switzerland")
};

// Define an endpoint that returns the static list of people.
// The endpoint is available at GET /persons.
app.MapGet("/persons", () => people)
    .WithName("GetPersons");

// Start processing incoming HTTP requests.
app.Run();

// Define the Person record used by the API response.
// Contains information about individuals with their role and nationality.
record Person(
    string Name,
    int Age,
    string Position,
    string Nationality
);