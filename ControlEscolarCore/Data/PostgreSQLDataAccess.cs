﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;
using Microsoft.Extensions.Configuration;
using NLog;
using Npgsql;

namespace ControlEscolarCore.Data
{
    /// <summary>
    /// Clase que maneje el acceso a datos PostgresSQL, incluyendo conexiones
    /// </summary>
    public class PostgreSQLDataAccess
    {
        //Logger usando el logginManeger
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.PostgreSQLDataAccess");

        //Cadena de conexión desde App.config
        private readonly string _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;


        private NpgsqlConnection _connection;
        private static PostgreSQLDataAccess? _instance;

        private PostgreSQLDataAccess ()
        {
            try
            {
                _connection = new NpgsqlConnection(_ConnectionString);
                _logger.Info("Instancia de cceso a datos creada correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar el acceso a la base de datos");

                throw;
            }
        }

        public static PostgreSQLDataAccess GetInstance ()
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

                // NUEVA LÍNEA: lanza excepción para que el sistema lo capture y no siga mal
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
            DataTable dataTable= new DataTable();
            try
            {
                _logger.Debug($"Ejecutando consulta: {query}"); 
                using(NpgsqlCommand command = CreateCommand(query, parameters))
                {
                   
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        _logger.Debug($"Consulta ejecutada correctamente: {query}");
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar una consulta en la base de datos:{query} ");
                throw;
            }
        }

        //prepra con los parametros
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

        public int ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                _logger.Debug($"Ejecutando operación: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    int result = command.ExecuteNonQuery();
                    _logger.Debug($"Operación ejecutada exitosamente. Filas afectadas: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la operación: {query}");
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
                    _logger.Debug($"Consulta escalar ejecutada correctamente. ID afectado: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar una consulta escalar en la base de datos: {query}");
                throw;
            }
        }

        public NpgsqlParameter CreateParameter(string name, object value)
        {
            //?? es como un if enfocado a nulos
            return new NpgsqlParameter(name, value ?? DBNull.Value);
        }

    }
}
