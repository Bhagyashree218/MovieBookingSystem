using Kemar.MBS.Repository.Entity.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Entity
{
    public class City : BaseEntity
    {
        public int CityId { get; set; } //Primary Key
        public string CityName { get; set; }

        public ICollection<Theatre> Theatres { get; set; }
    }
}
