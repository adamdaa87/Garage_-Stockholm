﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2._0.Services
{
    public interface IVehicleTypeSelectListService
    {
        Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync();
    }
}
