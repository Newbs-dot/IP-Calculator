using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
namespace IPlib
{
   public  class ipAPI
    {

       public class IPmainget
        {
            public static IP_address get_Subnet(IP_address ip, int cidr)
            {
                IP_address temp;
                byte[] bit_decimal = new byte[] { 0, 128, 192, 224, 240, 248, 252, 254, 255 };

                if (cidr <= 8)
                {
                    byte first = bit_decimal[cidr];
                    temp = new IP_address(first, 0, 0, 0);
                }
                else if (cidr > 8 && cidr <= 16)
                {
                    int pwr = cidr - 8;
                    byte second = bit_decimal[pwr];
                    temp = new IP_address(255, second, 0, 0);
                }
                else if (cidr > 16 && cidr <= 24)
                {
                    int pwr = cidr - 16;
                    byte third = bit_decimal[pwr];
                    temp = new IP_address(255, 255, third, 0);
                }
                else if (cidr > 24 && cidr <= 32)
                {
                    int pwr = cidr - 24;
                    byte fourth = bit_decimal[pwr];
                    temp = new IP_address(255, 255, 255, fourth);
                }
                else
                {
                    temp = new IP_address(0, 0, 0, 0);
                }
                IP_address sub = new IP_address((byte)(temp.first_octet & ip.first_octet),
                    (byte)(temp.second_octet & ip.second_octet),
                    (byte)(temp.third_octet & ip.third_octet),
                    (byte)(temp.fourth_octet & ip.fourth_octet));
                return sub;

            }
            public static IP_Mask GetIP_Mask(int cidr)
            {
                IP_Mask mask;
                byte[] bit_decimal = new byte[] { 0, 128, 192, 224, 240, 248, 252, 254, 255 };

                if (cidr <= 8)
                {
                    byte first = bit_decimal[cidr];
                    mask = new IP_Mask(first, 0, 0, 0);
                }
                else if (cidr > 8 && cidr <= 16)
                {
                    int pwr = cidr - 8;
                    byte second = bit_decimal[pwr];
                    mask = new IP_Mask(255, second, 0, 0);
                }
                else if (cidr > 16 && cidr <= 24)
                {
                    int pwr = cidr - 16;
                    byte third = bit_decimal[pwr];
                    mask = new IP_Mask(255, 255, third, 0);
                }
                else if (cidr > 24 && cidr <= 32)
                {
                    int pwr = cidr - 24;
                    byte fourth = bit_decimal[pwr];
                    mask = new IP_Mask(255, 255, 255, fourth);
                }
                else
                {
                    mask = new IP_Mask(0, 0, 0, 0);
                }

                return mask;
            }


        }
      public class IP_address
        {


            public byte first_octet, second_octet, third_octet, fourth_octet;
            public IP_address(byte a, byte b, byte c, byte d)
            {
                first_octet = a;
                second_octet = b;
                third_octet = c;
                fourth_octet = d;
            }
            public string PublicOrPrivateIP(byte a, byte b, ComboBox cidr)
            {
                string PubOrPriv = "Белый";
                switch (cidr.SelectedIndex)
                {
                    case 8:
                        if (a == 10)
                        {
                            PubOrPriv = "Серый";
                        }
                        else
                        {
                            PubOrPriv = "Белый";
                        }
                        break;
                    case 12:
                        if (a == 172 && (b >= 16 && b <= 31))
                        {
                            PubOrPriv = "Серый";
                        }
                        else
                        {
                            PubOrPriv = "Белый";
                        }
                        break;
                    case 16:
                        if (a == 192 && b == 168)
                        {
                            PubOrPriv = "Серый";
                        }
                        else
                        {
                            PubOrPriv = "Белый";
                        }
                        break;
                    case 10:
                        if (a == 100 && (b >= 64 && b <= 127))
                        {
                            PubOrPriv = "Серый";
                        }
                        else
                        {
                            PubOrPriv = "Белый";
                        }
                        break;
                    default:
                        PubOrPriv = "Белый";
                        break;


                }

                return PubOrPriv;

            }
            public void CalculateHostsMaxCount(ComboBoxItem cidr,TextBox MaxHostOutput)
            {
                double stepen = 32 - int.Parse(cidr.Content.ToString());
                long HostsMax = (long)Math.Pow(2.0, stepen);
                MaxHostOutput.Text = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", HostsMax.ToString("#,#", CultureInfo.InvariantCulture));
            }

            public void CalculateMinimalHostIp(IP_address sub,TextBox MinIpTextBox) {
                
                string valmin = String.Format("{0}.{1}.{2}.{3}",
                    sub.first_octet,
                    sub.second_octet,
                    sub.third_octet,
                    sub.fourth_octet + 1);

                MinIpTextBox.Text = valmin;

            }
        }
       public class IP_Mask
        {
            public bool[] maskFlags = new bool[32];
            public char[] subnetMaskBinaryChar;
            public double firstmaxoctet = 0,
                secondmaxoctet = 0,
                thirdmaxoctet = 0,
                fourthmaxoctet = 0;
            public char[] maskBinaryCharArray;
            public byte f_octet, s_octet, t_octet, fo_octet;
            public string subnetMaskBinary;
            public IP_Mask(byte a, byte b, byte c, byte d)
            {
                f_octet = a;
                s_octet = b;
                t_octet = c;
                fo_octet = d;
            }
            public void DecimalMaskDisplayAndMaskToBinaryCharArray(IP_Mask mask, TextBox textContainerForDecimalMask)
            {

                string valm = String.Format("{0}.{1}.{2}.{3}",
                    mask.f_octet, mask.s_octet, mask.t_octet,
                    mask.fo_octet);
                string valmBinary = String.Format("{0}{1}{2}{3}",
                    Convert.ToString(mask.f_octet, 2).PadLeft(8, '0'), Convert.ToString(mask.s_octet, 2).PadLeft(8, '0'), Convert.ToString(mask.t_octet, 2).PadLeft(8, '0'),
                    Convert.ToString(mask.fo_octet, 2).PadLeft(8, '0'));

                maskBinaryCharArray = valmBinary.ToCharArray();
                for (int i = 0; i < maskBinaryCharArray.Length; i++)
                {
                    if (maskBinaryCharArray[i].Equals('1'))
                    {
                        maskFlags[i] = true;

                    }
                    else
                    {
                        maskFlags[i] = false;
                    }
                }

                
                textContainerForDecimalMask.Text = valm;
            }
            public void CalculateBinarySubnetMask(IP_address subnet)
            {
                subnetMaskBinary = String.Format("{0}{1}{2}{3}",
                     Convert.ToString(subnet.first_octet, 2).PadLeft(8, '0'),
                     Convert.ToString(subnet.second_octet, 2).PadLeft(8, '0'),
                     Convert.ToString(subnet.third_octet, 2).PadLeft(8, '0'),
                     Convert.ToString(subnet.fourth_octet, 2).PadLeft(8, '0'));

                subnetMaskBinaryChar = subnetMaskBinary.ToCharArray();
                for (int i = 0; i < subnetMaskBinaryChar.Length; i++)
                {
                    for (int j = 0; j < maskFlags.Length; j++)
                    {
                        if (maskFlags[i] == false)
                        {
                            subnetMaskBinaryChar[i] = '1';
                        }
                    }
                }
                
                

            }
            public void DecimalMaxOctetsFromBinarySubnetMask()
            {
                ResetValues();

                int firstIndexLeveler = 7;
                int secondIndexLeveler = 1;
                int thirdIndexLeveler = 9;
                int fourthIndexLeveler = 17;
                for (int j = 7; j > -1; j--)
                {
                    //Console.WriteLine(String.Join(' ', j, j - p));
                    firstmaxoctet = firstmaxoctet + (int.Parse(subnetMaskBinaryChar[j - firstIndexLeveler].ToString()) * Math.Pow(2, j));
                    firstIndexLeveler = firstIndexLeveler - 2;

                }

                for (int j = 7; j > -1; j--)
                {
                    secondmaxoctet = secondmaxoctet + (int.Parse(subnetMaskBinaryChar[j + secondIndexLeveler].ToString()) * Math.Pow(2, j));
                    secondIndexLeveler = secondIndexLeveler + 2;
                }
                for (int j = 7; j > -1; j--)
                {
                    thirdmaxoctet = thirdmaxoctet + (int.Parse(subnetMaskBinaryChar[j + thirdIndexLeveler].ToString()) * Math.Pow(2, j));
                    thirdIndexLeveler = thirdIndexLeveler + 2;
                }
                for (int j = 7; j > -1; j--)
                {
                    fourthmaxoctet = fourthmaxoctet + (int.Parse(subnetMaskBinaryChar[j + fourthIndexLeveler].ToString()) * Math.Pow(2, j));
                    fourthIndexLeveler = fourthIndexLeveler + 2;
                }
                
            }
            public void BroadcastDisplay(IP_Mask mask,TextBox textContainerForBroadcast) {
                textContainerForBroadcast.Text = String.Format("{0}.{1}.{2}.{3}", mask.firstmaxoctet.ToString(), mask.secondmaxoctet.ToString(),
                    mask.thirdmaxoctet.ToString(), mask.fourthmaxoctet.ToString());
            }
            public void MaxIpDisplay(IP_Mask mask, TextBox textContainerForMaxIp)
            {
                textContainerForMaxIp.Text = String.Format("{0}.{1}.{2}.{3}", mask.firstmaxoctet.ToString(), mask.secondmaxoctet.ToString(), 
                    mask.thirdmaxoctet.ToString(), (mask.fourthmaxoctet - 1).ToString());
            }

            public void ResetValues()
            {
                firstmaxoctet = 0;
                secondmaxoctet = 0;
                thirdmaxoctet = 0;
                fourthmaxoctet = 0;

            }

        }
    }
}
