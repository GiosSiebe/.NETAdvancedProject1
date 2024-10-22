using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WineApp.Messages
{
    public class AnalyzePhotoMessage(ImageSource photo) : ValueChangedMessage<ImageSource>(photo)
    {
    }
}
