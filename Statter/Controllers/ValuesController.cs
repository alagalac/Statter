using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Statter.Filters;
using Statter.Models;

namespace Statter.Controllers
{
    public class ValuesController : ApiController
    {
        private DataClasses1DataContext context = new DataClasses1DataContext();

        [HttpGet]
        public IHttpActionResult Read(int id, int count = 1)
        {
            var stat = context.stats.FirstOrDefault(x => x.id == id);
            if (stat == null)
            {
                return NotFound();
            }

            var values = new List<string>();
            if (stat.stat_type == "COUNT")
            {
                values = context.stat_count_values.Where(x => x.stat_id == id).OrderByDescending(x => x.date_created).Take(count).Select(x => x.value.ToString()).ToList();
            }

            return Ok(values);
        }

        [IdentityBasicAuthentication]
        [Authorize]
        public IHttpActionResult Write(int id, string value)
        {
            var stat = context.stats.FirstOrDefault(x => x.id == id);
            if (stat == null)
            {
                return NotFound();
            }

            if (stat.stat_type == "COUNT")
            {

            }

            return Ok();
        }
    }
}
