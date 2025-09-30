using Microsoft.EntityFrameworkCore;
namespace StoreBackend.Api.Data;

public static class DataExtension
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
        await dbContext.Database.MigrateAsync();
    }
}
