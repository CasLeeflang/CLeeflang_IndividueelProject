using Contract_Layer.Reservation;
using DTOs;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Reservation
{
    public class ReservationCollection 
    {
        IReservationCollectionDAL _reservationCollectionDAL;
        public ReservationCollection()
        {
            _reservationCollectionDAL = ReservationFactoryDAL.CreateReservationCollectionDAL();
        }

        public ReservationCollection(IReservationCollectionDAL reservationCollectionDAL)
        {
            _reservationCollectionDAL = reservationCollectionDAL;
        }

        private List<ReservationModel> reservations { get; } = new List<ReservationModel>();

        public void CreateReservation(ReservationModel newReservation)
        {
            ReservationDTO newReservationDTO = new ReservationDTO
            {
                Id = newReservation.Id,
                Date = newReservation.Date,
                UserId = newReservation.UserId,
                BusinessId = newReservation.BusinessId,
                TimeSlotId = newReservation.TimeSlotId
            };

            _reservationCollectionDAL.CreateReservation(newReservationDTO);
        }

        public IEnumerable<ReservationModel> GetReservationByUserId(int userId)
        {
            IEnumerable<ReservationDTO> reservationDTOs = _reservationCollectionDAL.GetReservationByUserId(userId);

            foreach(var reservationDTO in reservationDTOs)
            {
                ReservationModel reservation = new ReservationModel(reservationDTO);
                reservations.Add(reservation);
            }

            return reservations;
        }
        public int GetNumberOfReservationsByUserId(int userId)
        {
            return _reservationCollectionDAL.GetNumberOfReservationsByUserId(userId);
        }

        public int GetNumberOfReservationsPerDateAndTimeSlotId(DateTime date, int timeSlotId)
        {
            return _reservationCollectionDAL.GetNumberOfReservationsPerDateAndTimeSlotId(date, timeSlotId);
        }

        public IEnumerable<ReservationModel> GetReservationByBusinessId(int businessId)
        {
            IEnumerable<ReservationDTO> reservationDTOs = _reservationCollectionDAL.GetReservationByBusinessId(businessId);

            foreach(var reservationDTO in reservationDTOs)
            {
                ReservationModel reservation = new ReservationModel(reservationDTO);
                reservations.Add(reservation);
            }

            return reservations;
        }

        public void DeleteReservation(int id)
        {
            _reservationCollectionDAL.DeleteReservation(id);
        }
    }
}
