using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "ECO PLANTA");

app.MapPost("/api/plantas/cadastrar", async ([FromBody] Planta planta, [FromServices] AppDataContext ctx) => 
{
    if (planta.OrigemId <= 0 || planta.TipoId <= 0)
    {
        return Results.BadRequest("OrigemId e TipoId são obrigatórios.");
    }

    if (!await ctx.Origens.AnyAsync(o => o.IdOrigem == planta.OrigemId) ||
        !await ctx.Tipos.AnyAsync(t => t.TipoId == planta.TipoId))
    {
        return Results.BadRequest("OrigemId ou TipoId inválidos.");
    }

    ctx.Plantas.Add(planta);
    await ctx.SaveChangesAsync();
    
    return Results.Created($"/api/plantas/buscar/{planta.IdPlanta}", planta);
});

app.MapGet("/api/plantas/buscar/{id}", async ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Planta? planta = await ctx.Plantas.Include(p => p.Origem).Include(p => p.Tipo).FirstOrDefaultAsync(p => p.IdPlanta == id);
    if (planta is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(planta);
});

app.MapGet("/api/plantas/listar", async ([FromServices] AppDataContext ctx) => 
{
    var plantas = await ctx.Plantas.Include(p => p.Origem).Include(p => p.Tipo).ToListAsync();
    if (plantas.Any())
    {
        return Results.Ok(plantas);
    }
    return Results.NotFound();
});

app.MapDelete("/api/plantas/deletar/{id}", async ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Planta? planta = await ctx.Plantas.FindAsync(id);
    if (planta is null)
    {
        return Results.NotFound();
    }
    ctx.Plantas.Remove(planta);
    await ctx.SaveChangesAsync();
    return Results.Ok(planta);
});

app.MapPut("/api/plantas/alterar/{id}", async ([FromRoute] int id, [FromBody] Planta plantaAlterada, [FromServices] AppDataContext ctx) => 
{
    Planta? planta = await ctx.Plantas.FindAsync(id);
    if (planta is null)
    {
        return Results.NotFound();
    }

    planta.Nome = plantaAlterada.Nome;

    if (plantaAlterada.OrigemId > 0)
    {
        planta.OrigemId = plantaAlterada.OrigemId;
    }
    if (plantaAlterada.TipoId > 0)
    {
        planta.TipoId = plantaAlterada.TipoId;
    }
    
    await ctx.SaveChangesAsync();
    return Results.Ok(planta);
});

app.MapPost("/api/origens/cadastrar", async ([FromBody] Origem origem, [FromServices] AppDataContext ctx) => 
{
    ctx.Origens.Add(origem);
    await ctx.SaveChangesAsync();
    return Results.Created($"/api/origens/buscar/{origem.IdOrigem}", origem);
});

app.MapGet("/api/origens/listar", async ([FromServices] AppDataContext ctx) => 
{
    var origens = await ctx.Origens.ToListAsync();
    if (origens.Any())
    {
        return Results.Ok(origens);
    }
    return Results.NotFound();
});

app.MapGet("/api/origens/buscar/{id}", async ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Origem? origem = await ctx.Origens.FindAsync(id);
    if (origem is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(origem);
});

app.MapDelete("/api/origens/deletar/{id}", async ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Origem? origem = await ctx.Origens.FindAsync(id);
    if (origem is null)
    {
        return Results.NotFound();
    }
    ctx.Origens.Remove(origem);
    await ctx.SaveChangesAsync();
    return Results.Ok(origem);
});

app.MapPut("/api/origens/alterar/{id}", async ([FromRoute] int id, [FromBody] Origem origemAlterada, [FromServices] AppDataContext ctx) => 
{
    Origem? origem = await ctx.Origens.FindAsync(id);
    if (origem is null)
    {
        return Results.NotFound();
    }
    origem.Pais = origemAlterada.Pais;
    await ctx.SaveChangesAsync();
    return Results.Ok(origem);
});

app.MapPost("/api/tipos/cadastrar", async ([FromBody] Tipo tipo, [FromServices] AppDataContext ctx) => 
{
    ctx.Tipos.Add(tipo);
    await ctx.SaveChangesAsync();
    return Results.Created($"/api/tipos/buscar/{tipo.TipoId}", tipo); 
});

app.MapGet("/api/tipos/listar", async ([FromServices] AppDataContext ctx) => 
{
    var tipos = await ctx.Tipos.ToListAsync();
    if (tipos.Any())
    {
        return Results.Ok(tipos); 
    }
    return Results.NotFound(); 
});

app.MapGet("/api/tipos/buscar/{id}", async ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Tipo? tipo = await ctx.Tipos.FindAsync(id);
    if (tipo is null)
    {
        return Results.NotFound(); 
    }
    return Results.Ok(tipo); 
});

app.MapDelete("/api/tipos/deletar/{id}", async ([FromRoute] int id, [FromServices] AppDataContext ctx) => 
{
    Tipo? tipo = await ctx.Tipos.FindAsync(id);
    if (tipo is null)
    {
        return Results.NotFound(); 
    }
    ctx.Tipos.Remove(tipo); 
    await ctx.SaveChangesAsync();
    return Results.Ok(tipo);
});

app.MapPut("/api/tipos/alterar/{id}", async ([FromRoute] int id, [FromBody] Tipo tipoAlterado, [FromServices] AppDataContext ctx) => 
{
    Tipo? tipo = await ctx.Tipos.FindAsync(id);
    if (tipo is null)
    {
        return Results.NotFound(); 
    }
    tipo.Nome = tipoAlterado.Nome;
    await ctx.SaveChangesAsync();
    return Results.Ok(tipo); 
});

app.Run();
