using System.Diagnostics;
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
        // Ik schrijf comments naar mezelf in het Engels,
        // Comments naar lectoren om vragen te stellen of uitleg te geven, schrijf ik in het Nederlands.
        // Ik doe dit omdat ik verkies monolingual (eentalig) te coderen.

        private TypeColors[] colors = new TypeColors[4];

        // Nullable zodat de compiler begrijpt dat ik deze variabellen
        // Later een waarde geef.
        private ComboBox[]? ComboBoxes;
        private Label[]? ColorLabels;

        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            // Ik hoop dat ik dit mag doen, ik verkies dit boven verbinden in XAML.
            CheckCodeBtn.Click += OnClickCheckCodeBtn;
            SetupGame();
        }

        private void OnClickCheckCodeBtn(object sender, RoutedEventArgs e)
        {

        }

        private void SetupGame()
        {
            ComboBoxes = new[] { Color1Cb, Color2Cb, Color3Cb, Color4Cb };
            ColorLabels = new[] { Color1Lbl, Color2Lbl, Color3Lbl, Color4Lbl };
            for (int i = 0; i < colors.Length; i++)
            {
                //Typecasting int => enum:int
                colors[i] = (TypeColors)random.Next(0, colors.Length);
            }
            UpdateTiteName();
            FillComboBoxes();
        }

        private void UpdateColorLabels(int i)
        {
            ColorLabels[i].Background = new SolidColorBrush(ToNetColor((TypeColors)ComboBoxes[i].SelectedItem));
        }

        /// <summary>
        /// Converts TypeColor enum values to proper .NET core Color objects.
        /// </summary>
        /// <param name="Color"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Color ToNetColor(TypeColors Color)
        {
            switch (Color)
            {
                default:
                    //Should not be possible, but makes the compiler happy.
                    return Colors.Transparent;

                case TypeColors.Blue:
                    return Colors.Blue;

                case TypeColors.Red:
                    return Colors.Red;

                case TypeColors.White:
                    return Colors.White;

                case TypeColors.Green:
                    return Colors.Green;

                case TypeColors.Orange:
                    return Colors.Orange;

                case TypeColors.Yellow:
                    return Colors.Yellow;
            }
        }

        private void FillComboBoxes()
        {
            foreach (ComboBox comboBox in ComboBoxes)
            {
                comboBox.Items.Clear();
            }

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

        private void Color4Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColorLabels(3);
        }

        private void Color3Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColorLabels(2);
        }

        private void Color2Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColorLabels(1);
        }

        private void Color1Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColorLabels(0);
        }
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