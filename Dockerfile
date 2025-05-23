# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar toda la solución al contenedor
COPY . ./

# Publicar únicamente el proyecto de la API
RUN dotnet publish API_Estudiantes_Test/API_Estudiantes_Test.csproj -c Release -o /app/out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos compilados desde la etapa de construcción
COPY --from=build /app/out .

# Exponer puertos necesarios
EXPOSE 80
EXPOSE 443

# Ejecutar el API
ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]