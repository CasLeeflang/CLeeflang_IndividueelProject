using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract_Layer.Reservation
{
    public interface IReservationCollectionDAL
    {
        void CreateReservation(ReservationDTO newReservaton);
        IEnumerable<ReservationDTO> GetReservationByUserId(int userId);
        int GetNumberOfReservationsByUserId(int userId);
        IEnumerable<ReservationDTO> GetReservationByBusinessId(int businessId);
        void DeleteReservation(int id);

    }
}
