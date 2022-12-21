namespace Decoy.ViewModels.Preferences.Items
{
    using Decoy.Domain.Models;
    using Prism.Mvvm;

    public class MaterialViewModel : BindableBase
    {
        #region Fields

        private string _name;
        private decimal _costImpact;
        private int _timeImpact;

        #endregion

        #region Properties

        public Material Model { get; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public decimal CostImpact
        {
            get => _costImpact;
            set => SetProperty(ref _costImpact, value);
        }

        public int TimeImpact
        {
            get => _timeImpact;
            set => SetProperty(ref _timeImpact, value);
        }

        #endregion

        #region Constructors

        public MaterialViewModel(Material material)
        {
            Model = material ?? throw new ArgumentNullException(nameof(material));

            Name = material.Name;
            CostImpact = material.CostImpact;
            TimeImpact = material.TimeImpact;
        }

        #endregion
    }
}
