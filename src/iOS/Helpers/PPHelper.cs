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

using Core;
using Core.Helpers.Manager;
using Foundation;
using Int.iOS;
using Xam.PayPal.iOS;

namespace iOS.Helpers
{
    public static class PPHelper
    {
        static PPHelper()
        {
            NSMutableDictionary dict = null;

            //if (AppData.Instance.PaypalConfig.Environment.Contains("live"))
            //{
            //    dict = new NSMutableDictionary
            //    {
            //        {Xamarin.PayPal.iOS.Constants.PayPalEnvironmentProduction, new NSString("clientId")}
            //    };
            //}
            //else
            //{
            dict = new NSMutableDictionary
                {
                    {
                        Constants.PayPalEnvironmentSandbox, new NSString("ASI_ZzQqUEU_v5QFwOeMxb2d03doX0qOLxCmtYNbxuNfmpFn_cZaHdJpVP_jiJ_ZAUsEK_jgjr6kIcnL")
                    }
                };
            //}

            PayPalMobile.InitializeWithClientIdsForEnvironments(dict);


            Config = new PayPalConfiguration
            {
                AcceptCreditCards = true,
                MerchantName = "Stadium",
                MerchantPrivacyPolicyURL = new NSUrl("https://www.example.com/privacy"),
                MerchantUserAgreementURL = new NSUrl("https://www.example.com/legal"),
                LanguageOrLocale = NSLocale.PreferredLanguages[0],
                PayPalShippingAddressOption = PayPalShippingAddressOption.Provided
            };
        }

        public static PayPalConfiguration Config { get; }

        public enum State
        {
            UserCancel,
            Succefull,
            Failed
        }
        public delegate void CompletionHandler(State state, NSDictionary paypalConfirmation);

        public static void Prepare()
        {
            //if (AppData.Instance.PaypalConfig.Environment.Contains("live"))
            //    PayPalMobile.PreconnectWithEnvironment(Xam.PayPal.iOS.Constants.PayPalEnvironmentProduction);
            //else
            PayPalMobile.PreconnectWithEnvironment(Constants.PayPalEnvironmentSandbox);

            CardIOUtilities.Preload();
        }

        public static void Buy(CompletionHandler callback)
        {
            Prepare();

            var payment = GetPayment();

            var paypal = new PayPalPaymentViewController(payment, Config, new PaypalDelegate(callback));

            var fixDel = paypal.PaymentDelegate;
            AppTools.RootNavigationController.PresentViewController(paypal, true, null);
        }

        public static string GetPaymentIdFromConfirmationResponse(NSDictionary paypalConfirmation)
        {
            var paymentResponse = paypalConfirmation?.ValueForKeyPath(new NSString("response"));
            var paymentId = paymentResponse?.ValueForKeyPath(new NSString("id"))?.ToString();
            return paymentId;
        }

        private static PayPalPayment GetPayment()
        {
            return PayPalPayment.PaymentWithAmount(new NSDecimalNumber(OrderManager.Instance.GetPrice),
                                                   App.CurrencyPaypal,
                                                   App.PaypalName,
                                                   PayPalPaymentIntent.Sale);
        }

        private class PaypalDelegate : PayPalPaymentDelegate
        {
            private readonly CompletionHandler _del;

            public PaypalDelegate(CompletionHandler del)
            {
                _del = del;
            }

            public override void PayPalPaymentDidCancel(PayPalPaymentViewController paymentViewController)
            {
                paymentViewController.DismissViewController(true, () => _del?.Invoke(State.UserCancel, null));
            }

            public override void PayPalPaymentViewController(PayPalPaymentViewController paymentViewController, PayPalPayment completedPayment)
            {
                paymentViewController.DismissViewController(true, () => _del?.Invoke(State.Succefull, completedPayment?.Confirmation));
            }
        }
    }
}
