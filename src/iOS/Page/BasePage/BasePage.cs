//
// BasePage.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2016 Songurov Fiodor
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
using Core;
using Core.ViewModels.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS;
using Int.iOS.Factories.Activity;
using UIKit;

namespace iOS.Page.BasePage
{
    public abstract class BaseView<TViewModel> : ComponentMVVMViewController<TViewModel> where TViewModel : ProjectBaseViewModel
    {
        protected override TViewModel ModelView => App.Instance.GetView(typeof(TViewModel)) as TViewModel;

        protected BaseView(IntPtr intP) : base(intP) { }

        //protected override UIView KeyboardHideGestureHostingView => this.View;

        [CrossView(nameof(ProjectNavigationBaseViewModel.RootView))]
        UIView rootview => View;

        public TViewModel GetModelView() => App.Instance.GetView(typeof(TViewModel)) as TViewModel;

        protected override void BindViews()
        {
            base.BindViews();

            GetModelView().OnCreate();
            AppTools.SetTextColorBarStyle(UIColor.White);
        }

        protected override void ReloadViews()
        {
            base.ReloadViews();
            GetModelView().UpdateData();
        }

        protected override void TranslateViews() { }

        protected virtual void GoToBack() => GoBack();

        protected override void RemoveHandlerViews() { }

        protected override void HandlerViews() { }
    }
}
