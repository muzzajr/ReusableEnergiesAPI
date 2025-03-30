using RenewableEnergiesApi.DB;

// Setup the database
var dbUtilities = new DbUtilities();
dbUtilities.CreateDatabase();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Register services for API endpoint dicovery
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AppDbContext with dependency injection
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RenwableReasourcesAPI");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
// Use the CORS policy
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

app.Run();
