using workshop.wwwapi.EndPoints;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCar(int id);
        bool AddCar(Car car);
        bool UpdateCar(Car car);
        bool DeleteCar(int id);
    }
}
