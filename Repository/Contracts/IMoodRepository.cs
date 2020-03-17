using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IMoodRepository : IRepositoryBase<Mood>
    {
        Mood GetMood(int moodId);

        void CreateMood(Mood newMood);

        List<Mood> GetMoods();
    }
}
