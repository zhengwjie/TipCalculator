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

namespace TipCalculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        Tip tipcal=new Tip();
        public MainWindow()
        {
            InitializeComponent();
        }
        //选定一个单选按钮时，
        //进行计算
        private void RadioButtonClick(object sender, RoutedEventArgs e)
        {
            performCal();
        }
        //执行计算
        private void performCal()
        {
            var selectRadio= this.MyStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            if (selectRadio != null)
            {
                tipcal.calTip(this.tipcal.billAmount, double.Parse(selectRadio.Tag.ToString()));
                this.TipAmount.Content = "TipAmount: ￥" + tipcal.tipAmount.ToString("f2");
                this.TotalAmount.Content = "TotalAmount: ￥" + tipcal.totalAmount.ToString("f2");
            }
        }

        private void lostFocus(object sender, RoutedEventArgs e)
        {
            performCal();
        }
        //按下回车键后，将TextBox中的数字转换成货币表示
        private void keyDown(object sender, KeyEventArgs e)
        {
            double billam = 0.00;
            try
            {
                billam = double.Parse(this.BillAmount.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Bill 格式错误");
            }
            this.tipcal.billAmount = billam;
            this.BillAmount.Text = "￥" + String.Format("{0:F}", billam);
            performCal();
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {

        }
    }
}
