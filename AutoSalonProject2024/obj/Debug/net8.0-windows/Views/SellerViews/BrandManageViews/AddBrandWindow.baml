   M S B A M L   `   `   `  ����O  KAutoSalonProject2024, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Eclr-namespace:AutoSalonProject2024.Views.SellerViews.BrandManageViews7AutoSalonProject2024.Views.SellerViews.BrandManageViews  5   	   L    FAutoSalonProject2024.Views.SellerViews.BrandManageViews.AddBrandWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   WlocalEclr-namespace:AutoSalonProject2024.Views.SellerViews.BrandManageViews     5   	     � Title$  AddBrandWindow��5   	   $	��450��6    $	��300��6-    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5	      �� .+�5
   
   �� $��20(�6   $��	60,20,0,0q�6"   Add new car brand6H   �� 5   
   $��90,0,0,0q�6   .��6"   Select Country:63   �� 5   
   -   5        $��CountryComboBox��5   {   $	��120��6    �� DisplayMemberPath$
 Name��6A   ��6   �� *	Countries+ �� SelectedItem 6Z   �� *	Country+6�   �� 5   
   -   5        $��comboBoxValidation��5   E   $y�	Collapsed=�6   $��30��6'   $��70,0,0,0q�63   
���  ��.��6p   Country must be selected6�   �� 5   
   -   5        $��brandNameLBL��5   #   $��	87,30,0,0q�6   .��67   Enter brand name:6J   �� 5   
   -   5        $��	BrandName��5   p   $	��120��6   $��21��6   ��6*   �� *	BrandName+6�   �� 5   
   -   5        $��lengthValidation��5   '   $y�	Collapsed=�6   $��20,0,0,0q�6?   
���  ��$��30��6b   .��6n   -+Brand name must be at least three charaters6�   �� 5   
   -   5        $��existValidation��5   '   $y�	Collapsed=�6   $��65,0,0,0q�6>   
���  ��$��30��6a   .��6m   Brand name already exists6�   �� 5   
   -   5        $��	SubmitBTN��5   [   $��0,50,0,0q�6   $	��100��6#   $��5q�6/   ��6;   �� *CreateBrand+.��6l   Submit6t   5      5      