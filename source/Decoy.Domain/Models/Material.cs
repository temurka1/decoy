namespace Decoy.Domain.Models
{
    public class Material
    {
        public string Name { get; set; } = string.Empty;

        public decimal CostImpact { get; set; }

        public int TimeImpact { get; set; }
    }
}
