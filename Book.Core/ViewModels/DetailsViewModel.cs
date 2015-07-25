using Books.Core.Services;
using Cirrious.MvvmCross.ViewModels;

namespace Books.Core.ViewModels
{
    /// <summary>
    /// TODO implement Details view model to download and hold detail information about the book
    /// Also you need to implement views for each platform for this model
    /// </summary>
    public class DetailsViewModel 
        : MvxViewModel
    {
        private readonly IBooksService _books;

        public DetailsViewModel(IBooksService books)
        {
            _books = books;
        }

        public void Init(string url) {
            _books.StartSearchAsync(url, result => VolumeInfo = result.items[0].volumeInfo ,
                error => { });
        }



        protected override void InitFromBundle(IMvxBundle parameters)
        {
            // TODO get and cast incomming bundle to the parameter passed from FirstViewModel
            // details here
            // https://github.com/MvvmCross/MvvmCross/wiki/ViewModel--to-ViewModel-navigation

            base.InitFromBundle(parameters);

        }

        private VolumeInfo _volumeInfo;

        public VolumeInfo VolumeInfo
        {
            get { return _volumeInfo; }
            set { _volumeInfo = value; RaisePropertyChanged(() => VolumeInfo); }
        }

    }
}
