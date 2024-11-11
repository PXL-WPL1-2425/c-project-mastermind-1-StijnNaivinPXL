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
        private TypeColors[] colors = new TypeColors[4];

        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            // Ik hoop dat ik dit mag doen, ik verkies dit boven verbinden in XAML.
            //CheckCodeBtn.Click += OnClickCheckCodeBtn;
            SetupGame();
        }

        /*private void OnClickCheckCodeBtn(object sender, RoutedEventArgs e)
        {

        }*/

        private void SetupGame()
        {
            for (int i = 0; i < colors.Length; i++)
            {
                //Typecasting int => enum:int
                colors[i] = (TypeColors)random.Next(0, colors.Length);
            }
            UpdateTiteName();
            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            Color1Cb.Items.Clear();
            Color2Cb.Items.Clear();
            Color3Cb.Items.Clear();
            Color4Cb.Items.Clear();

            // Heel erg hacky, maar ik verkies wat meer leesbaarheid over strings te gebruiken.
            foreach (TypeColors color in (TypeColors[])Enum.GetValues(typeof(TypeColors)))
            {
                Color1Cb.Items.Add(color);
                Color2Cb.Items.Add(color);
                Color3Cb.Items.Add(color);
                Color4Cb.Items.Add(color);
            }
        }

        private void UpdateTiteName()
        {
            this.Title = $"Mastermind - {ColorString}";
        }

        private string ColorString => $"({string.Join(", ", colors)})";
    }

    // Inside a namespace, easier access.
    // Kleur - 03 Rename
    enum TypeColors : int
    {
        Blue,
        Red,
        Orange,
        // Kleur - 03 patch
        Green,
        Yellow,
        White,
    }
}