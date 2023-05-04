using Garage_2._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage_2._0.Services
{
    public class UserSelectListService : IUserSelectListService
    {
        private readonly Garage_2_0Context _context;

        public UserSelectListService(Garage_2_0Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetUsersAsync()
        {

            return await _context.User
                .Select(u => new SelectListItem
                {
                    Text = $"{u.Fname} {u.Lname}" ,
                    Value = u.Id.ToString()
                })
                .ToListAsync();
        }
    }
}
