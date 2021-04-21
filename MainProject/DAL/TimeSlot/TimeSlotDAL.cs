using Dapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contract_Layer.TimeSlot;
using DAL.DataBase;
using Microsoft.Extensions.Configuration;

namespace DAL.TimeSlot
{
    public class TimeSlotDAL : ITimeSlotDAL, ITimeSlotCollectionDAL
    {
        public DBManager _dBManager = new DBManager();

        public class Get
        {            
            //  Methods that relate to getting timeslots?
            //  Access _dBManager from within nested class?
        }

        public void CreateTimeSlot(TimeSlotDTO newTimeSlot)
        {
            //Prepare sql query
            string sql = @"insert into dbo.TimeSlot (BusinessId, DayOTWeek, StartTime, EndTime, NumberOfSpots) 
                           values(@BusinessId, @DayOTWeek, @StartTime, @EndTime, @NumberOfSpots);";

            _dBManager.SaveData(sql, newTimeSlot);
        }

        public IEnumerable<TimeSlotDTO> LoadTimeSlotByBusinessId(int businessId)
        {
            string sql = $"select * from dbo.TimeSlot where BusinessId = @businessId";

            var dictionary = new Dictionary<string, object>
            {
                {"@businessId", businessId}

            };


            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<TimeSlotDTO>(sql, parameters);
        }

        public IEnumerable<TimeSlotDTO> LoadTimeSlotByUserId(int userId)
        {
            string sql = $"select * from dbo.TimeSlot where UserId = @userId";

            var dictionary = new Dictionary<string, object>
            {
                {"@userId", userId}

            };


            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<TimeSlotDTO>(sql, parameters);
        }

        public IEnumerable<TimeSlotDTO> GetTimeSlotByDayAndBusinessId(string day, int businessId)
        {
            string sql = $"Select * from dbo.TimeSlot where BusinessId = @businessId and DayOTWeek = @day";

            var dictionary = new Dictionary<string, object>
            {
                {"@businessId", businessId },
                {"@day", day}
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<TimeSlotDTO>(sql, parameters);
        }

        public IEnumerable<TimeSlotDTO> LoadTimeSlotById(int id)
        {
            string sql = $"select * from dbo.TimeSlot where Id = @id";

            var dictionary = new Dictionary<string, object>
            {
                {"@id", id}

            };


            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<TimeSlotDTO>(sql, parameters);
        }

        public void DeleteTimeSlot(int id)
        {
            string sql = $"delete from dbo.TimeSlot WHERE Id = @id";

            var dictionary = new Dictionary<string, object>
            {
                {"@id", id},

            };


            var parameters = new DynamicParameters(dictionary);


            _dBManager.DeleteData<TimeSlotDTO>(sql, parameters);
        }

        public void UpdateTimeSlot()
        {
            throw new NotImplementedException();
        }
    }
}
