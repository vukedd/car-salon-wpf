﻿#pragma checksum "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87B8C308A5E0D839A1A7E167874F6E582F0C77AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoSalonProject2024.Models;
using AutoSalonProject2024.Views.SellerViews;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AutoSalonProject2024.Views.SellerViews {
    
    
    /// <summary>
    /// HomepageWindow
    /// </summary>
    public partial class HomepageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBar;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceRangeFromTxtBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceRangeToTxtBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PropertySortCombo;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SortOrderCombo;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WelcomeMsg;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CarListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AutoSalonProject2024;component/views/sellerviews/homepagewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.LogOutMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 19 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNewButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 20 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 21 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 22 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaleButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 24 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowSalesButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 26 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowBrandsButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 27 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowModelsButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SearchBar = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            this.SearchBar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.PriceRangeFromTxtBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            this.PriceRangeFromTxtBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PriceRangeFromTxtBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 12:
            this.PriceRangeToTxtBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            this.PriceRangeToTxtBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PriceRangeToTxtBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 37 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PriceRangeSubmit);
            
            #line default
            #line hidden
            return;
            case 14:
            this.PropertySortCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            this.PropertySortCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PropertySortCombo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.SortOrderCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 44 "..\..\..\..\..\Views\SellerViews\HomepageWindow.xaml"
            this.SortOrderCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortOrderCombo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.WelcomeMsg = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 17:
            this.CarListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

