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
        int GetNumberOfReservationsPerDateAndTimeSlotId(DateTime date, int timeSlotId);
        IEnumerable<ReservationDTO> GetReservationByBusinessId(int businessId);
        void DeleteReservation(int id);
        IEnumerable<ReservationDTO> GetReservationById(int reservationId);

    }
}
