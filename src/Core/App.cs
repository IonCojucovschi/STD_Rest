//
// MyClass.cs
//
// Author:
//       Sogurov Fiodor <f.songurov@software-dep.net>
//
// Copyright (c) 2017 Songurov
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Akavache;
using Core.Services.MockServices;
using Core.Services.MockServices.RealServices;
using I18NPortable;
using Int.Core.Application.Exception;
using Int.Core.Application.Login.Contract;
using Int.Core.Data.MVVM.Contract;
using Int.Core.Network.Singleton;
using Splat;

namespace Core
{
    public sealed class App : Singleton<App>
    {
        public IBaseViewModel GetView(Type type) => Services.Service.Instance.ServiceViewModel.Get(type);

        public const string ServiceContractMock = "mock";
        public const string ServiceContract = "service_contract";

        public const string CurrencyEuro = "€";
        public const string CurrencyDollar = "$";

        public const string CurrencyPaypal = "EUR";
        public const string PaypalName = "Payment Stadium";


        public bool IsMock { get; set; }

        public bool IsDroid { get; set; } = true;

        public string NameSpacePage() => IsDroid ? "Droid.Page" : "iOS.Storyboard";

        public void Start()
        {

            I18N.Current
                .SetNotFoundSymbol("$")
                .SetFallbackLocale("it")
                .SetThrowWhenKeyNotFound(
                    true) // Optional: Throw an exception when keys are not found (recommended only for debugging)
                          //.SetLogger(text => Debug.WriteLine(text)) // action to output traces
                .Init(GetType().Assembly); // assembly where locales live

            BlobCache.ApplicationName = "Beer Shop";
            BlobCache.EnsureInitialized();

            IsMock = false;

            if (IsMock)
                InjectMockServices();
            else
                InjectServices();

            Services.Service.Instance.Start();

            ExceptionLogger.NonFatalException -= LogExceptionInAppOutput;
            ExceptionLogger.NonFatalException += LogExceptionInAppOutput;
        }

        private static void InjectServices()
        {
            Locator.CurrentMutable.RegisterConstant(
                new AuthenticateService(), typeof(ILogin), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new CategoryService(), typeof(ICategory), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new OrderService(), typeof(IOrder), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new PaymentService(), typeof(IPayment), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new FeedbackService(), typeof(IFeedback), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new CallService(), typeof(ICall), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new EventsService(), typeof(IEvents), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new NotificationService(), typeof(INotification), ServiceContract);
        }

        private void InjectMockServices()
        {
            //Locator.CurrentMutable.RegisterConstant(
            //new AuthenticateServiceMock(), typeof(ILogin), ServiceContractMock);
        }

        private void LogExceptionInAppOutput(Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"[{typeof(ExceptionLogger).Name}] {e.Message}");
        }
    }
}
