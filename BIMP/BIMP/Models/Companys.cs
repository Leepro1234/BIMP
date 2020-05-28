using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMP.Models
{
    public class Companys
    {
        //스케쥴 ID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int COMPANY_NO { get; set; }

        //고객명
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(45)]
        public string COMPANY_NM { get; set; }

        //고객연락처
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string COMPANY_PHONE { get; set; }

        //사용여부
        [Required]
        public string COMPANY_STATUS { get; set; }

    }
    public enum COMPANYSTATUS
    {
        Y, //사용중
        N  //미사용
    }
}