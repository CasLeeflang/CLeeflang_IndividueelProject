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
    public class ReservationModel
    {
        IReservationDAL _reservationDAL = FactoryDAL.ReservationFactoryDAL.CreateReservationDAL();

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public int TimeSlotId { get; set; }

        public ReservationModel()
        {

        }

        public ReservationModel(ReservationDTO reservationDTO)
        {
            Id = reservationDTO.Id;
            Date = reservationDTO.Date;
            UserId = reservationDTO.UserId;
            BusinessId = reservationDTO.BusinessId;
            TimeSlotId = reservationDTO.TimeSlotId;
        }

        public ReservationModel(DateTime date, int userId, int businessId, int timeSlotId)
        {
            Date = date;
            UserId = userId;
            BusinessId = businessId;
            TimeSlotId = timeSlotId;
        }

        public void Update(ReservationModel updatedReservation)
        {
            throw new NotImplementedException();
        }
    }
}
