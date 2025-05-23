# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar toda la solución primero
COPY . ./

# Publicar solo el proyecto API_Estudiantes_Test
RUN dotnet publish API_Estudiantes_Test/API_Estudiantes_Test.csproj -c Release -o /app/out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
EXPOSE 443

# Entrypoint dinámico
ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]
