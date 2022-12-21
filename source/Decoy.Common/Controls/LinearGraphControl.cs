namespace Decoy.Common.Controls
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Collections.Generic;

    using Extensions;
    using System.Globalization;

    public class LinearGraphControl : FrameworkElement
    {
        #region Fields

        private readonly List<Pen> _pensPalette;
        private readonly Typeface _typeface;

        private readonly double _pixelsPerDip;

        #endregion

        #region DependencyProperties

        public static readonly DependencyProperty GraphDataProperty =
            DependencyProperty.Register("GraphData", typeof(LinearGraphData), typeof(LinearGraphControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty LineHeightProperty =
            DependencyProperty.Register("LineHeight", typeof(double), typeof(LinearGraphControl), new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ForegroundBrushProperty =
            DependencyProperty.Register("ForegroundBrush", typeof(Brush), typeof(LinearGraphControl), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #region Properties

        public LinearGraphData GraphData
        {
            get => (LinearGraphData)GetValue(GraphDataProperty);
            set => SetValue(GraphDataProperty, value);
        }

        public double LineHeight
        {
            get => (double)GetValue(LineHeightProperty);
            set => SetValue(LineHeightProperty, value);
        }

        public Brush ForegroundBrush
        {
            get => (Brush)GetValue(ForegroundBrushProperty);
            set => SetValue(ForegroundBrushProperty, value);
        }

        #endregion

        #region Constructors

        public LinearGraphControl()
        {
            _typeface = new Typeface("Segoe UI");
            _pixelsPerDip = VisualTreeHelper.GetDpi(this).PixelsPerDip;

            var snap = Render.SnapToPixels(1.0);

            _pensPalette = new List<Pen>
            {
                new Pen(new SolidColorBrush(Color.FromRgb(226,135,67)), snap),
                new Pen(new SolidColorBrush(Color.FromRgb(30,129,176)), snap),
                new Pen(new SolidColorBrush(Color.FromRgb(120,164,104)), snap)
            };
        }

        #endregion

        #region Methods

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (GraphData == null || !GraphData.Items.Any())
                return;

            var graphData = GraphData.Items
                .Where(x => x.Percentage > 0.0M)
                .ToList();

            var actualWidth = Convert.ToDecimal(ActualWidth);
            var totalWidth = 0.0;

            for (int i = 0; i < graphData.Count; i++)
            {
                var item = graphData[i];

                var itemWidth = Decimal.ToDouble(item.Percentage * actualWidth);
                var itemPen = _pensPalette[i % _pensPalette.Count];

                var itemRect = new Rect(totalWidth, 0.0, itemWidth, LineHeight);

                switch (i)
                {
                    case 0:
                    {
                        drawingContext.DrawRoundedRectangle(itemPen.Brush, itemPen, itemRect, new CornerRadius(2.0, 0.0, 0.0, 2.0));
                        break;
                    }

                    case var _ when i == graphData.Count - 1:
                    {
                        drawingContext.DrawRoundedRectangle(itemPen.Brush, itemPen, itemRect, new CornerRadius(0.0, 2.0, 2.0, 0.0));
                        break;
                    }

                    default:
                        drawingContext.DrawRectangle(itemPen.Brush, itemPen, itemRect);
                        break;
                }

                var itemName = new FormattedText(
                    $"{item.Description} - {item.Percentage * 100:G2}%",
                    CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    _typeface,
                    12.0,
                    itemPen.Brush,
                    _pixelsPerDip);

                var itemTotal = new FormattedText(
                    item.Value,
                    CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    _typeface,
                    12.0,
                    ForegroundBrush,
                    _pixelsPerDip);

                var textPositionX = i == graphData.Count - 1
                    ? totalWidth + itemWidth - Math.Max(itemName.Width, itemTotal.Width)
                    : totalWidth;

                drawingContext.DrawText(itemName, new Point(textPositionX, 10.0));
                drawingContext.DrawText(itemTotal, new Point(textPositionX, 27.0));

                totalWidth += itemWidth;
            }
        }

        #endregion
    }
}
