using Daily.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => new DailyAnnotation(Guid.NewGuid(), "Wipro Event One", "Terminar deploy", false));

app.Run();
