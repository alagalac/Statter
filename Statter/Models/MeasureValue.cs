using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statter.Models
{
    public class MeasureValue
    {
        public int Id { get; set; }
        public int StatisticId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Value { get; set; }
    }
}