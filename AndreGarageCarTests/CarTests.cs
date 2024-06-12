
using Microsoft.EntityFrameworkCore;
using Models;
using V2AndreGarageCar_5by5.Controllers;
using V2AndreGarageCar_5by5.Data;

namespace AndreGarageCarTests
{
    public class CarTests
    {
        private DbContextOptions<V2AndreGarageCar_5by5Context> options;
        private void InitDataBase()
        {
            options = new DbContextOptionsBuilder<V2AndreGarageCar_5by5Context>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            using (var context = new V2AndreGarageCar_5by5Context(options))
            {
                context.Add(new Car { Plate = "AXU-4446",Name = "Focus", Color= "Blue", FabricationYear = 2021, ModelYear = 2022 });
                context.Add(new Car { Plate = "XUA-4446",Name = "Ferrari Enzo", Color= "RED", FabricationYear = 2021, ModelYear = 2022 });
                context.Add(new Car { Plate = "UAX-4446",Name = "Aventador", Color= "Yellow", FabricationYear = 2021, ModelYear = 2022 });
                context.SaveChanges();
            }
        }

        [Fact]
        public void TestGetAll()
        {
            InitDataBase();
            using (var context = new V2AndreGarageCar_5by5Context(options))
            {
                CarsController controller = new CarsController(context);
                var cars = controller.GetCar().Result.Value;

                Assert.Equal(3, cars.Count());
            }            
        }
        [Fact]
        public void TestGetById()
        {
            InitDataBase();
            using (var context = new V2AndreGarageCar_5by5Context(options))
            {
                CarsController controller = new CarsController(context);
                var car = controller.GetCar("XUA-4446").Result.Value;

                Assert.Equal("XUA-4446", car.Plate);
            }            
        }
        [Fact]
        public void TestCreate()
        {
            InitDataBase();
            using (var context = new V2AndreGarageCar_5by5Context(options))
            {
                CarsController controller = new CarsController(context);
                var car = new Car { Plate = "XUA-4447",Name = "Palio", Color= "Black", FabricationYear = 2021, ModelYear = 2022 };
                var result = controller.PostCar(car).Result.Value;

                Assert.Equal("XUA-4447", result.Plate);
            }            
        }
    }
}