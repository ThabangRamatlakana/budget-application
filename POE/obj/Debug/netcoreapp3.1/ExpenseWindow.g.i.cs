﻿#pragma checksum "..\..\..\ExpenseWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80AC4BA41AF51F8CE517682C340623454C5C8188"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POE;
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


namespace POE {
    
    
    /// <summary>
    /// ExpenseWindow
    /// </summary>
    public partial class ExpenseWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\ExpenseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxGroceries;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\ExpenseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxWaterAndElectricity;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ExpenseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxTravel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\ExpenseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxCellphone;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ExpenseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxOther;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ExpenseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSaveExpenses;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ExpenseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonNextExpense;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/POE;component/expensewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ExpenseWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBoxGroceries = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBoxWaterAndElectricity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxTravel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxCellphone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextBoxOther = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ButtonSaveExpenses = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\ExpenseWindow.xaml"
            this.ButtonSaveExpenses.Click += new System.Windows.RoutedEventHandler(this.ButtonSaveExpenses_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonNextExpense = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\ExpenseWindow.xaml"
            this.ButtonNextExpense.Click += new System.Windows.RoutedEventHandler(this.NextExpense);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
