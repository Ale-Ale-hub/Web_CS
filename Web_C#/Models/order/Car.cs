namespace Web_C_.Models.order
{
    public class Car
    {
        private  PhoneModel phoneModel;

        int Id { get; set; }
        public Car(PhoneModel phoneModel)
        {
            this.phoneModel = phoneModel;
        }

        public PhoneModel getPhone(int id)
        {
            phoneModel = phoneModel.getPhones().FirstOrDefault(x => x.Id == id);
            if (phoneModel == null)
            {

                phoneModel = new PhoneModel();
            }

            return phoneModel;
        }



    }
    
}
