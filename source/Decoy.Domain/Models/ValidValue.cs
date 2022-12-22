namespace Decoy.Domain.Models
{
    public class ValidValue
    {
        #region Properties

        public Guid Id { get; set; }

        public string Value { get; set; }

        public int CostImpactRating { get; set; }

        public int TimeImpactRating { get; set; }

        #endregion
    }
}
