using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        public IEnumerable<Car> GetCars()
        {
            using (var db = new DataContext())
            {
                return db.cars.ToList();
            }
        }
        public Car GetCar(int id)
        {
            Car? car = null;

            using (var db = new DataContext())
            {
                car = db.cars.FirstOrDefault(c => c.id == id);
            }

            return car;
        }

        public bool AddCar(Car car)
        {
            using (var db = new DataContext())
            {
                db.cars.Add(car);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCar(int id)
        {
            using (var db = new DataContext())
            {
                var target = db.cars.FirstOrDefault(a => a.id == id);
                if (target != null)
                {
                    db.Remove(target);
                    return true;
                }
            };
            return false;
        }


       
       

        public bool UpdateCar(Car car)
        {
            using (var db = new DataContext())
            {
                var target = db.cars.FirstOrDefault(c => c.id == car.id); 
                if (target != null)
                {
                    db.cars.Attach(target);
                    target.make = car.make;
                    target.model = car.model;
                    db.SaveChanges();
                    return true;

                }
            }
            return false;
        }
    }
}
