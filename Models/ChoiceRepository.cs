using SportActivities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivities.Models
{
    public class ChoiceRepository : IChoiceRepository
    {
        private readonly ApplicationDbContext _addDbContext;
        public ChoiceRepository(ApplicationDbContext appDbContext)
        {
            _addDbContext = appDbContext;
        }

        public IEnumerable<Choice> AllChoice
        {
            get
            {
                return _addDbContext.Choices;
            }
        }

        public Choice GetChoiceById(int id)
        {
            return _addDbContext.Choices.FirstOrDefault(c => c.ChoiceId == id);
        }

        public Choice GetChoiceByFirstActivityId(int id)
        {
            return _addDbContext.Choices.FirstOrDefault(c => c.FirstActivityId == id);
        }

        public void SaveChoice(Choice choice)
        {
            _addDbContext.Add(choice);
            _addDbContext.SaveChanges();
        }

        public void UpdateChoice()
        {
            _addDbContext.SaveChanges();
        }
    }
}
