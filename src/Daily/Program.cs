using Daily.Data;
using Daily.View;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DailyData>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//Return, status 201 - Created
//app.MapGet("/", () => Results.Ok(new DailyAnnotation(Guid.NewGuid(), "Wipro Event One", "Terminar deploy", false)));

//Method GET on Pattern Matching return (400) or (200)
app.MapGet("/v1/annotations", (DailyData data) =>
{
    var annotations = data.Annotations;
    return annotations is not null ? Results.Ok(annotations) : Results.NotFound();
}).Produces<Annotation>();

app.MapPost("/v1/annotations", (DailyData dataContext, DailyView viewModel) =>
{
    var daily = viewModel.MapTo();
    if (!viewModel.IsValid)
        return Results.BadRequest(viewModel.Notifications);

    dataContext.Annotations.Add(daily);
    dataContext.SaveChanges();

    return Results.Created($"/v1/annotatios/{daily.Id}", daily);
});

app.UseSwagger();
app.UseSwaggerUI();


app.Run();
