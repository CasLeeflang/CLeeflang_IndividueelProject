using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL;
using Variables.ValidationResponse;

namespace Logic.Reservation.Tests
{
    [TestClass()]
    public class ReservationModelTests
    {
        TestReservationDAL testDAL = new();
        ReservationCollection reservationCollection = new ReservationCollection(new TestReservationDAL());

        [TestMethod()]
        public void ValidateTest_NoExistingReservation_ValidTrue()
        {
            //  arrange
            ReservationModel reservation = new ReservationModel(DateTime.Now, 1, 1, 1, testDAL);

            //  Act
            ReservationValidation reservationValidation = reservation.Validate();

            //  Assert
            Assert.IsTrue(reservationValidation.Valid);
        }

        [TestMethod()]
        public void ValidationTest_SameDateSameTimeSlot_ValidFalseExistsForUserTrue()
        {
            //  arrange
            ReservationModel existingReservation = new ReservationModel(DateTime.Now, 1, 1, 1, testDAL);
            reservationCollection.CreateReservation(existingReservation);
            ReservationModel newReservation = new ReservationModel(DateTime.Now, 1, 1, 1, testDAL);

            //  Act
            ReservationValidation reservationValidation = newReservation.Validate();

            //  Assert
            Assert.IsTrue(reservationValidation.ExistsForUser && !reservationValidation.Valid);
        }

        [TestMethod()]
        public void ValidationTest_SameDateDifferentTimeSlot_ValidFalseExistsForUserTrue()
        {
            //  arrange
            ReservationModel existingReservation = new ReservationModel(DateTime.Now, 2, 2, 1, testDAL);
            reservationCollection.CreateReservation(existingReservation);
            ReservationModel newReservation = new ReservationModel(DateTime.Now, 2, 2, 2, testDAL);

            //  Act
            ReservationValidation reservationValidation = newReservation.Validate();

            //  Assert
            Assert.IsTrue(reservationValidation.ExistsForUser && !reservationValidation.Valid);
        }

        [TestMethod()]
        public void ValidationTest_DifferentDateSameTimeSlot_ValidTrueExistsForUserFalse()
        {
            //  arrange
            ReservationModel existingReservation = new ReservationModel(DateTime.Now, 3, 3, 1, testDAL);
            reservationCollection.CreateReservation(existingReservation);
            ReservationModel newReservation = new ReservationModel(DateTime.Now.AddDays(7), 3, 3, 1, testDAL);

            //  Act
            ReservationValidation reservationValidation = newReservation.Validate();

            //  Assert
            Assert.IsTrue(!reservationValidation.ExistsForUser && reservationValidation.Valid);
        }
    }
}