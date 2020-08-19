using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //declaring input data variables
        int operationSign;
        double input1;
        double input2;
        double result;

        //declaring operator signs
        string opPlus="+";
        string opMinus = "-";
        string opMultiply = "*";
        string opDivide = "/";

        Methods m = new Methods();

        public MainWindow()
        {
            InitializeComponent();
        }


        //event handlers when operation sign are pressed and change to according operation
        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            operationSign = 0;
            this.opSign.Text = opPlus;
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            operationSign = 1;
            this.opSign.Text = opMinus;
        }

        private void buttonMultiply_Click(object sender, RoutedEventArgs e)
        {
            operationSign = 2;
            this.opSign.Text = opMultiply;
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            operationSign = 3;
            this.opSign.Text = opDivide;
        }


        //event when calculate button is clicked
        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            input1 = Convert.ToDouble(this.userInput1.Text);
            input2 = Convert.ToDouble(this.userInput2.Text);


            // checks operation sign and operate according operation
            if (operationSign==0)
            {
                result = m.Add(input1, input2);
            }
            else if (operationSign==1)
            {
                result = m.Sub(input1, input2);
            }
            else if (operationSign == 2)
            {
                result = m.Mul(input1, input2);
            }
            else if (operationSign == 3)
            {
                result = m.Div(input1, input2);
            }

            //prints the result
            this.calcResult.Text = Convert.ToString(result);
        }
        
        //checking input
        private void userInput1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        //check if input is numeric

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }
    }
}
