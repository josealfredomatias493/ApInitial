using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApInitial.Models;
using System.Runtime.InteropServices;

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
        public ActionResult<IEnumerable<Citas>> GetCitas(string A, [Optional] int id)
        {
            try
            { 
                
                if(id!=0){
                    var variable = (from d in _Context.Citas.Include(x => x.Doctores).Include(x => x.Pacientes) where d.CtEstatus == A && (d.PacCodigo==id || d.DocCodigo==id) select d).OrderBy(x=> x.CtHorarioInicial).ToList();
                    return variable;
                }
                else
                {
                    var variable = (from d in _Context.Citas.Include(x => x.Doctores).Include(x => x.Pacientes) where d.CtEstatus == A select d).OrderBy(x => x.CtHorarioInicial).ToList();
                    return variable;
                }
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
                var horarioFinal= new DateTime(citas.CtHorarioInicial.Year,citas.CtHorarioFinal.Month,citas.CtHorarioInicial.Day,citas.CtHorarioFinal.Hour,citas.CtHorarioFinal.Minute,citas.CtHorarioFinal.Second);
                citas.CtHorarioFinal = horarioFinal;
                if (citas.CtHorarioFinal < citas.CtHorarioInicial)
                {
                    citas.CtEstatus = "X";
                    return citas;
                }
                var horario = (from d in _Context.Citas where d.DocCodigo == citas.DocCodigo && d.CtEstatus=="A" select d);
                foreach(var d in horario)
                {
                    if(citas.CtHorarioInicial > d.CtHorarioInicial && citas.CtHorarioInicial < d.CtHorarioFinal)
                    {
                        citas.CtEstatus = "Z";
                        break;
                    }
                    else if (citas.CtHorarioFinal > d.CtHorarioInicial && citas.CtHorarioFinal < d.CtHorarioFinal)
                    {
                        citas.CtEstatus = "Z";
                        break;
                    }
                    else
                    {
                        citas.CtEstatus = "A";
                    }
                }
                if (citas.CtEstatus == "Z")
                {
                    return citas;
                }
                else
                {
                    _Context.Citas.Add(citas);
                    _Context.SaveChanges();
                    return CreatedAtAction(nameof(GetCitasByID), new { id = citas.CtCodigo }, citas);
                }
                
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
                if (id != citas.CtCodigo)
                {
                    return BadRequest();
                }
                else if (citas.CtEstatus == "D")
                {
                    citas.CtEstatus = "A";
                    _Context.Entry(citas).State = EntityState.Modified;
                    _Context.SaveChanges();
                    return Ok(citas);
                }
                var horarioFinal = new DateTime(citas.CtHorarioInicial.Year, citas.CtHorarioFinal.Month, citas.CtHorarioInicial.Day, citas.CtHorarioFinal.Hour, citas.CtHorarioFinal.Minute, citas.CtHorarioFinal.Second);
                citas.CtHorarioFinal = horarioFinal;
                if (citas.CtHorarioFinal < citas.CtHorarioInicial)
                {
                    return BadRequest();
                }
                var horario = (from d in _Context.Citas where d.DocCodigo == citas.DocCodigo && d.CtEstatus == "A" select d).AsNoTracking();
                foreach (var d in horario)
                {
                    if (citas.CtHorarioInicial > d.CtHorarioInicial && citas.CtHorarioInicial < d.CtHorarioFinal)
                    {
                        citas.CtEstatus = "Z";
                        break;
                    }
                    else if (citas.CtHorarioFinal > d.CtHorarioInicial && citas.CtHorarioFinal < d.CtHorarioFinal)
                    {
                        citas.CtEstatus = "Z";
                        break;
                    }
                    else
                    {
                        citas.CtEstatus = "A";
                    }
                }
                if (citas.CtEstatus == "Z")
                {
                    return BadRequest();
                }
                else
                {
                    _Context.Entry(citas).State = EntityState.Modified;
                    _Context.SaveChanges();
                    return Ok(citas);
                }
                
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
