namespace Decoy.Common
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Threading.Tasks;

    using MvvmValidation;

    using Prism.Mvvm;

    public abstract class ValidatableBindableBase : BindableBase, IValidatable, INotifyDataErrorInfo, IDisposable
    {
        #region Fields

        private bool _hasErrors;

        #endregion

        #region Properties

        protected ValidationHelper Validator { get; }

        private NotifyDataErrorInfoAdapter NotifyDataErrorInfoAdapter { get; }

        public bool HasErrors
        {
            get => _hasErrors;
            set => SetProperty(ref _hasErrors, value);
        }

        #endregion

        #region Events

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add 
            { 
                NotifyDataErrorInfoAdapter.ErrorsChanged += value; 
            }
            remove 
            { 
                NotifyDataErrorInfoAdapter.ErrorsChanged -= value; 
            }
        }

        #endregion

        #region Constructors

        protected ValidatableBindableBase()
        {
            Validator = new ValidationHelper();

            NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);
            NotifyDataErrorInfoAdapter.ErrorsChanged += HandleErrorsChanged;

            PropertyChanged += HandlePropertyChanged;
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            PropertyChanged -= HandlePropertyChanged;
            NotifyDataErrorInfoAdapter.ErrorsChanged -= HandleErrorsChanged;
        }

        public Task<ValidationResult> Validate()
        {
            return Validator.ValidateAllAsync();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return NotifyDataErrorInfoAdapter.GetErrors(propertyName);
        }

        private void HandleErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            HasErrors = NotifyDataErrorInfoAdapter.HasErrors;
            RaisePropertyChanged(e.PropertyName);
        }

        private void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Validate();
        }

        #endregion
    }
}
