   M S B A M L   `   `   `  ����U  QCaliburn.Micro, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21fG4clr-namespace:Caliburn.Micro;assembly=Caliburn.MicroCaliburn.Micro  5      D @FluentWPF, Version=0.2.2.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5      E AGasStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GasStation.ViewsGasStation.Views 5	         GasStation.Views.MainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      ?cal24clr-namespace:Caliburn.Micro;assembly=Caliburn.Micro  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      ?fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  5      *localclr-namespace:GasStation.Views  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
        � Title$  GasStationControll��5      $	��700��5      $	��550��5      $	��700��5      $	��550��5      .��5      � ���	#70FFFFFF � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� asdad6   o� 5    
   -   5         o�Name$
 Menu��5!      $��0��5"      $��0��5#      $��5��5$      
���OO/�$��Segoe UI Black)�5&      $��14(�5'      
���������5)      �� *Items+ � 	Resources 5*       �� 
TargetType  Caliburn.Micro.Message �� Property �� Value  Caliburn.Micro.Action �� ElementName	 �� DataType   Caliburn.Micro.Screen
 �� ItemsSource��%g  'm�       (�� �     5/   +   *, +)�� 5+      " m�6   .�5,      ��  �@ Attach$3 -[Event Click] = [Action Select($DataContext)]��6;   �� 5-       �@ TargetWithoutContext 6H   �� *DataContext+$
 Menu��5.      �� 5/      "	  6+   
 6K   �� *Items+.R�50      �� $��10q�6    ��6,   �� *DisplayName+51      52      53      �� 55   
   -   5         ��Name$ 
ActiveItem��56      $��2��57      $��1��58      $��Center=�59      5:      5;      