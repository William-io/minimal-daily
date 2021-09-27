using Daily.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Return, status 201 - Created
app.MapGet("/", () => Results.Ok(new DailyAnnotation(Guid.NewGuid(), "Wipro Event One", "Terminar deploy", false)));

app.Run();
