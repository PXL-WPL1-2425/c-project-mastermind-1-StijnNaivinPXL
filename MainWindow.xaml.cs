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

namespace MasterMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Array, less memory allocation
        private Colors[] colors = new Colors[4];

        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            for (int i = 0; i < colors.Length; i++)
            {
                //Typecasting int => enum:int
                colors[i] = (Colors)random.Next(0, colors.Length);
            }
            UpdateTiteName();
        }

        private void UpdateTiteName()
        {
            this.Title = $"Mastermind - {ColorString}";
        }

        private string ColorString => $"({string.Join(", ", colors)})";
    }

    //Inside a namespace, easier access.
    enum Colors : int
    {
        Blue,
        Red,
        Orange,
        Yellow,
        White,
    }
}