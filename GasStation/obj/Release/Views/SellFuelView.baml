   M S B A M L   `   `   `  ���� E  AGasStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GasStation.ViewsGasStation.Views  #    GasStation.Views.SellFuelView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:GasStation.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � 	Resources     	FontBrush �� Color  BgBrush1 �� 
StartPoint �� EndPoint � Offset � Color  BorderBrush1  CheckedBrush  ToggleButtonLeft �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  ToggleButtonMid  ToggleButtonRight �� 
TargetType��%  &	        &	      &	 e     &	 x     &	 �     7  7  7   7  &	 �    7  7  7   7  &	 �    7  7  7   7  '	�     '�� ?    �� $ #DDDDDD���� $	 0,0&�$	 0,1&�.��� $ 0Q�$ #888888��� $ 1Q�$ #222222���� $ #333333���� $	 0,0&�$	 0,1&�.��� $ 0Q�$ #555555��� $ 1Q�$ #111111���� " d�.R��� $��Border��8��  8�� $��1q�$ 5,0,0,5��._��� #��z��$��Center=�$��Center=�#��z��$
��Bold"�8��  P� 	 �@J�IsMouseOver
 . . ��� $ Border�� � �� �#808080P� 	 �@d�	IsChecked$

 trueY�. ��� $ Border��8   � ���� " d�.R��� $��Border��8��  8�� $��0,1,0,1q�$ 0��._��� #��z��$��Center=�$��Center=�#��z��$
��Bold"�8��  P� 	 �@J�IsMouseOver
 . . ��� $ Border�� � �� �#808080P� 	 �@d�	IsChecked$

 trueY�. ��� $ Border��8   � ���� " d�.R��� $��Border��8��  8�� $��1q�$ 
0, 5, 5, 0��._��� #��z��$��Center=�$��Center=�#��z��$
��Bold"�8��  P� 	 �@J�IsMouseOver
 . . ��� $ Border�� � �� �#808080P� 	 �@d�	IsChecked$

 trueY�. ��� $ Border��8   � ���� " 	�.���  � ��$ 40����  � ��$ 40���� " ��.���  � ��$ 20(���  � ��$ Arial)�.���  � ColumnDefinitions �� $��20 ��� $
��Auto ��� $
��Auto ��� $��20 ��� $
��Auto ��� $��20 ��� $
��Auto ��� $��20 ��� $��* ��� $
��Auto ��� $��20 � � RowDefinitions �� $��20 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $��* ��� $��20 �.+��� $��1��$��1��$��7��.+��� -    ��Name$ PersonalInfo��$
��5,10q��� $��2��$��1��$��5�� �� Orientation$ 
Horizontal=�.+��� .��%#Дисконтна програма�� -    ��Name$ 	ClientNum��$��95��$��16(��� -    ��Name$ SearchClient��$��2��$��6��$��0,0,0,0q�$��12(�.��
Пошук�� $��3��$��1��$��5��.+��� -   $ 
ClientInfo��$
��5,10q��� $��4��$��1��$��2��.+��� .��Колонка №�� $��5��$��6��$��1��$��Right=�.+�	� -    	�Name$ Column1�� 	� 	GroupName$ Column��#���  .��1	� -   $ Column3��$��0,10,0,0q�$ Column��#���  .��3�� $��5��$��6��$��2��$
��Left=�.+�	� -   $ Column2��$ Column��#���  .��2	� -   $ Column4��$��0,10,0,0q�$ Column��#���  .��4�� $��5��$��4��$ 
Horizontal=�.+�	� -	   $ Type1��$
 Type��#���  .��A-95	� -
   $ Type2��$
 Type��#���  .��A-92	� -   $ Type3��$
 Type��#���  .��DP�� $��6��$��4��$��0,10,0,0q�$ 
Horizontal=�.+�	� -   $ Type4��$
 Type��#���  .��A-95+	� -   $ Type5��$
 Type��#���  .��DP+	� -   $ Type6��$
 Type��#���  .��LPG�� $��5��$��6��$ 
Horizontal=�.+��� -   $ Count��$	��100��$��20(��� $��6��$��6��$ 
Horizontal=�.+��� -   $ Money��$	��100��$��0,10,0,0q�$��20(��� -   $
 Sell��$��5��$��2��$��8��$��2��.��Розрахувати�� $��7��$��1��$��2��.+��� Інформація�� $��8��$��1��$��6��$
��Left=�.+�&   System.Windows.Controls.DataGrid     AutoGenerateColumns .    CanUserAddRows .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    
IsReadOnly . ����  �� Path$ Width����� $ Information.DefaultView��� -   $ LogOut��$��1��$��9��$	��100��$	��0,5q�$��12(�.��
Вийти�� -   $ Clear��$��2��$��9��$��12(�.��Очистити