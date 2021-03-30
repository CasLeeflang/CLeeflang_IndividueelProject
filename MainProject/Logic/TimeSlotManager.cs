using CLeeflang_IndividueelProject.Models;
using Models;
using SQLDataAccess;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class TimeSlotManager
    {
        public static int SaveTimeSlot(ITimeSlot timeSlot)
        {
            // map view model into DTO
            TimeSlotModel timeSlotDTO = new TimeSlotModel
            {
                BusinessId = timeSlot.BusinessId,
                DayOTWeek = timeSlot.DayOTWeek,
                StartTime = timeSlot.StartTime,
                EndTime = timeSlot.EndTime,
                NumberOfSpots = timeSlot.NumberOfSpots
            };

            //Prepare sql query
            string sql = @"insert into dbo.TimeSlot (BusinessId, DayOTWeek, StartTime, EndTime, NumberOfSpots) 
                           values(@BusinessId, @DayOTWeek, @StartTime, @EndTime, @NumberOfSpots);";

            return DBManager.SaveData(sql, timeSlotDTO);
        }

        public static List<TimeSlotModel> LoadTimeSlot(int businessId)
        {
            string sql = $"select * from dbo.TimeSlot where BusinessId = {businessId}";
            return DBManager.LoadDataList<TimeSlotModel>(sql);
        }
    }
}
