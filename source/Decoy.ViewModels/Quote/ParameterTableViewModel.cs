namespace Decoy.ViewModels.Quote
{
    using System.Collections.ObjectModel;

    using Prism.Mvvm;

    using Domain.Models;
    using Domain.Services;

    public class ParameterTableViewModel : BindableBase
    {
        #region Fields

        private readonly IQuoteGenerator _quoteGenerator;

        private ObservableCollection<QuoteItem> _quoteTableData;

        private decimal _totalCostImpact;
        private int _totalTimeImpact;

        #endregion

        #region Properties

        public ObservableCollection<QuoteItem> QuoteTableData
        {
            get => _quoteTableData;
            set => SetProperty(ref _quoteTableData, value);
        }

        public decimal TotalCostImpact
        {
            get => _totalCostImpact;
            set => SetProperty(ref _totalCostImpact, value);
        }

        public int TotalTimeImpact
        {
            get => _totalTimeImpact;
            set => SetProperty(ref _totalTimeImpact, value);
        }

        #endregion

        #region Constructor

        public ParameterTableViewModel(IQuoteGenerator quoteGenerator)
        {
            _quoteGenerator = quoteGenerator ?? throw new ArgumentNullException(nameof(quoteGenerator));
        }

        #endregion

        #region Methods

        public void Update(ProjectSettings projectSettings)
        {
            QuoteTableData = new ObservableCollection<QuoteItem>(_quoteGenerator.GetQuote(projectSettings));

            TotalCostImpact = QuoteTableData.Sum(x => x.CostImpact);
            TotalTimeImpact = QuoteTableData.Sum(x => x.TimeImpact);
        }

        #endregion
    }
}
