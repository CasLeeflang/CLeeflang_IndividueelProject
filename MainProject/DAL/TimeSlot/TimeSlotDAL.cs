using Dapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contract_Layer.TimeSlot;
using DAL.DataBase;
using Microsoft.Extensions.Configuration;
using System.Linq;

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

        public IEnumerable<TimeSlotDTO> GetTimeSlotByBusinessId(int businessId)
        {
            string sql = $"select Id, BusinessId, DayOTWeek, StartTime, EndTime, NumberOfSpots from dbo.TimeSlot where BusinessId = @businessId";
            //string sql = $"select T.*, U.BusinessName as BusinessName from dbo.TimeSlot T left join dbo.BusinessUser U on T.BusinessId = U.Id where BusinessId = @businessId";

            var dictionary = new Dictionary<string, object>
            {
                {"@businessId", businessId}
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<TimeSlotDTO>(sql, parameters);
        }

        public IEnumerable<TimeSlotDTO> GetTimeSlotByDayAndBusinessId(DateTime date, string day, int businessId)
        {
            //string sql = $"select T.*, Count(R.Id) from dbo.TimeSlot as T left outer join dbo.Reservation as R on T.Id = R.TimeSlotId where T.BusinessId = @businessId and T.DayOTWeek = @day";
            //string sql = $"Select * from dbo.TimeSlot where BusinessId = @businessId and DayOTWeek = @day";


            //  Star not de bedoeling
            //  Geen foutmelding als een kolom mist
            string sql = $"select T.Id, T.BusinessId, T.DayOTWeek, T.StartTime, T.EndTime, T.NumberOfSpots, count(R.Id) as NumberOfReservations from dbo.TimeSlot T left outer join dbo.Reservation R on T.Id = R.TimeSlotId and R.Date = @date where T.BusinessId = @businessId and T.DayOTWeek = @day group by T.Id, T.BusinessId, T.DayOTWeek, T.StartTime, T.EndTime, T.NumberOfSpots";

            var dictionary = new Dictionary<string, object>
            {
                {"@date", date },
                {"@businessId", businessId },
                {"@day", day}
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<TimeSlotDTO>(sql, parameters);
        }

        public IEnumerable<TimeSlotDTO> GetTimeSlotById(int id)
        {
            string sql = $"select Id, BusinessId, DayOTWeek, StartTime, EndTime, NumberOfSpots from dbo.TimeSlot where Id = @id";

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
