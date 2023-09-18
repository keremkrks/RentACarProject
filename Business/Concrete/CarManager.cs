using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                var addedEntity = context.Entry(car);

                var query = from c in context.Cars
                            join p in context.Brands
                            on c.BrandId equals p.BrandId
                            select new
                            {
                                BrandId = p.BrandId,
                                BrandName = p.BrandName
                            };

                Brand brand = new Brand();
                brand.BrandId = car.BrandId;
                brand.BrandName = context.Brands.Where(c => c.BrandId == car.BrandId).First().BrandName;

                if (car.DailyPrice > 0 && brand.BrandName.Length > 2)
                {
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                    Console.WriteLine("Araç kaydedildi. " + car.Description);
                }
                else
                {
                    throw new Exception("Araç kayıt edilemedi");
                }
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }
    }
}
