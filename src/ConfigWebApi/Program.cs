WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("MyEnvironment"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/wheels",
    (IConfiguration config) =>
    {
        var pairs = config.GetSection("Wheel")
            .GetChildren();

        string[] props = pairs.Select(pair => $"\"{pair.Key}\": \"{pair.Value}\"").ToArray();
        return $"{{\n{string.Join(",\n", props)}\n}}";
    });

app.Run();
