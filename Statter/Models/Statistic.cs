using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statter.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatisticType { get; set; }
        public Boolean Subscribed { get; set; }
    }
}