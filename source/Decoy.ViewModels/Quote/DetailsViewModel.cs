namespace Decoy.ViewModels.Quote
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Prism.Mvvm;

    using Decoy.Domain.Models;

    using Details;

    public class DetailsViewModel : BindableBase
    {
        #region Fields

        private ObservableCollection<ManufacturingDetailsViewModel> _perStageDetails;

        #endregion

        #region Properties

        public ObservableCollection<ManufacturingDetailsViewModel> PerStageDetails
        {
            get => _perStageDetails;
            set => SetProperty(ref _perStageDetails, value);
        }

        #endregion

        #region Constructors

        public DetailsViewModel()
        {
            _perStageDetails = new ObservableCollection<ManufacturingDetailsViewModel>();
        }

        #endregion

        #region Methods

        public void Update(IEnumerable<QuoteItem> quoteTableData)
        {
            PerStageDetails.Clear();

            var grouppedByManufacturingStage = quoteTableData
                .GroupBy(x => x.ManufacturingStage)
                .ToList();

            foreach (var group in grouppedByManufacturingStage)
            {
                PerStageDetails.Add(new ManufacturingDetailsViewModel(group.Key, group));
            }
        }

        #endregion
    }
}
