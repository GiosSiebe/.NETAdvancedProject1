using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WineApp.Services;

namespace WineApp.ViewModels
{
    public class HomeViewModel : ObservableObject, IHomeViewModel
    {
        private ImageSource photo;
        private bool pictureChosen;

        public bool PictureChosen
        {
            get => pictureChosen;
            set => SetProperty(ref pictureChosen, value);
        }
        public ImageSource Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }
        public ICommand AnalyzePictureCommand { get; set; }
        public ICommand TakePictureCommand { get; set; }
        public ICommand PickPictureCommand { get; set; }

        private INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService) {
            BindCommands();
            _navigationService = navigationService;
        }
        private void BindCommands()
        {
            AnalyzePictureCommand = new AsyncRelayCommand(GoToDetailsShow);
            TakePictureCommand = new AsyncRelayCommand(TakePhoto);
            PickPictureCommand = new AsyncRelayCommand(PickPhoto);
        }

        private async Task GoToDetailsShow()
        {
            await _navigationService.NavigateToDetailsAsync();
        }

        private async Task PickPhoto()
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();
            await ShowPicture(photo);
        }

        private async Task TakePhoto()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            await ShowPicture(photo);
        }

        private async Task ShowPicture(FileResult photo)
        {
            var resizedPhoto = await PhotoImageService.ResizePhotoStreamAsync(photo);
            Photo = ImageSource.FromStream(() => new MemoryStream(resizedPhoto));
            PictureChosen = true;
        }
    }
}
