using System;
using System.Collections.Generic;
using System.Data;
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

namespace IP_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public int index = 1;
        public MainWindow()
        {
            InitializeComponent();
            
            for (int i = 0; i < 32; i++)
            {
                ComboBoxItem a = new ComboBoxItem();
                 a.Content = i.ToString();
                CIDR.Items.Add(a);
            }
            
            
            CIDR.SelectionChanged += OnSelectionChanged;
            CIDR.DropDownOpened += OnDropDownOpened;
        }
        private void OnDropDownOpened(object sender, EventArgs e)
        {
            CIDR.SelectedItem = null;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
            if (CIDR.SelectedItem != null)
            {
                ComboBoxItem a = (ComboBoxItem)CIDR.SelectedItem;
                int cidrM = int.Parse(a.Content.ToString());
                IP_Mask mask = IPmain.GetIP_Mask(cidrM);
                string valm = String.Format("{0}.{1}.{2}.{3}",
                    mask.f_octet, mask.s_octet, mask.t_octet,
                    mask.fo_octet);

                Mask.Text = valm;
               
            }
        }
       

    }
}
