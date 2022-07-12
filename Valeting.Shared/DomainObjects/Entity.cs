namespace Valeting.Shared.DomainObjects
{
    public abstract class Entity
    {
        public Entity()
        {
            ExternalId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public Guid ExternalId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
