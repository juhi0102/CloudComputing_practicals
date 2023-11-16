using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using practical_WebApplication6.Models;

namespace practical_WebApplication6.Controllers
{
    public class EmplController : ApiController
    {
        private empldbEntities db = new empldbEntities();

        // GET: api/Empl
        public IQueryable<Empl> GetEmpls()
        {
            return db.Empls;
        }

        // GET: api/Empl/5
        [ResponseType(typeof(Empl))]
        public IHttpActionResult GetEmpl(int id)
        {
            Empl empl = db.Empls.Find(id);
            if (empl == null)
            {
                return NotFound();
            }

            return Ok(empl);
        }

        // PUT: api/Empl/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpl(int id, Empl empl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empl.Id)
            {
                return BadRequest();
            }

            db.Entry(empl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmplExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empl
        [ResponseType(typeof(Empl))]
        public IHttpActionResult PostEmpl(Empl empl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empls.Add(empl);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmplExists(empl.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = empl.Id }, empl);
        }

        // DELETE: api/Empl/5
        [ResponseType(typeof(Empl))]
        public IHttpActionResult DeleteEmpl(int id)
        {
            Empl empl = db.Empls.Find(id);
            if (empl == null)
            {
                return NotFound();
            }

            db.Empls.Remove(empl);
            db.SaveChanges();

            return Ok(empl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmplExists(int id)
        {
            return db.Empls.Count(e => e.Id == id) > 0;
        }
    }
}