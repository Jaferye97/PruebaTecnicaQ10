# Proyecto Gestión de Estudiantes y Materias - ASP.NET Core MVC

Este proyecto es una solución técnica para la gestión de estudiantes, materias y su asignación por semestres.
Está desarrollado en ASP.NET Core MVC siguiendo una arquitectura limpia con separación de responsabilidades por capas, uso de interfaces y principios SOLID.

## Herramientas utlizadas

- Visual Studio 2022 o superior
- .NET 8 SDK o superior
- SQL Server Express
- SQL Server Management Studio

---

## 📁 Estructura del Proyecto

PruebaTecnicaQ10
├── Domain # Entidades del dominio y modelos de vista
│ └── Model # Entidades como Estudiante, Materia, Semestre

├── Repository # Implementación del acceso a datos
│ ├── Context # DbContext y configuración
│ └── Repositories # Clases que acceden a la BD

├── Repository.Interface # Interfaces de los repositorios (contratos)
│ └── Interfaces # IEstudianteRepository, IMateriaRepository, etc.

├── Service # Lógica de negocio
│ └── Services # Clases que implementan la lógica

├── Service.Interface # Interfaces de los servicios (contratos)
│ └── Interfaces # IEstudianteService, IMateriaService, etc.

├── Web # Proyecto web MVC
│ ├── Controllers # Controladores MVC
│ ├── Features # Request y Response con mapping 
│ ├── Views # Vistas Razor (.cshtml)
│ └── appsettings.json # Configuraciones (incluye cadena de conexión)

## 1. Crear Base de Datos

Ve a la carpeta del proyecto llamada `BD` y ejecuta los siguientes scripts en orden utilizando SQL Server Express o en SQL Server Management Studio:

1. **01. Estructura Base.txt**  
   Crea las tablas y relaciones necesarias.

2. **02. Datos de prueba.txt**  
   Inserta datos de ejemplo en las tablas.

---

## 2. Configurar la Cadena de Conexión

Abre el archivo `appsettings.json` ubicado en el proyecto `Web`.

Modifica la sección `ConnectionStrings` con la conexión adecuada a tu instancia local de SQL Server Express:

```json
"ConnectionStrings": {
  "ConexionDb": "Server=DESKTOP-DU0MO1P\\SQLEXPRESS;Database=Q10_PruebaTecnica;Trusted_Connection=True;TrustServerCertificate=True;"
}