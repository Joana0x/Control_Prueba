﻿using Microsoft.AspNetCore.Mvc;
using ControlEscolarCore.Controller;


namespace ControlEstudiantesAPI
{
    [ApiController]
    [Route("api/[controller]")]
    //comentario para appi
    public class EstudiantesControllerAPI : ControllerBase
    {
        private readonly EstudiantesController _estudiantesController;
        private readonly ILogger<EstudiantesControllerAPI> _logger;


        public EstudiantesControllerAPI(EstudiantesController estudiantesController, ILogger<EstudiantesControllerAPI> logger)
        {
            _estudiantesController = estudiantesController;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los estudiantes con filtros opcionales
        /// </summary>
        /// <param name="soloActivos">Filtrar solo estudiantes activos</param>
        /// <param name="tipoFecha">1=Fecha nacimiento, 2=Fecha alta, 3=Fecha baja</param>
        /// <param name="fechaInicio">Fecha inicial del rango</param>
        /// <param name="fechaFin">Fecha final del rango</param>
        /// <returns>Lista de estudiantes</returns>
        [HttpGet("listado")]  // Ahora tiene una ruta específica
        
        public IActionResult GetEstudiantes(
    [FromQuery] bool soloActivos = true,
    [FromQuery] int tipoFecha = 0,
    [FromQuery] DateTime? fechaInicio = null,
    [FromQuery] DateTime? fechaFin = null)
        {
            try
            {
                var estudiantes = _estudiantesController.ObtnerTodosLosEstudiantes(
                    soloActivos,
                    tipoFecha,
                    fechaInicio,
                    fechaFin);

                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                // Log detallado + mensaje claro para Postman
                _logger.LogError(ex, $"Error al obtener estudiantes: {ex.Message}");
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


    }
}