using ApInitial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly CITASMEDICASContext _Context;
        public UsuarioController(CITASMEDICASContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> GetUsuarios()
        {
            try
            {
                return _Context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Usuarios> GetUsuariosByID(int id)
        {
            try
            {
                var Doc = _Context.Usuarios.Find(id);
                if (Doc == null)
                {
                    return NotFound();
                }
                return Doc;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<Usuarios> PostUsuarios(Usuarios usuarios)
        {
            try
            {
                _Context.Usuarios.Add(usuarios);
                _Context.SaveChanges();
                return CreatedAtAction(nameof(GetUsuariosByID), new { id = usuarios.UserCodigo }, usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UsuariosUpdate(int id, Usuarios usuarios)
        {
            try
            {
                if (id != usuarios.UserCodigo)
                {
                    return BadRequest();
                }
                _Context.Entry(usuarios).State = EntityState.Modified;
                _Context.SaveChanges();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteRoles(int id)
        {
            try
            {
                var Doc = _Context.Usuarios.Find(id);
                if (Doc == null)
                {
                    return NotFound();
                }
                _Context.Usuarios.Remove(Doc);
                _Context.SaveChanges();
                return Ok("Registro Cancelado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
