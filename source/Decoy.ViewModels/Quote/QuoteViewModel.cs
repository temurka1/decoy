namespace Decoy.ViewModels.Quote
{
    using Prism.Mvvm;

    using Decoy.Domain.Models;
    using Decoy.Domain.Services;

    public class QuoteViewModel : BindableBase
    {
        #region Fields

        private readonly ProjectSettings _projectSettings;

        private ParameterTableViewModel _parameterTable;
        private ParameterPanelViewModel _parameterPanel;

        #endregion

        #region Properties

        public ParameterTableViewModel ParameterTable
        {
            get => _parameterTable;
            set => SetProperty(ref _parameterTable, value);
        }

        public ParameterPanelViewModel ParameterPanel
        {
            get => _parameterPanel;
            set => SetProperty(ref _parameterPanel, value);
        }

        #endregion

        #region Constructors

        public QuoteViewModel(ProjectSettings projectSettings, IQuoteGenerator quoteGenerator)
        {
            _projectSettings = projectSettings ?? throw new ArgumentNullException(nameof(projectSettings));

            _parameterTable = new ParameterTableViewModel(quoteGenerator);
            _parameterPanel = new ParameterPanelViewModel();
        }

        #endregion

        #region Methods

        public void Update()
        {
            ParameterTable.Update(_projectSettings);
            ParameterPanel.Update(ParameterTable.QuoteTableData.AsEnumerable(), ParameterTable.TotalTimeImpact, ParameterTable.TotalCostImpact);
        }

        #endregion
    }
}
