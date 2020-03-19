using Repository.Contracts;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Data
{
    class MoodRepository : RepositoryBase<Mood> , IMoodRepository
    {
        public MoodRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public void CreateMood(Mood newMood)
        {
            Create(newMood);
        }
        public Mood GetMood(int moodId)
        {
            return FindByCondition(a => a.MoodId == moodId).FirstOrDefault();
        }

        public List<Mood> GetMoods()
        {
            return FindAll().ToList();
        }
    }
}
