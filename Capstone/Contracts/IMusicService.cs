using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Contracts
{
    public interface IMusicService
    {
        JToken GetPlaylistRecommendation(string genre);
    }
}
