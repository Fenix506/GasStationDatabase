   M S B A M L   `   `   `  ����E  AGasStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GasStation.ViewsGasStation.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      $    GasStation.Views.StatisticView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:GasStation.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Dwpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��8* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��20 �6   .+�5   
   �� -   5         ��Name$ Update��5   V   $��2��6   $��1��6!   $��Right=�6.   $	��100��6J   .��6f   Оновити6o   �� 5    
   $��2��5!      $��2��5"      $	��500��5#      $	��200��5$      .@�5%      �� $ ��По типу палива��6   .��5&      �   5'      �� 5(      $��* �6+   �� 5)      $��2* �6+   .+�5+      &   System.Windows.Controls.DataGrid  $��0��5,      $��10q�5-         AutoGenerateColumns .    CanUserAddRows .  ��50      ��  �� Path$ ResultTable.DefaultView�#  LiveCharts.Wpf.CartesianChart  51      $��1��52      $��10q�53      
�������&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�55         Series 56      �� *ResultSeries+   AxisX 58        LiveCharts.Wpf.Axis  	   
Foreground
	 �   �
   LabelFormatter
 6:   �� *FormatterType+   AxisY 5;           Title$ Продано��5<   !   
	 �   �
 5>   !   �� *	Formatter+5@      5A      5B      �� 5C      $��По продавцях��6   .��5D      �   5E      �� 5F      $��* �6+   �� 5G      $��2* �6+   .+�5I        $��0��5J      $��10q�5K       .  .  ��5N      �� $ ResultTable1.DefaultView�  5O      $��1��5P      $��10q�5Q      
�������$ Right=�5S       5T      �� *ResultSeries1+ 5V        
	 �   �
 6:   �� *
Formatter2+ 5Y        $ Продано��5Z   !   
	 �   �
 5\   !   �� *	Formatter+5^      5_      5`      5a      5e      5f      