using System.Printing;
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
using System.Windows.Threading;

namespace dynamiccanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private List<MovingEllipse> movingEllipses = new List<MovingEllipse>();
        private DispatcherTimer timer;
        private const double ellRadious = 15;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16),
            };
            timer.Tick += MoveObjects;
            timer.Start();
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPosition = e.GetPosition(canvas);
            Ellipse ellipse = new Ellipse
            {
                Width = 30,
                Height = 30,
                Fill = Brushes.Red,
                Stroke = Brushes.Red,
                StrokeThickness = 1
            };

            Canvas.SetLeft(ellipse, clickPosition.X - 15);
            Canvas.SetTop(ellipse, clickPosition.Y - 15);
            canvas.Children.Add(ellipse);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int ilosc;
            if(int.TryParse(textBox.Text, out ilosc))
            {
                for(int i =0; i < ilosc; i++)
                {
                    SolidColorBrush color = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                    Ellipse ellipse = new Ellipse
                    {
                        Width = ellRadious*2,
                        Height = ellRadious*2,
                        Fill = color,
                        Stroke = color,
                        StrokeThickness = 1
                    };
                    double x = ellRadious + random.NextDouble() * (canvas.ActualWidth - ellRadious);
                    double y = ellRadious + random.NextDouble() * (canvas.ActualHeight - ellRadious);
                    Canvas.SetLeft(ellipse, x);
                    Canvas.SetTop(ellipse, y);
                    MovingEllipse movEllipse = new MovingEllipse(ellipse, x, y, random.NextDouble() * 3 - 6, random.NextDouble() * 3 -6);
                    canvas.Children.Add(ellipse);
                    movingEllipses.Add(movEllipse);
                }
            }
            else
            {
                MessageBox.Show("Ilosc kulek musi byc liczba", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MoveObjects(object sender, EventArgs e)
        {
            foreach (MovingEllipse el in movingEllipses)
            {
                if(el.posX + el.velX + ellRadious * 2 >= canvas.ActualWidth)
                {
                    el.velX = -Math.Abs(el.velX);
                }
                else if(el.posX + el.velX <= 0)
                {
                    el.velX = Math.Abs(el.velX);
                }
                if (el.posY + el.velY + ellRadious * 2>= canvas.ActualHeight)
                {
                    el.velY = -Math.Abs(el.velY);
                }
                else if (el.posY + el.velY <= 0)
                {
                    el.velY = Math.Abs(el.velY);
                }
                CheckForCollisions(el);
                el.posX += el.velX;
                el.posY += el.velY;
                Canvas.SetLeft(el.Ellipse, el.posX);
                Canvas.SetTop(el.Ellipse, el.posY);
            }
        }
        private void CheckForCollisions(MovingEllipse el)
        {
            foreach (MovingEllipse other in movingEllipses)
            {
                if (el == other) continue;
                //double dist = Distance(el.posX, el.posY, other.posX, other.posY);
                double Xdiff = other.posX - el.posX;
                double Ydiff = other.posY - el.posY;
                if(Xdiff > 0 && Xdiff <= ellRadious * 2 && Ydiff > 0 && Ydiff <= ellRadious * 2)
                {
                    el.velX = -Math.Abs(el.velX);
                    el.velY = -Math.Abs(el.velY);
                    other.velX = Math.Abs(other.velX);
                    other.velY = Math.Abs(other.velY);
                }
                else if (Xdiff < 0 && Math.Abs(Xdiff) <= ellRadious * 2 && Ydiff > 0 && Ydiff <= ellRadious * 2)
                {
                    el.velX = Math.Abs(el.velX);
                    el.velY = -Math.Abs(el.velY);
                    other.velX = -Math.Abs(other.velX);
                    other.velY = Math.Abs(other.velY);
                }
                else if (Xdiff > 0 && Xdiff <= ellRadious * 2 && Ydiff < 0 && Math.Abs(Ydiff) <= ellRadious * 2)
                {
                    el.velX = -Math.Abs(el.velX);
                    el.velY = Math.Abs(el.velY);
                    other.velX = Math.Abs(other.velX);
                    other.velY = -Math.Abs(other.velY);
                }
                else if (Xdiff < 0 && Math.Abs(Xdiff) <= ellRadious * 2 && Ydiff < 0 && Math.Abs(Ydiff) <= ellRadious * 2)
                {
                    el.velX = Math.Abs(el.velX);
                    el.velY = Math.Abs(el.velY);
                    other.velX = -Math.Abs(other.velX);
                    other.velY = -Math.Abs(other.velY);
                }



            }
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        public class MovingEllipse
        {
            public Ellipse Ellipse;
            public double posX;
            public double posY;
            public double velX;
            public double velY;


            public MovingEllipse(Ellipse ellipse, double posX, double posY, double velX, double velY)
            {
                Ellipse = ellipse;
                this.posX = posX;
                this.posY = posY;
                this.velX = velX;
                this.velY = velY;
            }
        }
    }
}