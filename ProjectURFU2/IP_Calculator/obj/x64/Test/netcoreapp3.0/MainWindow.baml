   M S B A M L   `   `   `  ���� H  DIP_Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:IP_CalculatorIP_Calculator      IP_Calculator.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:IP_Calculator       � Title$  Ip-calc��$	��450��$	��800��$	��800��$	��450��
�������.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��1* ��� $��1* ��� $��1* � � ColumnDefinitions �� $
��1.1* ��� �� �� �� .+��� $��IP-Калькулятор��$��32(�$��5��$��Center=�$��	0,10,0,10q��� $*��$Введите ваш IP-адрес:��$
��Left=�$��	10,10,0,0q�$��2���� $5��/Введите номер подсети(CIDR):��$��2��$��0,50,0,0q�$
��Left=��� $7��1Минимальный IP-адрес в сети:��$��3��$��0,0,0,0q�$
��Left=��� -   $��MinIP��$��1��$��3��$	��Top=�$��	50,0,50,0q�$��2���� $9��3Максимальный IP-адрес в сети:��$��3��$��0,0,0,0q�$
��Left=�$��Bottom=��� $R��LМаксимальное количество IP-адресов в сети:��$��3��$��0,0,0,0q�$��Center=�$	��Top=�$��3��$��2���� -   $��MaxHosts��$��3��$��3��$��Center=�$��	90,0,90,0q�$��2���� -   $��MaxIP��$��1��$��3��$��Bottom=�$��	50,0,50,0q�$��2���� $ ��Маска подсети:��$��2��$��2��$��0,50,0,0q�$
��Left=��� -   $
��Mask��$��3��$��2��$	��Top=�$��
50,50,50,0q�$��2���� -   $2��,Посчитать адрес подсети��$��4��$��1��$��3��$��Bottom=�$��Center=��� -   $��
IP1stOctet��$��1��$��2��$	��Top=�$��
50,10,50,0q�.��***�� $��30(�$��.��$��1��$��2��$	��Top=�$��
140,-5,0,0q��� -   $��
IP2ndOctet��$��2��$��2��$	��Top=�$��
50,10,50,0q�.��***�� $��30(�$��.��$��2��$��2��$	��Top=�$��
140,-5,0,0q��� -   $��	IP3dOctet��$��3��$��2��$	��Top=�$��
50,10,50,0q�.��***�� $��30(�$��.��$��3��$��2��$	��Top=�$��
140,-5,0,0q��� -	   $��
IP4thOctet��$��4��$��2��$	��Top=�$��
50,10,50,0q�.��***�� -
   $
��CIDR��$��33,10,33,50q�$��1��$��2��$��Bottom=�