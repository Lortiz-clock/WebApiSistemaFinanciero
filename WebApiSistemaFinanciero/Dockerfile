#Usar una imagen oficial de .net para compilar y publicar
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

#Copiar archivos del proyecto

COPY . ./

#Restaurar dependencias
RUN dotnet restore --verbosity detailed

#Compilar y publicar en modo release 

RUN dotnet publish -c Release -o /out --verbosity detailed

#imagen ligera para ejecutar

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copiar la salida de la compilacion

COPY --from=build /out ./

# Configurar variables de entorno

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

# Exponer el puerto 80
EXPOSE 80
# COMANDO INICIO
ENTRYPOINT y esteyyy["dotnet", "WebApiSistemaFinanciero.dll"]