using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CalendarADHD.Models;

namespace CalendarADHD.Controllers
{
    public class WorkshiftsController : ApiController
    {
        private CalendarADHDDbContext db = new CalendarADHDDbContext();

        // GET: api/Workshifts
        public IQueryable<Workshift> GetWorkshifts()
        {
            return db.Workshifts;
        }
        public IEnumerable<Workshift> Get(string calendarUserEmail)
        {
            var workshifts = db.Workshifts.Where(Workshift => Workshift.CalendarUserEmail.Equals(calendarUserEmail));
            return workshifts;
        }
        public IEnumerable<Workshift> GetWorkshiftOfTask(string titleWorkTask)
        {
            var workshifts = db.Workshifts.Where(Workshift => Workshift.TitleWorkTask.Equals(titleWorkTask));
            return workshifts;
        }
        public IEnumerable<Workshift> Get(string calendarUserEmail, string titleWorkTask)
        {
            var workshifts = db.Workshifts.Where(Workshift => Workshift.CalendarUserEmail.Equals(calendarUserEmail) && Workshift.TitleWorkTask.Equals(titleWorkTask));
            return workshifts;
        }

        public int GetAvgWorkshiftTimeOfIdWorkTask(int idWorkTask)
        {
            int workshifts = (int)db.Workshifts.Where(Workshift => Workshift.IdWorkTask.Equals(idWorkTask)).Select(Workshift => Workshift.MinutesWorking).Average();

            return workshifts;
        }

        public int GetAvgWorkshiftTimeOfCalendarUserEmailIdWorkTask(string calendarUserEmail, int idWorkTask)
        {
            int workshifts = (int) db.Workshifts.Where(Workshift => Workshift.CalendarUserEmail.Equals(calendarUserEmail)&&Workshift.IdWorkTask.Equals(idWorkTask)).Select(Workshift => Workshift.MinutesWorking).Average();
            
            return workshifts;
        }
        

        // GET: api/Workshifts/5
        [ResponseType(typeof(Workshift))]
        public async Task<IHttpActionResult> GetWorkshift(int id)
        {
            Workshift workshift = await db.Workshifts.FindAsync(id);
            if (workshift == null)
            {
                return NotFound();
            }

            return Ok(workshift);
        }

        // PUT: api/Workshifts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkshift(int id, Workshift workshift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workshift.Id)
            {
                return BadRequest();
            }

            db.Entry(workshift).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshiftExists(id))
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

        // POST: api/Workshifts
        [ResponseType(typeof(Workshift))]
        public async Task<IHttpActionResult> PostWorkshift(Workshift workshift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workshifts.Add(workshift);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = workshift.Id }, workshift);
        }

        // DELETE: api/Workshifts/5
        [ResponseType(typeof(Workshift))]
        public async Task<IHttpActionResult> DeleteWorkshift(int id)
        {
            Workshift workshift = await db.Workshifts.FindAsync(id);
            if (workshift == null)
            {
                return NotFound();
            }

            db.Workshifts.Remove(workshift);
            await db.SaveChangesAsync();

            return Ok(workshift);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkshiftExists(int id)
        {
            return db.Workshifts.Count(e => e.Id == id) > 0;
        }
    }
}