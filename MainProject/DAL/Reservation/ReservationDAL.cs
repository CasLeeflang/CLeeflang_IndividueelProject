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
            string sql = $"select * from dbo.Reservation where UserId = @userId";

            var dictionary = new Dictionary<string, object>
            {
                {"@userId", userId }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<ReservationDTO>(sql, parameters);
        }

        public int GetNumberOfReservationsByUserId(int userId)
        {
            string sql = $"select Date from dbo.Reservation where UserId = @userId";

            var dictionary = new Dictionary<string, object>
            {
                {"@userId", userId }
            };

            var parameters = new DynamicParameters(dictionary);

            return _dBManager.LoadData<ReservationDTO>(sql, parameters).Count();
        }

        public IEnumerable<ReservationDTO> GetReservationByBusinessId(int businessId)
        {
            string sql = $"select * from dbo.Reservation where BusinessId = @businessId";

            var dictionary = new Dictionary<string, object>
            {
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
            string sql = $"";
        }
    }
}
