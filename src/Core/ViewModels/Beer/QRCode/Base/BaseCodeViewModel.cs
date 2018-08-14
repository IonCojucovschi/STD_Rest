//
//  BaseCodeViewModel.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2018 Songurov Fiodor
//
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
using System;
using Core.Extensions;
using Core.Helpers;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Core.Extensions;
using ZXing.Mobile;
using Core.Helpers.Manager;
using System.Threading;

namespace Core.ViewModels.Beer
{
    public abstract class BaseCodeViewModel : ProjectNavigationBaseViewModel
    {
        [CrossView]
        public IView BackgroundContainer { get; set; }


        [CrossView]
        public IText ConfirmTableText { get; set; }

        [CrossView]
        public IText TitleText { get; set; }

        [CrossView]
        public IText TableNrText { get; set; }

        [CrossView]
        public IText TableNrValueText { get; set; }

        [CrossView]
        public IView ViewQR { get; set; }


        [CrossView]
        public IView View1 { get; set; }

        [CrossView]
        public IView View2 { get; set; }

        [CrossView]
        public IView View3 { get; set; }

        [CrossView]
        public IView View4 { get; set; }

        [CrossView]
        public IView View5 { get; set; }

        [CrossView]
        public IView View6 { get; set; }

        [CrossView]
        public IView View7 { get; set; }

        [CrossView]
        public IView View8 { get; set; }

        [CrossView]
        public IImage ImageQR { get; set; }

        [CrossView]
        public IImage ImageScan { get; set; }

        public override void UpdateData()
        {
            base.UpdateData();

            BackgroundContainer?.SetBackgroundColor(ColorConstants.BackroundContent);

            View1?.SetBackgroundColor(ColorConstants.SelectorHome);
            View2?.SetBackgroundColor(ColorConstants.SelectorHome);
            View3?.SetBackgroundColor(ColorConstants.SelectorHome);
            View4?.SetBackgroundColor(ColorConstants.SelectorHome);
            View5?.SetBackgroundColor(ColorConstants.SelectorHome);
            View6?.SetBackgroundColor(ColorConstants.SelectorHome);
            View7?.SetBackgroundColor(ColorConstants.SelectorHome);
            View8?.SetBackgroundColor(ColorConstants.SelectorHome);

            ImageQR?.SetImageFromResource(DrawableConstants.QRBlurryIcon);

            if (ImageScan != null)
            {
                ImageScan.Visibility = ViewState.Visible;
                ImageScan?.SetImageFromResource(DrawableConstants.QRWaitIcon);
            }

            if (ConfirmTableText != null)
            {
                ConfirmTableText.Click -= ConfirmTableText_Click;
                ConfirmTableText.Click += ConfirmTableText_Click;

                ConfirmTableText.Text = RCode.ConfirmTable.ToUpperInvariant();
                ConfirmTableText.SetBackgroundColor(ColorConstants.BlackColor);
                ConfirmTableText.SetSelectedColor(ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent50));
                ConfirmTableText.SetTextColor(ColorConstants.WhiteColor);
                ConfirmTableText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
            }

            if (TitleText != null)
            {
                TitleText.Text = RCode.QrCode;
                TitleText.SetTextColor(ColorConstants.WhiteColor);
                TitleText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
            }

            if (TableNrText != null)
            {
                TableNrText.Text = RCode.TableNo;
                TableNrText.SetTextColor(ColorConstants.WhiteColor);
                TableNrText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
            }

            if (TableNrValueText != null)
            {
                TableNrValueText.Visibility = ViewState.Invisible;

                TableNrValueText.Text = string.Empty;
                TableNrValueText.SetTextColor(ColorConstants.SelectorHome);
                TableNrValueText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size36);
            }

            if (ImageQR.IsNull()) return;
            ImageQR.Click -= ImageQR_Click;
            ImageQR.Click += ImageQR_Click;
        }


        public async void ImageQR_Click(object sender, EventArgs e)
        {
#if __ANDROID__

            if ((int)Android.OS.Build.VERSION.SdkInt >= 23)
                Int.Droid.AppTools.CurrentActivity.RequestPermissions(new[] { Android.Manifest.Permission.Camera }, 0);

            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(Int.Droid.AppTools.CurrentActivity,
                                                                             Android.Manifest.Permission.Camera) == (int)Android.Content.PM.Permission.Granted)
                MobileBarcodeScanner.Initialize(Int.Droid.AppTools.ApplicationContext);
#endif
            HandleScanResult(await new MobileBarcodeScanner().Scan(new MobileBarcodeScanningOptions { AutoRotate = true }));
        }

        protected virtual void ConfirmTableText_Click(object sender, EventArgs e)
        {
            if (TableNrValueText.Text.IsNullOrWhiteSpace()) return;
            if (App.Instance.GetView(typeof(OrderTableViewModel)) is OrderTableViewModel a) a.TableNumber = TableNrValueText.Text;

            if (OrderManager.Instance.OrderType == OrderVisibility.Server)
            {
                Show();
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    OrderManager.Instance.UpdateOrder(TableNrValueText.Text, () =>
                    {
                        this.GoPage(PageConstants.PageNameOrderTable);
                    }, (obj) => ShowError(obj));
                });
            }
            else
                this.GoPage(PageConstants.PageNameOrderTable);
        }

        public void HandleScanResult(ZXing.Result result)
        {
            if (!string.IsNullOrEmpty(result?.Text))
            {
                if (TableNrValueText == null) return;
                if (int.TryParse(result.Text, out var number) && number > 0)
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
#if __ANDROID__
                        Thread.Sleep(1000);
#endif
                        TableNrValueText.Visibility = ViewState.Visible;

                        TableNrValueText.Text = result.Text;

                        ConfirmTableText?.SetBackgroundColor(ColorConstants.SelectorHome);
                        ConfirmTableText?.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));
                        ConfirmTableText?.SetTextColor(ColorConstants.WhiteColor);

                        ImageQR?.SetImageFromResource(DrawableConstants.QRIcon);

                        if (ImageScan != null)
                            ImageScan.Visibility = ViewState.Invisible;
                    });

                }
                else
                    ShowError(RCode.ReadAgain);
            }
            //else
            //ShowError(RCode.Error);
        }
    }
}
