﻿#pragma checksum "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34D1ABFE5D6BAA4B4AFC8162F7EC422242B6325B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoSalonProject2024.Views.SellerViews.CarManageViews;
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


namespace AutoSalonProject2024.Views.SellerViews.CarManageViews {
    
    
    /// <summary>
    /// SaleWindow
    /// </summary>
    public partial class SaleWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SalePrice;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SalePriceValidationLabel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BuyerName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BuyerNameValidationLabel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BuyerIdNumber;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IdNumValidationLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/AutoSalonProject2024;component/views/sellerviews/carmanageviews/salewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
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
            this.SalePrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
            this.SalePrice.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SalePrice_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
            this.SalePrice.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SalePrice_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SalePriceValidationLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.BuyerName = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
            this.BuyerName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.BuyerName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BuyerNameValidationLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.BuyerIdNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
            this.BuyerIdNumber.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.BuyerIdNumber_TextChanged);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\..\..\Views\SellerViews\CarManageViews\SaleWindow.xaml"
            this.BuyerIdNumber.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.BuyerId_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.IdNumValidationLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

