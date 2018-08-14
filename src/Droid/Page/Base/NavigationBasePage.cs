using Android.Graphics;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Core.ViewModels.Base;
using Int.Core.Application.Menu.Contract;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page.Base
{
    public abstract partial class NavigationBasePage<TViewModel> : BasePage<TViewModel>
        where TViewModel : ProjectNavigationBaseViewModel
    {
        protected sealed override int LayoutResource => Resource.Layout.base_page;
        protected abstract int LayoutContentResource { get; }

        protected override void FindViews()
        {
            base.FindViews();

            ModelView.CurrentPageName = GetType().Name;

            ModelView.MenuOpen = ToggleSideMenu;

            Window.SetSoftInputMode(SoftInput.AdjustNothing);

            LayoutInflater.Inflate(LayoutContentResource, FindViewById<FrameLayout>(Resource.Id.main_content));
        }
        protected override void OnResume()
        {
            base.OnResume();
            Drawer?.CloseDrawers();
        }
        protected override void InitViews()
        {
            base.InitViews();

            SideMenuListView.VerticalScrollBarEnabled = false;

            if (ModelView.TypeMenu == ProjectNavigationBaseViewModel.HeaderAreaActionType.Back)
                Drawer?.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
            Drawer?.SetScrimColor(Color.Transparent);

            SideMenuListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                              new MenuCellViewHolder(inflater,
                                               parent,
                                               ModelView.MenuCell)));
        }

        private void ToggleSideMenu()
        {
            if (Drawer != null && Drawer.IsDrawerOpen(SideMenuRootView))
                Drawer?.CloseDrawer(SideMenuRootView);
            else
                Drawer?.OpenDrawer(SideMenuRootView);
        }

        public override void OnBackPressed()
        {
            if (ModelView.TypeMenu == ProjectNavigationBaseViewModel.HeaderAreaActionType.Back)
                ModelView.GoBack();
        }
    }

    public class MenuCellViewHolder : ComponentViewHolder<IItemMenu>
    {
        public MenuCellViewHolder(LayoutInflater inflator, ViewGroup parent, ICrossCellViewHolder<IItemMenu> cellModel)
            : base(inflator.Inflate(Resource.Layout.menu_list_item, parent, false), cellModel) { }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.ImageItemMenu))]
        [InjectView(Resource.Id.menu_item_list_image)]
        public ImageView ImageItemMenu { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.RootView))]
        [InjectView(Resource.Id.menu_item_root)]
        public LinearLayout RootView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.Line))]
        [InjectView(Resource.Id.menu_itemLine)]
        public View Line { get; set; }
    }
}
