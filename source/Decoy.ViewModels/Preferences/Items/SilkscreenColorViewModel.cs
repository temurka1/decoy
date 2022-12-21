namespace Decoy.ViewModels.Preferences.Items
{
    using System.Windows.Media;
    using Prism.Mvvm;

    using Decoy.Domain.Models;

    public class SilkscreenColorViewModel : BindableBase
    {
        #region Fields

        private string _name;
        private Color _color;

        #endregion

        #region Properties

        public SilkscreenColor Model { get; }

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

        public SilkscreenColorViewModel(SilkscreenColor silkscreenColor)
        {
            Model = silkscreenColor ?? throw new ArgumentNullException(nameof(silkscreenColor));

            Name = silkscreenColor.Name;
            Color = Color.FromRgb(silkscreenColor.R, silkscreenColor.G, silkscreenColor.B);
        }

        #endregion
    }
}
