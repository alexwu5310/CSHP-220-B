   M S B A M L   `   `   `  ����E  AReadingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ReadingApp
ReadingApp  5   	   !    ReadingApp.AddReadingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ReadingApp     5   	   -   5          � Title$  AddReadingWindow��5   	   $	��250��6"   $	��540��6/    +� FocusedElement 6;   ��  �� ElementName$ uxTitle��.��5      � -   5         �Name$ uxGrid��5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Right=�61   Title:6U   �� 5   
   -   5         ��Name$ uxTitle��5      $��1��6:   $��0��6J   ��6#   �� *Title+6Y   �� 5   
   $��0��6   $��1��6$   $��Right=�61   	Author:6V   �� 5   
   -   5        $ uxAuthor��5      $��1��6<   $��1��6L   ��6$   �� *Author+6[   �� 5   
   $��0��6   $��2��6$   $��Right=�61   Type:6T   �� 5    
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��2��6>   .+�5!      	� -   5         	�Name$ uxMysteries��5!      	 d� 	IsChecked$
	 trueY�6/   .��6@   	Mysteries6K   	� 5"      -   5        $ 	uxRomance��5"      .��6-   	Romance66   	� 5#      -   5        $ uxThrillers��5#      .��6/   	Thrillers6:   	� 5$      -   5        $ uxScifi��5$      .��6+   Scifi62   	� 5%      -	   5        $ 	uxFantasy��5%      .��6-   	Fantasy66   	� 5&      -
   5        $ uxHistorical��5&      .��60   
Historical6<   5'      �� 5)   
   $��0��6   $��3��6$   $��Right=�61   Progrssion(Page#):6a   �� 5*   
   -   5        $ uxPage��5*      $��1��68   $��3��6H   ��6"   �� *Page+6W   �� 5,   
   $��0��6   $��4��6$   $��Right=�61   Notes:6U   �� 5-   
   -   5        $ uxNotes��5-      $��1��6:   $��4��6J   
 �� AcceptsReturn$

 True��6W    �� TextWrapping$
 Wrap=�6l   $��60��6�   ��6#   �� *Notes+6�   �� 5/   
   $ 
Horizontal=�6   $��1��6.   $��5��6>   $��Right=�6K   .+�50      �� -   5         ��Name$ uxSubmit��50      $��10��6(   $��Center=�66   $��10q�6j   .��6v   Add6{   �� 51      -   5        $ uxCancel��51      $��10��6(   $��Center=�66   $��10q�6j   .��6v   Cancel6~   52      53      54      