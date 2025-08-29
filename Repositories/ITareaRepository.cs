using MinimalAPI.Models;

namespace MinimalAPI.Repositories
{
    public interface ITareaRepository
    {
        Task<Tarea> AddAsync(TareasDto tareaDto);
        Task<IEnumerable<Tarea>> GetAllAsync();
        Task<Tarea?> UpdateAsync(int id, TareasDto tareaDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Tarea>> GetCompletadasAsync();
        Task<IEnumerable<Tarea>> SearchAsync(string busqueda);
    }
}