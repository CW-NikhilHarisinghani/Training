using BuisnessAccessLayer.IStockBAL;
using BuisnessAccessLayer.StockBAL;
using DataAccessLayer.DapperContext;
using DataAccessLayer.IStockRepository;
using DataAccessLayer.StockRepository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockBAL, StockBAL>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
