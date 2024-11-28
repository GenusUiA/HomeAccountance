using System;
using System.Data.SqlTypes;
using System.Linq;

namespace Course_project_HOME_ACCOUNTANCE.classes
{
    public class Goal
    {
        public int goal_id { get; set; }
        public string definition { get; set; }
        public decimal sum { get; set; }
        public decimal current_sum { get; set; }
        public DateTime[] period { get; set; }
    }
}