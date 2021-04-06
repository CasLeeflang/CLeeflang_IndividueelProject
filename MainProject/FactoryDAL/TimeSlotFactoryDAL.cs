using DAL.TimeSlot;
using Interface.TimeSlot;
using System;

namespace FactoryDAL
{
    public class TimeSlotFactoryDAL
    {
        // Interface Segregation
        public static ITimeSlotDAL CreateTimeSlotDAL()
        {
            return new TimeSlotDAL();
        }

        public static ITimeSlotCollectionDAL CreateTimeSlotCollectionDAL()
        {
            return new TimeSlotDAL();
        }
    }
}
