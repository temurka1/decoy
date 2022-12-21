namespace Decoy.Common
{
    using System.Reflection;
    using System.Windows;

    public static class Render
    {
        #region Fields

        private static readonly double _halfPixelSize;

        #endregion

        #region Properties

        public static double PixelSize { get; }

        public static int Dpi { get; }

        #endregion

        #region Constructors

        static Render()
        {
            const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Static;
            var dpiProperty = typeof(SystemParameters).GetProperty("Dpi", flags);

            Dpi = (int)dpiProperty.GetValue(null, null);
            PixelSize = 96.0 / Dpi;
            _halfPixelSize = PixelSize / 2;
        }

        #endregion

        #region Methods

        static public double SnapToPixels(double value)
        {
            value += _halfPixelSize;

            var div = (value * 1000) / (PixelSize * 1000);

            return (int)div * PixelSize;
        }

        #endregion
    }
}
