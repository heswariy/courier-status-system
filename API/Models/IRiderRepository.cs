using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IRiderRepository
    {
        IEnumerable<Rider> GetAllRiders();
        Rider GetRiderById(int riderId);
        Rider AddRider(Rider rider);
        Rider UpdateRider(Rider rider);
        void DeleteRider(int? riderId);
    }
}
