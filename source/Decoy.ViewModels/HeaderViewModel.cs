namespace Decoy.ViewModels
{
    using Prism.Mvvm;

    public class HeaderViewModel : BindableBase
    {
        #region Fields

        private string _updateStatus;
        private string _message;

        #endregion

        #region Properties

        public string UpdateStatus
        {
            get => _updateStatus;
            set => SetProperty(ref _updateStatus, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        #endregion

        #region Constructors

        public HeaderViewModel()
        {
            _message = $"Describe your design and receive real-time design feedback for manufacturing and{Environment.NewLine}component sourcing. If you update your design, we will provide an updated quote.";
            _updateStatus = "Everything is up to date ✓";
        }

        #endregion
    }
}
