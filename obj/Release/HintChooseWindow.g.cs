﻿#pragma checksum "..\..\HintChooseWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AB2B8A458A6E22E90AD3C82603838EF06A56BD444A92608B164C00C8957F3DA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp3;


namespace WpfApp3 {
    
    
    /// <summary>
    /// HintChooseWindow
    /// </summary>
    public partial class HintChooseWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\HintChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectHintsText;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\HintChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ChangeQuestion;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\HintChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ViewersSupport;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\HintChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox HalfAnswers;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\HintChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AddLife;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\HintChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CallFriend;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\HintChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetHintsButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp3;component/hintchoosewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HintChooseWindow.xaml"
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
            this.SelectHintsText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ChangeQuestion = ((System.Windows.Controls.CheckBox)(target));
            
            #line 23 "..\..\HintChooseWindow.xaml"
            this.ChangeQuestion.Checked += new System.Windows.RoutedEventHandler(this.HintSelection_Checked);
            
            #line default
            #line hidden
            
            #line 23 "..\..\HintChooseWindow.xaml"
            this.ChangeQuestion.Unchecked += new System.Windows.RoutedEventHandler(this.HintSelection_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ViewersSupport = ((System.Windows.Controls.CheckBox)(target));
            
            #line 24 "..\..\HintChooseWindow.xaml"
            this.ViewersSupport.Checked += new System.Windows.RoutedEventHandler(this.HintSelection_Checked);
            
            #line default
            #line hidden
            
            #line 24 "..\..\HintChooseWindow.xaml"
            this.ViewersSupport.Unchecked += new System.Windows.RoutedEventHandler(this.HintSelection_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.HalfAnswers = ((System.Windows.Controls.CheckBox)(target));
            
            #line 25 "..\..\HintChooseWindow.xaml"
            this.HalfAnswers.Checked += new System.Windows.RoutedEventHandler(this.HintSelection_Checked);
            
            #line default
            #line hidden
            
            #line 25 "..\..\HintChooseWindow.xaml"
            this.HalfAnswers.Unchecked += new System.Windows.RoutedEventHandler(this.HintSelection_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddLife = ((System.Windows.Controls.CheckBox)(target));
            
            #line 26 "..\..\HintChooseWindow.xaml"
            this.AddLife.Checked += new System.Windows.RoutedEventHandler(this.HintSelection_Checked);
            
            #line default
            #line hidden
            
            #line 26 "..\..\HintChooseWindow.xaml"
            this.AddLife.Unchecked += new System.Windows.RoutedEventHandler(this.HintSelection_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CallFriend = ((System.Windows.Controls.CheckBox)(target));
            
            #line 27 "..\..\HintChooseWindow.xaml"
            this.CallFriend.Checked += new System.Windows.RoutedEventHandler(this.HintSelection_Checked);
            
            #line default
            #line hidden
            
            #line 27 "..\..\HintChooseWindow.xaml"
            this.CallFriend.Unchecked += new System.Windows.RoutedEventHandler(this.HintSelection_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GetHintsButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\HintChooseWindow.xaml"
            this.GetHintsButton.Click += new System.Windows.RoutedEventHandler(this.GetHintsButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
