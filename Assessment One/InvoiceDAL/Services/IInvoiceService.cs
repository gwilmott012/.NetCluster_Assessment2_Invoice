using InvoiceDAL.Models;
using System.Collections.Generic;

namespace InvoiceDAL.Services
{
    public interface IInvoiceService
    {
        List<Invoice> GetCustomerInvoices(int Customer_Id);
        int GetMaxInvoiceId();
        List<Invoice> CreateOrUpdateInvoice(Invoice invoice);
        List<Invoice> GetInvoicesById(int Customer_Id);
        void DeleteInvoiceById(int Id);

    }
}
