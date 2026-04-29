using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiplyingCircles
{
    public class Ball
    {
        public Ellipse ellipse;
        public double posX;
        public double posY;
        public double velX;
        public double velY;

        public Ball(Ellipse Ellipse, double x, double y,  double velX, double velY)
        {
            ellipse = Ellipse;
            posX = x; posY = y;
            this.velX = velX;
            this.velY = velY;
        }
    }

    public partial class MainWindow : Window
    {
        private List<Ball> balls = new List<Ball>();
        private const double ballRadious = 15;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            CreateBall(10, 10, true);
            _ = Update();
            Task.Run(Update);
        }

        public void CreateBall(double x, double y, bool isParent = false)
        {
            double velX = (random.NextDouble()-0.5)*2;
            double velY = (random.NextDouble() - 0.5) * 2;
            SolidColorBrush color = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
            Ellipse ellipse = new Ellipse
            {
                Width = 30,
                Height = 30,
                Fill = color,
                Stroke = color,
                StrokeThickness = 1
            };
            Ball ball = new Ball(ellipse, x, y, velX, velY);
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
            canvas.Children.Add(ellipse);
            if(isParent) ellipse.MouseLeftButtonDown += EllipseMouseLeftButtonDown;
            balls.Add(ball);
        }

        private void EllipseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(this);
            if (sender is Ellipse clickedEllipse)
            {
                CreateBall(clickPoint.X, clickPoint.Y);
            }
        }

        private void MoveBalls()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                Ball el = balls[i];
                if (el.posX + el.velX + ballRadious * 2 >= canvas.ActualWidth)
                {
                    el.velX = -Math.Abs(el.velX);
                }
                else if (el.posX + el.velX <= 0)
                {
                    el.velX = Math.Abs(el.velX);
                }
                if (el.posY + el.velY + ballRadious * 2 >= canvas.ActualHeight)
                {
                    el.velY = -Math.Abs(el.velY);
                }
                else if (el.posY + el.velY <= 0)
                {
                    el.velY = Math.Abs(el.velY);
                }
                el.posX += el.velX;
                el.posY += el.velY;
                Canvas.SetLeft(el.ellipse, el.posX);
                Canvas.SetTop(el.ellipse, el.posY);
            }
        }

        public async Task Update()
        {
            MoveBalls();
            await Task.Delay(5);
            await Update();
        }
    }
}