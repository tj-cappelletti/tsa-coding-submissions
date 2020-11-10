using System;
using System.Collections.Generic;
using System.Text;

namespace Tsa.CodingChallenge.Submissions.Core.Security
{
    public interface IPasswordStorage
    {
        string CreateHash(string password);

        bool VerifyPassword(string password, string goodHash);
    }
}
