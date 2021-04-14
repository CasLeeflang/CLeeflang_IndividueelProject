using Contract_Layer.Reservation;
using DAL.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDAL
{
    public class ReservationFactoryDAL
    {
        public static IReservationDAL CreateReservationDAL()
        {
            return new ReservationDAL();
        }

        public static IReservationCollectionDAL CreateReservationCollectionDAL()
        {
            return new ReservationDAL();
        }
    }
}
