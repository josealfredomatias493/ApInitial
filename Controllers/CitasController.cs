using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApInitial.Models;
using Microsoft.EntityFrameworkCore;

namespace ApInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly CITASMEDICASContext _Context;

        public CitasController(CITASMEDICASContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Citas>> GetCitas(string A)
        {
            try
            {
                //Agregar Include para traer datos de doctores (JOIN)
                var variable = (from d in _Context.Citas.Include(x=> x.Doctores) where d.CtEstatus == A select d).ToList();
                return variable;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Citas> GetCitasByID(int id)
        {
            try
            {
                var Ct = _Context.Citas.Find(id);
                if (Ct == null)
                {
                    return NotFound();
                }
                return Ct;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Citas> PostCitas(Citas citas)
        {
            try
            {
                _Context.Citas.Add(citas);
                _Context.SaveChanges();
                return CreatedAtAction(nameof(GetCitasByID), new { id = citas.CtCodigo }, citas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult CitasUpdate(int id, Citas citas)
        {
            try
            {
                citas.CtEstatus = "A";
                if (id != citas.CtCodigo)
                {
                    return BadRequest();
                }
                _Context.Entry(citas).State = EntityState.Modified;
                _Context.SaveChanges();
                return Ok(citas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult CitasPacientes(int id)
        {
            try
            {
                var Date = _Context.Citas.Find(id);
                if (Date == null)
                {
                    return NotFound();
                }
                else
                {
                    var variable = (from d in _Context.Citas where d.CtCodigo == id select d);
                    foreach (var d in variable)
                    {
                        d.CtEstatus = "D";
                    }
                    _Context.SaveChanges();
                }
                return Ok(Date);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
