using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;


namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            var x= context.Jobs.Include(x => x.Customer).Select(x => new JobModel
            {
                JobId = x.JobId,
                CustomerId = x.CustomerId,
                Customer = x.Customer,
                Engineer = x.Engineer,
                When = x.When
            }).ToArray();
            return x;
        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs.Include(x => x.Customer).Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                CustomerId = x.CustomerId,
                Customer = x.Customer,
                Engineer = x.Engineer,
                When = x.When
            }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                CustomerId = model.CustomerId,
                Engineer = model.Engineer,
                When = model.When
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                CustomerId = addedJob.Entity.CustomerId,
                Engineer = addedJob.Entity.Engineer,
                When = addedJob.Entity.When
            };
        }
    }
}
