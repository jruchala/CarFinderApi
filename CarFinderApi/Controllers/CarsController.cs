using CarFinderApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarFinderApi.Controllers
{
    [RoutePrefix("api/Cars")]

    public class CarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Get all years
        /// </summary>
        /// <returns>List of all years for which cars records exist</returns>
        [Route("Year")]
        public async Task<List<string>> GetAllYears()
        {
            return await db.GetAllYears();
        }

        /// <summary>
        /// Get Makes by year
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Returns a list of auto makers for which records exist for the entered year</returns>
        [Route("Make")]
        public async Task<List<string>> GetMakesByYear(string year)
        {
            return await db.GetMakesByYear(year);
        }

        /// <summary>
        /// Get Models by year and make
        /// </summary>
        /// <param name="year"></param>
        /// <param name="make"></param>
        /// <returns>Returns a list of models for which records exist for the entered year and auto maker</returns>
        [Route("Model")]
        public async Task<List<string>> GetModelByYearAndMake(string year, string make)
        {
            return await db.GetModelByYearAndMake(year, make);
        }

        /// <summary>
        /// Get Trim By Year, Make and Model
        /// </summary>
        /// <param name="year"></param>
        /// <param name="make"></param>
        /// <returns>Returns a list of trim types for which records exist for the entered year and auto maker and make</returns>
        [Route("Trim")]
        public async Task<List<string>> GetTrimByYearMakeModel(string year, string make, string model)
        {
            return await db.GetTrimByYearMakeModel(year, make, model);
        }

        /// <summary>
        /// Get Cars By Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Returns all the records of cars in a given year</returns>
        [Route("CarsByYear")]
        public async Task<List<Car>> GetCarsByYear(string year)
        {
            return await db.GetCarsByYear(year);
        }

        /// <summary>
        /// Get Cars By Year and Make
        /// </summary>
        /// <param name="year"></param>
        /// <param name="make"></param>
        /// <returns>Returns all the records of cars from a given maker in a given year</returns>
        [Route("CarsByYearMake")]
        public async Task<List<Car>> GetCarsByYearAndMake(string year, string make)
        {
            return await db.GetCarsByYearAndMake(year, make);
        }

        /// <summary>
        /// Get Cars By Year, Make and Model
        /// </summary>
        /// <param name="year"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <returns>Returns all the records of cars of a given model from a given maker in a given year</returns>
        [Route("CarsByYearMakeModel")]
        public async Task<List<Car>> GetCarsByYearMakeAndModel(string year, string make, string model)
        {
            return await db.GetCarsByYearMakeAndModel(year, make, model);
        }

        /// <summary>
        /// Get Cars By Year, Make, Model and Trim
        /// </summary>
        /// <param name="year"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="trim"></param>
        /// <returns>Returns all the records of cars of a given trim package of a given model from a given maker in a given year</returns>
        [Route("CarsByYearMakeModelTrim")]
        public async Task<List<Car>> GetCarsByYearMakeModelAndTrim(string year, string make, string model, string trim)
        {
            return await db.GetCarsByYearMakeModelAndTrim(year, make, model, trim);
        }
    }
}
