using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoexEntity
{
    [Table("bond", Schema = "importfiles")]
    public class BondEntity : CommonEntity
    {
        [Key]
        [Ignore]
        public int Id { get; set; }
        public string? Boardid { get; set; }
        public string? Shortname { get; set; }
        public string? Secid { get; set; }
        public string? Numtrades { get; set; }
        public string? Low { get; set; }
        public string? Volume { get; set; }
        public string? MP2ValTrd { get; set; }
        public string? AdmittedValue { get; set; }
        public string? Duration { get; set; }
        public string? IriCPiClose { get; set; }
        public string? BeiClose { get; set; }
        public string? FaceValue { get; set; }
        public string? CurrencyId { get; set; }
        public string? CbrClose { get; set; }
        public string? FaceUnit { get; set; }
        public string? TradingSession { get; set; }


        public decimal? Accint { get; set; }
        public decimal? AdmittedQuote { get; set; }
        public decimal? Close { get; set; }
        public decimal? CouponPercent { get; set; }
        public decimal? CouponValue { get; set; }
        public decimal? High { get; set; }
        public decimal? Legalcloseprice { get; set; }
        public decimal? Marketprice2 { get; set; }
        public decimal? Marketprice3 { get; set; }
        public decimal? Marketprice3TradesValue { get; set; }
        public decimal? Waprice { get; set; }
        public decimal? Open { get; set; }
        public decimal? YieldAtWap { get; set; }
        public decimal? YieldClose { get; set; }
        public decimal? YieldLastCoupon { get; set; }
        public decimal? YieldToOffer { get; set; }
        public decimal? Value { get; set; }


        public DateTime? BuyBackDate { get; set; }
        public DateTime? LastTradeDate { get; set; }
        public DateTime? MatDate { get; set; }
        public DateTime? OfferDate { get; set; }
        public DateTime? Tradedate { get; set; }
    }
}