using Assessment_One.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_One.Helpers
{
    public static class InvoiceHelper
    {
        private static int resizeAmount = 5;

        /// <summary>
        /// Adds passed in invoice to array and if there is no space in array calls resize adding more spaces in array.
        /// </summary>
        public static Invoice[] Add(Invoice[] invArray, Invoice invoice)
        {
            int nextFreeSpot = ArrayHelpers.GetNextFreeSpotInArray(invArray);

            if (nextFreeSpot == -1)
            {
                invArray = Resize(invArray);
                nextFreeSpot = ArrayHelpers.GetNextFreeSpotInArray(invArray);
            }

            invArray[nextFreeSpot] = invoice;
            return invArray;
        }

        /// <summary>
        /// Clones passed in array to a backup array.
        /// </summary>
        public static Invoice[] Clone(Invoice[] invArray)
        {
            Invoice[] clonedArray = new Invoice[invArray.Length];
            for (int i = 0; i < invArray.Length; i++)
            {
                clonedArray[i] = invArray[i];
            }
            return clonedArray;
        }

        /// <summary>
        /// Filters passed in array to only contain invoices of the passed in id.
        /// </summary>
        public static Invoice[] FilterByInvoiceId(Invoice[] invArray, int InvoiceId)
        {
            Invoice[] filteredArray = new Invoice[invArray.Length];
            int filteredArrayPos = 0;

            for (int i = 0; i < invArray.Length; i++)
            {
                if (invArray[i] != null && invArray[i].Id == InvoiceId)
                {
                    filteredArray[filteredArrayPos++] = invArray[i];
                }
            }
            return filteredArray;
        }

        /// <summary>
        /// Filters passed in array to only contain invoices for the customer of the passed in id.
        /// </summary>
        public static Invoice[] FilterByCustomerId(Invoice[] invArray, int CustomerId)
        {
            Invoice[] filteredArray = new Invoice[invArray.Length];
            int filteredArrayPos = 0;

            for (int i = 0; i < invArray.Length; i++)
            {
                if (invArray[i] != null && invArray[i].Customer_Id == CustomerId )
                {
                    filteredArray[filteredArrayPos++] = invArray[i];
                }
            }
            return filteredArray;
        }

        /// <summary>
        /// Filters passed in array to only contain invoices not of the passed in id.
        /// </summary>
        public static Invoice[] DeleteByInvoiceId(Invoice[] invArray, int InvoiceId)
        {
            Invoice[] filteredArray = new Invoice[invArray.Length];
            int filteredArrayPos = 0;

            for (int i = 0; i < invArray.Length; i++)
            {
                if (invArray[i] != null && invArray[i].Id != InvoiceId)
                {
                    filteredArray[filteredArrayPos++] = invArray[i];
                }
            }
            return filteredArray;
        }

        /// <summary>
        /// Updates passed in array to details of passed in invoice by id.
        /// </summary>
        public static Invoice[] UpdateByInvoiceId(Invoice[] invArray, Invoice invoice)
        {
            Invoice[] newArray = new Invoice[invArray.Length];

            for (int i = 0; i < invArray.Length; i++)
            {
                if (invArray[i] != null && invArray[i].Id == invoice.Id)
                {
                    invArray[i] = invoice;
                }
            }
            return invArray;
        }

        /// <summary>
        /// Resizes passed in array adding 5 to the total value.
        /// </summary>
        private static Invoice[] Resize(Invoice[] invArray)
        {
            Invoice[] clonedArray = new Invoice[invArray.Length + resizeAmount];
            for (int i = 0; i < invArray.Length; i++)
            {
                clonedArray[i] = invArray[i];
            }
            return clonedArray;
        }
    }
}
