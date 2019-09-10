using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheGuardianWebAPI.Core.Models
{
    public interface IStoryListService
    {

        void InitializeStoryList(IEnumerable<StoryHeader> items);


        Task GetQueryResults(Dictionary<string, string> dictionary);

    }
}
