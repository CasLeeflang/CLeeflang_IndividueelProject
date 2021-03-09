using CLeeflang_IndividueelProject.Models;
using Models;
using SQLDataAccess;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class TimeSlotManager
    {
        public static int SaveTimeSlot(ITimeSlotView timeSlot)
        {
            // map view model into DTO
            TimeSlotModel timeSlotDTO = new TimeSlotModel
            {
                BusinessUserId = timeSlot.BusinessUserId,
                DayOTWeek = timeSlot.DayOTWeek,
                StartTime = timeSlot.StartTime,
                EndTime = timeSlot.EndTime,
                NumberOfSpotsAvailable = timeSlot.NumberOfSpotsAvailable
            };

            //Prepare sql query
            string sql = @"insert into dbo.TimeSlot (BusinessUserId, DayOTWeek, StartTime, EndTime, NumberOfSpotsAvailable) 
                           values(@BusinessUserId, @DayOTWeek, @StartTime, @EndTime, @NumberOfSpotsAvailable);";

            return DBManager.SaveData(sql, timeSlotDTO);
        }

        public static List<TimeSlotModel> LoadTimeSlot(int businessId)
        {
            string sql = $"select * from dbo.TimeSlot where BusinessUserId = {businessId}";
            return DBManager.LoadDataList<TimeSlotModel>(sql);
        }
    }
}
