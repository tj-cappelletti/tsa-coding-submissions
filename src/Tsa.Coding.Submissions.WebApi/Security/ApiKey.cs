using System;
using System.Collections.Generic;

namespace Tsa.Coding.Submissions.WebApi.Security
{
    public class ApiKey
    {
        public DateTime Created { get; }

        public int Id { get; }

        public string Key { get; }

        public string Owner { get; }

        public IReadOnlyCollection<string> Roles { get; }

        public ApiKey(int id, string owner, string key, DateTime created, IReadOnlyCollection<string> roles)
        {
            Id = id;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Created = created;
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }
    }
}
