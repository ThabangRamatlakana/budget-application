   M S B A M L   `   `   `  ����>  :POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:POEPOE  5   	       POE.CalculateWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:POE     5   	   -   5          � Title$  	Calculate��5   	   $	��400��6   $	��400��6(   ���#f58c8b � WindowStyle$
 None=�6I   .��5	      �  � RowDefinitions 5
   
   �� 5      $��80 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   6+   .+�5   
   �� $��0��6   $��0��6   $��2��6-   $
��20px(�6A   $��Center=�6Q   ���	#FFE0E0E0${�False��5   &   .��5      �� $/��)To calculate, press the calculate button:��6   $
��Wrap=�6I   $��Center=�6]   $��Center=�6z   5      �� 5   
   -   5         ��Name$ ButtonCalculate��5      $��	Calculate��6*   $
��70px��6>   $��	23,38,0,0q�6K   $
��Left=�6^   $	��Top=�6y   6�   �� 5   
   -   5        $ 
ButtonExit��5      $��0��6%   $��1��62   $
��EXIT��6B   $
��70px��6Q   $��0,15,0,0q�6^   $��Right=�6p   $��Bottom=�6�   6�   �� 5   
   -   5         ��Name$ RichTextBoxDisplayInfo��5   G   $��1��6   $��0��6#   $��2��63   ���#f58c8b6g   5      5      