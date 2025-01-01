using IndustrialMachineManagement.Models;
namespace IndustrialMachineManagement.Services
{
    public interface IMachineService
    {
        Task<List<Machine>> GetAllMachinesAsync();
        Task<Machine?> GetMachineByIdAsync(Guid id);
        Task<Machine> AddMachineAsync(Machine machine);
        Task<bool> UpdateMachineAsync(Machine machine);
        Task<bool> DeleteMachineAsync(Guid id);
        Task<bool> ToggleMachineStatusAsync(Guid id);
        Task<bool> UpdateMachineDataAsync(Guid id, string data);
    }
}
