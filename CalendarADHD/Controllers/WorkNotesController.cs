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
    public class WorkNotesController : ApiController
    {
        private CalendarADHDDbContext db = new CalendarADHDDbContext();

        // GET: api/WorkNotes
        public IQueryable<WorkNote> GetWorkNotes()
        {
            return db.WorkNotes;
        }

        public IEnumerable<WorkNote> Get(string titleWorkTask, string calendarUserEmail)
        {
            var workNotes = db.WorkNotes.Where(WorkNote => WorkNote.TitleWorkTask.Equals(titleWorkTask)&&WorkNote.CalendarUserEmail.Equals(calendarUserEmail));
            return workNotes;
        }
        // GET: api/WorkNotes/5
        [ResponseType(typeof(WorkNote))]
        public async Task<IHttpActionResult> GetWorkNote(int id)
        {
            WorkNote workNote = await db.WorkNotes.FindAsync(id);
            if (workNote == null)
            {
                return NotFound();
            }

            return Ok(workNote);
        }

        // PUT: api/WorkNotes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkNote(int id, WorkNote workNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workNote.Id)
            {
                return BadRequest();
            }

            db.Entry(workNote).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkNoteExists(id))
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

        // POST: api/WorkNotes
        [ResponseType(typeof(WorkNote))]
        public async Task<IHttpActionResult> PostWorkNote(WorkNote workNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkNotes.Add(workNote);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = workNote.Id }, workNote);
        }

        // DELETE: api/WorkNotes/5
        [ResponseType(typeof(WorkNote))]
        public async Task<IHttpActionResult> DeleteWorkNote(int id)
        {
            WorkNote workNote = await db.WorkNotes.FindAsync(id);
            if (workNote == null)
            {
                return NotFound();
            }

            db.WorkNotes.Remove(workNote);
            await db.SaveChangesAsync();

            return Ok(workNote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkNoteExists(int id)
        {
            return db.WorkNotes.Count(e => e.Id == id) > 0;
        }
    }
}