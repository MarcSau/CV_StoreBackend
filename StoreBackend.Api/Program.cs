using StoreBackend.Api.Data;
using StoreBackend.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Store");
builder.Services.AddSqlite<StoreContext>(connString);

var app = builder.Build();
app.MapProductEndpoints();
app.Run();
