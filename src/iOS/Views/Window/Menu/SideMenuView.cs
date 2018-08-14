using Foundation;
using System;
using UIKit;

namespace iOS
{
    public partial class SideMenuView : UIView
    {
        public SideMenuView(IntPtr handle) : base(handle) { }

        public UIView RootView => viewRoot;

        public UITableView TTableView => TableView;

        public UIImageView ImageViewMenu => imgMenu;

        public UIView TouchAreMenu => viewTouchAreMenu;

        public UIView ViewContainer => viewContainer;
    }
}