﻿
namespace APIs_Task.Models
{
    public class Report
    {
        public int companyId { get; set; }
        public int branchId { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }    
        public List<Create> creates { get; set; }
    }
}
