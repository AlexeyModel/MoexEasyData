using System.ComponentModel.DataAnnotations.Schema;

namespace MoexEntity
{
    [Table("coupon", Schema = "importfiles")]
    public class CouponEntity : CommonEntity
    {
        public string? Isin { get; set; }
        public string? Name { get; set; }
        public string? IssueValue { get; set; }
        public string? CouponDate { get; set; }
        public string? RecordDate { get; set; }
        public string? StartDate { get; set; }
        public string? InitialFacevalue { get; set; }
        public string? FaceValue { get; set; }
        public string? FaceUnit { get; set; }
        public string? Value { get; set; }
        public string? ValuePrc { get; set; }
        public string? ValueRub { get; set; }
    }
}
