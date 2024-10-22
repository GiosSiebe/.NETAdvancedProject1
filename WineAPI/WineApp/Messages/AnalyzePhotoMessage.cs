using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineApp.Messages
{
    public class AnalyzePhotoMessage(ImageSource photo) : ValueChangedMessage<ImageSource>(photo)
    {
    }
}
