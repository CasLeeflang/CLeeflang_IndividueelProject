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
        TestUserDAL testDAL = new();
        UserCollection userCollection = new UserCollection(new TestUserDAL());

        [TestMethod()]
        public void ValidateTest_NoExistingUser_ValidTrue()
        {
            //  arrange            
            UserModel user = new UserModel("DirkJan","Dirk","Jan", "Wachtwoord1", "DirkJan@user.com", DateTime.Parse("1/1/1950"), testDAL);
            
            //  Act
            UserRegistration _registrationValidation = user.Validate();

            //  Assert
            Assert.IsTrue(_registrationValidation.Valid);
        }

        [TestMethod()]
        public void ValidateTest_ExistingUserName_ValidFalseUserNameErrorTrue()
        {
            //  arrange
            UserModel user = new UserModel("BobRepo", "Bob", "Repo", "Wachtwoord1", "BobRepo@user.com", DateTime.Parse("1/1/1950"), testDAL);
            userCollection.CreateUser(user);
            UserModel user2 = new UserModel("BobRepo", "John", "user", "Wachtwoord1", "John@user.com", DateTime.Parse("1/1/1950"), testDAL);

            //  Act
            UserRegistration _registrationValidation = user2.Validate();
            var temp = userCollection.GetUserByUserName("BobRepo");
            //  Assert
            Assert.IsTrue(_registrationValidation.UserNameError && !_registrationValidation.Valid);
        }

        [TestMethod()]
        public void ValidateTest_ExistingEmail_ValidFalseEmailErrorTrue()
        {
            //  arrange
            UserModel user = new UserModel("BobRepo", "Bob", "Repo", "Wachtwoord1", "BobRepo@user.com", DateTime.Parse("1/1/1950"), testDAL);
            userCollection.CreateUser(user);
            UserModel user2 = new UserModel("JohnUser", "John", "user", "Wachtwoord1", "BobRepo@user.com", DateTime.Parse("1/1/1950"), testDAL);

            //  Act
            UserRegistration _registrationValidation = user2.Validate();

            //  Assert
            Assert.IsTrue(_registrationValidation.EmailError && !_registrationValidation.Valid);
        }

        [TestMethod()]
        public void ValidateTest_DoBInFuture_ValidFalseDoBErrorTrue()
        {
            //  arrange
            UserModel user = new UserModel("BobRepo", "Bob", "Repo", "Wachtwoord1", "BobRepo@user.com", DateTime.Parse("1/1/3021"), testDAL);


            //  Act
            UserRegistration _registrationValidation = user.Validate();

            //  Assert
            Assert.IsTrue(_registrationValidation.DoBError && !_registrationValidation.Valid);
        }

        [TestMethod()]
        public void ValidateTest_DoBBefore1800_ValidFalseDoBErrorTrue()
        {
            //  arrange
            UserModel user = new UserModel("BobRepo", "Bob", "Repo", "Wachtwoord1", "BobRepo@user.com", DateTime.Parse("1/1/450"), testDAL);


            //  Act
            UserRegistration _registrationValidation = user.Validate();

            //  Assert
            Assert.IsTrue(_registrationValidation.DoBError && !_registrationValidation.Valid);
        }
    }
}