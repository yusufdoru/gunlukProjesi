   M S B A M L   `   `   `  ����  gunlukProje    gunlukProje.MainWindow   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    5      :Custom-http://schemas.microsoft.com/wpf/2008/toolkit  5      :d2http://schemas.microsoft.com/expression/blend/2008  6?   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6|   -   5          �Name$  Window��5       � Title$ Günlük 1.0��5      $	��542��5      $	��415��6   $
��Left=�6   $	��Top=�66    � WindowStartupLocation$ CenterScreen=�6N   ���	#FF00C3FF.��5
      � -   5         �Name$ 
LayoutGrid��5
      .+�5   
   o� -   5        $��menu1��5   8   $��Stretch=�6   $��5q�6-   $	��Top=�6E   ���	#FF00C4FF$��Center=�6t    o� 
IsMainMenu . $��LeftToRight=�6�   .@�5      m� -   5        $��	Hakkında��5      
�������
�������$��Center=�6g   $��Center=�6�   $��0q�6�   5      � 5   
   -   5        $��
gridGunluk��5      ���	#FF40A3F8$��Stretch=�68   $��5,30,5,5q�6T    � ColumnDefinitions 5      �� 5      $
��317* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��txtMetin��5   F   $��Stretch=�6   $��5,5,5,35q�64   $��Stretch=�6V   $��0q�6r    �� 
IsReadOnly .  
������� �� AcceptsReturn .  �� 
AcceptsTab . 	 �� TextWrapping$
	 Wrap=�6�   "
 �� VerticalScrollBarVisibility$

 Auto=�6�    �� AutoWordSelection .   J� 	AllowDrop .  $��0q�6/  9� 5      -   5        $��	expander1��5   A   $	��179��6   $��Center=�6$   $	��Top=�6R   $��1��6j   ���	#FF0AC6FF
�������$��2,2,2,0q�6�   $��Center=�6�   $	��Top=�6�    9� 
IsExpanded .   9� ExpandDirection$
 Left=�6  .��5      )  #Microsoft.Windows.Controls.Calendar  -   5          Name$ takvim1��5   "   $��Center=�63   $��5q�6P   $��Center=�6u   {�.    DisplayMode$ Month=�6�      SelectionMode$ 
SingleDate=�6�   5      �� 5      -	   5        $��spButonAlan��5   T   $��29��6   $��Stretch=�6%   $��5,0,0,5q�6C   $��Bottom=�6g    �� Orientation$ 
Horizontal=�6�   .+�5      �� -
   5        $��btnYeni��5   7   $��Oluştur��6   $��23��6+   $��75��6F   $��Center=�6Q   $��Center=�6n   6�   �� 5      -   5        $��	btnKaydet��5   6   $��Kaydet��6   $��23��6*   $��75��6G   $��Center=�6R   $��Center=�6o   6�   �� 5      -   5        $��
btnDuzenle��5   7   $��Düzenle��6   $��23��6+   $��75��6I   6T   �� 5      -   5        $��btnSil��5   3   $	��Sil��6   $��23��6'   $��75��6A   6L   5      5!      5"      5#      