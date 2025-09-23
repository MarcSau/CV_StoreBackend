using StoreBackend.Api.Data;
using StoreBackend.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connString = builder.Configuration.GetConnectionString("Store");
builder.Services.AddSqlite<StoreContext>(connString);

app.MapProductEndpoints();
app.Run();
