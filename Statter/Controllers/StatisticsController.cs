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
    public class StatisticsController : ApiController
    {
        private DataClasses1DataContext context = new DataClasses1DataContext();

        [HttpGet]
        public IEnumerable<Statistic> Index(string searchText = "")
        {
            IEnumerable<stat> statistics;

            if (!String.IsNullOrEmpty(searchText))
            {
                statistics = context.stats.Where(x => x.name.Contains(searchText)).Take(15);
            }
            else
            {
                statistics = context.stats.Take(15);
            }

            var stats = new List<Statistic>();

            foreach (var item in statistics)
            {
                var s = new Statistic();
                s.Id = item.id;
                s.Name = item.name;
                s.StatisticType = item.stat_type;
                s.Description = item.description;
                stats.Add(s);
            }

            return stats;
        }

        [HttpGet]
        public IHttpActionResult Show(int id)
        {
            var stat = context.stats.FirstOrDefault(x => x.id == id);
            if (stat == null)
            {
                return NotFound();
            }

            var s = new Statistic();
            s.Id = stat.id;
            s.Name = stat.name;
            s.StatisticType = stat.stat_type;
            s.Description = stat.description;

            return Ok(s);
        }

        public IHttpActionResult Subscribe(int id)
        {
            var stat = context.stats.FirstOrDefault(x => x.id == id);
            if (stat == null)
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Unsubscribe(int id)
        {
            var stat = context.stats.FirstOrDefault(x => x.id == id);
            if (stat == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
