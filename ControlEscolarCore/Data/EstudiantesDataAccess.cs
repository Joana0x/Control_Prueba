using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Controller;
using ControlEscolarCore.Model;
using ControlEscolarCore.Utilities;
using NLog;
using Npgsql;

namespace ControlEscolarCore.Data
{
    class EstudiantesDataAccess
    {
        //Logger usando el LoggingManager
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.EstudianteDataAccess");

        private readonly PostgreSQLDataAccess _dbAccess = null;

        private readonly PersonasDataAccess _personasDataAccess;

        public EstudiantesDataAccess()
        {
            try
            {
                //Obtener instancia de PosgresSQLAccess atraves de su método GetInstance
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _personasDataAccess = new PersonasDataAccess();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al intentar crear instancia de EstudiantesDataAccess");
                throw;
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes(bool soloActivos = true, int tipoFecha = 0, DateTime? fechaInicio = null, DateTime? fechaFinal = null)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            try
            {
                string query = @"
                    SELECT e.id, e.matricula, e.semestre, e.fecha_alta, e.fecha_baja, e.estatus,
                        CASE
                            WHEN e.estatus = 0 THEN 'Baja'
                            WHEN e.estatus = 1 THEN 'Activo'
                            WHEN e.estatus = 2 THEN 'Baja temporal'
                            ELSE 'Desconocido'
                        END AS descestatus_estudiante,
                        e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, p.curp,
                        CASE 
                            WHEN p.estatus = TRUE THEN 'Activo'
                            ELSE 'Inactivo'
                        END AS estatus_persona
                    FROM escolar.estudiantes e
                    INNER JOIN seguridad.personas p ON e.id_persona = p.id
                    WHERE 1=1";

                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

                if (soloActivos)
                {
                    query += " AND e.estatus = 1";
                }

                if (fechaInicio != null && fechaFinal != null)
                {
                    switch (tipoFecha)
                    {
                        case 1:
                            query += " AND p.fecha_nacimiento BETWEEN @fechaInicio AND @fechaFinal";
                            break;
                        case 2:
                            query += " AND e.fecha_alta BETWEEN @fechaInicio AND @fechaFinal";
                            break;
                        case 3:
                            query += " AND e.fecha_baja BETWEEN @fechaInicio AND @fechaFinal";
                            break;
                    }
                    parameters.Add(_dbAccess.CreateParameter("@fechaInicio", fechaInicio.Value));
                    parameters.Add(_dbAccess.CreateParameter("@fechaFinal", fechaFinal.Value));
                }

                query += " ORDER BY e.id";

                _dbAccess.Connect();
                DataTable result = _dbAccess.ExecuteQuery_Reader(query, parameters.ToArray());

                foreach (DataRow row in result.Rows)
                {
                    Persona personas = new Persona(
                        Convert.ToInt32(row["id_persona"]),
                        row["nombre_completo"].ToString() ?? "",
                        row["correo"].ToString() ?? "",
                        row["telefono"].ToString() ?? "",
                        row["curp"].ToString() ?? "",
                        row["fecha_nacimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_nacimiento"]) : null,
                        row["estatus_persona"].ToString() == "Activo"
                    );

                    Estudiante estudiante = new Estudiante(
                        Convert.ToInt32(row["id"]),
                        Convert.ToInt32(row["id_persona"]),
                        row["matricula"].ToString() ?? "",
                        row["semestre"].ToString() ?? "",
                        Convert.ToDateTime(row["fecha_alta"]),
                        row["fecha_baja"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_baja"]) : null,
                        Convert.ToInt32(row["estatus"]),
                        row["descestatus_estudiante"].ToString() ?? "",
                        personas
                    );
                    estudiantes.Add(estudiante);
                }

                _logger.Debug($"Se obtuvieron {estudiantes.Count} registros de estudiantes");
                return estudiantes;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al intentar obtener la lista de estudiantes de la base de datos");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public int InsertarEstudiante(Estudiante estudiante)
        {
            try
            {
                // Primero insertamos la persona
                int idPersona = _personasDataAccess.InsertarPersona(estudiante.DatosPersonales);

                if (idPersona <= 0)
                {
                    _logger.Error($"No se pudo insertar la persona para el estudiante {estudiante.Matricula}");
                    return -1;
                }

                // Actualizar el IdPersona en el objeto estudiante
                estudiante.IdPersona = idPersona;

                // Luego insertamos el estudiante
                string query = @"
                    INSERT INTO escolar.estudiantes (id_persona, matricula, semestre, fecha_alta, estatus)
                    VALUES (@IdPersona, @Matricula, @Semestre, @FechaAlta, @Estatus)
                    RETURNING id";

                // Crea los parámetros
                NpgsqlParameter paramIdPersona = _dbAccess.CreateParameter("@IdPersona", estudiante.IdPersona);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramIdPersona, paramMatricula,
                                                           paramSemestre, paramFechaAlta, paramEstatus);

                // Convierte el resultado a entero
                int idestudiante_generado = Convert.ToInt32(resultado);
                _logger.Info($"Estudiante insertado correctamente con ID: {idestudiante_generado}");

                // Actualizar el Id en el objeto estudiante
                //estudiante.Id = idestudiante_generado;

                return idestudiante_generado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el estudiante con matrícula {estudiante.Matricula}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }


        /// <summary>
        /// Verifica si una matricula ya está registrada en la base de datos.
        /// </summary>
        /// <param name="matricula">Matricula a verificar</param>
        /// <returns>True si la matricula ya existe, false en caso contrario</returns>
        public bool ExisteMatricula(string matricula)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM escolar.estudiantes WHERE matricula = @Matricula";

                // Crea el parámetro
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", matricula);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                object? resultado = _dbAccess.ExecuteScalar(query, paramMatricula);

                int cantidad = Convert.ToInt32(resultado);
                bool existe = cantidad > 0;

                return existe;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia de la matricula {matricula}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un objeto Estudiante si se encuentra, null si no existe.
        /// </summary>
        public Estudiante? ObtenerEstudiantePorId(int id)
        {
            try
            {
                string query = @"
                SELECT e.id, e.matricula, e.semestre, e.fecha_alta, e.fecha_baja, e.estatus,
                       e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, 
                       p.curp, p.estatus as estatus_persona
                FROM escolar.estudiantes e
                INNER JOIN seguridad.personas p ON e.id_persona = p.id
                WHERE e.id = @Id";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", id);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta con el parámetro
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún estudiante con ID {id}");
                    return null;
                }

                // Obtiene la primera fila (debería ser la única)
                DataRow row = resultado.Rows[0];

                // Crear el objeto Persona
                Persona persona = new Persona(
                    Convert.ToInt32(row["id_persona"]),
                    row["nombre_completo"].ToString() ?? "",
                    row["correo"].ToString() ?? "",
                    row["telefono"].ToString() ?? "",
                    row["curp"].ToString() ?? "",
                    row["fecha_nacimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_nacimiento"]) : null,
                    Convert.ToBoolean(row["estatus_persona"])
                );

                // Crear el objeto Estudiante
                Estudiante estudiante = new Estudiante(
                    Convert.ToInt32(row["id"]),
                    Convert.ToInt32(row["id_persona"]),
                    row["matricula"].ToString() ?? "",
                    row["semestre"].ToString() ?? "",
                    Convert.ToDateTime(row["fecha_alta"]),
                    row["fecha_baja"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_baja"]) : null,
                    Convert.ToInt32(row["estatus"]),
                    row["estatus"].ToString() ?? "Desconocido",
                    persona
                );

                return estudiante;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el estudiante con ID {id}");
                return null;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                _logger.Debug($"Actualizando estudiante con ID {estudiante.Id} y persona con ID {estudiante.IdPersona}");

                // Primero actualizamos los datos de la persona
                bool actualizacionPersonaExitosa = _personasDataAccess.ActualizarPersona(estudiante.DatosPersonales);

                if (!actualizacionPersonaExitosa)
                {
                    _logger.Warn($"No se pudo actualizar la persona con ID {estudiante.IdPersona}");
                    return false;
                }

                // Luego actualizamos los datos del estudiante
                string queryEstudiante = @"
                    UPDATE estudiantes
                    SET matricula = @Matricula,
                        semestre = @Semestre,
                        fecha_alta = @FechaAlta,
                        estatus = @Estatus,
                        fecha_baja = @FechaBaja
                    WHERE id = @IdEstudiante";

                // Establecemos la conexión a la BD
                _dbAccess.Connect();

                // Creamos los parámetros para la actualización del estudiante
                NpgsqlParameter paramIdEstudiante = _dbAccess.CreateParameter("@IdEstudiante", estudiante.Id);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);
                NpgsqlParameter paramFechaBaja = _dbAccess.CreateParameter("@FechaBaja", estudiante.FechaBaja.HasValue ? (object)estudiante.FechaBaja.Value : DBNull.Value);

                // Ejecutamos la actualización del estudiante
                int filasAfectadasEstudiante = _dbAccess.ExecuteNonQuery(queryEstudiante,
                    paramIdEstudiante, paramMatricula, paramSemestre,
                    paramFechaAlta, paramEstatus, paramFechaBaja);

                bool exito = filasAfectadasEstudiante > 0;

                if (!exito)
                {
                    _logger.Warn($"No se pudo actualizar el estudiante con ID {estudiante.Id}. No se encontró el registro");
                }
                else
                {
                    _logger.Debug($"Estudiante con ID {estudiante.Id} actualizado correctamente");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el estudiante con ID {estudiante.Id}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

    }
}