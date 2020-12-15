using System.Text.Json.Serialization;

namespace OpenDart.Model
{
    /// <summary>
    /// 기업개황 - DART에 등록되어있는 기업의 개황정보를 제공합니다.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// 에러 및 정보 코드
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 에러 및 정보 메시지
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// 고유번호 - 공시대상회사의 고유번호(8자리)
        /// </summary>
        [JsonPropertyName("corp_code")]
        public string CorporationCode { get; set; }

        /// <summary>
        ///  정식명칭 - 정식회사명칭
        /// </summary>
        [JsonPropertyName("corp_name")]
        public string CorporationName { get; set; }

        /// <summary>
        /// 영문명칭 - 영문정식회사명칭
        /// </summary>
        [JsonPropertyName("corp_name_eng")]
        public string CorporationNameEnglish { get; set; }

        /// <summary>
        /// 종목명(상장사) 또는 약식명칭(기타법인)
        /// </summary>
        [JsonPropertyName("stock_name")]
        public string StockName { get; set; }

        /// <summary>
        ///  상장회사인 경우 주식의 종목코드 - 상장회사의 종목코드(6자리)
        /// </summary>
        [JsonPropertyName("stock_code")]
        public string StockCode { get; set; }

        /// <summary>
        /// 대표자명
        /// </summary>
        [JsonPropertyName("ceo_nm")]
        public string CeoName { get; set; }

        /// <summary>
        /// 법인구분 법인구분 : Y(유가), K(코스닥), N(코넥스), E(기타)
        /// </summary>
        [JsonPropertyName("corp_cls")]
        public string CorporationClass { get; set; }

        /// <summary>
        /// 법인등록번호
        /// </summary>
        [JsonPropertyName("jurir_no")]
        public string CorporationNumber { get; set; }

        /// <summary>
        /// 사업자등록번호
        /// </summary>
        [JsonPropertyName("bizr_no")]
        public string BusinessRegistrationNumber { get; set; }

        /// <summary>
        /// 주소
        /// </summary>
        [JsonPropertyName("adres")]
        public string Address { get; set; }

        /// <summary>
        /// 홈페이지
        /// </summary>
        [JsonPropertyName("hm_url")]
        public string HomepageUrl { get; set; }

        /// <summary>
        /// IR홈페이지
        /// </summary>
        [JsonPropertyName("ir_url")]
        public string IRUrl { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        [JsonPropertyName("phn_no")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 팩스번호
        /// </summary>
        [JsonPropertyName("fax_no")]
        public string FaxNumber { get; set; }

        /// <summary>
        /// 업종코드
        /// </summary>
        [JsonPropertyName("induty_code")]
        public string IndutyCode { get; set; }

        /// <summary>
        /// 설립일(YYYYMMDD)
        /// </summary>
        [JsonPropertyName("est_dt")]
        public string EstablishmentDate { get; set; }

        /// <summary>
        /// 결산월(MM)
        /// </summary>
        [JsonPropertyName("acc_mt")]
        public string AccountMonth { get; set; }

    }
}
