using Microsoft.EntityFrameworkCore;
using Web_C_.DAL.Configuration;
using Web_C_.DAL.Model.TypeProducts;
using Web_C_.Database.Data;

namespace Web_C_.Database
{
    public class StoreDbContext : DbContext
    {

        public DbSet<UserDto > Users { get; set; }
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<PhoneDto> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StoreDb;Trusted_Connection=true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            

            modelBuilder.Entity<PhoneDto>().HasData(new[]
            {

                new PhoneDto(){Id= 1, Name = "Samsung Galaxy A23 4/64 ГБ, черный", Price = 45780, Amount = 10, Description="Samsung Galaxy A23 – отличный пример современного функционального смартфона, который обеспечивает хорошую производительность, более чем достойную автономность и не помешает превратить яркий момент в незабываемый кадр. Он получил современный дисплей с частотой обновления до 90 Гц и разрешением FHD+, восьмиядерный процессор и достойный запас оперативной памяти и хранилища."},
                new PhoneDto(){Id= 2,Name ="Samsung Galaxy A23 4/64 ГБ, черный", Price= 25670, Amount = 5, Description = "Смартфон Galaxy A32 оснащён гибко настраиваемым экраном «Always On Display» - вместо обычного индикатора уведомлений, вы получаете возможность пользоваться базовыми функциями и считывать необходимую информацию из выключенного экрана, что также помогает экономить лишний расход заряда батареи." },
                new PhoneDto(){Id= 3, Name = "Apple iPhone 11 64GB Black (черный) A2221", Price = 15490, Amount=20, Description = "iPhone 14 Pro (6.1\") противоударный Прозрачный купить в Москве дешево с доставкой. Чехол-накладка силикон Deppa Gel Shockproof Case D-88325 для iPhone 14 Pro (6.1\") противоударный Прозрачный – продажа по низкой цене с гарантией. Фото, технические характеристики, отзывы, аксессуары, видео – все это поможет вам определиться с выбором."},
                new PhoneDto(){Id= 4,Name = "Apple iPhone 14 Pro Max 1Tb Deep Purple (тёмно-фиолетовый) A2894", Price = 143999, Amount = 50, Description = "Лучший дисплей iPhone с невероятной контрастностью и более высоким разрешением. И передняя панель Ceramic Shield, с которой риск повреждений дисплея при падении в четыре раза ниже."}
            
            });
        }
    }
}
