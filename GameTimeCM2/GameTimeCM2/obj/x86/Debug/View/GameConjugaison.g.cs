﻿#pragma checksum "C:\Users\jonat\OneDrive\Bureau\trunk\dev\GameTimeCM2\GameTimeCM2\GameTimeCM2\View\GameConjugaison.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8262C000650628ABC71E04DC54AAA3EB"
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
    partial class GameConjugaison : 
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
            case 2: // View\GameConjugaison.xaml line 12
                {
                    this.StoryCard = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 3: // View\GameConjugaison.xaml line 21
                {
                    this.GameConju = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // View\GameConjugaison.xaml line 34
                {
                    this.Cards = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // View\GameConjugaison.xaml line 37
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Btn_CheckReponse;
                }
                break;
            case 6: // View\GameConjugaison.xaml line 30
                {
                    this.TextQuestion = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // View\GameConjugaison.xaml line 31
                {
                    this.TextScore = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // View\GameConjugaison.xaml line 26
                {
                    this.btn_ = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_).Click += this.Btn_QuitGame;
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

