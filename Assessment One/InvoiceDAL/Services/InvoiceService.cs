using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceDAL.Models;
using System.Configuration;

namespace InvoiceDAL.Services
{
    public class InvoiceService : IInvoiceService
    {

        string connectionString;

        public InvoiceService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["InvoiceConnection"].ConnectionString.ToString();
        }

        public List<Invoice> CreateInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> DeleteInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetInvoices()
        {
            throw new NotImplementedException();
        }

        public int GetMaxInvoiceId()
        {
            throw new NotImplementedException();
        }

        public List<Invoice> InvoiceExists(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> UpdateInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
