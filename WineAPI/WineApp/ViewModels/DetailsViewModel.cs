using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public class DetailsViewModel : ObservableObject, IDetailsViewModel
    {
        private Recipe recipe;

        public Recipe DetectedRecipe
        {
            get { return recipe; }
            set => SetProperty(ref recipe, value);
        }

        public ICommand ToggleFavoriteCommand { get; set; }
        public ICommand ShowMoreWinesCommand { get; set; }
        public ICommand NavigateToWineCommand { get; set; }


    }
}

