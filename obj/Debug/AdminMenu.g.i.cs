﻿#pragma checksum "..\..\AdminMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BE221BBAA10F4074951AC8F2BE5816968C79DC74D546F4696B44071F0D3E5C77"
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
    /// AdminMenu
    /// </summary>
    public partial class AdminMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInfo;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInfo2;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClient;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCompte;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGuichet;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInteret;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrelever;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMarge;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AdminMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTransaction;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AdminMenu.xaml"
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
            System.Uri resourceLocater = new System.Uri("/guichetauto_projet;component/adminmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminMenu.xaml"
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
            this.lblInfo = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblInfo2 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnClient = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\AdminMenu.xaml"
            this.btnClient.Click += new System.Windows.RoutedEventHandler(this.btnClient_click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCompte = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\AdminMenu.xaml"
            this.btnCompte.Click += new System.Windows.RoutedEventHandler(this.btnCompte_click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnGuichet = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\AdminMenu.xaml"
            this.btnGuichet.Click += new System.Windows.RoutedEventHandler(this.btnGuichet_click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnInteret = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\AdminMenu.xaml"
            this.btnInteret.Click += new System.Windows.RoutedEventHandler(this.btnInteret_click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPrelever = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\AdminMenu.xaml"
            this.btnPrelever.Click += new System.Windows.RoutedEventHandler(this.btnPrelever_click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnMarge = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\AdminMenu.xaml"
            this.btnMarge.Click += new System.Windows.RoutedEventHandler(this.btnMarge_click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnTransaction = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\AdminMenu.xaml"
            this.btnTransaction.Click += new System.Windows.RoutedEventHandler(this.btnAfficherTransac_click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnQuit = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\AdminMenu.xaml"
            this.btnQuit.Click += new System.Windows.RoutedEventHandler(this.btnQuitter_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

