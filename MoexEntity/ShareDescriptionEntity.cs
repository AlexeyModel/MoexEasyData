using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoexEntity
{
    [Table("sharedescription", Schema = "importfiles")]
    public class ShareDescriptionEntity : CommonEntity
    {
        [Key]
        [Ignore]
        public int Id { get; set; }
        public string? Boardid { get; set; }
        public string? Tradedate { get; set; }
        public string? Shortname { get; set; }
        public string? Secid { get; set; }
        public string? Numtrades { get; set; }
        public string? Value { get; set; }
        public string? Open { get; set; }
        public string? Low { get; set; }
        public string? High { get; set; }
        public string? Legalcloseprice { get; set; }
        public string? Waprice { get; set; }
        public string? Close { get; set; }
        public string? Volume { get; set; }
        public string? Marketprice2 { get; set; }
        public string? Marketprice3 { get; set; }
        public string? AdmittedQuote { get; set; }
        public string? MP2ValTrd { get; set; }
        public string? Marketprice3TradesValue { get; set; }
        public string? AdmittedValue { get; set; }
        public string? Waval { get; set; }
        public string? TradingSession { get; set; }
    }
}
