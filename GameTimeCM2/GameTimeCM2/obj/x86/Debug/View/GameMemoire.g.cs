﻿#pragma checksum "C:\trunk\dev\GameTimeCM2\GameTimeCM2\GameTimeCM2\View\GameMemoire.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7BA7011E03450DF8CA459B264FE0E9CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameTimeCM2
{
    partial class GameMemoire : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\GameMemoire.xaml line 15
                {
                    this.Memory = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // View\GameMemoire.xaml line 18
                {
                    this.Storyboard_StackFinishGame = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 4: // View\GameMemoire.xaml line 34
                {
                    this.Storyboard_StackNewGame = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 5: // View\GameMemoire.xaml line 54
                {
                    this.grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // View\GameMemoire.xaml line 71
                {
                    this.Stack_FinishGame = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7: // View\GameMemoire.xaml line 73
                {
                    this.RT_FG = (global::Windows.UI.Xaml.Media.CompositeTransform)(target);
                }
                break;
            case 8: // View\GameMemoire.xaml line 79
                {
                    this.TextNbCoup = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // View\GameMemoire.xaml line 80
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.Click_BtnOtherGame;
                }
                break;
            case 10: // View\GameMemoire.xaml line 81
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.Click_BtnReGame;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

