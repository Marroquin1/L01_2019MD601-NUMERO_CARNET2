using L01_2019MD601_NUMERO_CARNET2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace L01_2019MD601_NUMERO_CARNET2.Propierties
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {

        private readonly usuariosContext _usuariosContexto;

        public usuariosController(usuariosContext usuariosContexto)
        {
            _usuariosContexto = usuariosContexto;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {

            List<usuarios> listadoUsuarios = (from e in _usuariosContexto.usuarios select e).ToList();

            if (listadoUsuarios.Count() == 0)
            {

                return NotFound();

            }
            return Ok(listadoUsuarios);

        }

        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            usuarios? usuario = _usuariosContexto.usuarios.FirstOrDefault(e => e.usuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet]
        [Route("Find/{filtro1}/{filtro2}")]

        public IActionResult FindbyNombreApellido(string filtro1, string filtro2)
        {
            usuarios? usuario = _usuariosContexto.usuarios
                              .FirstOrDefault(e => e.nombre.Contains(filtro1) && e.apellido.Contains(filtro2));

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        public IActionResult FindbyRol(int idrol)
        {
            usuarios? usuario = _usuariosContexto.usuarios.FirstOrDefault(e => e.rolId == idrol);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarUsuario([FromBody] usuarios usuario)
        {
            try
            {

                _usuariosContexto.usuarios.Add(usuario);
                _usuariosContexto.SaveChanges();
                return Ok(usuario);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }

        [HttpPut]
        [Route("Actualizar/{id}")]

        public IActionResult ActualizarUsuarios(int id, [FromBody] usuarios usuarioModificar)
        {
            // Para alterar un registro, se obtiene el registro actual de la base de datos al cual alteraremos una propiedad

            usuarios? usuarioActual = _usuariosContexto.usuarios.FirstOrDefault(e => e.usuarioId == id);

            // verificamos que exista el registro segun su id
            if (usuarioActual == null)
            {
                return NotFound();
            }

            // si se encuentra el registro se alteraran los campos modificables
            usuarioActual.rolId = usuarioModificar.rolId;
            usuarioActual.nombreUsuario = usuarioModificar.nombreUsuario;
            usuarioActual.clave = usuarioModificar.clave;
            usuarioActual.nombre = usuarioModificar.nombre;
            usuarioActual.apellido = usuarioModificar.apellido;

            // se marca el registro como modificado en el contexto y se envia la modificacion a la bd
            _usuariosContexto.Entry(usuarioActual).State = EntityState.Modified;
            _usuariosContexto.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarUsuario(int id)
        {
            //para actualizar un registro se obtiene el registro original de la base de datos al cual eliminaremos

            usuarios? usuario = _usuariosContexto.usuarios.FirstOrDefault(e => e.usuarioId == id);

            //Verificamos que existe el registro segun su id

            if (usuario == null)
            {
                return NotFound();
            }

            //ejecutamos la accion de eliminar el registro
            _usuariosContexto.usuarios.Attach(usuario);
            _usuariosContexto.usuarios.Remove(usuario);
            _usuariosContexto.SaveChanges();
            return Ok(usuario);
        }


    }
}
