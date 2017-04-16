using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_One.DataEntities
{
    class Invoice
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string Description { get; set; }
        public double Costs { get; set; }
        public DateTime Payment_Date { get; set; }
    }
}
