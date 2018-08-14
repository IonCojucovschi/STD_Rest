// This file has been autogenerated from a class added in the UI designer.

using System;
using iOS.Page.BasePage;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using UIKit;

namespace iOS.Storyboard
{
    public partial class Call : BasePageNavigation<CallViewModel>
    {
        public Call(IntPtr handle) : base(handle) { }
    }

    public partial class Call
    {
        [CrossView(nameof(CallViewModel.TitleText))]
        public UILabel view111 => lblTitle;

        [CrossView(nameof(CallViewModel.TableNrText))]
        UILabel view21 => lblTableNr;

        [CrossView(nameof(CallViewModel.TableNrValueText))]
        UILabel view31 => lblTableNrValue;

        [CrossView(nameof(CallViewModel.ConfirmTableText))]
        UILabel view41 => lblConfirm;

        [CrossView(nameof(CallViewModel.ViewQR))]
        UIView view51 => viewQR;


        [CrossView(nameof(CallViewModel.View1))]
        UIView view6 => line1;

        [CrossView(nameof(CallViewModel.View2))]
        UIView view7 => line2;

        [CrossView(nameof(CallViewModel.View3))]
        UIView view8 => line3;

        [CrossView(nameof(CallViewModel.View4))]
        UIView view9 => line4;

        [CrossView(nameof(CallViewModel.View5))]
        UIView view10 => line5;

        [CrossView(nameof(CallViewModel.View6))]
        UIView view11 => line6;

        [CrossView(nameof(CallViewModel.View7))]
        UIView view12 => line7;

        [CrossView(nameof(CallViewModel.View8))]
        UIView view13 => line8;


        [CrossView(nameof(CallViewModel.ImageQR))]
        UIImageView view14 => imgQR;

        [CrossView(nameof(CallViewModel.ImageScan))]
        UIImageView view15 => imgLoading;

        [CrossView(nameof(CallViewModel.ContentView))]
        UIView propName3 => viewBackroundContent;
    }
}