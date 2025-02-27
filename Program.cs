using MyApi.Repositories.Database;
using MyApi.Repositories.Prices;
using MyApi.Repositories.Products;
using MyApi.Repositories.Stocks;
using MyApi.Repositories.Warehouse;
using MyApi.Services.Csv;
using MyApi.Services.File;
using MyApi.Services.Warehouse;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<ICsvMapperService, CsvMapperService>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IStocksRepository, StocksRepository>();
builder.Services.AddScoped<IPricesRepository, PricesRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();