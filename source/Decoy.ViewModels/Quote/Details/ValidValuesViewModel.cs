namespace Decoy.ViewModels.Quote.Details
{
    using System.Collections.ObjectModel;

    using Prism.Mvvm;

    using Decoy.Domain.Models;

    public class ValidValuesViewModel : BindableBase
    {
        #region Fields

        private ObservableCollection<ValidValueViewModel> _values;

        #endregion

        #region Properties

        public ObservableCollection<ValidValueViewModel> Values
        {
            get => _values;
            set => SetProperty(ref _values, value);
        }

        #endregion

        #region Constructors

        public ValidValuesViewModel(QuoteDetailsItem details)
        {
            _values = new ObservableCollection<ValidValueViewModel>(
                details.ValidValues?.Select(x => new ValidValueViewModel(x, x.Id == details.ValueId)) ?? new List<ValidValueViewModel>());
        }

        #endregion
    }
}
