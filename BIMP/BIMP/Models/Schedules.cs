using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMP.Models
{
    public class schedules
    {
        //스케쥴 ID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SCHEDULE_NO { get; set; }

        //고객명
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string ORDER_NAME{ get; set; }
        
        //등록일
        public string RGSDT { get; set; }

        //고객연락처
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ORDER_PHONE { get; set; }

        //출발일
        [Required]
        public string START_DT{ get; set; }


        //일정
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(3000)]
        public string SCHEDULE_CONTENTS { get; set; }

        //인승
        [Required]
        public string SEATER { get; set; }

        //기사명
        [Required]
        public string DRIVER_NAME { get; set; }

        //차량번호
        [Required]
        public string DIVER_CAR_NUMBER { get; set; }

        //차량금액(고객)
        public string CAR_PRICE { get; set; }

        //배차금액(기사)
        public string DISPATCH_PRICE { get; set; }

        //결제방법
        public BILLING_GUBUN BILLING_GU { get; set; }

        //예약금 입금여부
        public string DEPOSIT { get; set; }
        //예약금 입금날짜
        public string DEPOSIT_DT{ get; set; }

        //전액 입금여부
        public string FULL_AMOUNT_YN { get; set; }
        //전액입금날짜
        public string FULL_AMOUNT_DT { get; set; }

        //기사입금여부
        public string DRIVER_AMOUNT_YN { get; set; }
        //기사입금날짜
        public string DRIVER_AMOUNT_DT { get; set; }

        public string SCHEDULE_STASUS { get; set; }
        //비고
        public string REMARK { get; set; }

        public int USER_NO { get; set; }
    }
    public enum BILLING_GUBUN
    {
        카드,
        현금,
        세금계산서
    }
    public enum PAYMENT
    {
        입금완료,
        입금미완료
    }
}