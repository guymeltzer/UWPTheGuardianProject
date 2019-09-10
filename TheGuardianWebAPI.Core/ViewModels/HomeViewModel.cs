using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TheGuardianWebAPI.Core.Models;
using Newtonsoft.Json;

namespace TheGuardianWebAPI.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private Dictionary<string, string> _params;
        private MvxCommand _showStoryCommand;
        //command to change the section according to the category of the article you click on
        private MvxCommand<string> _changeSectionCommand;
        private StoryHeader _selectedItem;
        private IMvxNavigationService _navigationService;
        private StoryListService _storylist;
        private StoryDetails _details;
        

        //in the constructor creates a list and a dictionary
        public HomeViewModel(StoryListService storylist, IMvxNavigationService navigationService)
        {
            _storylist = storylist;
            _navigationService = navigationService;
            _params = new Dictionary<string, string>()
            {
                {Constants.API_KEY_PARAM, Constants.API_KEY },
                {Constants.SHOW_FIELDS_PARAM, Constants.ADDITIONAL_PARAM }
            };

        }

        public ObservableCollection<StoryHeader> Stories => _storylist.Stories;

        public async Task Init(string param)
        {
            await Section(param);
        }

        // a function that adds to the dictionary which category or section of article I want the param string to be about
        public async Task Section(string param)
        {
            Dictionary<string, string> collection = new Dictionary<string, string>(_params);

            if (!string.IsNullOrEmpty(param))
                collection.Add(Constants.SECTION_PARAM, param);

            await _storylist.GetQueryResults(collection);
        }

        public MvxCommand ShowStoryCommand
        {
            get
            {
                return _showStoryCommand ?? (_showStoryCommand = new MvxCommand(async () =>
                {
                    if (_selectedItem != null)
                    {
                        StoryDetails _details = new StoryDetails { Title = _selectedItem.WebTitle, Subtitle = _selectedItem.StoryHeaderAdditionalFields.TrailTextString, Url = _selectedItem.WebUrl };
                        await _navigationService.Navigate<StoryViewModel, StoryDetails>(_details);

                    }
                }));
            }
        }

        //protected override void SaveStateToBundle(IMvxBundle bundle)
        //{
        //    base.SaveStateToBundle(bundle);

        //    bundle.Data["MyParameter"] = JsonConvert.SerializeObject(_initialParameter);
        //}

        public StoryDetails Details
        {
            get
            {
                return _details;
            }

            set
            {
                SetProperty(ref _details, value);
            }
        }

        public MvxCommand<string> ChangeSectionCommand
        {
            get
            {
                return _changeSectionCommand ?? (_changeSectionCommand = new MvxCommand<string>(async param =>
                {
                    await Section(param);
                }));
            }
        }

        //when a story is clicked performs a set to that selected item and calls ShowStoryCommand
        public StoryHeader SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                ShowStoryCommand.Execute();
            }
        }
    }
}