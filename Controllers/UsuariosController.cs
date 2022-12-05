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
        public ActionResult<IEnumerable<Usuarios>> GetUsuarios(string A)
        {
            try
            {
                var variable = (from d in _Context.Usuarios where d.UserEstatus==A select d).ToList();
                return variable;
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
                usuarios.UserFechaCreacion= DateTime.Now.ToString("f");
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
                usuarios.UserEstatus="A";
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
                var User = _Context.Usuarios.Find(id);
                if (User == null)
                {
                    return NotFound();
                }
                else
                {
                    var variable = (from d in _Context.Usuarios where d.UserCodigo == id select d);
                    foreach (var d in variable)
                    {
                        d.UserEstatus = "D";
                    }
                    _Context.SaveChanges();
                }
                return Ok(User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
