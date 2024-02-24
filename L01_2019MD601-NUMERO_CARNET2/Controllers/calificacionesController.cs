using L01_2019MD601_NUMERO_CARNET2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace L01_2019MD601_NUMERO_CARNET2.Propierties
{
    [Route("api/[controller]")]
    [ApiController]
    public class calificacionesController : ControllerBase
    {

        private readonly calificacionesContext _calificacionesContexto;

        public calificacionesController(calificacionesContext calificacionesContexto)
        {
            _calificacionesContexto = calificacionesContexto;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {

            List<calificaciones> listadocalificaciones = (from e in _calificacionesContexto.calificaciones select e).ToList();

            if (listadocalificaciones.Count() == 0)
            {

                return NotFound();

            }
            return Ok(listadocalificaciones);

        }

        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult GetPublicacion(int id)
        {
            calificaciones? calificacion = _calificacionesContexto.calificaciones.FirstOrDefault(e => e.publicacionId == id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return Ok(calificacion);
        }


        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarCalificaciones([FromBody] calificaciones calificacion)
        {
            try
            {

                _calificacionesContexto.calificaciones.Add(calificacion);
                _calificacionesContexto.SaveChanges();
                return Ok(calificacion);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }

        [HttpPut]
        [Route("Actualizar/{id}")]

        public IActionResult ActualizarCalificaciones(int id, [FromBody] calificaciones calificacionModificar)
        {
            // Para alterar un registro, se obtiene el registro actual de la base de datos al cual alteraremos una propiedad

            calificaciones? calificacionesActual = _calificacionesContexto.calificaciones.FirstOrDefault(e => e.calificacionId == id);

            // verificamos que exista el registro segun su id
            if (calificacionesActual == null)
            {
                return NotFound();
            }

            // si se encuentra el registro se alteraran los campos modificables
            calificacionesActual.publicacionId = calificacionModificar.publicacionId;
            calificacionesActual.usuarioId = calificacionModificar.usuarioId;
            calificacionesActual.calificacion = calificacionModificar.calificacion;
          
            
            // se marca el registro como modificado en el contexto y se envia la modificacion a la bd
            _calificacionesContexto.Entry(calificacionModificar).State = EntityState.Modified;
            _calificacionesContexto.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarEquipo(int id)
        {
            //para actualizar un registro se obtiene el registro original de la base de datos al cual eliminaremos

            calificaciones? calificacion = _calificacionesContexto.calificaciones.FirstOrDefault(e => e.calificacionId == id);

            //Verificamos que existe el registro segun su id

            if (calificacion == null)
            {
                return NotFound();
            }

            //ejecutamos la accion de eliminar el registro
            _calificacionesContexto.calificaciones.Attach(calificacion);
            _calificacionesContexto.calificaciones.Remove(calificacion);
            _calificacionesContexto.SaveChanges();
            return Ok(calificacion);
        }

    }
}
