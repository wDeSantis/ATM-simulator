﻿#pragma checksum "..\..\AdminBloquageOP.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BD27100A20D617105416069F5E171688D7021BC12E6462FAD58C48F627912509"
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
    /// AdminBloquageOP
    /// </summary>
    public partial class AdminBloquageOP : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\AdminBloquageOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCodeCli;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AdminBloquageOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCodeCli;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AdminBloquageOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBloquer;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AdminBloquageOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDebloquer;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AdminBloquageOP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMenu;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AdminBloquageOP.xaml"
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
            System.Uri resourceLocater = new System.Uri("/guichetauto_projet;component/adminbloquageop.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminBloquageOP.xaml"
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
            this.lblCodeCli = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.txtCodeCli = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\AdminBloquageOP.xaml"
            this.txtCodeCli.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtEntree_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnBloquer = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\AdminBloquageOP.xaml"
            this.btnBloquer.Click += new System.Windows.RoutedEventHandler(this.btnBloquer_click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDebloquer = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\AdminBloquageOP.xaml"
            this.btnDebloquer.Click += new System.Windows.RoutedEventHandler(this.btnDebloquer_click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnMenu = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\AdminBloquageOP.xaml"
            this.btnMenu.Click += new System.Windows.RoutedEventHandler(this.btnMenu_click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnQuit = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\AdminBloquageOP.xaml"
            this.btnQuit.Click += new System.Windows.RoutedEventHandler(this.btnQuitter_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

