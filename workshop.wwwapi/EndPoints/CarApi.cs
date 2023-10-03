using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.EndPoints
{
    public static class CarApi
    {
        public static void ConfigureCarApi(this WebApplication app)
        {
            app.MapGet("/cars", GetCars);
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCars(IRepository repository)
        {
            return Results.Ok(repository.GetCars());
        }

    }
}
