using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageSchedule.Models
{
    public class Merchant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        [Required]
        public string fullName { get; set; }

        [StringLength(255)]
        [Required]
        public string phoneNumber { get; set; }

        [StringLength(255)]
        [Required]
        public string email { get; set; }

        [StringLength(255)]
        [Required]
        public string nameStore { get; set; }

        //loài hàng hóa
        [StringLength(255)]
        [Required]
        public string typeMerchant { get; set; }

        public virtual Category Category { get; set; }

        [StringLength(255)]
        [Required]
        public string service { get; set; }
        //trụ sở
        [StringLength(255)]
        [Required]
        public string headquarter { get; set; }

        public int status { get; set; }

        public virtual User User { get; set; }

    }
}