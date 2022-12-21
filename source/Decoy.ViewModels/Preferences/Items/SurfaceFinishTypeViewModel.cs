namespace Decoy.ViewModels.Preferences.Items
{
    using Decoy.Domain.Models;
    using Prism.Mvvm;

    public class SurfaceFinishTypeViewModel : BindableBase
    {
        #region Fields

        private string _name;
        private decimal _costImpact;
        private int _timeImpact;

        #endregion

        #region Properties

        public SurfaceFinishType Model { get; }

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

        public SurfaceFinishTypeViewModel(SurfaceFinishType surfaceFinishType)
        {
            Model = surfaceFinishType ?? throw new ArgumentNullException(nameof(surfaceFinishType));

            Name = surfaceFinishType.Name;
            CostImpact = surfaceFinishType.CostImpact;
            TimeImpact = surfaceFinishType.TimeImpact;
        }

        #endregion
    }
}
