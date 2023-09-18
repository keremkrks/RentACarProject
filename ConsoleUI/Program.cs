using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCoreCarDal());
            Car car1 = new Car { BrandId = 4, ColorId = 3, ModelYear = 2017,
                DailyPrice = 5000, Description = "Kadjar Otomatik" };
            carManager.AddCar(car1);


        }

    }
}
