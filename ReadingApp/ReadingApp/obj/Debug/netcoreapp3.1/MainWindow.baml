   M S B A M L   `   `   `  ����E  AReadingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ReadingApp
ReadingApp  5   	       ReadingApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ReadingApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $
��1100��6)   .��5	      �� .+�5
   
   o� .@�5      m� $��_File��6   .@�5      m� -   5         m�Name$ uxAdd��5      $
��_Add��6*   6N   m� 5      -   5        $ uxModify��5      $��_Modify��6-   6p   m� 5      -   5        $ uxDelete��5      $��_Delete��6-   6p   m� 5      -   5        $��E_xit��5      6A   5      5      �� 5   
   -   5         ��Name$ uxReadingList��5      $	��350��6*    � ContextMenu 5      �� 5      .@�5      m� -   5        $ uxContextAdd��5      $
��_Add��65   6C   m� 5      -   5        $ uxContextModify��5      $��_Modify��68   6`   m� 5      -   5        $ uxContextDelete��5      $��_Delete��68   6`   5       �� View 5      �� 5      .P�5      �� -	   5        uxListHeader��$��Title��5   b    �� Width$	 250��6q    �� DisplayMemberBinding 6;   �� *Title+6q   �� 5      $��Author��6M   $	 100��6]    6%   �� *Author+6]   �� 5      $
��Type��6K   $ 70��6Y    6%   �� *Type+6Y   �� 5      $
��Page��6K   $ 50��6Y    6%   �� *Page+6Y   �� 5       $��Notes��6L   $
 auto��6[    6%   �� *Notes+6[   5!      5#      �� 5$   
    �� Orientation$ 
Horizontal=�6   .+�5%      �� $��Search by        ��6   	� 5&      -
   5         	�Name$ uxTitle��5&      	 d� 	IsChecked$
	 trueY�6+   .��6<   Title6C   	� 5'      -   5        $ uxAuthor��5'      .��6,   Author64   5(      �� 5*   
   -   5        
 ��Name$
 uxSearch��5*      $�� ��6$   6-   5+      5,      