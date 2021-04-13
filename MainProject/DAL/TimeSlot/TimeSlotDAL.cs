using Dapper;
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
            string sql = $"select * from dbo.TimeSlot where BusinessId = @businessId";

            var dictionary = new Dictionary<string, object>
            {
                {"@businessId", businessId},

            };


            var parameters = new DynamicParameters(dictionary);

            return DBManager.LoadData<TimeSlotDTO>(sql, parameters);
        }

        public void DeleteTimeSlot(int id)
        {
            string sql = $"delete from dbo.TimeSlot WHERE Id = @id";

            var dictionary = new Dictionary<string, object>
            {
                {"@id", id},

            };


            var parameters = new DynamicParameters(dictionary);


            DBManager.DeleteData<TimeSlotDTO>(sql, parameters);
        }

        public void UpdateTimeSlot()
        {
            throw new NotImplementedException();
        }
    }
}
