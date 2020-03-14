using System;
using System.Collections.Generic;
using System.Text;
using Tsa.CodingChallenge.Submissions.Model;

namespace Tsa.CodingChallenge.Submissions.Client
{
    public interface ITestDataSetsClient
    {
        IList<TestDataSetModel> Get();

        IList<TestDataSetModel> Get(int problemId);
    }
}