using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace FriendOrganizer.UI.View.Service
{
    public class MessageDialogService : IMessageDialogService
    {
        private MetroWindow metroWindow => (MetroWindow)App.Current.MainWindow;

        public async Task<MessageDialogResult> ShowOkCancelDialog(string text, string title)
        {
            var result = await metroWindow.ShowMessageAsync(title, text, MessageDialogStyle.AffirmativeAndNegative);
            return result == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative ? MessageDialogResult.Ok : MessageDialogResult.Cancel;
        }

        public async Task ShowInfoDialog(string info)
        {
            await metroWindow.ShowMessageAsync("Info", info);
        }
    }

    public enum MessageDialogResult
    {
        Ok,
        Cancel
    }
}
