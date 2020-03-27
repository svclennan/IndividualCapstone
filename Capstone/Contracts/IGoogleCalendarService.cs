using Capstone.Models;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Contracts
{
    public interface IGoogleCalendarService
    {
        void AddMood(Mood mood);
        void AddActivity(Activity activity);
        Events GetEvents();
        public Events GetMoods();
    }
}
