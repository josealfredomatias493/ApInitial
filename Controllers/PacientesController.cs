using ApInitial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : Controller
    {
        private readonly CITASMEDICASContext _Context;
        public PacientesController(CITASMEDICASContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pacientes>> GetPacientes()
        {
            try
            {
                return _Context.Pacientes.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Pacientes> GetPacientesByID(int id)
        {
            try
            {
                var Pac = _Context.Pacientes.Find(id);
                if (Pac == null)
                {
                    return NotFound();
                }
                return Pac;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<Pacientes> PostPacientes(Pacientes pacientes)
        {
            try
            {
                _Context.Pacientes.Add(pacientes);
                _Context.SaveChanges();
                return CreatedAtAction(nameof(GetPacientesByID), new { id = pacientes.PacCodigo }, pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult PacientesUpdate(int id, Pacientes pacientes)
        {
            try
            {
                if (id != pacientes.PacCodigo)
                {
                    return BadRequest();
                }
                _Context.Entry(pacientes).State = EntityState.Modified;
                _Context.SaveChanges();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult PacientesDelete(int id)
        {
            try
            {
                var Pac = _Context.Pacientes.Find(id);
                if (Pac == null)
                {
                    return NotFound();
                }
                _Context.Pacientes.Remove(Pac);
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

