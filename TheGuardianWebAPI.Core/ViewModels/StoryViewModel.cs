using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TheGuardianWebAPI.Core.Models;
using MvvmCross.Navigation;

namespace TheGuardianWebAPI.Core.ViewModels
{
    public class StoryViewModel : MvxViewModel<StoryDetails>
    {
        private IMvxNavigationService _navservice;
        private StoryDetails _details;
        private MvxCommand _goBackCommand;
        public StoryDetails Details
        {
            get
            {
                return _details;
            }
        }

        public StoryViewModel(IMvxNavigationService Service)
        {
            _navservice = Service;
        }
        
        public override void Prepare(StoryDetails details)
        {
            _details = details;
        }

        // when you are in a story and click the back button it closes the article and returns to home page
        public MvxCommand GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new MvxCommand(() =>
                {
                    _navservice.Close(this);
                }));
            }
        }

        
    }
}
