using Kemar.MBS.Repository.Entity.BaseEntities;

namespace Kemar.MBS.Repository.Entity
{
    public class Theatre : BaseEntity
    {
        public int TheatreId {  get; set; }     //Primary Key
        public int CityId { get; set; }     // Foreign Key 
        public string TheatreName { get; set; }
        public string Address { get; set; }

        public City City { get; set; }
        public ICollection<Screen> Screens { get; set; }
    }
}
