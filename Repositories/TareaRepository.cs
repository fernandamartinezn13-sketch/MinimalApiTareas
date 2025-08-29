using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;
using MinimalAPI.Data;

namespace MinimalAPI.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly AddDbContext _db;
        public TareaRepository(AddDbContext db)
        {
            _db = db;
        }

        // Agregar nueva tarea
        public async Task<Tarea> AddAsync(TareasDto tareaDto)
        {
            if (!Enum.TryParse<EstadoTarea>(tareaDto.Estado, true, out var estadoEnum))
                throw new ArgumentException($"Estado inválido: {tareaDto.Estado}");

            var nuevaTarea = new Tarea
            {
                Titulo = tareaDto.Titulo,
                Descripcion = tareaDto.Descripcion,
                Estado = estadoEnum,
                FechaCreacion = DateTime.Now
            };

            _db.Tareas.Add(nuevaTarea);
            await _db.SaveChangesAsync();
            return nuevaTarea;
        }

        // Obtener todas las tareas
        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            return await _db.Tareas.ToListAsync();
        }

        // Actualizar tarea
        public async Task<Tarea?> UpdateAsync(int id, TareasDto tareaDto)
        {
            var tarea = await _db.Tareas.FindAsync(id);
            if (tarea == null) return null;

            if (!Enum.TryParse<EstadoTarea>(tareaDto.Estado, true, out var estadoEnum))
                throw new ArgumentException($"Estado inválido: {tareaDto.Estado}");

            tarea.Titulo = tareaDto.Titulo;
            tarea.Descripcion = tareaDto.Descripcion;
            tarea.Estado = estadoEnum;

            await _db.SaveChangesAsync();
            return tarea;
        }

        // Eliminar tarea
        public async Task<bool> DeleteAsync(int id)
        {
            var tarea = await _db.Tareas.FindAsync(id);
            if (tarea == null) return false;

            _db.Tareas.Remove(tarea);
            await _db.SaveChangesAsync();
            return true;
        }

        // Obtener tareas completadas
        public async Task<IEnumerable<Tarea>> GetCompletadasAsync()
        {
            return await _db.Tareas
                .Where(t => t.Estado == EstadoTarea.Completada)
                .ToListAsync();
        }

        // Buscar tareas por título o descripción
        public async Task<IEnumerable<Tarea>> SearchAsync(string busqueda)
        {
            return await _db.Tareas
                .Where(t => t.Titulo.Contains(busqueda) || t.Descripcion.Contains(busqueda))
                .ToListAsync();
        }
    }
}