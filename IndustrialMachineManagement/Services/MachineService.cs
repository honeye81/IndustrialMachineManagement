using IndustrialMachineManagement.Models;
namespace IndustrialMachineManagement.Services
{
    public class MachineService : IMachineService
    {
        private List<Machine> _machines = new();

        public MachineService()
        {
            // Add sample data
            _machines.Add(new Machine
            {
                Id = Guid.NewGuid(),
                Name = "Machine 1",
                IsOnline = true,
                LastDataReceived = DateTime.Now,
                LastData = "Temperature: 25°C"
            });
        }

        public async Task<List<Machine>> GetAllMachinesAsync()
        {
            return await Task.FromResult(_machines);
        }

        public async Task<Machine?> GetMachineByIdAsync(Guid id)
        {
            return await Task.FromResult(_machines.FirstOrDefault(m => m.Id == id));
        }

        public async Task<Machine> AddMachineAsync(Machine machine)
        {
            machine.Id = Guid.NewGuid();
            _machines.Add(machine);
            return await Task.FromResult(machine);
        }

        public async Task<bool> UpdateMachineAsync(Machine machine)
        {
            var index = _machines.FindIndex(m => m.Id == machine.Id);
            if (index != -1)
            {
                _machines[index] = machine;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteMachineAsync(Guid id)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                _machines.Remove(machine);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> ToggleMachineStatusAsync(Guid id)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                machine.IsOnline = !machine.IsOnline;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> UpdateMachineDataAsync(Guid id, string data)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                machine.LastData = data;
                machine.LastDataReceived = DateTime.Now;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
