using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public static class Seeder
    {
        public static void Seed(this WebApplication app)
        {
            using (var db = new DataContext())
            {
                if(!db.People.Any())
                {
                    db.People.Add(new Person() { Name="Nigel"});
                    db.People.Add(new Person() { Name = "Dave" });
                    db.People.Add(new Person() { Name = "Bob" });
                    db.SaveChanges();

                }

                if(!db.Cars.Any())
                {
                    db.Cars.Add(new Car() { Make = "VW", Model = "Beetle", PersonId=1 });
                    db.Cars.Add(new Car() { Make = "VW", Model = "Golf", PersonId=2 });
                    db.Cars.Add(new Car() { Make = "VW", Model = "Up", PersonId=3 });
                    db.SaveChanges();

                }
                
                db.SaveChanges();
            }
        }
    }
}
