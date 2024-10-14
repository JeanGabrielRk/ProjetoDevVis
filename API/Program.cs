using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "ECO PLANTA");

app.MapPost("/api/plantas/cadastrar", ([FromBody] Planta planta, [FromServices] AppDataContext ctx) => 
{
    ctx.Plantas.Add(planta);
    ctx.SaveChanges();
    return Results.Created("", planta);
});

app.MapGet("/api/plantas/buscar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Planta? planta = ctx.Plantas.Find(id);
    if(planta is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(planta);
});

app.MapGet("/api/plantas/listar", ([FromBody] Planta planta, [FromServices] AppDataContext ctx) => 
{
    if(ctx.Plantas.Any())
    {
        return Results.Ok(ctx.Plantas.ToList());
    }
    return Results.NotFound();
});

app.MapDelete("/api/plantas/deletar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Planta? planta = ctx.Plantas.Find(id);
    if(planta is null)
    {
        return Results.NotFound();
    }
    ctx.Plantas.Remove(planta);
    ctx.SaveChanges();
    return Results.Ok(planta);
});

app.MapPut("/api/plantas/alterar/{id}", ([FromRoute] int id, [FromBody] Planta plantaAlterada, [FromServices] AppDataContext ctx) => 
{
    Planta? planta = ctx.Plantas.Find(id);
    if(planta is null)
    {
        return Results.NotFound();
    }
    planta.Nome = plantaAlterada.Nome;
    ctx.Plantas.Update(planta);
    ctx.SaveChanges();
    return Results.Ok(planta);
});

app.Run();
