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
        public IHttpActionResult Index(int statisticId, int count = 1)
        {
            var stat = context.stats.FirstOrDefault(x => x.id == statisticId);
            if (stat == null)
            {
                return NotFound();
            }

            var values = new List<string>();
            if (stat.stat_type == "COUNT")
            {
                values = context.stat_count_values.Where(x => x.stat_id == statisticId).OrderByDescending(x => x.date_created).Take(count).Select(x => x.value.ToString()).ToList();
            }

            return Ok(values);
        }

 //       [IdentityBasicAuthentication]
 //       [Authorize]
        [HttpPost]
        public IHttpActionResult Create(StatisticValue val)
        {
            var stat = context.stats.FirstOrDefault(x => x.id == val.StatisticId);
            if (stat == null)
            {
                return NotFound();
            }

            try
            {
                if (stat.stat_type == "COUNT")
                {
                    var v = new stat_count_value();
                    v.stat_id = val.StatisticId;
                    v.value = Convert.ToInt64(val.Value);
                    v.date_created = DateTime.Now;

                    context.stat_count_values.InsertOnSubmit(v);
                }
            
                context.SubmitChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
