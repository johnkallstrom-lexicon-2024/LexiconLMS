using LexiconLMS.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Core.Entities
{
    public abstract class BaseIdentityEntity<TKey>
        : IdentityUser<TKey>, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
    public abstract class BaseIdentityEntity : BaseIdentityEntity<int>
    {
    }
}
