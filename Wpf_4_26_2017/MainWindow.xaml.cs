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
using System.ComponentModel;

namespace Wpf_4_26_2017
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window ,INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            StringBuilder a = new StringBuilder();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btn_result_Click(object sender, RoutedEventArgs e)
        {
            Trans _trans = new Trans();
           tebl_result.Text= _trans._chuyen(txb_Input.Text);
        }
    }
     
}
