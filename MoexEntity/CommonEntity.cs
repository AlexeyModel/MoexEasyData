using CsvHelper.Configuration.Attributes;

namespace MoexEntity
{
    public class CommonEntity
    {
        [Ignore]
        public long Pid { get; set; }
    }
}
