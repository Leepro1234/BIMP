using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMP.Models
{
    public class Sales
    {
        //매출ID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SALE_NO{ get; set; }

        //업체ID
        public int COMPANY_NO { get; set; }

        //상품ID
        public int GOODS_NO { get; set; }

        //단가
        [Required]
        public string PRICE  { get; set; }

        //수량
        [Required]
        public string QTY { get; set; }

        //판매금액
        [Required]
        public string SALEAMT { get; set; }

        //수금금액
        [Required]
        public string COLLECTAMT { get; set; }

        //결제구분
        [Required]
        public SALEGU SALEGU { get; set; }

        //판매일
        public string RGSDT { get; set; }

        //판매자
        public string REGISTER { get; set; }

        //매출수정일
        public string UPDDT { get; set; }


        //매출수정자
        public string UPDUSR { get; set; }

        //반품여부
        public string RTNYN{ get; set; }

    }
    public enum SALEGU
    {
        현금,
        계좌이체,
    }
    public enum RTNYN
    {
        판매,
        반품,
    }
    public class SalesModel
    {
        public int SALE_NO { get; set; }
        public int COMPANY_NO { get; set; }
        public int GOODS_NO { get; set; }
        public string COMPANY_NM { get; set; }
        public string GOODS_NM { get; set; }
        public string QTY { get; set; }
        public string PRICE { get; set; }
        public string SALEAMT { get; set; }
        public SalesModel()
        {
            
        }
    }
}