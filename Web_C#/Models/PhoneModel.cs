
namespace Web_C_.Models
{
    public class PhoneModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Have { get; set; }
        public string Description { get; set; }

        public PhoneModel(int id, string name, int price, bool have, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Have = have;
            Description = description;
        }
        private List<PhoneModel> phones = new List<PhoneModel>();
        public PhoneModel()
        {

            phones.Add
                (
                new PhoneModel(1, "Samsung Galaxy A23 4/64 ГБ, черный", 45780, true, "Samsung Galaxy A23 – отличный пример современного функционального смартфона, который обеспечивает хорошую производительность, более чем достойную автономность и не помешает превратить яркий момент в незабываемый кадр. Он получил современный дисплей с частотой обновления до 90 Гц и разрешением FHD+, восьмиядерный процессор и достойный запас оперативной памяти и хранилища.")


                );
            phones.Add(new PhoneModel(2, "Samsung Galaxy A23 4/64 ГБ, черный", 25670, false, "Смартфон Galaxy A32 оснащён гибко настраиваемым экраном «Always On Display» - вместо обычного индикатора уведомлений, вы получаете возможность пользоваться базовыми функциями и считывать необходимую информацию из выключенного экрана, что также помогает экономить лишний расход заряда батареи.")
                );
            phones.Add(new PhoneModel(3, "Apple iPhone 11 64GB Black (черный) A2221", 15490, true, "iPhone 14 Pro (6.1\") противоударный Прозрачный купить в Москве дешево с доставкой. Чехол-накладка силикон Deppa Gel Shockproof Case D-88325 для iPhone 14 Pro (6.1\") противоударный Прозрачный – продажа по низкой цене с гарантией. Фото, технические характеристики, отзывы, аксессуары, видео – все это поможет вам определиться с выбором."));

            phones.Add(new PhoneModel(4, "Apple iPhone 14 Pro Max 1Tb Deep Purple (тёмно-фиолетовый) A2894", 143999, false, "Лучший дисплей iPhone с невероятной контрастностью и более высоким разрешением. И передняя панель Ceramic Shield, с которой риск повреждений дисплея при падении в четыре раза ниже."));
                

            
    }

        
        public List<PhoneModel> getPhones()
        {

            return phones;
        }

}
}
