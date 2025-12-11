# Documentación técnica — ApiVete

## Portada
- Institución: Universidad Tecnologica Metropolitana de Alta Tecnologia
- Materia: Desarrollo de APIs / Arquitectura de Software
- Grupo: A
- Cuatrimestre: 10
- Equipo: Daniela Macias, Daniel Alexander Muñoz, Josue Armando Guerrero, Josue Alexander Saucedo
- Nombre del proyecto: ApiVete

---

## 1. Descripción del problema
ApiVete es una API REST para la gestión operativa de una clínica veterinaria. Centraliza información sobre clientes, mascotas, productos, ventas y consultas, y proporciona autenticación mediante JWT. La API facilita integraciones con aplicaciones web o móviles y automatiza operaciones frecuentes (registro de ventas, historial de mascotas, gestión de inventario).

## 2. Arquitectura general
- Patrón por capas: Controllers (API), Services (lógica y utilidades), Context (EF Core), Models (entidades / DTOs), Migrations.
- Tecnologías: .NET 8, C# 12, Entity Framework Core 8, SQL Server, JWT para autenticación.

Diagrama (sencillo):


## 3. Modelo de datos final
Entidades principales y tablas:
- `Cliente` → `cat_clientes`
- `Mascota` → `cat_mascotas`
- `Producto` → `cat_productos`
- `Venta` → `cat_ventas`
- `Consulta` → `ret_consultas`
- `Usuario` → `seg_usuarios`

Diagrama ER (simplificado):


## 4. Lista de endpoints (resumen)
Formato: `ruta` — `VERBO` — Descripción — Parámetros — Respuestas principales

Autenticación
- `api/Auth/register` — POST — Registrar usuario (uso de pruebas). Body: `RegisterRequest` (`Username`, `Password`, `Role?`). Respuestas: `201` creado, `409` usuario existe, `400` datos inválidos.
- `api/Auth/login` — POST — Login. Body: `LoginRequest` (`Username`, `Password`). Respuestas: `200` token, `401` credenciales inválidas.

Clientes
- `api/Clientes` — GET — Lista clientes. `200` JSON[].
- `api/Clientes/{id}` — GET — Obtener cliente. `200` objeto, `404` no encontrado.
- `api/Clientes` — POST — Crear cliente. Body: `Cliente`. `201` creado, `400` inválido.
- `api/Clientes/{id}` — PUT — Actualizar cliente. `204` OK, `400` id mismatch, `404` no encontrado.
- `api/Clientes/{id}` — DELETE — Eliminar cliente. `204` OK, `404` no encontrado.

Productos, Mascotas, Consultas y Ventas siguen la misma estructura CRUD.

## 5. Instrucciones para desplegar en local
Requisitos:
- .NET 8 SDK
- SQL Server (local o en Docker)

Pasos:
1. Clonar el repositorio.
2. Configurar `appsettings.json` con `ConnectionStrings:CadenaSQL` apuntando a tu SQL Server.
3. Restaurar paquetes:
   - `dotnet restore`
4. (Migraciones) Generar y aplicar migraciones:
   - `dotnet tool install --global dotnet-ef --version 8.*` (si hace falta)
   - `dotnet ef migrations add AddInitial`
   - `dotnet ef database update`
   Si no puedes usar EF Tools, hay una migración incluida en `Migrations` que puedes aplicar manualmente en la base de datos.
5. Ejecutar la API:
   - `dotnet run`
6. Abrir Swagger en `https://localhost:{port}/swagger`.

## 6. Swagger y colección de pruebas
- Swagger está habilitado; se recomienda configurar autenticación JWT en Swagger para probar endpoints protegidos.
- Se proporciona una colección de Postman/Thunder Client con ejemplos de `register`, `login` y CRUD en `tools/Postman-ApiVete.postman_collection.json`.

## 7. Resumen de pruebas realizadas
- Pruebas funcionales manuales mediante Swagger: registro, login, token JWT, CRUD para entidades.
- Pruebas de errores: comprobación de `404`, `400` y `401` en escenarios típicos.

## 8. Conclusiones y mejoras futuras
- Migrar hashing de contraseñas a BCrypt/Argon2.
- Separar DTOs y lógica de negocio en Services/Repositories.
- Implementar middleware global para errores y respuestas estándar (ProblemDetails).
- Añadir validaciones más estrictas y pruebas automatizadas (unitarias e integración).


