# 🏦 WebApi Sistema Financiero

## 🔗 Demo en vivo

[Ver API en Swagger](https://api-sistemafinanciero-c0dmbvb4hnd9dtgd.canadacentral-01.azurewebsites.net/swagger/index.html)

REST API desarrollada con ASP.NET Core y Entity Framework Core para la gestión de un sistema financiero. Documentada con Swagger UI.

## 🛠️ Tecnologías

- ASP.NET Core 10
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI 3.0
- Docker

## 📦 Módulos disponibles

| Módulo | GET | POST | PUT | DELETE |
|---|---|---|---|---|
| Clientes | ✅ | ✅ | ✅ | ✅ |
| Empleados | ✅ | ✅ | ✅ | ✅ |
| Cuentas | ✅ | ✅ | ✅ | ✅ |

## 🚀 Correr localmente

### Requisitos
- .NET 10 SDK
- SQL Server
- Visual Studio 2022 o VS Code

### Pasos

1. Clonar el repositorio
```bash
   git clone https://github.com/Lortiz-clock/WebApiHotel.git
```

2. Configurar la cadena de conexión en `appsettings.json`
```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=db_AlianzaRegional;Integrated Security=True;Trust Server Certificate=True"
     }
   }
```

3. Correr la aplicación
```bash
   dotnet run
```

4. Abrir Swagger
   https://localhost:{puerto}/swagger
## 🐳 Correr con Docker

```bash
docker build -t webapi-sistema-financiero .
docker run -p 8080:80 webapi-sistema-financiero
```

## 📁 Estructura del proyecto

WebApiSistemaFinanciero/

├── Controllers/

│   ├── ClientesController.cs

│   ├── CuentasController.cs

│   └── EmpleadoController.cs

├── DTOs/

│   ├── ClientesDTOs.cs

│   ├── ClientesCrearDTOs.cs

│   ├── ActualizarClienteDTOs.cs

│   ├── EmpleadoDTO.cs

│   ├── CrearEmpleadoDTOs.cs

│   └── EditarEmpleado.cs

└── Models/
👨‍💻 Autor
Luis Fernando Ortiz Hernández

GitHub • www.linkedin.com/in/luis-fernando-ortiz-hernandez-a12934271
   
