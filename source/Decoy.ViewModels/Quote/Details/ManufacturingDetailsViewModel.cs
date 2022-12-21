namespace Decoy.ViewModels.Quote.Details
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Prism.Mvvm;

    using Decoy.Domain.Models;

    public class ManufacturingDetailsViewModel : BindableBase
    {
        #region Fields

        private string _manufacturingStage;
        private string _impacts;

        private ObservableCollection<DetailsItemViewModel> _items;

        #endregion

        #region Properties

        public string ManufacturingStage
        {
            get => _manufacturingStage;
            set => SetProperty(ref _manufacturingStage, value);
        }

        public string Impacts
        {
            get => _impacts;
            set => SetProperty(ref _impacts, value);
        }

        public ObservableCollection<DetailsItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        #endregion

        #region Constructors

        public ManufacturingDetailsViewModel(string key, IEnumerable<QuoteItem> quoteItems)
        {
            ManufacturingStage = key;
            Impacts = $"${quoteItems.Sum(x => x.CostImpact):0,0.00}, {quoteItems.Sum(x => x.TimeImpact)} days";

            var details = quoteItems
                .Where(x => x.Details != null)
                .SelectMany(x => x.Details)
                .Select(x => new DetailsItemViewModel(x));

            Items = new ObservableCollection<DetailsItemViewModel>(details);
        }

        #endregion
    }
}
