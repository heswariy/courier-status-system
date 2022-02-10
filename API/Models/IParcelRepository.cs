using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IParcelRepository
    {
        IEnumerable<Parcel> GetAllParcels();
        Parcel GetParcelByTrackingNum(string trackingNum);
    }
}
