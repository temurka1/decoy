namespace Decoy.Domain.Models
{
    public class QuoteDetailsItem
    {
        #region Properties

        public string Operation { get; set; }

        public string OperationDetails { get; set; }

        public int TimeImpactRating { get; set; }

        public int CostImpactRating { get; set; }

        public List<ValidValue> ValidValues { get; set; }

        #endregion
    }
}
