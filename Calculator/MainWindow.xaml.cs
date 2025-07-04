using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace calc
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private string currentNumber = "0";
        private string previousNumber = string.Empty;
        private string currentOperator = string.Empty;
        private bool isNewEntry = true;

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Next-Gen Calculator"; // ウィンドウのタイトルを設定
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var number = button.Content.ToString();

            if (isNewEntry)
            {
                currentNumber = number;
                isNewEntry = false;
            }
            else
            {
                if (currentNumber == "0")
                {
                    currentNumber = number;
                }
                else
                {
                    currentNumber += number;
                }
            }
            DisplayTextBlock.Text = currentNumber;
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            currentOperator = button.Content.ToString();
            previousNumber = currentNumber;
            isNewEntry = true;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(previousNumber) || string.IsNullOrEmpty(currentOperator))
            {
                return;
            }

            double num1 = double.Parse(previousNumber);
            double num2 = double.Parse(currentNumber);
            double result = 0;

            switch (currentOperator)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        DisplayTextBlock.Text = "Error";
                        return;
                    }
                    break;
            }

            currentNumber = result.ToString();
            DisplayTextBlock.Text = currentNumber;
            previousNumber = string.Empty;
            currentOperator = string.Empty;
            isNewEntry = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "0";
            previousNumber = string.Empty;
            currentOperator = string.Empty;
            isNewEntry = true;
            DisplayTextBlock.Text = "0";
        }
    }
}