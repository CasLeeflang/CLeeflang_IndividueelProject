using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract_Layer.User;
using TestDAL;
using Variables.ValidationResponse;

namespace Logic.User.Tests
{
    [TestClass()]
    public class UserModelTests
    {
        IUserCollectionDAL userCollectionDAL = new TestUserDAL();
        IUserDAL userDAL = new TestUserDAL();
        [TestMethod()]
        public void ValidateTest_NoExistingUser_ValidTrue()
        {
            //  Arange
            UserModel user = new UserModel("test","test","user", "Wachtwoord1", "test@user.com", DateTime.Now, userDAL);

            //UserRegistration _registrationValidation = user.Validate();

            Assert.IsTrue(_registrationValidation.Valid);
        }
    }
}