using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoexEntity
{
    [Table("offers", Schema = "importfiles")]
    public class OffersEntity : CommonEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Isin { get; set; }
        public string? Name { get; set; }
        public string? IssueValue { get; set; }
        public string? OfferDate { get; set; }
        public string? OfferDateStart { get; set; }
        public string? OfferDateEnd { get; set; }
        public string? FaceValue { get; set; }
        public string? FaceUnit { get; set; }
        public string? Price { get; set; }
        public string? Value { get; set; }
        public string? Agent { get; set; }
        public string? OfferType { get; set; }
        public string? Secid { get; set; }
        public string? PrimaryBoardId { get; set; }
    }
}
