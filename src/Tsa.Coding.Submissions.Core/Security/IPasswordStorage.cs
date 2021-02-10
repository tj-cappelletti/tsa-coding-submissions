namespace Tsa.Coding.Submissions.Core.Security
{
    public interface IPasswordStorage
    {
        string CreateHash(string password);

        bool VerifyPassword(string password, string goodHash);
    }
}
