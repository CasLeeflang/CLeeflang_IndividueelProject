using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.TimeSlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL;
using Contract_Layer.TimeSlot;
using Variables.ValidationResponse;

namespace Logic.TimeSlot.Tests
{
    [TestClass()]
    public class TimeSlotModelTests
    {
        TestTimeSlotDAL timeSlotTestDal = new();

        ITimeSlotCollectionDAL timeSlotCollectionDAL = new TestTimeSlotDAL();

        [TestMethod()]
        public void ValidateTest_NoException_ValidTrue()
        {
            //  Arrang
            TimeSlotModel timeSlot = new TimeSlotModel(1, "Mon", DateTime.Parse("15:00"), DateTime.Parse("18:00"), 50);

            //  Act
            TimeSlotCreation timeSlotCreation = timeSlot.Validate();

            //  Assert
            Assert.IsTrue(timeSlotCreation.Valid);
        }

        [TestMethod()]
        public void ValidateTest_StartTimeAfterEndTime_TimeErrorTrueValidFalse()
        {

            //  Arrang
            TimeSlotModel timeSlot = new TimeSlotModel(1, "Mon", DateTime.Parse("18:00"), DateTime.Parse("15:00"), 50);

            //  Act
            TimeSlotCreation timeSlotCreation = timeSlot.Validate();

            //  Assert
            Assert.IsTrue(timeSlotCreation.TimeError && !timeSlotCreation.Valid);
        }

        [TestMethod()]
        public void ValidateTest_LessThan1Spot_SpotErrorTrueValidFalse()
        {
            //  Arrange
            TimeSlotModel timeSlot = new TimeSlotModel(1, "Mon", DateTime.Parse("15:00"), DateTime.Parse("18:00"), -5);

            //  Act
            TimeSlotCreation timeSlotCreation = timeSlot.Validate();

            //  Assert
            Assert.IsTrue(timeSlotCreation.SpotError && !timeSlotCreation.Valid);
        }
    }
}