using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarADHD.Models
{
    public class SettingsPause
    {
        public int Id { get; set; }
        public int MinPauseBeforeActivity { get; set; }
        public string CalendarUserEmail { get; set; }
    }
}