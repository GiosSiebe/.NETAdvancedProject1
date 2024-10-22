using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineApp.Messages;
using WineApp.Services;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public class DetailsViewModel : ObservableRecipient, IDetailsViewModel, IRecipient<AnalyzePhotoMessage>
    {
        private ObservableCollection<Wine> wines;
        public ObservableCollection<Wine> Wines
        {
            get { return wines; }
            set => SetProperty(ref wines, value);
        }
        public ICommand ToggleFavoriteCommand { get; set; }
        public ICommand ShowMoreWinesCommand { get; set; }
        public ICommand NavigateToWineCommand { get; set; }

        private ImageSource photo;
        public ImageSource Photo
        {
            get { return photo; }
            set => SetProperty(ref photo, value);
        }
        public void Receive(AnalyzePhotoMessage message)
        {
            Photo = message.Value;
        }

        private Recipe detectedRecipe;

        public Recipe DetectedRecipe
        {
            get { return detectedRecipe; }
            set => SetProperty(ref detectedRecipe, value);
        }

        private INavigationService _navigationService;
        public DetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Register<DetailsViewModel, AnalyzePhotoMessage>(this, (r, m) => r.Receive(m));
            BindCommands();
            AnalyzePhoto();
        }

        private void BindCommands()
        {
            ToggleFavoriteCommand = new RelayCommand(ToggleFavorite);
            ShowMoreWinesCommand = new RelayCommand(ShowWines);
            NavigateToWineCommand = new RelayCommand(NavigateToWine);
        }

        private void ShowWines()
        {
            Wines = DetectedRecipe.Wines;
        }

        private void NavigateToWine()
        {
            _navigationService.NavigateToWineAsync();
        }

        private void ToggleFavorite()
        {
        }


    }
}

