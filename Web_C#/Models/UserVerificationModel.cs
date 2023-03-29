namespace Web_C_.Models
{
    public class UserVerificationModel
        
    {
        private List<RegistrationModel> ArrayListRegistration = new List<RegistrationModel>();

        public UserVerificationModel()
        {
            ArrayListRegistration.Add(new RegistrationModel()
            {
                Name = "Pop",
                Email = "Pop2005@mail.ru",
                Phone = "+79876417155",
                Password = "2wsxzaq1",
                ConfirmPassword = "2wsxzaq1",

            }

           );
            ArrayListRegistration.Add(new RegistrationModel()
            {
                Name = "Ale",
                Email = "Ale2005@mail.ru",
                Phone = "+79876417152",
                Password = "papaapap5",
                ConfirmPassword = "papaapap5",

            }

            );
        }
        public bool name { get; set; }
        public bool email { get; set; }
        public bool phone { get; set; }
        public bool userVerification(string name, string email, string phone, ref UserVerificationModel userVerification)
        {


            foreach (var user in ArrayListRegistration)
            {
                userVerification.name = user.Name.ToLower() == name.ToLower() ? true : false;
                userVerification.email = user.Email.ToLower() == email.ToLower() ? true : false;
                userVerification.phone = user.Phone.ToLower() == phone.ToLower() ? true : false;
                if (userVerification.name || userVerification.email || userVerification.phone)
                {
                    return true;

                }

            }
            return false;
        }
        public void AddingUser(RegistrationModel user)
        {
            ArrayListRegistration.Add(user);
        }
        public void Save()
        {

            ;
        }
    }
}
