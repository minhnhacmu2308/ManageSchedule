using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageSchedule.Models
{
    public class AdditionalTimekeeping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int type { get; set; }

        public int typeChild { get; set; }

        public TimeSpan start { get; set; }

        public TimeSpan end { get; set; }

        public DateTime date { get; set; }

        public string note { get; set; }

        public int status { get; set; }

        public virtual User User { get; set; }
    }
}