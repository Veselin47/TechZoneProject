namespace TechZoneProject.Data.Models
{
    public class Gpu : Product
    {
        public int WarrantyMonths { get; set; }
        public int MemorySizeGb { get; set; }
        public string MemoryType { get; set; } = null!; 
        public int CudaCores { get; set; }
        public int BusWidthBit { get; set; }
        public int FrequencyMhz { get; set; }
        public string Connectors { get; set; } = null!; 
    }
}