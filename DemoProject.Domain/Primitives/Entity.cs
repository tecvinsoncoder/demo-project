namespace DemoProject.Domain.Primitives
{
    public abstract class Entity : IAuditable
    {
        protected Entity(Guid id) => Id = id;

        protected Entity() { }

        public Guid Id { get; protected set; }

        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
