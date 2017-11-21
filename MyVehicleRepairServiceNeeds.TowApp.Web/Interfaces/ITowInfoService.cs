using MyVehicleRepairServiceNeeds.Models;
using MyVehicleRepairServiceNeeds.TowApp.Web.Domain;
using MyVehicleRepairServiceNeeds.TowApp.Web.Models;
using System.Collections.Generic;

namespace MyVehicleRepairServiceNeeds.Services.cs
{
    public interface ITowInfoService
    {
        int Add(TowInfoAddRequest model);
        List<TowInfo> Get();
        void Update(TowInfoUpdateRequest model, int id);
        void Delete(int id);
        TowInfo Get(int id);
    }
}