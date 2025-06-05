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

namespace KlaviaturaFull
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private string[] texts = new[]

    {
        "ffdffffdasdasdfrwa",
        "eeeefarderion na  na na",
        "8888899dand dawn show",
        "include iostream yes",
        "primer primera primera"
    };
        private int wrongKeyCount = 0;
        private bool isTracking = false;
        private int fails = 0;
        private bool isTextShown = false;
        private int currentTextIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            GenerateRandomText();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1); 
            
            this.KeyDown += MainWindow_KeyDown;
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (isTracking)
            {
                
                if (e.Key != Key.A)
                {
                    fails++;
                    FailsButton.Content = fails.ToString();
                }
            }
        }
        private void DifficultySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DifficultyNumberText.Text = ((int)e.NewValue).ToString();
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTextShown)
            {
                RandomTextBlock.Text = texts[currentTextIndex];
                isTextShown = true;
            }
            else
            {
                currentTextIndex = (currentTextIndex + 1) % texts.Length; 
                RandomTextBlock.Text = texts[currentTextIndex];
            }
            _timer.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            RandomTextBlock.Text = ""; 
        }
        private bool isCapsLockOn = false;

        private void CapsLockButton_Click(object sender, RoutedEventArgs e)
        {
            isCapsLockOn = !isCapsLockOn;

            if (isCapsLockOn)
                CapsLockButton.Background = System.Windows.Media.Brushes.LightGreen;
            else
                CapsLockButton.Background = System.Windows.Media.Brushes.LightGray;
        }

        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string symbol = btn.Content.ToString();
                InputTextBox.Text += symbol;
            }
        }
        private void KeButton_Click(object sender, RoutedEventArgs e)
        {
            // Переключение состояния Caps Lock
            isCapsLockOn = !isCapsLockOn;

            // Обновление текста на кнопке в зависимости от состояния
            if (isCapsLockOn)
            {
                CapsLockButton.Content = "Caps Lock ON";
                CapsLockButton.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                CapsLockButton.Content = "Caps Lock";
                CapsLockButton.Background = new SolidColorBrush(Color.FromRgb(181, 181, 181));
            }
        }

        // Обработчик Backspace
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(InputTextBox.Text))
            {
                InputTextBox.Text = InputTextBox.Text.Substring(0, InputTextBox.Text.Length - 1);
            }
        }

        // Обработчик Space
        private void Space_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text += " ";
        }

        // Обработчик Tab
        private void Tab_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text += "\t";
        }
        private void Full_BacSpace(object sender, RoutedEventArgs e)
        {

            InputTextBox.Text = " ";
        }
        private void GenerateRandomText()
        {
            string[] sampleTexts = new string[]
            {
            "Пример текста 1",
            "Случайный текст 2",
            "Вот такой рандомный текст",
            "Тестовая строка",
            "Еще один пример"
            };

            Random rnd = new Random();
            int index = rnd.Next(sampleTexts.Length);
            RandomTextBlock.Text = sampleTexts[index];
        }
       

        
    }
}