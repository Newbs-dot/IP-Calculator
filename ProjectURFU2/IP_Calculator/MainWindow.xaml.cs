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
using System.Globalization;
using System.Reflection;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using IPlib;
namespace IP_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
      
      
        public MainWindow()
        {
            InitializeComponent();
            StartupComboboxInitialization();
           // CIDR.SelectionChanged += OnSelectionChanged;
            CIDR.DropDownOpened += OnDropDownOpened;
            CIDR.SelectedIndex = 0;
            MakeAllPropertiesReadOnly();
         
        }

       
        public void StartupComboboxInitialization() {
            for (int i = 0; i < 33; i++)
            {
                ComboBoxItem a = new ComboBoxItem();
                a.Content = i.ToString();
                CIDR.Items.Add(a);
            }
        }
        public void MakeAllPropertiesReadOnly() {
            Mask.IsReadOnly = true;
            MaxHosts.IsReadOnly = true;
            MaxIP.IsReadOnly = true;
            Broadcast.IsReadOnly = true;
            MinIP.IsReadOnly = true;
            PublicOrPrivateIp.IsReadOnly = true;
        }
       
        public void CalculateFinalValues()
        {
            byte first = byte.Parse(IP1stOctet.Text);
            byte second = byte.Parse(IP2ndOctet.Text);
            byte third = byte.Parse(IP3dOctet.Text);
            byte fourth = byte.Parse(IP4thOctet.Text);
            
            ipAPI.IP_address ip = new ipAPI.IP_address(first, second, third, fourth);

            ComboBoxItem a = (ComboBoxItem)CIDR.SelectedItem;

            ip.CalculateHostsMaxCount(a, MaxHosts);

            int cidrI = int.Parse(a.Content.ToString());
            ipAPI.IP_address subnet = ipAPI.IPmainget.get_Subnet(ip, cidrI);
         
            ip.CalculateMinimalHostIp(subnet, MinIP);
           
            ipAPI.IP_Mask mask = ipAPI.IPmainget.GetIP_Mask(cidrI);

            mask.DecimalMaskDisplayAndMaskToBinaryCharArray(mask, Mask);

            mask.CalculateBinarySubnetMask(subnet);

            mask.DecimalMaxOctetsFromBinarySubnetMask();

            mask.MaxIpDisplay(mask, MaxIP);
            
            mask.BroadcastDisplay(mask, Broadcast);
            
            PublicOrPrivateIp.Text= ip.PublicOrPrivateIP(first, second, CIDR);
           
        }
       
        private void Button_Click(object sender, RoutedEventArgs e) {
            try
            {
                CalculateFinalValues();
               
            }
            catch {
                if (CIDR.SelectedItem == null)
                {
                    MessageBox.Show("Введите значение номера подсети(CIDR)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                MessageBox.Show("Введите правильные значения исходного ip адреса", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnDropDownOpened(object sender, EventArgs e)
        {
            CIDR.SelectedIndex = 0;
        }
        /*
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        */
       

    }
}
