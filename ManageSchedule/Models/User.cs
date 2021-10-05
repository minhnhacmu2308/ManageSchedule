using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageSchedule.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        [Required]
        public string fullName { get; set; }

        [StringLength(255)]
        [Required]
        public string userName { get; set; }

        [StringLength(255)]
        [Required]
        public string email { get; set; }

        [StringLength(255)]
        [Required]
        public string password { get; set; }

        public int status { get; set; }
 
        public virtual Role Role { get; set; }

    }
}