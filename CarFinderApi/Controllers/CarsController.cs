using CarFinderApi.Models;
using System;
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
        /// <returns></returns>
        [Route("Year")]
        public async Task<List<string>> GetAllYears()
        {
            return await db.GetAllYears();
        }

        [Route("Make")]
        public async Task<List<string>> GetMakesByYear(string year)
        {
            return await db.GetMakesByYear(year);
        }

    }
}
