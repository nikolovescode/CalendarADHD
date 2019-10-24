using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalendarADHD.Models
{
    public class CalendarADHDDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CalendarADHDDbContext() : base("name=CalendarADHDDbContext")
        {
        }


        public System.Data.Entity.DbSet<CalendarADHD.Models.Workshift> Workshifts { get; set; }

        public System.Data.Entity.DbSet<CalendarADHD.Models.WorkTask> WorkTasks { get; set; }

        public System.Data.Entity.DbSet<CalendarADHD.Models.PlannedWorkshift> PlannedWorkshifts { get; set; }

        public System.Data.Entity.DbSet<CalendarADHD.Models.WorkNote> WorkNotes { get; set; }

        public System.Data.Entity.DbSet<CalendarADHD.Models.SettingsPause> SettingsPauses { get; set; }
    }
}
