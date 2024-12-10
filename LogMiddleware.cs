namespace PhotoPortfolio;

public class LogMiddleware
{
    private readonly RequestDelegate _next;

    public LogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var method = context.Request.Method;
        var path = context.Request.Path;
        var moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
        var timestamp = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, moscowTimeZone);


        Console.WriteLine($"[{timestamp}] Zapros: {method} {path}");
        
        var logMessage = $"{method} {path}: {timestamp}";
        await File.AppendAllTextAsync("request_logs.txt", logMessage + Environment.NewLine);
        await _next(context);
    }
}