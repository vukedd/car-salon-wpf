   M S B A M L   `   `   `  ����O  KAutoSalonProject2024, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:AutoSalonProject2024.Views.SellerViews.CarManageViews5AutoSalonProject2024.Views.SellerViews.CarManageViews  5   	   F    @AutoSalonProject2024.Views.SellerViews.CarManageViews.SaleWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   UlocalCclr-namespace:AutoSalonProject2024.Views.SellerViews.CarManageViews     5   	     � Title$  
SaleWindow��5   	   $	��550��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z   .��5	      �� .+�5
   
   �� $��40(�6   $��90,0,0,0q�6"   Create Sale6A   �� 5   
   $��15(�6   $��	150,0,0,0q�6   .��61   Sale price:6>   �� 5   
   -   5        $��	SalePrice��5   *   $��20��6   $	��140��6   ��6;   �� *	SalePrice+6�   �� 5   
   -   5        $��SalePriceValidationLabel��5   V   $��	110,0,0,0q�6   
���  ��$��10(�64   $y�Hidden=�6B   .��6v   '%Sale price must be at least 500 euros6�   �� 5   
   $��15(�6   $��	150,0,0,0q�6   .��61   Buyer name:6>   �� 5   
   -   5        $��	BuyerName��5   *   $��20��6   $	��140��6   ��6;   �� *BuyerFullName+6�   �� 5   
   -   5        $��BuyerNameValidationLabel��5   U   $��30,0,0,0q�6   $��10(�6"   
���  ��$y�Hidden=�6A   .��6u   ECBuyer name cannot containt numbers and must be 3-20 characters long6�   �� 5   
   $��15(�6   $��	130,0,0,0q�6   .��61   Buyer Id number:6C   �� 5   
   -   5        $��BuyerIdNumber��5   *   $��20��6   $	��140��6   ��6?   �� *BuyerIdNumber+6�   �� 5   
   -   5        $��IdNumValidationLabel��5   H   
���  ��$��	110,0,0,0q�6!   $y�Hidden=�64   .��6d   !Id number must contain 9 digits6�   �� 5   
   $��15(�6   $��30��6   $	��100��6+   $��0,20,0,0q�67   ��6I   �� *
CreateSale+.��6h   
Sell car6r   5      5      