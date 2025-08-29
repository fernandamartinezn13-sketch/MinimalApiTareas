// archivo: Models/TareasDto.cs
namespace MinimalAPI.Models
{
    public class TareasDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";
    }
}