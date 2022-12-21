namespace Decoy.ViewModels.Preferences.Items
{
    using System.Windows.Media;
    using Prism.Mvvm;

    using Decoy.Domain.Models;

    public class SolderMasksViewModel : BindableBase
    {
        #region Fields

        private string _name;
        private Color _color;

        #endregion

        #region Properties

        public SolderMask Model { get; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public Color Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        #endregion

        #region Constructors

        public SolderMasksViewModel(SolderMask solderMask)
        {
            Model = solderMask ?? throw new ArgumentNullException(nameof(solderMask));

            Name = solderMask.Name;
            Color = Color.FromRgb(solderMask.R, solderMask.G, solderMask.B);
        }

        #endregion
    }
}
