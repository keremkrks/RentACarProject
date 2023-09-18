using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCoreCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                var addedEntity = context.Entry(entity);
                if (entity.BrandId >= 0 || entity.DailyPrice > 0 || entity.Description.Length>=2)
                {
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Araç Kayıt Edilemedi");
                }

            }

        }

        public void Delete(Car entity)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
             }
        }

        public Car Get()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                return filter != null ? context.Set<Car>().Where(filter).ToList() : context.Set<Car>().ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
