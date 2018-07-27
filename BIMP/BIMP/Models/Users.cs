using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMP.Models
{
    public class users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int USER_NO { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string USER_ID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }

        public string MAIL { get; set; }

        public string NAME { get; set; }

        public string COUNTRY { get; set; }

        public string USER_STATUS { get; set; }

        public List<schedules> Schedule {get;set;}
    }
}