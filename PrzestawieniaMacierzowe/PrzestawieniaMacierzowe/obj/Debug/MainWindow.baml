   M S B A M L   `   `   `  ����R  NPrzestawieniaMacierzowe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PrzestawieniaMacierzowePrzestawieniaMacierzowe  5   	   (    "PrzestawieniaMacierzowe.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:PrzestawieniaMacierzowe     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      6   �� 5      $��40 �6   6*   �� 5      6   .+�5   
   �� $��Center=�6   .��64   	3-4-1-5-26?   �� 5   
   $��1��6   $��Center=�6    .��6D   	3-4-1-5-26O   �� 5   
   -   5        $��EncryptInput��5      $��1��6   $��Center=�63   .��6W   CRYPTOGRAPHY6e   �� 5   
   -   5        $��DecryptInput��5      $��1��6   $��1��63   $��Center=�6C   .��6g   YPCTRRAOPGHY6u   �� 5   
   -   5        $��2��5      $��Center=�6.   .��6R   	Zaszyfruj6]   �� 5   
   -   5        $��2��5      $��1��6   $��Center=�6>   .��6b   	Odszyfruj6m   �� 5   
   -   5        $��EncryptedText��5      $��3��6   $��Center=�64   6Z   �� 5    
   -   5        $��DecryptedText��5    /   $��3��6   $��1��6   $��Center=�6D   6j   5!      5"      