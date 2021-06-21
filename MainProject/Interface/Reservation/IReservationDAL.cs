using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract_Layer.Reservation
{
    public interface IReservationDAL
    {
        void UpdateReservation(ReservationDTO updatedReservation);
        IEnumerable<ReservationDTO> GetReservationByUserIdAndDateAndBusinessId(int userId, DateTime date, int businessId);
        void CheckCustomerIn(int reservationId);
        void CheckCustomerOut(int reservationId);
    }
}
