﻿using Essence.DataAccess.DataInitializers;

namespace Essence.Presentation.Extensions;

public static class ExtensionMethods
{
    public static string GetReturnUrl(this HttpRequest Request)
    {
        string? returnUrl = Request.Headers["Referer"];

        if (string.IsNullOrEmpty(returnUrl))
            returnUrl = "/";

        return returnUrl;
    }
    public static async Task InitDatabaseAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<DbContextInitalizer>();
            await initializer.InitDatabaseAsync();
        }
    }
}
