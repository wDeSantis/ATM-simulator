﻿#pragma checksum "..\..\DepotEpargne.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5E3398F5EE42CA6C0170EEB8F248902621A9BA0CFA3639CB3D85C728D898290A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using guichetauto_projet;


namespace guichetauto_projet {
    
    
    /// <summary>
    /// DepotEpargne
    /// </summary>
    public partial class DepotEpargne : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\DepotEpargne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDollarSign;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\DepotEpargne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMontant;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\DepotEpargne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMontant;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\DepotEpargne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDéposer;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\DepotEpargne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMenu;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\DepotEpargne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnQuit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/guichetauto_projet;component/depotepargne.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DepotEpargne.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblDollarSign = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblMontant = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtMontant = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\DepotEpargne.xaml"
            this.txtMontant.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtMontant_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDéposer = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\DepotEpargne.xaml"
            this.btnDéposer.Click += new System.Windows.RoutedEventHandler(this.btnDeposerEpargne_click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnMenu = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\DepotEpargne.xaml"
            this.btnMenu.Click += new System.Windows.RoutedEventHandler(this.btnMenu_click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnQuit = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\DepotEpargne.xaml"
            this.btnQuit.Click += new System.Windows.RoutedEventHandler(this.btnQuitter_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

