using Interface.TimeSlot;
using Models;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TimeSlot
{
    public class TimeSlotDAL : ITimeSlotDAL, ITimeSlotCollectionDAL
    {
        public void CreateTimeSlot(TimeSlotDTO newTimeSlot)
        {
            //Prepare sql query
            string sql = @"insert into dbo.TimeSlot (BusinessId, DayOTWeek, StartTime, EndTime, NumberOfSpots) 
                           values(@BusinessId, @DayOTWeek, @StartTime, @EndTime, @NumberOfSpots);";

            DBManager.SaveData(sql, newTimeSlot);
        }

        public IEnumerable<TimeSlotDTO> LoadTimeSlotByBusinessId(int businessId)
        {
            string sql = $"select * from dbo.TimeSlot where BusinessId = {businessId}";

            return DBManager.LoadDataList<TimeSlotDTO>(sql);
        }

        public void DeleteTimeSlot(int id)
        {
            string sql = $"delete from dbo.TimeSlot WHERE Id = {id}";

            DBManager.DeleteData<TimeSlotDTO>(sql);
        }

        public void UpdateTimeSlot()
        {
            throw new NotImplementedException();
        }
    }
}
