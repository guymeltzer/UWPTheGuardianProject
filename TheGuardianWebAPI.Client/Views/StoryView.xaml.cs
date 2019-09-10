using TheGuardianWebAPI.Core;
using MvvmCross.Platforms.Uap.Views;
using Windows.UI.Xaml;


namespace TheGuardianWebAPI.Client.Views
{
    public sealed partial class StoryView : MvxWindowsPage
    {
        public StoryView()
        {
            this.InitializeComponent();
        }

        private void PaneButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

    }
}