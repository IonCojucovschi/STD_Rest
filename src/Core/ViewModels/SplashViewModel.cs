//
// SplashViewModel.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2017 Songurov Fiodor
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

using Core.Extensions;
using Core.Helpers;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels
{
    public class SplashViewModel : ProjectBaseViewModel
    {
        [CrossView]
        public IImage ImageIcon { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();

            var fonts = new[]
            {
                FontsConstant.OpenSansBold,
                FontsConstant.OpenSansBoldItalic,
                FontsConstant.OpenSansExtraBold,
                FontsConstant.OpenSansExtraBoldItalic,
                FontsConstant.OpenSansItalic,
                FontsConstant.OpenSansLight,
                FontsConstant.OpenSansLightItalic,
                FontsConstant.OpenSansRegular,
                FontsConstant.OpenSansSemibold,
                FontsConstant.OpenSansSemiboldItalic,
                FontsConstant.RobotoBold
            };

#if __ANDROID__
            Int.Droid.Tools.Font.FontManager.Instance.Add(fonts);
#else
            Int.iOS.Tools.Font.FontManager.Instance.Add(fonts);
#endif
            this.GoPage(PageConstants.PageNameHome);
        }
    }
}