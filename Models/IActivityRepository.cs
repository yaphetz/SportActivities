using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivities.Models
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> AllActivities { get; }
        IEnumerable<Activity> AllRejectedActivities { get; }
        IEnumerable<Activity> AllWaitingForApprovalActivities { get; }
        IEnumerable<Activity> AllApprovedActivities { get; }

        Activity GetActivityById(int id);
        Activity GetRejectedActivityById(int id);
        Activity GetWaitingForApprovalActivityById(int id);
        Activity GetApprovedActivityById(int id);

        void AddNewActivity(Activity activity);
        void DeleteActivity(int id);
        void UpdateActivity();
    }
}
