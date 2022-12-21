namespace Decoy.Common.Controls
{
    using System.Windows;
    using System.Windows.Media;

    public class RatingControl : FrameworkElement
    {
        #region DependencyProperties

        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register("Rating", typeof(int), typeof(RatingControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty MaxRatingProperty =
            DependencyProperty.Register("MaxRating", typeof(int), typeof(RatingControl), new FrameworkPropertyMetadata(5, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty RatedBrushProperty =
            DependencyProperty.Register("RatedBrush", typeof(Brush), typeof(RatingControl), new FrameworkPropertyMetadata(Brushes.Green, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty UnratedBrushProperty =
            DependencyProperty.Register("UnratedBrush", typeof(Brush), typeof(RatingControl), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Properties

        public int Rating
        {
            get => (int)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }
        public int MaxRating
        {
            get => (int)GetValue(MaxRatingProperty);
            set => SetValue(MaxRatingProperty, value);
        }

        public Brush RatedBrush
        {
            get => (Brush)GetValue(RatedBrushProperty);
            set => SetValue(RatedBrushProperty, value);
        }

        public Brush UnratedBrush
        {
            get => (Brush)GetValue(UnratedBrushProperty);
            set => SetValue(UnratedBrushProperty, value);
        }

        #endregion

        #region Methods

        protected override void OnRender(DrawingContext drawingContext)
        {
            var snap = Render.SnapToPixels(1.0);

            var ratedPen = new Pen(RatedBrush, snap);
            var unratedPen = new Pen(UnratedBrush, snap);

            var width = 1.0;
            var y = ActualHeight / 2.0;

            for (int i = 0; i < Rating; i++)
            {
                drawingContext.DrawEllipse(RatedBrush, ratedPen, new Point(width, y), 4, 4);
                width += 10;
            }

            for (int i = Rating; i < MaxRating; i++)
            {
                drawingContext.DrawEllipse(UnratedBrush, unratedPen, new Point(width, y), 4, 4);
                width += 10;
            }
        }

        #endregion
    }
}
