using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;
using Microsoft.Extensions.Configuration;
using NLog;
using Npgsql;


namespace ControlEscolarCore.Data
{
    public class PostgreSQLDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.PostgreSQLDataAccess");

        private readonly string _ConnectionString;
        private NpgsqlConnection _connection;
        private static PostgreSQLDataAccess? _instance;

public PostgreSQLDataAccess()
    {
        try
        {
            // Construimos el objeto de configuración
            var configBuilder = new ConfigurationBuilder().AddEnvironmentVariables();
            var configuration = configBuilder.Build();

            // Obtenemos la cadena de conexión
            _ConnectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Cadena de conexión 'DefaultConnection' no encontrada en las variables de entorno.");

            _logger.Info($"Cadena de conexión obtenida: {_ConnectionString}");

            _connection = new NpgsqlConnection(_ConnectionString);
            _logger.Info("Instancia de acceso a datos creada correctamente.");
        }
        catch (Exception ex)
        {
            _logger.Fatal(ex, "Error al inicializar el acceso a la base de datos");
            throw;
        }
    }



    public static PostgreSQLDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PostgreSQLDataAccess();
            }
            return _instance;
        }

        public bool Connect()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                    _logger.Info("Conexión a la base de datos establecida correctamente");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al conectar a la base de datos");
                throw new Exception("No se pudo conectar a la base de datos. Verifica la configuración.", ex);
            }
        }

        public bool Disconnect()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                    _logger.Info("Conexión a la base de datos cerrada correctamente");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al cerrar la conexión a la base de datos");
                throw;
            }
        }

        public DataTable ExecuteQuery_Reader(string query, params NpgsqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                _logger.Debug($"Ejecutando consulta: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    _logger.Debug("Consulta ejecutada correctamente");
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar una consulta: {query}");
                throw;
            }
        }

        public int ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                _logger.Debug($"Ejecutando operación: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    int result = command.ExecuteNonQuery();
                    _logger.Debug($"Filas afectadas: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar operación: {query}");
                throw;
            }
        }

        public object? ExecuteScalar(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                _logger.Debug($"Ejecutando consulta escalar: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    object? result = command.ExecuteScalar();
                    _logger.Debug($"Resultado escalar: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar consulta escalar: {query}");
                throw;
            }
        }

        public NpgsqlParameter CreateParameter(string name, object value)
        {
            return new NpgsqlParameter(name, value ?? DBNull.Value);
        }

        private NpgsqlCommand CreateCommand(string query, NpgsqlParameter[] parameters)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
                foreach (var param in parameters)
                {
                    _logger.Trace($"Parámetro: {param.ParameterName} = {param.Value ?? "NULL"}");
                }
            }
            return command;
        }
    }
}
