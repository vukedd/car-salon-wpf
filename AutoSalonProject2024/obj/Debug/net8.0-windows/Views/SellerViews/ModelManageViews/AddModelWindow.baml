   M S B A M L   `   `   `  ����O  KAutoSalonProject2024, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Eclr-namespace:AutoSalonProject2024.Views.SellerViews.ModelManageViews7AutoSalonProject2024.Views.SellerViews.ModelManageViews  5   	   L    FAutoSalonProject2024.Views.SellerViews.ModelManageViews.AddModelWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   WlocalEclr-namespace:AutoSalonProject2024.Views.SellerViews.ModelManageViews     5   	     � Title$  AddModelWindow��5   	   $	��450��6    $	��300��6-    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5	      �� .+�5
   
   �� $��20(�6   $��	60,20,0,0q�6"   Add new car model6H   �� 5   
   $��
100,10,0,0q�6   .��6$   Select brand:63   �� 5   
   -   5        $��CarBrandCombo��5   y    �� DisplayMemberPath$
 Name��62   $	��150��6K   ��6   �� *Brands+ �� SelectedItem 6W   �� *
carBrand+6�   �� 5   
   -   5        $��CarBrandValidation��5   J   
���  ��$��72,0,0,0q�6!   $y�	Collapsed=�63   .��6d   Car brand must be selected!6�   �� 5   
   $��
120,10,0,0q�6   .��6$   Name:6+   �� 5   
   -   5        $��CarModelNameTB��5   v   $��22��6   $	��150��6   ��6*   �� *carModelName+6�   �� 5   
   -   5        $��CarModelValidation��5   J   
���  ��$��22,0,0,0q�6!   $y�	Collapsed=�63   .��6d   .,Model name must be longer than 3 characters!6�   �� 5   
   $��0,20,0,0q�6   $	��100��6#   $��10q�6/   ��6<   �� *AddCarModel+.��6\   Submit6d   5      5      