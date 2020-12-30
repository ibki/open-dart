using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenDart.Model
{
    // TODO: 클래스명 변경필요
    /// <summary>
    /// 고유번호 - DART에 등록되어있는 공시대상회사의 고유번호,회사명,대표자명,종목코드, 최근변경일자를 파일로 제공합니다.
    /// </summary>
    public class Corporation
    {
        /// <summary>
        /// 고유번호 - 공시대상회사의 고유번호(8자리)
        /// </summary>
        [BsonId]
        [XmlElement("corp_code")]
        public string Code { get; set; }

        /// <summary>
        /// 정식명칭 - 정식회사명칭
        /// </summary>
        [XmlElement("corp_name")]
        public string Name { get; set; }

        /// <summary>
        /// 종목코드 - 상장회사인 경우 주식의 종목코드(6자리)
        /// </summary>
        [XmlElement("stock_code")]
        public string StockCode { get; set; }

        /// <summary>
        /// 최종변경일자 - 기업개황정보 최종변경일자(YYYYMMDD)
        /// </summary>
        [XmlElement("modify_date")]
        public string ModifyDate { get; set; }
    }

    [XmlRoot("result")]
    public class CorporationList
    {
        [XmlElement("list")]
        public List<Corporation> Corporations { get; set; }
    }



    public class Error
    {
        /// <summary>
        /// 에러 및 정보 코드
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 에러 및 정보 메시지
        /// </summary>
        public string Message { get; set; }
    }
}
