   M S B A M L   `   `   `  ����I  ETravelInRussia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TravelInRussiaTravelInRussia  5          TravelInRussia.ToursPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TravelInRussia     5        N� Title$  	ToursPage��5	       N� 
FontFamily$ Comic Sans MS)�6    � 	Resources 5       �� 
TargetType 
  Actual �� Triggers P� Property P� Value �� Property �� Value��%  &	        �� 5   
   " ��6    5      P� 5       � ��$ Актуален��6*   . �5      ��  � ��
 � � �63   5      P� 5       � ��$ Не актуален��6*   . �5      ��  � ��
 �  ��63   5      5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $
��auto �6   6-   �� 5      $��* �6   6)   .+�5   
   � 
 � ColumnDefinitions
 5      �� 5      $��* �6#   6/   �� 5       $
��auto �6#   62   .+�5"      �  � Orientation$ 
Horizontal=�6   $��Center=�61   .+�5#      ��  �� Orientation$ 
Horizontal=�6   .+�5$      �� $:��4Введите название для поиска:��6    $	��175��6D    �� TextAlignment$ Right=�6P   6h   �� 5%      -   5         ��Name$ TBoxSearchName��5%   *   $	��225��6   6i   5&      �� 5'      $ 
Horizontal=�6   .+�5(      �� $:��4Введите описание для поиска:��6    $	��175��6D   $ Right=�6P   6h   �� 5)      -   5        $ TBoxSearchDescription��5)   *   $	��225��6   6p   5*      �� 5+      $ 
Horizontal=�6   .+�5,      �� $��Выберите тип��6    $	��175��64   $ Right=�6@   6X   �� 5-      -   5         ��Name$ 	ComboType��5-   +   $	��225��6    �� DisplayMemberPath$
 Name��6l   6�   5.      �� 5/      -   5         ��Name$ CheckActual��5/      $0��*Только актуальные туры��6p   $��Center=�6�   $��Center=�6�   $��30��6�   6�   �� 50      $ 
Horizontal=�6   .+�51      �� -   5         ��Name$ BtnPriceIncr��51      $*��$По возрастанию цены��63   6n   �� 52      -   5        $ BtnPriceDecr��52      $$��По убыванию цены��63   6k   53      54      �� 56      -   5         ��Name$ TextTotalPrice��56      $��1��60   $��Right=�6@   $
��auto��6\   $	��150��6i   $
��Wrap=�6x   $��5q�6�   6�   58      �� 5:   
   -   5         ��Name$ 
LViewTours��5:       $��1��6   $��Disabled=�64   $��Center=�6j   ��5;      �� 5<      .R�5=      � $ 
Horizontal=�6    $��Center=�69   6X   5>      ��5A      �� 5B      .R�5C      � $��20q�6   $	��400��6'   	 5D      �� 5E      $��70 �6,   6:   �� 5F      $	��310 �6,   6;   �� 5G      $
��auto �6,   6<   �� 5H      $
��auto �6,   6<   .+�5J      �� $	��400��6    $��1��6,   $��UniformToFill=�69   $��Center=�6Q   $��5q�6n   ��5K      �� 5L   "    �� Path$ ImagePreview�6*    �� TargetNullValue 5M   &   ��5N   *   Resources/icons/picture.png��6S   5P   #   5R      �� 5S      $��Center=�6:   $ Center=�6U   $	��390��6l   $
��Wrap=�6x   $��Center=�6�   $	��5 5q�6�   $��26(�6�   $��0��6�   ��6$   �� *Name+6�   �� 5T      $��Center=�6V   $��5 5 5 15q�6s   $��26(�6�   $
��Bold"�6�   $��2��6�   ��6$   �� *Price+ �� StringFormat$ {0:N2} РУБ��6�   �� 5U      $��Right=�6g   $��14(�6�   $��3��6�   ��6$   �� *TicketCount+$* $Билетов осталось: {0}��6�   �� 5V      #��[  6@   $
��Left=�6`   $��14(�6|   $��3��6�   ��6$   �� *
ActualText+6�   5W      5X      5Z      5\      5]      