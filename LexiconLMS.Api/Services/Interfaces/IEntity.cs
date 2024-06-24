namespace LexiconLMS.Core.Interfaces
{
    public interface IEntity<TKey> where TKey : notnull, IEquatable<TKey>
    {
        TKey Id { get; set; }
        DateTime Created { get; set; }
        DateTime? LastModified { get; set; }
    }
    public interface IEntity : IEntity<int>
    {
    }
}
