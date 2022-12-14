namespace Decoy.ViewModels.Quote.Details
{
    using Prism.Mvvm;
    using Decoy.Domain.Models;
    using System.Collections.ObjectModel;

    public class DetailsItemViewModel : BindableBase
    {
        #region Fields

        public string _operation;
        public string _value;

        private int _timeImpactRating;
        private int _costImpactRating;

        private ValidValuesViewModel _validValues;

        #endregion

        #region Properties

        public string Operation 
        { 
            get => _operation; 
            set => SetProperty(ref _operation, value); 
        }

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

        public ValidValuesViewModel ValidValues
        {
            get => _validValues;
            set => SetProperty(ref _validValues, value);
        }

        #endregion

        #region Constructors

        public DetailsItemViewModel(QuoteDetailsItem details) 
        {
            _operation = details.Operation;
            _value = details.Value;

            _costImpactRating = details.CostImpactRating;
            _timeImpactRating = details.TimeImpactRating;

            _validValues = new ValidValuesViewModel(details);
        }

        #endregion
    }
}
