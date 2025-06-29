using BuisnessAccessLayer.IStockBAL;
using BuisnessAccessLayer.StockBAL;
using DataAccessLayer.DapperContext;
using DataAccessLayer.IStockRepository;
using DataAccessLayer.StockRepository;
using Helper.DataHelper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockBAL, StockBAL>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var app = builder.Build();
app.UseCors("AllowLocalhostReactApp"); 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
