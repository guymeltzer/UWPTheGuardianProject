using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace TheGuardianWebAPI.Core.Models
{
   public class StoryListService : INotifyPropertyChanged, IStoryListService
    {
        private ObservableCollection<StoryHeader> _stories;
        private HttpService _httpService;
        private SearchResult _results;

        public ObservableCollection<StoryHeader> Stories { get => _stories; }

        public StoryListService(HttpService service)
        {
            _httpService = service;
            _stories = new ObservableCollection<StoryHeader>();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void InitializeStoryList(IEnumerable<StoryHeader> items)
        {
            _stories.Clear();

            foreach (var item in items)
            {
                _stories.Add(item);
            }
        }

        //Calls a function that performs a call to the API and resets the story list via the response
        public async Task GetQueryResults(Dictionary<string, string> dictionary)
        {
            _results = await _httpService.GetAsync<SearchResult>(Constants.BASE_API_URL, dictionary);
            InitializeStoryList(_results.SearchResponse.StoryHeaders);
        }
    }
}
