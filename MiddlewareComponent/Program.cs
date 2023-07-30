using MiddlewareComponent.Components;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseMiddleware<AgeMiddleware>();

app.MapGet("/", () => "");

app.Run();
