using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoexEntity
{
    [Table("eurobonddescription", Schema = "importfiles")]
    public class EurobondDescriptionEntity : CommonEntity
    {
        [Key]
        [Ignore]
        public int Id { get; set; }
        public string? Secid { get; set; }
        public string? Issuename { get; set; }
        public string? Name { get; set; }
        public string? Shortname { get; set; }
        public string? Regnumber { get; set; }
        public string? Isin { get; set; }
        public string? Issuedate { get; set; }
        public string? Matdate { get; set; }
        public string? Buybackdate { get; set; }
        public string? Initialfacevalue { get; set; }
        public string? Faceunit { get; set; }
        public string? Latname { get; set; }
        public string? Hasprospectus { get; set; }
        public string? Decisiondate { get; set; }
        public string? Isconcessionagreement { get; set; }
        public string? Hasdefault { get; set; }
        public string? Hastechnicaldefault { get; set; }
        public string? Programregistrynumber { get; set; }
        public string? Emitentmismatchfirst { get; set; }
        public string? Emitentmismatchcur { get; set; }
        public string? Listlevel { get; set; }
        public string? Daystoredemption { get; set; }
        public string? Isqualifiedinvestors { get; set; }
        public string? Qualinvestorgroup { get; set; }
        public string? Couponfrequency { get; set; }
        public string? Coupondate { get; set; }
        public string? Couponvalue { get; set; }
        public string? Morningsession { get; set; }
        public string? Eveningsession { get; set; }
        public string? Highrisk { get; set; }
        public string? Type { get; set; }
        public string? Typename { get; set; }
    }
}
