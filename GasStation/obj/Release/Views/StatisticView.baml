   M S B A M L   `   `   `  ���� E  AGasStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GasStation.ViewsGasStation.Views  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf $    GasStation.Views.StatisticView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:GasStation.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Dwpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     .���   � ColumnDefinitions  �� $��20 ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��20 �.+��� -    ��Name$ Update��$��1��$��1��$��Right=�$	��100��.��Оновити�� $��2��$��1��$	��500��$	��200��.@��� $ ��По типу палива��.���   �� $��* ��� $��2* �.+�&   System.Windows.Controls.DataGrid  $��0��$��10q�   AutoGenerateColumns .    CanUserAddRows .  ����  �� Path$ ResultTable.DefaultView�#  LiveCharts.Wpf.CartesianChart  $��1��$��10q�
�������&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�   Series �� *ResultSeries+   AxisX   LiveCharts.Wpf.Axis  	   
Foreground
	 �   �
   LabelFormatter
 �� *FormatterType+   AxisY      Title$ Продано��
	 �   �
 �� *	Formatter+�� $��По продавцях��.���   �� $��* ��� $��2* �.+�  $��0��$��10q� .  .  ���� $ ResultTable1.DefaultView�  $��1��$��10q�
�������$ Right=� �� *ResultSeries1+   
	 �   �
 �� *
Formatter2+   $ Продано��
	 �   �
 �� *	Formatter+