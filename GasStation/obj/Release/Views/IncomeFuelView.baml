   M S B A M L   `   `   `  ���� E  AGasStation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GasStation.ViewsGasStation.Views  %    GasStation.Views.IncomeFuelView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:GasStation.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � 	Resources     	FontBrush �� Color  BgBrush1 �� 
StartPoint �� EndPoint � Offset � Color  BorderBrush1  CheckedBrush  ToggleButtonLeft �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  ToggleButtonMid  ToggleButtonRight �� 
TargetType��%�  &	        &	      &	 e     &	 x     &	 �     7  7  7   7  &	 �    7  7  7   7  &	 �    7  7  7   7  '	�     �� $ #DDDDDD���� $	 0,0&�$	 0,1&�.��� $ 0Q�$ #888888��� $ 1Q�$ #222222���� $ #333333���� $	 0,0&�$	 0,1&�.��� $ 0Q�$ #555555��� $ 1Q�$ #111111���� " d�.R��� $��Border��8��  8�� $��1q�$ 5,0,0,5��._��� #��z��$��Center=�$��Center=�#��z��$
��Bold"�8��  P� 	 �@J�IsMouseOver
 . . ��� $ Border�� � �� �#808080P� 	 �@d�	IsChecked$

 trueY�. ��� $ Border��8   � ���� " d�.R��� $��Border��8��  8�� $��0,1,0,1q�$ 0��._��� #��z��$��Center=�$��Center=�#��z��$
��Bold"�8��  P� 	 �@J�IsMouseOver
 . . ��� $ Border�� � �� �#808080P� 	 �@d�	IsChecked$

 trueY�. ��� $ Border��8   � ���� " d�.R��� $��Border��8��  8�� $��1q�$ 
0, 5, 5, 0��._��� #��z��$��Center=�$��Center=�#��z��$
��Bold"�8��  P� 	 �@J�IsMouseOver
 . . ��� $ Border�� � �� �#808080P� 	 �@d�	IsChecked$

 trueY�. ��� $ Border��8   � ���� " 	�.���  � ��$ 40����  � ��$ 40��.���  � ColumnDefinitions �� $��20 ��� $��* ��� $
��Auto ��� $��20 ��� $
��Auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $��* ��� $
��Auto ��� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��20 �.+��� $��2��$��2�� �� Orientation$ 
Horizontal=�.+�	� -    	�Name$ Type1�� 	� 	GroupName$
 Type��#���  .��A-95	� -   $ Type2��$
 Type��#���  .��A-92	� -   $ Type3��$
 Type��#���  .��DP�� $��3��$��2��$ 
Horizontal=�.+�	� -   $ Type4��$
 Type��#���  .��A-95+	� -   $ Type5��$
 Type��#���  .��DP+	� -   $ Type6��$
 Type��#���  .��LPG�� $��2��$��4��.+��� -    ��Name$ Count��$	��120��$��40��$��5q��� $��3��$��4��.+��� -    ��Name$ Income��$	��120��$��40��$��5q�.��Отримано