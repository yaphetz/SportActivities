using Microsoft.EntityFrameworkCore;
using SportActivities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivities.Models
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _addDbContext;
        public ActivityRepository(ApplicationDbContext appDbContext)
        {
            _addDbContext = appDbContext;
        }

        //---

        public IEnumerable<Activity> AllActivities => _addDbContext.Activities;
        public IEnumerable<Activity> AllRejectedActivities => _addDbContext.Activities.Where(a => a.Status == false);
        public IEnumerable<Activity> AllWaitingForApprovalActivities => _addDbContext.Activities.Where(a => a.Status == null);
        public IEnumerable<Activity> AllApprovedActivities => _addDbContext.Activities.Where(a => a.Status == true);

        public Activity GetActivityById(int id)
        {
            return _addDbContext.Activities.FirstOrDefault(a => a.ActivityId == id);
        }
        public Activity GetRejectedActivityById(int id)
        {
            return _addDbContext.Activities.FirstOrDefault(a => a.ActivityId == id && a.Status == false);
        }
        public Activity GetWaitingForApprovalActivityById(int id)
        {
            return _addDbContext.Activities.FirstOrDefault(a => a.ActivityId == id && a.Status == null);
        }
        public Activity GetApprovedActivityById(int id)
        {
            return _addDbContext.Activities.FirstOrDefault(a => a.ActivityId == id && a.Status == true);
        }

        public void AddNewActivity(Activity activity)
        {
            _addDbContext.Add(activity);
            _addDbContext.SaveChanges();
        }
        public void DeleteActivity(int id)
        {
            _addDbContext.Remove(_addDbContext.Activities
                .Include(a=>a.FirstChoices)
                .Include(a=>a.DefaultChoices)
                .FirstOrDefault(a => a.ActivityId == id));
            _addDbContext.SaveChanges();
        }
        public void UpdateActivity()
        {
            _addDbContext.SaveChanges();
        }
    }
}
