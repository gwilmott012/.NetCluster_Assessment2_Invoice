using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Services
{
    public interface IInvoiceService
    {
        List<Invoice> GetInvoices();
        List<Invoice> UpdateInvoice(Invoice invoice);
        List<Invoice> DeleteInvoice(Invoice invoice);
        int GetMaxInvoiceId();
        List<Invoice> InvoiceExists(Invoice invoice);
        List<Invoice> CreateInvoice(Invoice invoice);
    }
}
