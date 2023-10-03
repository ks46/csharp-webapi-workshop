using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.EndPoints
{
    public static class CarApi
    {
        public static void ConfigureCarApi(this WebApplication app)
        {
            app.MapGet("/cars", GetCars);
            app.MapGet("/cars/{id}", GetCar);
            app.MapPost("/cars", AddCar);

            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCars(IRepository repository)
        {
            return Results.Ok(repository.GetCars());
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCar(int id, IRepository repository)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var car = repository.GetCar(id);
                    return repository.AddCar(car) ? Results.Ok(car) : Results.NotFound();
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddCar(Car car, IRepository repository)
        {
            try
            {
                return await Task.Run(() =>
                {
                    return repository.AddCar(car) ? Results.Ok(car) : Results.NotFound();
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            
        }

        private static async Task<IResult> DeleteCar(int id, IRepository repository)
        {
            try
            {
                if (repository.DeleteCar(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        private static async Task<IResult> UpdateCar(Car car, IRepository repository)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (repository.UpdateCar(car)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


    }
}
