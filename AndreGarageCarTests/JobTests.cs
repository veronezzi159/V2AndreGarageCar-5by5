using AndreGarageJob.Controllers;
using AndreGarageJob.Data;
using Microsoft.EntityFrameworkCore;
using Models;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreGarageTests
{
    public class JobTests
    {
        private DbContextOptions<AndreGarageJobContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<AndreGarageJobContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new AndreGarageJobContext(options))
            {
                context.Job.Add(new Models.Job { Id = 1, Description = "Troca de oleo" });
                context.Job.Add(new Models.Job { Id = 2, Description = "Troca de Pneu" });
                context.Job.Add(new Models.Job { Id = 3, Description = "Troca de Amortecedores" });
                context.SaveChanges();
            }
        }

        [Fact]
        public void TestGetAll()
        {
            InitializeDataBase();
            using (var context = new AndreGarageJobContext(options))
            {
                JobsController controller = new JobsController(context);
                var jobs = controller.GetJob().Result.Value;

                Assert.Equal(3, jobs.Count());
            }
        }
        [Fact]
        public void TestGetById()
        {
            InitializeDataBase();
            using (var context = new AndreGarageJobContext(options))
            {
                JobsController controller = new JobsController(context);
                var job = controller.GetJob(2).Result.Value;

                Assert.Equal(2, job.Id);
            }
        }
        [Fact]
        public void TestCreate()
        {
            InitializeDataBase();
            using (var context = new AndreGarageJobContext(options))
            {
                JobsController controller = new JobsController(context);
                var job = new Job { Id = 4, Description = "Troca de Correia Dentada" };
                var result = controller.PostJob(job).Result.Value;

                Assert.Equal(4 ,result.Id);
            }
        }
    }
}
