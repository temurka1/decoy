namespace Decoy.Domain.Models
{
    public class QuoteItem
    {
        #region Properties

        public string ManufacturingStage { get; set; } = string.Empty;

        public string Parameter { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

        public int TimeImpact { get; set; }

        public decimal CostImpact { get; set; }

        public List<QuoteDetailsItem> Details { get; set; }

        #endregion
    }
}
