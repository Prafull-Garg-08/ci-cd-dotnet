var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Define route for root URL
app.MapGet("/", (HttpContext context) =>
{
    context.Response.Redirect("/swagger");
    return Results.Empty(); // End the request
});

// Define route for GET UTC time
app.MapGet("/time/utc", () => Results.Ok(DateTime.UtcNow));

await app.RunAsync();
