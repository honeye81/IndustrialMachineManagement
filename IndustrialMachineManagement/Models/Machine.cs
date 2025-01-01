﻿namespace IndustrialMachineManagement.Models
{
    public class Machine
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public DateTime LastDataReceived { get; set; }
        public string LastData { get; set; } = string.Empty;
    }
}
