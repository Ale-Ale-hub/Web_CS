using Web_C_.BL.Implementations;
using Web_C_.BL.Interfaces;
using Web_C_.DAL.Implementations;
using Web_C_.DAL.Interfaces;
using Web_C_.Infrastructure;

namespace Web_C_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IServiceCollection services = builder.Services;
            services.AddControllersWithViews();
            services.AddSingleton<IUserBL, UserModel>();
            services.AddSingleton<IProductBL, ProductBL>();
            services.AddSingleton< IUserDAL, UserDAL >();
            services.AddSingleton<ProductsDAL>();

            services.AddSingleton<OrderRepository>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}