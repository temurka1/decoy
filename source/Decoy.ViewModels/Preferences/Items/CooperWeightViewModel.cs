namespace Decoy.ViewModels.Preferences.Items
{
    using Prism.Mvvm;

    using Decoy.Domain.Models;

    public class CooperWeightViewModel : BindableBase
    {
        #region Fields

        private string _value;

        #endregion

        #region Properties

        public CooperWeight Model { get; }

        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        #endregion

        #region Constructors

        public CooperWeightViewModel(CooperWeight copperWeight)
        {
            Model = copperWeight ?? throw new ArgumentNullException(nameof(copperWeight));
            Value = copperWeight.Value;
        }

        #endregion
    }
}
