namespace Decoy.ViewModels
{
    using Prism.Mvvm;
    using Prism.Commands;

    using Infrastructure;

    using Domain.Models;
    using Domain.Services;

    using Preferences;
    using Quote;
    using Order;

    public class MainViewModel : BindableBase
    {
        #region Fields

        private readonly ProjectSettings _projectSettings;

        private HeaderViewModel _header;

        private PreferencesViewModel _preferences;
        private QuoteViewModel _quote;
        private OrderViewModel _order;


        private bool _isPreferencesTabExpanded;
        private bool _isQuoteTabExpanded;
        private bool _isOrderTabExpanded;

        #endregion

        #region Properties

        public HeaderViewModel Header 
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        public PreferencesViewModel Preferences
        {
            get => _preferences;
            set => SetProperty(ref _preferences, value);
        }

        public QuoteViewModel Quote
        {
            get => _quote;
            set => SetProperty(ref _quote, value);
        }

        public OrderViewModel Order
        {
            get => _order;
            set => SetProperty(ref _order, value);
        }

        public bool IsPreferencesTabExpanded
        {
            get => _isPreferencesTabExpanded;
            set
            {
                if (SetProperty(ref _isPreferencesTabExpanded, value))
                {
                    IsQuoteTabExpanded = !_isPreferencesTabExpanded;
                }
            }
        }

        public bool IsQuoteTabExpanded
        {
            get => _isQuoteTabExpanded;
            set => SetProperty(ref _isQuoteTabExpanded, value);
        }

        public bool IsOrderTabExpanded
        {
            get => _isOrderTabExpanded;
            set => SetProperty(ref _isOrderTabExpanded, value);
        }

        public DelegateCommand UpdateCommand { get; }

        public DelegateCommand PlaceOrderCommand { get; }

        public DelegateCommand ResetCommand { get; }

        public DelegateCommand SaveCommand { get; }

        #endregion

        #region Constructors

        public MainViewModel(DecoyDbContext dbContext, IQuoteGenerator quoteGenerator)
        {
            _projectSettings = new ProjectSettings();

            Header = new HeaderViewModel();

            Preferences = new PreferencesViewModel(_projectSettings, dbContext);
            Quote = new QuoteViewModel(_projectSettings, quoteGenerator);
            Order = new OrderViewModel();

            UpdateCommand = new DelegateCommand(ExecuteUpdateCommand);
            PlaceOrderCommand = new DelegateCommand(ExecutePlaceOrderCommand, CanExecutePlaceOrderCommand)
                .ObservesProperty(() => IsPreferencesTabExpanded);

            ResetCommand = new DelegateCommand(ExecuteResetCommand);
            SaveCommand = new DelegateCommand(ExecuteSaveCommand, CanExecuteSaveCommand)
                .ObservesProperty(() => Preferences.ProjectBasics.HasErrors);

            IsPreferencesTabExpanded = true;
        }

        #endregion

        #region Methods

        private async void ExecuteUpdateCommand()
        {
            Header.UpdateStatus = "Updating... 🗘";

            await Task.Delay(3000).ConfigureAwait(false);

            Header.UpdateStatus = "Everything is up to date ✓";
        }

        private bool CanExecutePlaceOrderCommand()
        {
            return !IsPreferencesTabExpanded;
        }

        private void ExecutePlaceOrderCommand()
        {
            IsOrderTabExpanded = true;

            Order.Message = $"Your order is here.{Environment.NewLine}Click button below to confirm it!";
        }

        private void ExecuteResetCommand()
        {
            Preferences.LoadDefaults();
        }

        private bool CanExecuteSaveCommand()
        {
            return !Preferences.ProjectBasics.HasErrors;
        }

        private void ExecuteSaveCommand()
        {
            IsPreferencesTabExpanded = false;
            IsOrderTabExpanded = false;

            Quote.Update();

            var days = $"{Quote.ParameterTable.TotalTimeImpact} {(Quote.ParameterTable.TotalTimeImpact == 1 ? "day" : "days")}";
            var boards = $"{_projectSettings.BoardsQuantity} {(_projectSettings.BoardsQuantity == 1 ? "board" : "boards")}";

            Header.Message = $"Your {boards} will be delivered in {days}.{Environment.NewLine}Running total ${Quote.ParameterTable.TotalCostImpact:0,0.00}";
        }

        #endregion
    }
}
