using Microsoft.AspNetCore.Mvc;
using Resunet.BL.Auth;
using Web_C_.BL.Interfaces;
using Web_C_.Database.Data;

namespace Web_C_.ViewComponents
{
    public class MainMenu : ViewComponent
    {
        private readonly ISessionDb sessionDb;
        private readonly IUserBL userBL;

        public MainMenu(ISessionDb sessionDb, IUserBL userBL)
        {
            this.sessionDb = sessionDb;
            this.userBL = userBL;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? userName = null ;
            int? sessionId = (await sessionDb.GetSession()).UserId;
            if (sessionId != null)
            {
                UserDto? userDto = await userBL.GetByUserIdAsync((int)sessionId!);
                if (userDto != null)
                {
                    userName = userDto.Name!;
                    return View("MainMenu", (object)userName);
                }
                //Ошибка он есть в сессии, но нет в базе
            }
            return View("MainMenu", (object)userName!);
        }


    }
}
