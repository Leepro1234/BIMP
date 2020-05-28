using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMP.Models
{
    public class Goods
    {
        //상품ID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GOODS_NO { get; set; }

        //상품명
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(45)]
        public string GOODS_NM { get; set; }

        //스타일
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string STYLE { get; set; }

        //컬러
        public string COLOR  { get; set; }

        //사이즈
        public string SIZE { get; set; }
    }
}