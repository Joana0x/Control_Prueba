# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar solo lo necesario (después del .dockerignore actualizado)
COPY . ./

# Compilar solo el proyecto API
RUN dotnet publish API_Estudiantes_Test/API_Estudiantes_Test.csproj -c Release -o /app/out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]