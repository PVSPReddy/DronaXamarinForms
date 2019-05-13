using System;
using Android.Content;
using Android.Graphics;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundEdgeStackLayout), typeof(AndroidRoundEdgeStackLayoutRender))]
namespace FireBaseTestPOC.Droid.CustomControls
{
    public class AndroidRoundEdgeStackLayoutRender : VisualElementRenderer<StackLayout>
    {
        Context context;

        private float _cornerRadius;
        private RectF _bounds;
        private Path _path;
        private Xamarin.Forms.Color StartColor { get; set; }
        private Xamarin.Forms.Color EndColor { get; set; }
        private GradientStyle gradientStyle { get; set; }
        RoundEdgeStackLayout stack;
        private Canvas CustomCanvas { get; set; }

        public AndroidRoundEdgeStackLayoutRender(Context _context) : base(_context)
        {
            context = _context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                stack = e.NewElement as RoundEdgeStackLayout;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            try
            {
                _cornerRadius = 0.0f;
                if (stack.CornerWRT == CornerRadiusReference.WRTHeightRequest && stack.CornerRadius == 0)
                {
                    _cornerRadius = (stack.HeightRequest > 0) ? (float)(stack.HeightRequest) : 0.0f;
                }
                else if (stack.CornerWRT == CornerRadiusReference.WRTWidthRequest && stack.CornerRadius == 0)
                {
                    _cornerRadius = (stack.WidthRequest > 0) ? (float)(stack.WidthRequest) : 0.0f;
                }
                else
                {
                    _cornerRadius = (float)(stack.CornerRadius);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            if (w != oldw && h != oldh)
            {
                _bounds = new RectF(0, 0, w, h);
            }
            _path = new Path();
            _path.Reset();
            _path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
            //_path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Ccw);
            _path.Close();
        }

        private void CustomDispatchDraw(Canvas canvas)
        {
            try
            {
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
                this.gradientStyle = stack.GradientDirection;
                if (_path != null) 
                {
                    int height = Height;
                    int width = Width;

                    if (gradientStyle == GradientStyle.Vertical)
                    {
                        width = 0;
                    }
                    else if (gradientStyle == GradientStyle.Horizontal)
                    {
                        height = 0;
                    }
                    else 
                    {
                        height = 0;
                    }

                    var gradient = new Android.Graphics.LinearGradient(0, 0, width, height, this.StartColor.ToAndroid(), this.EndColor.ToAndroid(), Android.Graphics.Shader.TileMode.Mirror);
                    var paint = new Android.Graphics.Paint()
                    {
                        Dither = true,
                    };

                    paint.SetShader(gradient);
                    canvas.Save();
                    canvas.ClipPath(_path);
                    canvas.DrawPaint(paint);
                    try
                    {
                        if (stack.HasBorderColor == true)
                        {
                            var borderPaint = new Paint();
                            borderPaint.AntiAlias = true;
                            borderPaint.StrokeWidth = 2;
                            borderPaint.SetStyle(Paint.Style.Stroke);
                            borderPaint.Color = stack.BorderColor.ToAndroid();//global::Android.Graphics.Color.White;
                            canvas.DrawPath(_path, borderPaint);
                        }
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message + "\n" + ex.StackTrace;
                        System.Diagnostics.Debug.WriteLine(msg);
                    }
                    canvas.Restore();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            CustomCanvas = canvas;
            CustomDispatchDraw(CustomCanvas);
            //base.Draw(canvas);
            base.DispatchDraw(canvas);
            canvas.Restore();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            System.Diagnostics.Debug.WriteLine("Current Page is " + this.GetType().ToString() + " : " + e.PropertyName);
            if(CustomCanvas != null)
            {
                CustomDispatchDraw(CustomCanvas);
            }
        }
    }
}