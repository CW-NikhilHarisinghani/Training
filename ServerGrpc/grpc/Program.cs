var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddSingleton<IValueForMoney, ValueForMoney>();
builder.Services.AddSingleton<IRepository, Repository>();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5230, o => o.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGrpcService<ComputeValueForMoneyServiceImpl>();
app.UseHttpsRedirection();

app.Run();