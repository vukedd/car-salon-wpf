   M S B A M L   `   `   `  ����O  KAutoSalonProject2024, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:AutoSalonProject2024.Views.SellerViews.CarManageViews5AutoSalonProject2024.Views.SellerViews.CarManageViews  5   	   H    BAutoSalonProject2024.Views.SellerViews.CarManageViews.AddCarWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   UlocalCclr-namespace:AutoSalonProject2024.Views.SellerViews.CarManageViews     5   	     � Title$  AddCarWindow��5   	   $	��780��6   $	��500��6+    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6\   .��5	      �� .+�5
   
   �� $��40(�6   $��	170,0,0,0q�6"   	Add car6>   �� 5   
   $��15(�6   $��	210,0,0,0q�6   .��61   Brand:69   �� 5   
   -   5        $��
brandCombo��5   �   $	��100��6   $��22��6    �� DisplayMemberPath$
 Name��6J   ��6+   �� *Brands+ �� SelectedItem 6�   �� *
CarBrand+�� 5   
   -   5        $��BrandValidationLabel��5   H   
���  ��$��	170,0,0,0q�6!   $y�Hidden=�64   .��6d   Car brand must be selected!6�   �� 5   
   $��15(�6   $��	205,0,0,0q�6   .��61   Model:69   �� 5   
   -   5        $��modelsCombo��5   D   $	��100��6   $��22��6   $
 Name��6+    6W   �� *
CarModel+6y   �� 5   
   -   5        $��ModelValidationLabel��5   H   
���  ��$��	160,0,0,0q�6!   $y�Hidden=�64   .��6d   Car model must be selected!6�   �� 5   
   $��15(�6   $��	185,0,0,0q�6   .��61   Production year:6C   �� 5   
   -   5        $��ProductionYearTB��5   I   $��20��6   $��80��6   ��6)   �� *ProductionYear+6�   �� 5   
   -   5        $#��ProductionYearValidationLabel��5   H   
���  ��$��	120,0,0,0q�6!   $y�Hidden=�64   .��6m   0.*Production year must be between 1950 and 20256�   �� 5   
   $��15(�6   $��	190,0,0,0q�6   .��61   Horse power:6?   �� 5   
   -   5        $��HorsePowerTB��5   q   $��20��6   $��80��6   ��6)   �� *
HorsePower+6�   �� 5   
   -   5        $��HorsePowerValidationLabel��5   H   
���  ��$��	135,0,0,0q�6!   $y�Hidden=�64   .��6i   &$*Horse power must be from 50 to 10006�   �� 5   
   $��15(�6   $��	185,0,0,0q�6   .��61   Purchase price:6B   �� 5   
   -	   5        $��PurchasePriceTB��5   u   $��20��6   $	��120��6   ��6*   �� *PurchasePrice+6�   �� 5   
   -
   5        $"��PurchasePriceValidationLabel��5   G   
���  ��$��90,0,0,0q�6!   $y�Hidden=�63   .��6k   =;*Purchase price must be greater than 0 and less than 5 mil.6�   �� 5   
   $��15(�6   $��	205,0,0,0q�6   $��
Fuel type:��61   �� 5   
   -   5        $��fuelType��5   +   $	��100��6   $��22��6    6;   �� *
FuelType+6�   �� 5   
   -   5        $��FuelTypeValidationLabel��5   H   
���  ��$��	160,0,0,0q�6!   $y�Hidden=�64   .��6g   FuelType must be selected!6�   �� 5   
   $��	190,0,0,0q�6   $��15(�6#   .��61   Purchase date:6A   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��PurchaseDateDP��5   >   $	��120��6   $��25��6!   $��0,0,0,0q�6-      SelectedDate 6T   �� *PurchaseDate+6|   �� 5   
   $��
195,20,0,0q�6   $��15(�6%   .��63   Car images:6@   �� 5    
   -   5        $��
Add_Images��5    H   $	��100��6<   ��6   �� *UploadAndProcessImages+.��6Z   
Add images6f   �� 5!   
   -   5        $��ImageUploadLBL��5!      $��	180,0,0,0q�6&   .��69   No images uploaded*6N   �� 5"   
   $��50��6   $��30��6   $��0,10,0,0q�6(   ��6:   �� *AddCar+.��6U   Submit6]   5#      5$      