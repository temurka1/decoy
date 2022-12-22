namespace Decoy.ViewModels.Quote.Details
{
    using Prism.Mvvm;
    using Decoy.Domain.Models;

    public class ValidValueViewModel : BindableBase
    {
        #region Fields

        public string _value;
        public string _operationDetails;

        private int _timeImpactRating;
        private int _costImpactRating;

        private bool _isCurrent;

        #endregion

        #region Properties

        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public int TimeImpactRating
        {
            get => _timeImpactRating;
            set => SetProperty(ref _timeImpactRating, value);
        }

        public int CostImpactRating
        {
            get => _costImpactRating;
            set => SetProperty(ref _costImpactRating, value);
        }

        public bool IsCurrent
        {
            get => _isCurrent;
            set => SetProperty(ref _isCurrent, value);
        }

        #endregion

        #region Constructors

        public ValidValueViewModel(ValidValue validValue, bool isCurrent)
        {
            _value = validValue.Value;
            _costImpactRating = validValue.CostImpactRating;
            _timeImpactRating = validValue.TimeImpactRating;

            _isCurrent = isCurrent;
        }

        #endregion
    }
}
