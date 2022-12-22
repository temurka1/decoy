namespace Decoy.ViewModels.Order
{
    using Prism.Commands;
    using Prism.Mvvm;

    public class OrderViewModel : BindableBase
    {
        #region Fields

        private string _message;

        #endregion

        #region Properties

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand MakeOrderCommand { get; }

        #endregion

        #region Constructors

        public OrderViewModel()
        {
            Message = $"There are no orders yet.{Environment.NewLine}Your orders will appear here.";

            MakeOrderCommand = new DelegateCommand(ExecuteMakeOrderCommand);
        }

        #endregion

        #region Methods

        private async void ExecuteMakeOrderCommand()
        {
        }

        #endregion
    }
}
