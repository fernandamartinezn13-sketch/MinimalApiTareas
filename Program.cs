using MinimalAPI.Models;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar base de datos
builder.Services.AddDbContext<AddDbContext>(options =>
    options.UseSqlite("Data Source=tareas.db"));

builder.Services.AddScoped<ITareaRepository, TareaRepository>();

var app = builder.Build();

// ENDPOINTS

// Crear nueva tarea
app.MapPost("/tareas", async (ITareaRepository repo, TareasDto nuevaTareaDto) =>
{
    try
    {
        var nuevTarea = await repo.AddAsync(nuevaTareaDto);
        return Results.Created($"/tareas7{nuevTarea.Id}", nuevTarea);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

 // Obtener todas las tareas
app.MapGet("/tareas", async (ITareaRepository repo) =>
{
    var tareas = await repo.GetAllAsync();
    return Results.Ok(tareas);
});


// Actualizar tarea
app.MapPut("/tareas/{id}", async (ITareaRepository repo, int id, TareasDto tareaDto) =>
{
    try
    {
        var tareaActualizada = await repo.UpdateAsync(id, tareaDto);
        if (tareaActualizada == null) return Results.NotFound();
        return Results.Ok(tareaActualizada);

    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// Eliminar tarea
app.MapDelete("/tareas/{id}", async (ITareaRepository repo, int id) =>
{
    var tareaEliminada = await repo.DeleteAsync(id);
    return tareaEliminada ? Results.NoContent() : Results.NotFound();
});

//Busqueda de tareas completadas
app.MapGet("/tareas/completadas", async (ITareaRepository repo) =>
{
    var tareasCompletadas = await repo.GetCompletadasAsync();
    return Results.Ok(tareasCompletadas);

});

app.MapGet("/tareas/search", async (ITareaRepository repo, string Busqueda) =>
{
    var resultados = await repo.SearchAsync(Busqueda);
    return Results.Ok(resultados);

});

app.Run();