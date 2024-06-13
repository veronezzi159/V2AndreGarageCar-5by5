using AndreGarageCarJob.Controllers;
using AndreGarageCarJob.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AndreGarageTests
{
    public class CarJobTests
    {
        private DbContextOptions<AndreGarageCarJobContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<AndreGarageCarJobContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new AndreGarageCarJobContext(options))
            {
                context.Car.Add(new Car { Plate = "AXU-4446", Name = "Focus", Color = "Blue", FabricationYear = 2021, ModelYear = 2022 });
                context.Car.Add(new Car { Plate = "XUA-4446", Name = "Ferrari Enzo", Color = "RED", FabricationYear = 2021, ModelYear = 2022 });
                context.Car.Add(new Car { Plate = "UAX-4446", Name = "Aventador", Color = "Yellow", FabricationYear = 2021, ModelYear = 2022 });
                context.Job.Add(new Job { Id = 1, Description = "Troca de oleo" });
                context.Job.Add(new Job { Id = 2, Description = "Troca de Pneu" });
                context.Job.Add(new Job { Id = 3, Description = "Troca de Amortecedores" });
                context.CarJob.Add(new CarJob {Id = 1 ,Car = context.Car.Find("AXU-4446"), Job = context.Job.Find(1), Status = true });

                context.SaveChanges();
            }
        }
        [Fact]
        public void TestCreate()
        {
            InitializeDataBase();
            using (var context = new AndreGarageCarJobContext(options))
            {
                CarJobsController controller = new CarJobsController(context);
                var carJob = new CarJobDTO { CarPlate = "AXU-4446", JobId = 1, Status = true };
                var result = controller.PostCarJob(carJob).Result.Value;

                Assert.Equal("AXU-4446", result.Car.Plate);
            }
        }
        [Fact]
        public void TestGetAll()
        {
            InitializeDataBase();
            using (var context = new AndreGarageCarJobContext(options))
            {
                CarJobsController controller = new CarJobsController(context);
                var carJobs = controller.GetCarJob().Result.Value;

                Assert.Equal(1, carJobs.Count());
            }
        }
        [Fact]
        public void TestGetById()
        {
            InitializeDataBase();
            using (var context = new AndreGarageCarJobContext(options))
            {
                CarJobsController controller = new CarJobsController(context);
                var carJob = controller.GetCarJob(1).Result.Value;

                Assert.Equal(1, carJob.Id);
            }
        }
    }
}
