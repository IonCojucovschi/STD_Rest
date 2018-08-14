using Android.App;
using Core;
using Core.ViewModels.Base;

namespace Droid.Page.Base
{
    [Activity(Label = "", Icon = "@mipmap/icon")]
    public abstract partial class BasePage<TViewModel> :
    Int.Droid.Factories.Activity.ComponentMVVMActivity<TViewModel> where TViewModel : ProjectBaseViewModel
    {
        protected override TViewModel ModelView => App.Instance.GetView(typeof(TViewModel)) as TViewModel;

        protected override void TranslateViews()
        {
        }

        protected override void HandlerViews()
        {
        }

        protected override void FindViews()
        {
        }

        protected override void RemoveHandlerViews()
        {
        }
        protected override void InitViews()
        {
            base.InitViews();

            ModelView?.OnCreate();
        }
    }
}

