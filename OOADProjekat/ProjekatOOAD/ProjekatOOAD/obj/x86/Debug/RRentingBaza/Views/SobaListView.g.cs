﻿#pragma checksum "C:\Users\XMAN\Untitled\OOADProjekat\ProjekatOOAD\ProjekatOOAD\RRentingBaza\Views\SobaListView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E8BDD154F0BD42A0F3EBE5DC2522E256"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjekatOOAD.RRentingBaza.Views
{
    partial class SobaListView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 9 "..\..\..\..\RRentingBaza\Views\SobaListView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.CijenaSobeTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.CijenaSobeInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.BrojKrevetaTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.BrojKrevetaInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.buttonDodaj = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 41 "..\..\..\..\RRentingBaza\Views\SobaListView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.buttonDodaj).Click += this.buttonDodaj_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.SlikaSobeLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.buttonUpload = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 46 "..\..\..\..\RRentingBaza\Views\SobaListView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.buttonUpload).Click += this.buttonUpload_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.SobeIS = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

