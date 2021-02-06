using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivities.Models
{
    public interface IChoiceRepository
    {
        IEnumerable<Choice> AllChoice { get; }
        Choice GetChoiceById(int id);
        Choice GetChoiceByFirstActivityId(int id);

        void SaveChoice(Choice choice);
        void UpdateChoice();
    }
}
