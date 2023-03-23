using FitnesGalaxyApp.Models;
using FitnesGalaxyApp.Model;

namespace FitnesGalaxyApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestGetHash()
        {
            ClassHash classHash = new Model.ClassHash();
            string testpassword = "password";
            string testpasswordhash = "5F4DCC3B5AA765D61D8327DEB882CF99";
            
            Assert.That(testpasswordhash, Is.EqualTo(classHash.GetHash(testpassword)));
        }
        [Test]
        public void TestHash()
        {
            SignUpUserControll signUpUserControll = new SignUpUserControll();
            string Password = "Vladsapsan228";
             
             Assert.That(signUpUserControll.ValidatePassword(Password, out Password), Is.EqualTo(true));
        }
    }
}