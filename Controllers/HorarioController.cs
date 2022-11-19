using ApInitial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : Controller
    {
        private readonly CITASMEDICASContext _Context;
        public HorarioController(CITASMEDICASContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Horario>> GetHorarios()
        {
            try
            {
                return _Context.Horarios.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Horario> GetHorariosByID(int id)
        {
            try
            {
                var Doc = _Context.Horarios.Find(id);
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
        public ActionResult<Horario> PostHorarios(Horario horario)
        {
            try
            {
                _Context.Horarios.Add(horario);
                _Context.SaveChanges();
                return CreatedAtAction(nameof(GetHorariosByID), new { id = horario.HrCodigo }, horario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult HorariosUpdate(int id, Horario horario)
        {
            try
            {
                if (id != horario.HrCodigo)
                {
                    return BadRequest();
                }
                _Context.Entry(horario).State = EntityState.Modified;
                _Context.SaveChanges();
                return Ok(horario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteHorarios(int id)
        {
            try
            {
                var ht = _Context.Horarios.Find(id);
                if (ht == null)
                {
                    return NotFound();
                }
                _Context.Horarios.Remove(ht);
                _Context.SaveChanges();
                return Ok(ht);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
