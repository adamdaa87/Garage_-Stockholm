using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2._0.Services
{
    public interface IUserSelectListService
    {
        Task<IEnumerable<SelectListItem>> GetUsersAsync();
    }
}
