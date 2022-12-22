namespace Decoy.Domain.Models
{
    public class QuoteDetailsItem
    {
        #region Properties

        public string Operation { get; set; }

        public string Value { get; set; }

        public Guid ValueId { get; set; }

        public int TimeImpactRating { get; set; }

        public int CostImpactRating { get; set; }

        public List<ValidValue> ValidValues { get; set; }

        #endregion
    }
}
