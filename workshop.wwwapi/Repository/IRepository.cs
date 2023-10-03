using workshop.wwwapi.EndPoints;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Car> GetCars();
    }
}
