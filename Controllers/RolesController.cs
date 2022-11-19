using ApInitial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly CITASMEDICASContext _Context;
        public RolesController(CITASMEDICASContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Roles>> GetRoles()
        {
            try
            {
                return _Context.Roles.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Roles> GetRolesByID(int id)
        {
            try
            {
                var Doc = _Context.Roles.Find(id);
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
        public ActionResult<Roles> PostRoles(Roles roles)
        {
            try
            {
                _Context.Roles.Add(roles);
                _Context.SaveChanges();
                return CreatedAtAction(nameof(GetRolesByID), new { id = roles.RlCodigo }, roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult RolesUpdate(int id, Roles roles)
        {
            try
            {
                if (id != roles.RlCodigo)
                {
                    return BadRequest();
                }
                _Context.Entry(roles).State = EntityState.Modified;
                _Context.SaveChanges();
                return Ok(roles);
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
                var Doc = _Context.Roles.Find(id);
                if (Doc == null)
                {
                    return NotFound();
                }
                _Context.Roles.Remove(Doc);
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
