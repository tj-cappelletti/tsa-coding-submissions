using System;

namespace Tsa.CodingChallenge.Submissions.Business.Entities
{
    public class Submission
    {
        public DateTime EvaluatedDateTime { get; set; }

        public string FileName { get; set; }

        public int Id { get; set; }

        public Login Login { get; set; }

        public int LoginId { get; set; }

        public Problem Problem { get; set; }

        public int ProblemId { get; set; }

        public byte[] RawFile { get; set; }

        public DateTime SubmissionDateTime { get; set; }
    }
}