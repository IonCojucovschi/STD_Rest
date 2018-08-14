//
// FontsName.cs
//
// Author:
//       Sogurov Fiodor <f.songurov@software-dep.net>
//
// Copyright (c) 2016 Songurov
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

namespace Core.Helpers
{
    public static class FontsConstant
    {
        public const string OpenSansBold = "OpenSans-Bold.ttf";
        public const string OpenSansBoldItalic = "OpenSans-BoldItalic.ttf";
        public const string OpenSansExtraBold = "OpenSans-ExtraBold.ttf";
        public const string OpenSansExtraBoldItalic = "OpenSans-ExtraBoldItalic.ttf";
        public const string OpenSansItalic = "OpenSans-Italic.ttf";
        public const string OpenSansLight = "OpenSans-Light.ttf";
        public const string OpenSansLightItalic = "OpenSans-LightItalic.ttf";
#if __ANDROID__
        public const string OpenSansRegular = "OpenSans-Regular.ttf";
#else
        public const string OpenSansRegular = "OpenSans.ttf";
#endif

        public const string OpenSansSemibold = "OpenSans-Semibold.ttf";
        public const string OpenSansSemiboldItalic = "OpenSans-SemiboldItalic.ttf";

        public const string RobotoBold = "Roboto-Bold.ttf";
		public const string RobotoRegular = "Roboto-Regular.ttf";

		public const string MontserratBold = "Montserrat-Bold.ttf";

        public const float Size10 = 10;
        public const float Size12 = 12;
        public const float Size14 = 14;
        public const float Size15 = 15;
        public const float Size16 = 16;
        public const float Size18 = 18;
        public const float Size20 = 20;
        public const float Size24 = 24;
        public const float Size28 = 28;
        public const float Size34 = 34;
        public const float Size36 = 36;
    }
}
