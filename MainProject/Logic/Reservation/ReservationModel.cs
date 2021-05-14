using Contract_Layer.Reservation;
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
    }
}
