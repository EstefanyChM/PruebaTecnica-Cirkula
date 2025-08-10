# Cirkula Web API

API desarrollada en .NET 8 que forma parte del ecosistema Cirkula.  
Se encarga de gestionar la lógica de negocio, servicios, acceso a datos y comunicación con las aplicaciones móviles y web del proyecto.

---

## 📦 Tecnologías principales

- .NET 8 Web API como framework principal
- Entity Framework Core 8 para acceso y mapeo a base de datos
- FluentValidation para validaciones de entrada
- AutoMapper para mapeo entre DTOs y entidades
- FirebaseAuthentication.net y FirebaseStorage.net para autenticación y almacenamiento en Firebase
- Swashbuckle.AspNetCore para generación automática de documentación Swagger
- Microsoft.AspNetCore.Http para manejo de peticiones HTTP

---

## 📂 Estructura de proyectos

La solución está organizada en capas siguiendo una arquitectura limpia y modular:

| Carpeta / Proyecto                          | Descripción |
|---------------------------------------------|-------------|
| 01-APIS / Cirkula.WebApi                    | Punto de entrada de la API, configuración de servicios y middlewares |
| 02-BUSINESS / Cirkula.Business              | Definición de interfaces de la capa de negocio |
| 02-BUSINESS / Cirkula.BusinessImpl          | Implementaciones de la capa de negocio |
| 03-SERVICES / Cirkula.Services              | Definición de interfaces de servicios |
| 03-SERVICES / Cirkula.ServiceImpl           | Implementaciones de servicios externos (Firebase) |
| 04-REPOSITORY / Cirkula.Repository          | Definición de interfaces de repositorios |
| 04-REPOSITORY / Cirkula.RepositoryImpl      | Implementaciones de acceso a datos con Entity Framework Core |
| 05-MODELS / DBCirkula.Models                | Modelos de base de datos (EF Core) |
| 05-MODELS / Cirkula.DTO.Models              | Data Transfer Objects (DTOs) para transporte de datos |
| 05-MODELS / Cirkula.RequestResponse.Models  | Modelos de request y response |
| 05-MODELS / Cirkula.Validator.Models        | Modelos con validaciones mediante FluentValidation |
| 06-UTILITIES / Cirkula.Mapper               | Configuración y perfiles de AutoMapper |
| 06-UTILITIES / UtilConstants                | Constantes y utilidades globales |

---

## 🚀 Scripts y comandos útiles

Dentro de la carpeta raíz del backend:

| Comando | Descripción |
|---------|-------------|
| dotnet restore | Restaura las dependencias de todos los proyectos |
| dotnet build | Compila la solución |
| dotnet run --project 01-APIS/Cirkula.WebApi | Ejecuta la API |
| dotnet ef migrations add <Nombre> | Crea una nueva migración de base de datos |
| dotnet ef database update | Aplica migraciones a la base de datos |
| dotnet list <Proyecto>.csproj package | Lista las dependencias de un proyecto |

---

## 📜 Documentación automática

La API expone documentación Swagger de forma automática al ejecutar el proyecto y acceder a la ruta:

https://localhost:<puerto>/swagger

---

## 🔗 Integración con el ecosistema

Esta API es consumida por:
- Cirkula Mobile (React Native + Expo)
- Cirkula Web (Frontend web)
- Servicios internos para gestión de ventas, usuarios y pedidos
