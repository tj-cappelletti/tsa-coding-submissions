using System;
using System.Security.Cryptography;

namespace Tsa.CodingChallenge.Submissions.Business.Security
{
    public class PasswordStorage
    {
        // These constants may be changed without breaking existing hashes.
        public const int SaltBytes = 24;
        public const int HashBytes = 18;
        public const int Pbkdf2Iterations = 64000;

        // These constants define the encoding and may not be changed.
        public const int HashSections = 5;
        public const int HashAlgorithmIndex = 0;
        public const int IterationIndex = 1;
        public const int HashSizeIndex = 2;
        public const int SaltIndex = 3;
        public const int Pbkdf2Index = 4;

        public static string CreateHash(string password)
        {
            // Generate a random salt
            var salt = new byte[SaltBytes];

            try
            {
                using (var csprng = new RNGCryptoServiceProvider())
                {
                    csprng.GetBytes(salt);
                }
            }
            catch (CryptographicException cryptographicException)
            {
                throw new CannotPerformOperationException("Random number generator not available.", cryptographicException);
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw new CannotPerformOperationException("Invalid argument given to random number generator.", argumentNullException);
            }

            var hash = Pbkdf2(password, salt, Pbkdf2Iterations, HashBytes);

            // format: algorithm:iterations:hashSize:salt:hash
            var parts = $"sha1:{Pbkdf2Iterations}:{hash.Length}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";

            return parts;
        }

        public static bool VerifyPassword(string password, string goodHash)
        {
            char[] delimiter = { ':' };
            var split = goodHash.Split(delimiter);

            if (split.Length != HashSections)
                throw new InvalidHashException("Fields are missing from the password hash.");

            // We only support SHA1 with C#.
            if (split[HashAlgorithmIndex] != "sha1")
                throw new CannotPerformOperationException("Unsupported hash type.");

            int iterations;

            try
            {
                iterations = int.Parse(split[IterationIndex]);
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw new CannotPerformOperationException("Invalid argument given to Int32.Parse", argumentNullException);
            }
            catch (FormatException formatException)
            {
                throw new InvalidHashException("Could not parse the iteration count as an integer.", formatException);
            }
            catch (OverflowException overflowException)
            {
                throw new InvalidHashException("The iteration count is too large to be represented.", overflowException);
            }

            if (iterations < 1)
                throw new InvalidHashException("Invalid number of iterations. Must be >= 1.");

            byte[] salt;

            try
            {
                salt = Convert.FromBase64String(split[SaltIndex]);
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw new CannotPerformOperationException("Invalid argument given to Convert.FromBase64String", argumentNullException);
            }
            catch (FormatException formatException)
            {
                throw new InvalidHashException("Base64 decoding of salt failed.", formatException);
            }

            byte[] hash;

            try
            {
                hash = Convert.FromBase64String(split[Pbkdf2Index]);
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw new CannotPerformOperationException("Invalid argument given to Convert.FromBase64String", argumentNullException);
            }
            catch (FormatException formatException)
            {
                throw new InvalidHashException("Base64 decoding of pbkdf2 output failed.", formatException);
            }

            int storedHashSize;

            try
            {
                storedHashSize = int.Parse(split[HashSizeIndex]);
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw new CannotPerformOperationException("Invalid argument given to Int32.Parse", argumentNullException);
            }
            catch (FormatException formatException)
            {
                throw new InvalidHashException("Could not parse the hash size as an integer.", formatException);
            }
            catch (OverflowException overflowException)
            {
                throw new InvalidHashException("The hash size is too large to be represented.", overflowException);
            }

            if (storedHashSize != hash.Length)
                throw new InvalidHashException("Hash length doesn't match stored hash length.");

            var testHash = Pbkdf2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++) diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt))
            {
                pbkdf2.IterationCount = iterations;
                return pbkdf2.GetBytes(outputBytes);
            }
        }
    }
}