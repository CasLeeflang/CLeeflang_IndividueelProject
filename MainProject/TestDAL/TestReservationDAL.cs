using Contract_Layer.Reservation;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDAL
{
    public class TestReservationDAL: IReservationCollectionDAL, IReservationDAL
    {
        public static List<ReservationDTO> ReservationStorage { get; private set; } = new List<ReservationDTO>();
        public List<ReservationDTO> TempStorage { get; private set; } = new List<ReservationDTO>();

        public void CreateReservation(ReservationDTO reservation)
        {
            ReservationStorage.Add(reservation);
        }

        public IEnumerable<ReservationDTO> GetReservationByUserId(int userId)
        {
            TempStorage.Add(ReservationStorage.FirstOrDefault(o => o.UserId == userId));
            return TempStorage;
        }

        public int GetNumberOfReservationsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReservationsPerDateAndTimeSlotId(DateTime date, int timeSlotId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservationDTO> GetReservationByBusinessId(int businessId)
        {
            TempStorage.Add(ReservationStorage.FirstOrDefault(o => o.BusinessId == businessId));
            return TempStorage;
        }

        public void DeleteReservation(int id)
        {
            ReservationStorage.Remove(ReservationStorage.FirstOrDefault(o => o.Id == id));
        }

        public void UpdateReservation(ReservationDTO reservation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservationDTO> GetReservationByUserIdAndDateAndBusinessId(int userId, DateTime date, int businessId)
        {
            TempStorage.Add(ReservationStorage.FirstOrDefault(o => o.UserId == userId && o.Date.Date == date.Date && o.BusinessId == businessId));
            return TempStorage;
        }
    }
}
