using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statter.Models
{
    public class CountValue
    {
        public int Id { get; set; }
        public int StatisticId { get; set; }
        public DateTime DateCreated { get; set; }
        public long Value { get; set; }
    }
}