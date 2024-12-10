using PhotoPortfolio;
var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();
app.UseAuthorization();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Контора Сыча");
app.UseMiddleware<LogMiddleware>();
app.MapControllers();
app.Run();

