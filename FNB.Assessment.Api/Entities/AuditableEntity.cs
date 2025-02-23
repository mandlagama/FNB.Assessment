namespace FNB.Assessment.Services.Api.Entities
{
    public abstract class AuditableEntity
    {
        public int CreatedById { get; set; }

        public int ModifiedById { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
