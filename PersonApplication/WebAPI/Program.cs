using DataAccessLayer;
using RepositoryLayer;
using ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DI objects for all layers.
builder.Services.AddDataAccessLayerDI(builder.Configuration["JsonFilePath"]);
builder.Services.AddRepositoryLayerDI();
builder.Services.AddServiceLayerDI();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((setup) =>
    setup.AddPolicy("default", (options) =>
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
