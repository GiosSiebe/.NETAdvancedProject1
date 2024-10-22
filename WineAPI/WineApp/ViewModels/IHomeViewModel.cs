using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WineApp.ViewModels
{
    public interface IHomeViewModel
    {
        ICommand AnalyzePictureCommand { get; set; }
    }
}
