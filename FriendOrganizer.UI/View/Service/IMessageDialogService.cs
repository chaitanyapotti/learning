using System.Threading.Tasks;

namespace FriendOrganizer.UI.View.Service
{
    public interface IMessageDialogService
    {
        Task<MessageDialogResult> ShowOkCancelDialog(string text, string title);

        Task ShowInfoDialog(string info);
    }
}