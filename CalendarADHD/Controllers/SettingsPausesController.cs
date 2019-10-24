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
    public class SettingsPausesController : ApiController
    {
        private CalendarADHDDbContext db = new CalendarADHDDbContext();

        // GET: api/SettingsPauses
        public IQueryable<SettingsPause> GetSettingsPauses()
        {
            return db.SettingsPauses;
        }

        public IEnumerable<SettingsPause> Get(string calendarUserEmail)
        {
            var pauses = db.SettingsPauses.Where(SettingsPause => SettingsPause.CalendarUserEmail.Equals(calendarUserEmail));
            return pauses;
        }

        // GET: api/SettingsPauses/5
        [ResponseType(typeof(SettingsPause))]
        public async Task<IHttpActionResult> GetSettingsPause(int id)
        {
            SettingsPause settingsPause = await db.SettingsPauses.FindAsync(id);
            if (settingsPause == null)
            {
                return NotFound();
            }

            return Ok(settingsPause);
        }

        // PUT: api/SettingsPauses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSettingsPause(int id, SettingsPause settingsPause)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != settingsPause.Id)
            {
                return BadRequest();
            }

            db.Entry(settingsPause).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingsPauseExists(id))
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

        // POST: api/SettingsPauses
        [ResponseType(typeof(SettingsPause))]
        public async Task<IHttpActionResult> PostSettingsPause(SettingsPause settingsPause)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SettingsPauses.Add(settingsPause);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = settingsPause.Id }, settingsPause);
        }

        // DELETE: api/SettingsPauses/5
        [ResponseType(typeof(SettingsPause))]
        public async Task<IHttpActionResult> DeleteSettingsPause(int id)
        {
            SettingsPause settingsPause = await db.SettingsPauses.FindAsync(id);
            if (settingsPause == null)
            {
                return NotFound();
            }

            db.SettingsPauses.Remove(settingsPause);
            await db.SaveChangesAsync();

            return Ok(settingsPause);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SettingsPauseExists(int id)
        {
            return db.SettingsPauses.Count(e => e.Id == id) > 0;
        }
    }
}