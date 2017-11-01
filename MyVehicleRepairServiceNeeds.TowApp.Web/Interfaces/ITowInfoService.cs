using MyVehicleRepairServiceNeeds.Models;

namespace MyVehicleRepairServiceNeeds.Services.cs
{
    public interface ITowInfoService
    {
        int CreateTowRecord(TowInfoAddRequest model);
    }
}