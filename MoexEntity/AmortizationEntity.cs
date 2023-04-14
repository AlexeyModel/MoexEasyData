using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoexEntity
{
    [Table("amortization", Schema = "importfiles")]
    public class AmortizationEntity : CommonEntity
    {
        [Key]
        [Ignore]
        public int Id { get; set; }
        public string? Isin { get; set; }
        public string? Name { get; set; }
        public string? AmortizationDate { get; set; }
        public string? FaceUnit { get; set; }
        public string? DataSource { get; set; }
        public string? Secid { get; set; }
        public string? PrimaryBoardId { get; set; }
        public string? FaceValue { get; set; }
        public string? InitialFaceValue { get; set; }
        public string? IssueValue { get; set; }
        public string? Value { get; set; }
        public string? ValuePrc { get; set; }
        public string? ValueRub { get; set; }
    }
}
