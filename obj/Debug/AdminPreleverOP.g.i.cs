﻿#pragma checksum "..\..\AdminPreleverOP.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CAECCE6C93AC0A260B0E24FAD73B850845D7F3E018B61D4D89ADFE1058BD32BD"
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
    /// AdminPreleverOP
    /// </summary>
    public partial class AdminPreleverOP : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\AdminPreleverOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInfo;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AdminPreleverOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDollarSign;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AdminPreleverOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCodeCli;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AdminPreleverOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCodeCli;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AdminPreleverOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMontant;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AdminPreleverOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMontant;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AdminPreleverOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrélever;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AdminPreleverOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMenu;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AdminPreleverOP.xaml"
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
            System.Uri resourceLocater = new System.Uri("/guichetauto_projet;component/adminpreleverop.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminPreleverOP.xaml"
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
            this.lblDollarSign = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblCodeCli = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtCodeCli = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\AdminPreleverOP.xaml"
            this.txtCodeCli.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtEntree_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblMontant = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtMontant = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\AdminPreleverOP.xaml"
            this.txtMontant.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtMontant_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPrélever = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\AdminPreleverOP.xaml"
            this.btnPrélever.Click += new System.Windows.RoutedEventHandler(this.btnPrelever_click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnMenu = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\AdminPreleverOP.xaml"
            this.btnMenu.Click += new System.Windows.RoutedEventHandler(this.btnMenu_click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnQuit = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\AdminPreleverOP.xaml"
            this.btnQuit.Click += new System.Windows.RoutedEventHandler(this.btnQuitter_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

