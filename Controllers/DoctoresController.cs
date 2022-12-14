using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApInitial.Models;

namespace ApInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private readonly CITASMEDICASContext _Context;

        public DoctoresController(CITASMEDICASContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Doctores>> GetDoctores(string A)
        {
            try
            {
                var variable = (from d in _Context.Doctores where d.DocEstatus == A select d).ToList();
                return variable;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Doctores> GetDoctoresByID(int id)
        {
            try
            {
                var Doc = _Context.Doctores.Find(id);
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
        public ActionResult<Doctores> PostDoctores(Doctores doctores)
        {
            try
            {
                _Context.Doctores.Add(doctores);
                _Context.SaveChanges();
                return CreatedAtAction(nameof(GetDoctoresByID), new { id = doctores.DocCodigo }, doctores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult DoctoresUpdate(int id, Doctores doctores)
        {
            try
            {
                doctores.DocEstatus = "A";
                if (id != doctores.DocCodigo)
                {
                    return BadRequest();
                }
                _Context.Entry(doctores).State = EntityState.Modified;
                _Context.SaveChanges();
                return Ok(doctores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePacientes(int id)
        {
            try
            {
                var Doc = _Context.Doctores.Find(id);
                if (Doc == null)
                {
                    return NotFound();
                }
                else
                {
                    var variable = (from d in _Context.Doctores where d.DocCodigo == id select d);
                    foreach (var d in variable)
                    {
                        d.DocEstatus = "D";
                    }
                    _Context.SaveChanges();
                }
                return Ok(Doc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
