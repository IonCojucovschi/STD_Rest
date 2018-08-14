using System;
using Android.Views;
using Android.Widget;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class Call
    {
        /// views 
        [CrossView(nameof(CodeViewModel.BackgroundContainer))]
        [InjectView(Resource.Id.background_wrapper_content)]
        protected View BackgroundContainer { get; set; }

        [CrossView(nameof(CodeViewModel.View1))]
        [InjectView(Resource.Id.view_1code)]
        protected View View1 { get; set; }

        [CrossView(nameof(CodeViewModel.View2))]
        [InjectView(Resource.Id.view_2code)]
        protected View View2 { get; set; }

        [CrossView(nameof(CodeViewModel.View3))]
        [InjectView(Resource.Id.view_3code)]
        protected View View3 { get; set; }

        [CrossView(nameof(CodeViewModel.View4))]
        [InjectView(Resource.Id.view_4code)]
        protected View View4 { get; set; }

        [CrossView(nameof(CodeViewModel.View5))]
        [InjectView(Resource.Id.view_5code)]
        protected View View5 { get; set; }

        [CrossView(nameof(CodeViewModel.View6))]
        [InjectView(Resource.Id.view_6code)]
        protected View View6 { get; set; }

        [CrossView(nameof(CodeViewModel.View7))]
        [InjectView(Resource.Id.view_7code)]
        protected View View7 { get; set; }

        [CrossView(nameof(CodeViewModel.View8))]
        [InjectView(Resource.Id.view_8code)]
        protected View View8 { get; set; }


        ///images
        [CrossView(nameof(CodeViewModel.ImageQR))]
        [InjectView(Resource.Id.qr_image)]
        protected ImageView ImageQR { get; set; }

        [CrossView(nameof(CodeViewModel.ImageScan))]
        [InjectView(Resource.Id.scan_image)]
        protected ImageView ImageScan { get; set; }

        ///text views
        [CrossView(nameof(CodeViewModel.TitleText))]
        [InjectView(Resource.Id.title_text)]
        protected TextView TitleText { get; set; }

        [CrossView(nameof(CodeViewModel.TableNrText))]
        [InjectView(Resource.Id.table_number_code)]
        protected TextView TableNrText { get; set; }

        [CrossView(nameof(CodeViewModel.TableNrValueText))]
        [InjectView(Resource.Id.table_value_number_code)]
        protected TextView TableNrValueText { get; set; }

        [CrossView(nameof(CodeViewModel.ConfirmTableText))]
        [InjectView(Resource.Id.table_confirm_value)]
        protected TextView ConfirmTableText { get; set; }
    }
}
