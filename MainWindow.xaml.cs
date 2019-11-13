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

namespace SkidMark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        List<SkidMark> asdf = new List<SkidMark>();

        private double friction;
        private double skidMark;

        private void Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                skidMark = Convert.ToDouble(skid.Text);
                friction = Convert.ToDouble(fric.Text);

                double rslt = Math.Sqrt(254 * skidMark * friction);

                result.Text = Math.Round(rslt, 2).ToString();

                asdf.Add(new SkidMark() { value = result.Text });

                skidList.ItemsSource = asdf;
                skidList.Items.Refresh();
            }
            catch(Exception err)
            {
                string error = string.Format("[SYSTEM] : 입력 값 오류. 다시 입력해주세요.\n{0}", err.Message);
                MessageBox.Show(error);
            }
        }

        public class SkidMark
        {
            public string value { get; set; }
        }
    }
}