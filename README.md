ApiVete - Sistema de Gestión Veterinaria
ApiVete es una API RESTful desarrollada con .NET 8 para la administración integral de una clínica veterinaria. El sistema permite gestionar clientes, expedientes de mascotas, inventario de productos, registro de ventas y control de consultas médicas (historial clínico y vacunación).

Características Principales
Gestión de Clientes: Registro y administración de dueños de mascotas.

Expediente de Mascotas: Control de pacientes, incluyendo especie, raza y peso.

Inventario: Catálogo de productos y servicios con control de precios y stock.

Ventas: Registro transaccional de productos vendidos a clientes.

Consultas Médicas: Historial clínico, diagnósticos, tratamientos y vacunación.

Arquitectura: Basada en Entity Framework Core (Code First).

Tecnologías Utilizadas
Framework: .NET 8 SDK

Lenguaje: C# 12

ORM: Entity Framework Core

Base de Datos: SQL Server

Documentación: Swagger / OpenAPI

Requisitos Previos
Para ejecutar este proyecto localmente, necesitas tener instalado:

SDK de .NET 8.0: 

SQL Server: (Puede ser la versión Express, Developer o LocalDB).

Editor de Código: Visual Studio 2022 o Visual Studio Code.

Cliente API (Opcional): Postman o Thunder Client (aunque el proyecto incluye Swagger).

Instalación y Configuración
Sigue estos pasos para levantar la API en tu entorno local:

1. Clonar el repositorio
Abre tu terminal y ejecuta:

Bash

git clone <URL_DE_TU_REPOSITORIO>
cd ApiVete
2. Configurar la Base de Datos
Abre el archivo appsettings.json en la raíz del proyecto. Asegúrate de configurar la cadena de conexión CadenaSQL apuntando a tu servidor local de SQL Server.

JSON

{
  "ConnectionStrings": {
    "CadenaSQL": "Server=.;Database=VeterinariaDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
Nota: Si usas SQL Express, cambia Server=. por Server=.\\SQLEXPRESS.

3. Crear la Base de Datos (Migraciones)
Este proyecto utiliza Entity Framework Code First. Para generar la base de datos y las tablas automáticamente, abre la terminal en la carpeta del proyecto y ejecuta:

PowerShell

# Restaura las dependencias y herramientas
dotnet restore

# Aplica la migración para crear la DB
dotnet ef database update
(Si usas Visual Studio, puedes usar la Consola del Administrador de Paquetes con el comando: Update-Database).

4. Ejecutar la API
Una vez creada la base de datos, inicia el servidor:

Bash

dotnet run
O presiona F5 si estás en Visual Studio.

Documentación de la API (Swagger)
Una vez que la aplicación esté corriendo, puedes ver y probar todos los endpoints disponibles accediendo a:

https://localhost:<TU_PUERTO>/swagger
(Generalmente el puerto es 7000, 5000 o similar, verifica la consola al iniciar).

Estructura de la Base de Datos
El sistema consta de 5 tablas principales optimizadas:

cat_clientes: Información de contacto de los dueños.

cat_mascotas: Datos de los pacientes (integra raza y especie).

cat_productos: Productos y servicios vendibles.

rel_ventas: Transacciones de venta vinculadas a clientes y productos.

rel_consultas: Registro de atenciones médicas y vacunación.
