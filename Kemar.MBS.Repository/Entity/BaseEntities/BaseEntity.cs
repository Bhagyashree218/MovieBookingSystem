namespace Kemar.MBS.Repository.Entity.BaseEntities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }          // AdminId or UserId
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }         // AdminId or UserId
        public bool IsActive { get; set; } = true;
    }
}
