# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar toda la solución
COPY . ./

# Compilar solo el proyecto API_Estudiantes_Test
RUN dotnet publish ControlEscolar1/API_Estudiantes_Test/API_Estudiantes_Test.csproj -c Release -o /app/out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
EXPOSE 443

# Ejecutar el .dll de la API
ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]
