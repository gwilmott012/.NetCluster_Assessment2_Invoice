using Assessment_One.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_One.Helpers
{
    public static class CustomerHelpers
    {
        private static int resizeAmount = 5;

        /// <summary>
        /// Adds passed in customer to array and if there is no space in array calls resize adding more spaces in array.
        /// </summary>
        public static Customer[] Add(Customer[] custArray, Customer customer)
        {
            int nextFreeSpot = ArrayHelpers.GetNextFreeSpotInArray(custArray);

            if (nextFreeSpot == -1)
            {
                custArray = Resize(custArray);
                nextFreeSpot = ArrayHelpers.GetNextFreeSpotInArray(custArray);
            }
            
            custArray[nextFreeSpot] = customer;
            return custArray;
        }
        
        /// <summary>
        /// Clones passed in array to a backup array.
        /// </summary>
        public static Customer[] Clone(Customer[] custArray)
        {
            Customer[] clonedArray = new Customer[custArray.Length];
            for (int i = 0; i < custArray.Length; i++)
            {
                clonedArray[i] = custArray[i];
            }
            return clonedArray;
        }

        /// <summary>
        /// Filters passed in customers to only contain customers of the passed in name.
        /// </summary>
        public static Customer[] FilterByName(Customer[] custArray, string name)
        {
            Customer[] filteredArray = new Customer[custArray.Length];
            int filteredArrayPos = 0;

            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i].Customer_Name == name)
                {
                    filteredArray[filteredArrayPos++] = custArray[i];
                }
            }
            return filteredArray;
        }

        /// <summary>
        /// Filters passed in customers to only contain customers of the passed in id.
        /// </summary>
        public static Customer[] FilterByCustomerId(Customer[] custArray, int CustomerId)
        {
            Customer[] filteredArray = new Customer[custArray.Length];
            int filteredArrayPos = 0;

            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i].Id == CustomerId)
                {
                    filteredArray[filteredArrayPos++] = custArray[i];
                }
            }
            return filteredArray;
        }




        /// <summary>
        /// Resizes passed in array adding 5 to the total value.
        /// </summary>
        private static Customer[] Resize(Customer[] custArray)
        {
            Customer[] clonedArray = new Customer[custArray.Length + resizeAmount];
            for (int i = 0; i < custArray.Length; i++)
            {
                clonedArray[i] = custArray[i];
            }
            return clonedArray;
        }



    }
}
