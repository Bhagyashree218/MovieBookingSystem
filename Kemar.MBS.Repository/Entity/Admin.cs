using Kemar.MBS.Repository.Entity.BaseEntities;
namespace Kemar.MBS.Repository.Entity
{
    public class Admin : BaseEntity
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string Password { get; set; }
    }     
}
