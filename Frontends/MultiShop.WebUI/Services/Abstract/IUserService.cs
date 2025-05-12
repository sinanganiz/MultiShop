using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
