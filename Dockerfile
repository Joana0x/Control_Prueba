# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos del proyecto
COPY . .

# Restaurar paquetes y publicar
RUN dotnet restore API_Estudiantes_Test/API_Estudiantes_Test.csproj
RUN dotnet publish API_Estudiantes_Test/API_Estudiantes_Test.csproj -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar archivos publicados
COPY --from=build /app/publish .

# Asegurar que escuche en el puerto 8080 como Render espera
ENV ASPNETCORE_URLS=http://+:8080

# Exponer puertos (opcional si ya defines ASPNETCORE_URLS)
EXPOSE 8080

ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]
