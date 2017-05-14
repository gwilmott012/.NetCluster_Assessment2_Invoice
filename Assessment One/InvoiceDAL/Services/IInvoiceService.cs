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
        List<Invoice> GetCustomerInvoices(int Customer_Id);
        int GetMaxInvoiceId();
        List<Invoice> CreateOrUpdateInvoice(Invoice invoice);
        List<Invoice> GetInvoicesById(int Customer_Id);
    }
}
