using Contract_Layer.Reservation;
using DAL.DataBase;
using Dapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reservation
{
    public class ReservationDAL : IReservationDAL, IReservationCollectionDAL
    {
        DBManager _dBManager = new DBManager();

        public void CreateReservation(ReservationDTO newReservaton)
        {
            string sql = @"insert into dbo.Reservation (Date, UserId, BusinessId, TimeSlotId)
                            values(@Date, @UserId, @BusinessId, @TimeSlotId);";

            _dBManager.SaveData(sql, newReservaton);
        }

        public IEnumerable<ReservationDTO> GetReservationByUserId(int userId)
        {
            string sql = @"select R.Id, R.Date, R.UserId, R.BusinessId, R.TimeSlotId, U.FirstName as Firstname, U.LastName as LastName, B.BusinessName as BusinessName, T.StartTime as StartTime, T.EndTime as EndTime 

                           from 

                           dbo.Reservation R 
                           left join dbo.BusinessUser B on R.BusinessId = B.Id 
                           left join dbo.TimeSlot T on R.TimeSlotId = T.Id 
                           left join dbo.[User] U on R.UserId = U.Id

                           where 

                           UserId = @userId 

                           order by 

                           R.Date, T.StartTime";

            var dictionary = new Dictionary<string, object>
            {
                {"@userId", userId }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<ReservationDTO>(sql, parameters);
        }

        public int GetNumberOfReservationsByUserId(int userId)
        {
            string sql = $"select count(Date) from dbo.Reservation where UserId = @userId";

            var dictionary = new Dictionary<string, object>
            {
                {"@userId", userId }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<int>(sql, parameters).First();
        }

        public IEnumerable<ReservationDTO> GetReservationByBusinessId(int businessId)
        {
            string sql = @"select R.Id, R.Date, R.UserId, R.BusinessId, R.TimeSlotId, U.FirstName as Firstname, U.LastName as LastName, B.BusinessName as BusinessName, T.StartTime as StartTime, T.EndTime as EndTime 

                           from 

                           dbo.Reservation R 
                           left join dbo.BusinessUser B on R.BusinessId = B.Id 
                           left join dbo.TimeSlot T on R.TimeSlotId = T.Id 
                           left join dbo.[User] U on R.UserId = U.Id

                           where 

                           R.BusinessId = @businessId 

                           order by 

                           R.Date, T.StartTime";

            var dictionary = new Dictionary<string, object>
            {
                {"@businessId", businessId }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<ReservationDTO>(sql, parameters);
        }

        public int GetNumberOfReservationsPerDateAndTimeSlotId(DateTime date, int timeSlotId)
        {
            string sql = $"select Id from dbo.Reservation where Date = @date and TimeSlotId = @timeSlotId;";

            var dictionary = new Dictionary<string, object>
            {
                {"@date", date },
                {"@timeSlotId", timeSlotId }
            };

            var parameters = new DynamicParameters(dictionary);
            return _dBManager.LoadData<ReservationDTO>(sql, parameters).Count();
        }

        public IEnumerable<ReservationDTO> GetReservationByUserIdAndDateAndBusinessId(int userId, DateTime date, int businessId)
        {
            string sql = $"select Id, Date, UserId, BusinessId, TimeSlotId from dbo.Reservation where UserId = @userId and Date = @date and BusinessId = @businessId";

            var dictionary = new Dictionary<string, object>
            {
                {"@userId", userId },
                {"@date", date },
                {"@businessId", businessId }

            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<ReservationDTO>(sql, parameters);
        }
        public void UpdateReservation(ReservationDTO updatedReservation)
        {
            string sql = $"";
        }

        public void DeleteReservation(int id)
        {
            string sql = $"delete from dbo.Reservation where Id = @id";

            var dictionary = new Dictionary<string, object>
            {
                {"@id", id }
            };

            var parameters = new DynamicParameters(dictionary);

            _dBManager.DeleteData<ReservationDTO>(sql, parameters);
        }
    }
}
