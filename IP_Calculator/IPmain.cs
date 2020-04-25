using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace IP_Calculator
{
    class IPmain
    {
        public static IP_address get_Subnet(IP_address ip, int cidr) {
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
            else {
                temp = new IP_address(0, 0, 0, 0);
            }
            IP_address sub = new IP_address((byte)(temp.first_octet & ip.first_octet),
                (byte)(temp.second_octet & ip.second_octet),
                (byte)(temp.third_octet & ip.third_octet),
                (byte)(temp.fourth_octet & ip.fourth_octet));
            return sub;
            
        }
        public static IP_Mask GetIP_Mask(int cidr){
            IP_Mask mask;
            byte[] bit_decimal = new byte[] { 0, 128, 192, 224, 240, 248, 252, 254, 255 };

            if (cidr <= 8)
            {
                byte first = bit_decimal[cidr];
                mask= new IP_Mask(first, 0, 0, 0);
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
    class IP_address {
        public byte first_octet,second_octet,third_octet,fourth_octet;
        public IP_address(byte a, byte b, byte c, byte d) {
            first_octet = a;
            second_octet = b;
            third_octet = c;
            fourth_octet = d;
        }
        
    }
    class IP_Mask {
        public byte f_octet, s_octet, t_octet, fo_octet;
       
        public IP_Mask(byte a ,byte b, byte c, byte d) {
            f_octet = a;
            s_octet = b;
            t_octet = c;
            fo_octet = d;
        }
    
    }
}
