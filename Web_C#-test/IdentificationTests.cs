using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Transactions;
using Web_C_.BL.Implementations;
using Web_C_.ModelsView;
using Web_C__test.Helpers;

namespace Web_C__test
{
    public class IdentificationTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task RegistrationTest()
        {
            using (TransactionScope scope = Helper.CreateTransactionScope())
            {
                ModelStateDictionary modelEmail = new ModelStateDictionary();
                ModelStateDictionary modelPhone = new ModelStateDictionary();
                Guid guid = Guid.NewGuid();
                Random rnd = new Random();
                string numberPhone = "+7";
                for (int i = 0; i < 3; i++)
                {
                    numberPhone += rnd.Next(100, 999).ToString();
                }


                string email = guid.ToString().Substring(0, 6) + "@mail.ru";

                await userBL.ValidateEmailAsync(email, modelEmail);
                await userBL.ValidatePhoneAsync(numberPhone, modelPhone);

                Assert.IsTrue(modelEmail.IsValid);
                Assert.IsTrue(modelPhone.IsValid);
                
                await userBL.AddUserAsync( new RegistrationModel() { Email = email, Phone = numberPhone, Name = "Ale", Password = "1234qwer"});
                
            }
        }

        [Test]
        public async Task LoginTest()
        {
            using (TransactionScope scope = Helper.CreateTransactionScope())
            {
                Guid guid = Guid.NewGuid();
                string email = guid.ToString() + "@mail.ru";

                (int userId, UserViewModel? user) = await userBL.AuthenticateAsync("qwer@mail.ru", "1234qwer");
                Assert.IsNotNull(user);
                Assert.NotZero(userId);
                (userId, user) = await userBL.AuthenticateAsync(email, "1234qwer");
                Assert.IsNull(user);
                Assert.Zero(userId);
                (userId, user) = await userBL.AuthenticateAsync("qwer@mail.ru", "11334qwer");
                Assert.IsNull(user);
                Assert.Zero(userId);
            }
        }

        //[Test]
        //public async Task SessionTest() 
        //{
        //    //Ќ”жно реализовать свою сессию

        //    using (TransactionScope scope = Helper.CreateTransactionScope())
        //    {
        //        Assert.IsFalse(await sessionDb.IsLoggedInAsync());
        //        await sessionDb.SetUserIdAsync(new Random().Next(1, 999));
        //        Assert.IsTrue(await sessionDb.IsLoggedInAsync());

        //        Assert.NotNull((await userSession.GetUserWithSession((await sessionDb.GetSession()).DbSessionId)));
        //        Assert.Null(await userSession.GetUserWithSession(Guid.NewGuid()));
        //    }
        //}



    }
}