using MvvmCross.Platforms.Uap.Views;
using TheGuardianWebAPI.Core;
using TheGuardianWebAPI.Core.Models;
using Windows.UI.Xaml;

namespace TheGuardianWebAPI.Views
{
    public sealed partial class HomeView : MvxWindowsPage
    {
        public HomeView()
        {
            this.InitializeComponent();
        }

        private void PaneButton_Click(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

        private void StackPanel_Loaded (object sender, RoutedEventArgs e)
        {
            StoryHeader _storyheader = storyList.Items[0] as StoryHeader;
        }
    }
}