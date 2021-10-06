using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ManageSchedule.Models
{
    public class ScheduleWork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        [Required]
        public string title { get; set; }

        public TimeSpan start { get; set; }

        public TimeSpan endTime { get; set; }

        public DateTime date { get; set; }

        [StringLength(255)]
        [Required]
        public string purpose { get; set; }

        public virtual Merchant Merchant { get; set; }

       
        [StringLength(500)]
        [Required]
        public string address { get; set; }

        public string note { get; set; }

        public int status { get; set; }

        public virtual User User { get; set; }

    }
}