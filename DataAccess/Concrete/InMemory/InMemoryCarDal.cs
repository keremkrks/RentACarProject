
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 6, BrandId=1, ColorId=1, ModelYear=2017, DailyPrice=1000, Description="Renault Megane Beyaz Otomatik" },
                new Car { Id = 7, BrandId=1, ColorId=2, ModelYear=2022, DailyPrice=5000, Description="Renault Austral Gri Otomatik" },
                new Car { Id = 8, BrandId=2, ColorId=3, ModelYear=2014, DailyPrice=2000, Description="Nissan Qashqai Siyah Manuel" },
                new Car { Id = 9, BrandId=3, ColorId=3, ModelYear=2016, DailyPrice=2500, Description="Opel İnsignia Siyah Otomatik" },
                new Car { Id = 10, BrandId=3, ColorId=4, ModelYear=2023, DailyPrice=4000, Description="Opel Mokka Kırmızı Otomatik" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(new Car());
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
           _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
