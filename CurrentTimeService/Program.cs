var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Handle HTTPS redirection if HTTPS is available
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseRouting();

app.UseAuthorization();

// Define the GET endpoint for UTC time
app.MapGet("/time/utc", () => Results.Ok(DateTime.UtcNow));

// Define the GET endpoint for the root URL
app.MapGet("/", () => Results.Ok("Welcome to the CICD .NET application!"));

await app.RunAsync();
