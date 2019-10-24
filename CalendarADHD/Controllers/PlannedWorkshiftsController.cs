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
    public class PlannedWorkshiftsController : ApiController
    {
        private CalendarADHDDbContext db = new CalendarADHDDbContext();

        // GET: api/PlannedWorkshifts
        public IQueryable<PlannedWorkshift> GetPlannedWorkshifts()
        {
            return db.PlannedWorkshifts;
        }

        // GET: api/PlannedWorkshifts/5
        [ResponseType(typeof(PlannedWorkshift))]
        public async Task<IHttpActionResult> GetPlannedWorkshift(int id)
        {
            PlannedWorkshift plannedWorkshift = await db.PlannedWorkshifts.FindAsync(id);
            if (plannedWorkshift == null)
            {
                return NotFound();
            }

            return Ok(plannedWorkshift);
        }

        public IEnumerable<PlannedWorkshift> Get(DateTime date, string calendarUserEmail)
        {
            var shifts = db.PlannedWorkshifts.Where(PlannedWorkshift => PlannedWorkshift.Year.Equals(date.Year) && PlannedWorkshift.Month.Equals(date.Month) && PlannedWorkshift.Day.Equals(date.Day) && PlannedWorkshift.CalendarUserEmail.Equals(calendarUserEmail));
            return shifts;
        }

        //Hämta dagens arbetspass beroende på om de är klara eller ej klara
        public IEnumerable<PlannedWorkshift> Get(DateTime date, string calendarUserEmail, bool done)
        {
            var shifts = db.PlannedWorkshifts.Where(PlannedWorkshift => PlannedWorkshift.Year.Equals(date.Year) && PlannedWorkshift.Month.Equals(date.Month) && PlannedWorkshift.Day.Equals(date.Day) && PlannedWorkshift.CalendarUserEmail.Equals(calendarUserEmail) && PlannedWorkshift.Done.Equals(false));
            return shifts;
        }

        // PUT: api/PlannedWorkshifts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlannedWorkshift(int id, PlannedWorkshift plannedWorkshift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plannedWorkshift.Id)
            {
                return BadRequest();
            }

            db.Entry(plannedWorkshift).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlannedWorkshiftExists(id))
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

        // POST: api/PlannedWorkshifts
        [ResponseType(typeof(PlannedWorkshift))]
        public async Task<IHttpActionResult> PostPlannedWorkshift(PlannedWorkshift plannedWorkshift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlannedWorkshifts.Add(plannedWorkshift);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = plannedWorkshift.Id }, plannedWorkshift);
        }

        // DELETE: api/PlannedWorkshifts/5
        [ResponseType(typeof(PlannedWorkshift))]
        public async Task<IHttpActionResult> DeletePlannedWorkshift(int id)
        {
            PlannedWorkshift plannedWorkshift = await db.PlannedWorkshifts.FindAsync(id);
            if (plannedWorkshift == null)
            {
                return NotFound();
            }

            db.PlannedWorkshifts.Remove(plannedWorkshift);
            await db.SaveChangesAsync();

            return Ok(plannedWorkshift);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlannedWorkshiftExists(int id)
        {
            return db.PlannedWorkshifts.Count(e => e.Id == id) > 0;
        }
    }
}