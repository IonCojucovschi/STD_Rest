using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace iOS.Storyboard
{
    partial class Splash
    {
        [CrossView(nameof(SplashViewModel.ImageIcon))]
        UIKit.UIImageView cvImageIcon => ImageIcon;
    }
}
