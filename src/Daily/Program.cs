using Daily.Data;
using Daily.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DailyData>();

var app = builder.Build();


//Return, status 201 - Created
//app.MapGet("/", () => Results.Ok(new DailyAnnotation(Guid.NewGuid(), "Wipro Event One", "Terminar deploy", false)));

//Method GET on Pattern Matching return (400) or (200)
app.MapGet("/v1/annotations", (DailyData data) =>
{
    var annotations = data.Annotations;
    return annotations is not null ? Results.Ok(annotations) : Results.NotFound();
});

app.Run();
