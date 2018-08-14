//
//  PPHelper.cs
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
using Xamarin.PayPal.Android;
using Android.Content;
using Android.App;
using Core.Helpers.Manager;
using Java.Math;
using Int.Droid;
using Core;

namespace Droid.Helpers
{
    public static class PPHelper
    {
        static PPHelper()
        {
            Config = new PayPalConfiguration()
                                            .Environment("sandbox")
                                            .ClientId("ASI_ZzQqUEU_v5QFwOeMxb2d03doX0qOLxCmtYNbxuNfmpFn_cZaHdJpVP_jiJ_ZAUsEK_jgjr6kIcnL")
                                            .AcceptCreditCards(true)
                                              .MerchantName("Stadium")
                                              .MerchantPrivacyPolicyUri(Android.Net.Uri.Parse("https://www.example.com/privacy"))
                                              .MerchantUserAgreementUri(Android.Net.Uri.Parse("https://www.example.com/legal"));
        }

        public static PayPalConfiguration Config { get; }


        public const int RequestCodePayment = 0xF;

        private static PayPalPayment GetPayment()
        {
            return new PayPalPayment(new BigDecimal(OrderManager.Instance.GetPrice),
                                     App.CurrencyPaypal,
                                     App.PaypalName,
                                     PayPalPayment.PaymentIntentSale);
        }

        public static void Buy()
        {
            var intent = new Intent(AppTools.CurrentActivity, typeof(PaymentActivity));
            intent.PutExtra(PayPalService.ExtraPaypalConfiguration, Config);
            intent.PutExtra(PaymentActivity.ExtraPayment, GetPayment());
            AppTools.CurrentActivity.StartActivityForResult(intent, RequestCodePayment);
        }

        public static bool ProcessResponse(int requestCode,
                                           Result resultCode,
                                           Intent data, Action<string> successPaymentId, Action error, Action cancelPayment)
        {
            if (requestCode != RequestCodePayment) return false;
            switch (resultCode)
            {
                case Result.Ok:
                    var confirm = (PaymentConfirmation)data.
                        GetParcelableExtra(PaymentActivity.ExtraResultConfirmation);

                    if (confirm.ProofOfPayment.State == "approved")
                    {
                        successPaymentId?.Invoke(confirm.ProofOfPayment.PaymentId);

                        return true;
                    }

                    error?.Invoke();

                    break;
                case Result.Canceled:
                    cancelPayment?.Invoke();
                    break;
                default:
                    error?.Invoke();
                    break;
            }
            return false;
        }
    }
}
