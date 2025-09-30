using StoreBackend.Api.Data;
using StoreBackend.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Store");
builder.Services.AddSqlite<StoreContext>(connString);
builder.Logging.AddConsole();

var app = builder.Build();

app.MapProductEndpoints();
app.MapProductTypeEndpoints();
app.MapTransactionEndpoints();

await app.MigrateDbAsync();
app.Run();