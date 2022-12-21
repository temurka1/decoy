namespace Decoy.ViewModels.Order
{
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

        #endregion

        #region Constructors

        public OrderViewModel()
        {
            Message = $"There are no orders yet.{Environment.NewLine}Your orders will appear here.";
        }

        #endregion
    }
}
