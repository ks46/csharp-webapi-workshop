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
                return db.Cars.ToList();
            }
        }
        public Car GetCar(int id)
        {
            Car? car = null;

            using (var db = new DataContext())
            {
                car = db.Cars.FirstOrDefault(c => c.Id == id);
            }

            return car;
        }

        public bool AddCar(Car car)
        {
            using (var db = new DataContext())
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCar(int id)
        {
            using (var db = new DataContext())
            {
                var target = db.Cars.FirstOrDefault(a => a.Id == id);
                if (target != null)
                {
                    db.Remove(target);
                    db.SaveChanges();
                    return true;
                }
            };
            return false;
        }


       
       

        public bool UpdateCar(Car car)
        {
            using (var db = new DataContext())
            {
                var target = db.Cars.FirstOrDefault(c => c.Id == car.Id); 
                if (target != null)
                {
                    db.Cars.Attach(target);
                    target.Make = car.Make;
                    target.Model = car.Model;
                    target.PersonId = car.PersonId;
                    db.SaveChanges();
                    return true;

                }
            }
            return false;
        }

        public bool DeletePerson(int id)
        {
            using (var db = new DataContext())
            {
                var target = db.People.FirstOrDefault(a => a.Id == id);
                if (target != null)
                {
                    db.Remove(target);
                    db.SaveChanges();
                    return true;
                }
            };
            return false;
        }

    }
}
