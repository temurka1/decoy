namespace Decoy.ViewModels.Quote.Details
{
    using Prism.Mvvm;
    using Decoy.Domain.Models;

    public class DetailsItemViewModel : BindableBase
    {
        #region Fields

        public string _operation;
        public string _operationDetails;

        private int _timeImpactRating;
        private int _costImpactRating;

        #endregion

        #region Fields

        public string Operation 
        { 
            get => _operation; 
            set => SetProperty(ref _operation, value); 
        }

        public string OperationDetails
        {
            get => _operationDetails;
            set => SetProperty(ref _operationDetails, value);
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

        #endregion

        #region Properties

        public DetailsItemViewModel(QuoteDetailsItem details) 
        {
            _operation = details.Operation;
            _operationDetails = details.OperationDetails;

            _costImpactRating = details.CostImpactRating;
            _timeImpactRating = details.TimeImpactRating;
        }

        #endregion
    }
}
