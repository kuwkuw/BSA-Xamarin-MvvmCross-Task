using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Books.Touch.Views
{
    [Register("DatailsView")]
    public class DatailsView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var titleLabel = new UILabel(new RectangleF(0, 10, 300, 30));
            Add(titleLabel);

            var authorLabel = new UILabel(new RectangleF(0, 45, 300, 30));
            Add(authorLabel);


            var set = this.CreateBindingSet<DatailsView, Core.ViewModels.DetailsViewModel>();
            set.Bind(titleLabel).To(vm => vm.VolumeInfo.title);
            set.Bind(authorLabel).To(vm => vm.VolumeInfo.authorSummary);
            set.Apply();
        }
    }
}