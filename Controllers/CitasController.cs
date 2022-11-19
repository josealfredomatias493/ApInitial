using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApInitial.Models;
using Microsoft.Build.Framework;

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
        public ActionResult<IEnumerable<Citas>> GetCitas()
        {
            try
            {
                return _Context.Citas.ToList();
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
                var Ct = _Context.Citas.Find(id);
                if (Ct == null)
                {
                    return NotFound();
                }
                _Context.Citas.Remove(Ct);
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
