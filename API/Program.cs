using API.modelos;
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

app.MapPost("/api/origens/cadastrar", ([FromBody] Origem origem, [FromServices] AppDataContext ctx) => 
{
    ctx.Origens.Add(origem);
    ctx.SaveChanges();
    return Results.Created(" ", origem);
});

app.MapGet("/api/origens/listar", ([FromBody] Origem origens, [FromServices] AppDataContext ctx) => 
{
    if(ctx.Origens.Any())
    {
        return Results.Ok(ctx.Origens.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/api/origens/buscar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Origem? origem = ctx.Origens.Find(id);
    if(origem is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(origem);
});

app.MapDelete("/api/origens/deletar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Origem? origem = ctx.Origens.Find(id);
    if(origem is null)
    {
        return Results.NotFound();
    }
    ctx.Origens.Remove(origem);
    ctx.SaveChanges();
    return Results.Ok(origem);
});

app.MapPut("/api/origens/alterar/{id}", ([FromRoute] int id, [FromBody] Origem origemAlterada, [FromServices] AppDataContext ctx) => 
{
    Origem? origem = ctx.Origens.Find(id);
    if(origem is null)
    {
        return Results.NotFound();
    }
    origem.Pais = origemAlterada.Pais;
    ctx.Origens.Update(origem);
    ctx.SaveChanges();
    return Results.Ok(origem);
});

app.MapPost("/api/tipos/cadastrar", ([FromBody] Tipo tipo, [FromServices] AppDataContext ctx) => 
{
    
    ctx.Tipos.Add(tipo);
    ctx.SaveChanges();
    return Results.Created($"/api/tipo/buscar/{tipo}", tipo); 
});

app.MapGet("/api/tipos/listar", ([FromServices] AppDataContext ctx) => 
{
   
    var tipo = ctx.Tipos.ToList();
    if (tipo.Any())
    {
        return Results.Ok(tipo); 
    }
    return Results.NotFound(); 
});

app.MapGet("/api/tipos/buscar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    
    Tipo? tipo = ctx.Tipos.Find(id);
    if (tipo is null)
    {
        return Results.NotFound(); 
    }
    return Results.Ok(tipo); 
});

app.MapDelete("/api/tipos/deletar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
   
    Tipo? tipo = ctx.Tipos.Find(id);
    if (tipo is null)
    {
        return Results.NotFound(); 
    }
    ctx.Tipos.Remove(tipo); 
    ctx.SaveChanges();
    return Results.Ok(tipo);
});

app.MapPut("/api/tipos/alterar/{id}", ([FromRoute] int id, [FromBody] Tipo tipoAlterado, [FromServices] AppDataContext ctx) => 
{
    
    Tipo? tipo = ctx.Tipos.Find(id);
    if (tipo is null)
    {
        return Results.NotFound(); 
    }

    tipo.Nome = tipoAlterado.Nome;

    ctx.Tipos.Update(tipo);
    ctx.SaveChanges();
    return Results.Ok(tipo); 
});

app.Run();
