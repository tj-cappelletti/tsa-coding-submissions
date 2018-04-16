using System.ComponentModel.DataAnnotations.Schema;

namespace Tsa.CodingChallenge.Submissions.Core.Entities
{
    public class TestDataSetElement
    {
        public int? ArraySequence { get; set; }

        [Column("DataTypeId")]
        public DataType DataType { get; set; }

        public int Id { get; set; }

        public string Identifier { get; set; }

        public bool IsArrayElement { get; set; }

        public int Sequence { get; set; }

        public int TestDataSetId { get; set; }

        public TestDataSet TestDataSet { get; set; }

        public string Value { get; set; }
    }
}