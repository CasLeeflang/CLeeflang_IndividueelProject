using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.BusinessUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL;
using Variables.ValidationResponse;

namespace Logic.BusinessUser.Tests
{
    [TestClass()]
    public class BusinessUserModelTests
    {
        TestBusinessUserDAL testDAL = new();
        BusinessUserCollection businessUserCollection = new BusinessUserCollection(new TestBusinessUserDAL());

        [TestMethod()]
        public void ValidateTest_NoExistingUser_ValidTrue()
        {
            //  arrange
            BusinessUserModel businessUser = new BusinessUserModel(0, "Monk", "Monk123", "Wachtwoord1", "Monk@mail.com", "Climbing", testDAL);

            //  Act
            BusinessRegistration _registrationValidation = businessUser.Validate();

            //  Assert
            Assert.IsTrue(_registrationValidation.Valid);
        }

        [TestMethod()]
        public void ValidateTest_ExistingUserName_ValidFalseUserNameErrorTrue()
        {

            //  arrange
            BusinessUserModel businessUserExisting = new BusinessUserModel(1, "BeBoulder", "BeBoulder123", "Wachtwoord1", "BeBoulder@mail.com", "Climbing", testDAL);
            businessUserCollection.CreateBusinessUser(businessUserExisting);
            BusinessUserModel businessUserNew = new BusinessUserModel(2, "NotBeBoulder", "BeBoulder123", "Wachtwoord1", "NotBeBoulder@mail.com", "Climbing", testDAL);

            //  Act
            BusinessRegistration _registrationValidation = businessUserNew.Validate();

            //  Assert
            Assert.IsTrue(_registrationValidation.UserNameError && !_registrationValidation.Valid);
        }

        [TestMethod()]
        public void ValidationTest_ExistingBusinessName_ValidFalseBusinessNameErrorTrue()
        {
            //  arrange
            BusinessUserModel businessUserExisting = new BusinessUserModel(3, "BeBoulder", "BeBoulder123", "Wachtwoord1", "BeBoulder@mail.com", "Climbing", testDAL);
            businessUserCollection.CreateBusinessUser(businessUserExisting);
            BusinessUserModel businessUserNew = new BusinessUserModel(4, "BeBoulder", "NotBeBoulder123", "Wachtwoord1", "NotBeBoulder@mail.com", "Climbing", testDAL);

            //  Act
            BusinessRegistration _registrationValidation = businessUserNew.Validate();

            //  Assert
            Assert.IsTrue(_registrationValidation.BusinessNameError && !_registrationValidation.Valid);
        }

        [TestMethod()]
        public void ValidationTest_ExistingEmail_ValidFalseEmailErrorTrue()
        {
            //  arrange
            BusinessUserModel businessUserExisting = new BusinessUserModel(5, "BeBoulder", "BeBoulder123", "Wachtwoord1", "BeBoulder@mail.com", "Climbing", testDAL);
            businessUserCollection.CreateBusinessUser(businessUserExisting);
            BusinessUserModel businessUserNew = new BusinessUserModel(6, "NotBeBoulder", "NotBeBoulder123", "Wachtwoord1", "BeBoulder@mail.com", "Climbing", testDAL);

            //  Act
            BusinessRegistration _registrationValidation = businessUserNew.Validate();

            //  Assert
            Assert.IsTrue(_registrationValidation.EmailError && !_registrationValidation.Valid);
        }
    }
}