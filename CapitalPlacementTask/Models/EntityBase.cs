// Ignore Spelling: Testme

namespace CapitalPlacementTask.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
