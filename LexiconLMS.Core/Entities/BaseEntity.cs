namespace LexiconLMS.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; internal set; }
        public DateTime LastModified { get; internal set; }
    }
}
