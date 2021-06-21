using Contract_Layer.Reservation;
using DTOs;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables.ValidationResponse;

namespace Logic.Reservation
{
    public class ReservationModel
    {
        IReservationDAL _reservationDAL = FactoryDAL.ReservationFactoryDAL.CreateReservationDAL();

        public ReservationModel(DateTime date, int userId, int businessId, int timeSlotId, IReservationDAL reservationDAL)
        {
            _reservationDAL = reservationDAL;
            Date = date;
            UserId = userId;
            BusinessId = businessId;
            TimeSlotId = timeSlotId;
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public int TimeSlotId { get; set; }
#nullable enable
        public bool CheckedIn { get; set; }
        public string? BusinessName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
#nullable disable

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
            CheckedIn = reservationDTO.CheckedIn;
            BusinessName = reservationDTO.BusinessName;
            FirstName = reservationDTO.FirstName;
            LastName = reservationDTO.LastName;
            StartTime = ToString(reservationDTO.StartTime, "HH:mm");
            EndTime = ToString(reservationDTO.EndTime, "HH:mm");
        }

        public ReservationModel(DateTime date, int userId, int businessId, int timeSlotId)
        {
            Date = date;
            UserId = userId;
            BusinessId = businessId;
            TimeSlotId = timeSlotId;
            CheckedIn = false;
        }

        public void Update(ReservationModel updatedReservation)
        {
            throw new NotImplementedException();
        }

        private string ToString(DateTime? dt, string format) => dt == null ? "n/a" : ((DateTime)dt).ToString(format);

        public ReservationValidation Validate()
        {
            ReservationDTO existingReservation = _reservationDAL.GetReservationByUserIdAndDateAndBusinessId(UserId, Date, BusinessId).FirstOrDefault();
            ReservationValidation _reservationvalidation = new();

            if (existingReservation == null)
            {
   
                    _reservationvalidation.Valid = true;

            }
            else
            {
                if (existingReservation.UserId == UserId)
                {
                    _reservationvalidation.ExistsForUser = true;
                } 

            }

            return _reservationvalidation;
        }

        public void CheckCustomerIn()
        {
            _reservationDAL.CheckCustomerIn(Id);
        }

        public void CheckCustomerOut()
        {
            _reservationDAL.CheckCustomerOut(Id);
        }
    }
}
