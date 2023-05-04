using Garage_2._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage_2._0.Services
{
    public class VehicleTypeSelectListService : IVehicleTypeSelectListService
    {
        private readonly Garage_2_0Context _context;

        public VehicleTypeSelectListService(Garage_2_0Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync()
        {
            return await _context.VehicleType
                //.Select(t => t.TypeName)
                .Select(g => new SelectListItem
                {
                    Text = g.TypeName,
                    Value = g.Id.ToString()
                })
                .ToListAsync();
        }
    }
}
