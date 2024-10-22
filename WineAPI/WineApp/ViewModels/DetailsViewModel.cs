using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineApp.Messages;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public class DetailsViewModel : ObservableRecipient, IDetailsViewModel, IRecipient<AnalyzePhotoMessage>
    {
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

        private Recipe recipe;

        public Recipe DetectedRecipe
        {
            get { return recipe; }
            set => SetProperty(ref recipe, value);
        }

        public DetailsViewModel()
        {
            Messenger.Register<DetailsViewModel, AnalyzePhotoMessage>(this, (r, m) => r.Receive(m));
        }

        public ICommand ToggleFavoriteCommand { get; set; }
        public ICommand ShowMoreWinesCommand { get; set; }
        public ICommand NavigateToWineCommand { get; set; }


    }
}

