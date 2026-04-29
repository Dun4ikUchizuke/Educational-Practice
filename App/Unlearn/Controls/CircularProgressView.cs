using Microsoft.Maui.Graphics;

namespace Unlearn.Controls;

public class CircularProgressView : GraphicsView
{
    public static readonly BindableProperty ProgressProperty =
        BindableProperty.Create(
            nameof(Progress),
            typeof(double),
            typeof(CircularProgressView),
            0d,
            propertyChanged: (b, o, n) => ((CircularProgressView)b).Invalidate());

    public static readonly BindableProperty StrokeThicknessProperty =
        BindableProperty.Create(
            nameof(StrokeThickness),
            typeof(float),
            typeof(CircularProgressView),
            12f,
            propertyChanged: (b, o, n) => ((CircularProgressView)b).Invalidate());

    public static readonly BindableProperty TrackColorProperty =
        BindableProperty.Create(
            nameof(TrackColor),
            typeof(Color),
            typeof(CircularProgressView),
            Color.FromArgb("#2C2C2C"),
            propertyChanged: (b, o, n) => ((CircularProgressView)b).Invalidate());

    public static readonly BindableProperty ProgressColorProperty =
        BindableProperty.Create(
            nameof(ProgressColor),
            typeof(Color),
            typeof(CircularProgressView),
            Color.FromArgb("#1D6E52"),
            propertyChanged: (b, o, n) => ((CircularProgressView)b).Invalidate());

    /// <summary>0..1</summary>
    public double Progress
    {
        get => (double)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }

    public float StrokeThickness
    {
        get => (float)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    public Color TrackColor
    {
        get => (Color)GetValue(TrackColorProperty);
        set => SetValue(TrackColorProperty, value);
    }

    public Color ProgressColor
    {
        get => (Color)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
    }

    public CircularProgressView()
    {
        Drawable = new CircularProgressDrawable(this);
    }

    sealed class CircularProgressDrawable : IDrawable
    {
        private readonly CircularProgressView _view;

        public CircularProgressDrawable(CircularProgressView view) => _view = view;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();

            var size = Math.Min(dirtyRect.Width, dirtyRect.Height);
            var stroke = _view.StrokeThickness;

            // square rect centered, leaving room for stroke
            var rect = new RectF(
                dirtyRect.Center.X - size / 2 + stroke / 2,
                dirtyRect.Center.Y - size / 2 + stroke / 2,
                size - stroke,
                size - stroke);

            canvas.StrokeLineCap = LineCap.Round;
            canvas.StrokeSize = stroke;

            // Track
            canvas.StrokeColor = _view.TrackColor;
            canvas.DrawArc(rect, -90, 360, false, false);

            // Progress
            var p = Math.Clamp(_view.Progress, 0, 1);
            if (p > 0)
            {
                canvas.StrokeColor = _view.ProgressColor;
                canvas.DrawArc(rect, -90, (float)(360 * p), false, false);
            }

            canvas.RestoreState();
        }
    }
}