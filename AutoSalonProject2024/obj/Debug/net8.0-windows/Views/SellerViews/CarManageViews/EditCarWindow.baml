   M S B A M L   `   `   `  ����O  KAutoSalonProject2024, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:AutoSalonProject2024.Views.SellerViews.CarManageViews5AutoSalonProject2024.Views.SellerViews.CarManageViews  5   	   I    CAutoSalonProject2024.Views.SellerViews.CarManageViews.EditCarWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   UlocalCclr-namespace:AutoSalonProject2024.Views.SellerViews.CarManageViews     5   	     � Title$  EditCarWindow��5   	   $	��750��6   $	��500��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N   .��5	      �� .+�5
   
   �� $��40(�6   $��	170,0,0,0q�6"   
Edit car6?   �� 5   
   $��15(�6   $��	210,0,0,0q�6   .��61   Brand:69   �� 5   
   -   5        $��
brandCombo��5   �   $	��100��6   $��25��6    �� DisplayMemberPath$
 Name��6y   ��6+   �� *Brands+ �� SelectedItem 6�   �� *
CarBrand+�� 5   
   -   5        $��CarBrandValidationLabel��5   H   
���  ��$��	120,0,0,0q�6!   $y�Hidden=�64   .��6g   Car brand must be selected!6�   �� 5   
   $��15(�6   $��	205,0,0,0q�6   .��61   Model:69   �� 5   
   -   5        $��modelsCombo��5   D   $	��100��6   $��25��6   $
 Name��6+    6W   �� *
CarModel+�� 5   
   -   5        $��CarModelValidationLabel��5   H   
���  ��$��	120,0,0,0q�6!   $y�Hidden=�64   .��6g   Car model must be selected!6�   �� 5   
   $��15(�6   $��	175,0,0,0q�6   .��61   Year of production:6F   �� 5   
   -   5        $��ProductionYearTB��5   �   $��20��6   $��80��6   ��6)   �� *ProductionYear+6�   �� 5   
   -   5        $#��ProductionYearValidationLabel��5   H   
���  ��$��	120,0,0,0q�6!   $y�Hidden=�64   .��6m   /-Production year must be between 1950 and 20256�   �� 5   
   $��15(�6   $��	190,0,0,0q�6   .��61   Horse power:6?   �� 5   
   -   5        $��HorsePowerTB��5   �   $��20��6   $��80��6   ��6)   �� *
HorsePower+6�   �� 5   
   -   5        $��HorsePowerValidationLabel��5   H   
���  ��$��	120,0,0,0q�6!   $y�Hidden=�64   .��6i   &$*Horse power must be from 50 to 10006�   �� 5   
   $��15(�6   $��	185,0,0,0q�6   .��61   Purchase price:6B   �� 5   
   -	   5        $��PurchasePriceTB��5   �   $��20��6   $	��120��6   ��6*   �� *PurchasePrice+6�   �� 5   
   -
   5        $"��PurchasePriceValidationLabel��5   H   
���  ��$��	120,0,0,0q�6!   $y�Hidden=�64   .��6l   =;*Purchase price must be greater than 0 and less than 5 mil.6�   �� 5   
   $��15(�6   $��	205,0,0,0q�6   $��
Fuel type:��61   �� 5   
   -   5        $��fuelType��5   +   $	��100��6   $��25��6    6;   �� *
FuelType+6_   �� 5   
   -   5        $��FuelTypeValidationLabel��5   H   
���  ��$��	120,0,0,0q�6!   $y�Hidden=�64   .��6g   FuelType must be selected!6�   �� 5   
   $	��100��6   $��25��6   $��0,50,0,0q�6)   ��6;   �� *	EditCar+.��6W   Submit changes6g   5      5      