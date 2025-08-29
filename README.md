# Minimal API - Tareas 📝

API minimalista desarrollada en *.NET 8* para gestionar tareas, utilizando *Entity Framework Core* y *SQLite*.  
---

## 🔹 Tecnologías
- .NET 8 (Minimal APIs)  
- C#  
- Entity Framework Core  
- SQLite  
- Visual Studio Code (o IDE de tu preferencia)  
---
## 🚀 Cómo ejecutar el proyecto

1. Clonar el repositorio:
- git clone https://github.com/fernandamartinezn13-sketch/MinimalApiTareas.git
- cd MinimalApiTareas

2. Restaurar dependencias:
- dotnet restore

3. Crear la base de datos y aplicar migraciones:
- dotnet ef database update

4. Ejecutar la API:
- dotnet run

🔹 Endpoints
Método	Ruta	Descripción
- POST	/tareas	Crear nueva tarea
- GET	/tareas	Listar todas las tareas
- PUT	/tareas/{id}	Actualizar tarea por ID
- DELETE	/tareas/{id}	Eliminar tarea por ID
- GET	/tareas/completadas	Listar tareas completadas
- GET	/tareas/search?busqueda=texto	Buscar por título o descripción
- Recuerda usar Content-Type: application/json en POST y PUT.

🔹 Estructura del proyecto
- Models/ → Entidades y DTOs (Tarea, TareasDto, EstadoTarea)
- Data/ → AddDbContext para EF Core
- Repositories/ → ITareaRepository y TareaRepository 
- Program.cs →  Definición de endpoints
