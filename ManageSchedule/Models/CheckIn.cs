using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageSchedule.Models
{
    public class CheckIn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public TimeSpan checkIn { get; set; }

        public TimeSpan checkOut { get; set; }

        public DateTime date { get; set; }

        public int status { get; set; }

        public virtual User User { get; set; }
    }
}