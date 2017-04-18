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
        private static int resizeAmount = 1;

        /// <summary>
        /// Adds a new customer or updates an existing customer
        /// </summary>
        public static Customer[] AddOrUpdate(Customer[] custArray, Customer customer)
        {
            if (CustomerExists(custArray, customer))
            {
                custArray = Update( custArray, customer);
            }
            else
            {
                custArray = Add(custArray, customer);
            }
            return custArray;
        }

        /// <summary>
        /// Adds passed in customer to array and if there is no space in array calls resize adding more spaces in array.
        /// </summary>
        private static Customer[] Add(Customer[] custArray, Customer customer)
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
        /// Adds passed in customer to array and if there is no space in array calls resize adding more spaces in array.
        /// </summary>
        private static Customer[] Update(Customer[] custArray, Customer customer)
        {
            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i] != null && custArray[i].Id == customer.Id)
                {
                    custArray[i] = customer;
                }
            }

            return custArray;
        }

        /// <summary>
        /// Checks to see if a customer is already in the array.
        /// </summary>
        private static bool CustomerExists(Customer[] custArray, Customer customer)
        {
            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i] != null && custArray[i].Id  == customer.Id)
                {
                    return true;
                }
            }

            return false;
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
        /// Filters passed in array to only contain customers of the passed in name.
        /// </summary>
        public static Customer[] FilterByName(Customer[] custArray, string name)
        {
            Customer[] filteredArray = new Customer[custArray.Length];
            int filteredArrayPos = 0;

            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i] != null && custArray[i].Customer_Name.ToLower() == name.ToLower())
                {
                    filteredArray[filteredArrayPos++] = custArray[i];
                }
            }
            return TrimArray(filteredArray);
        }

        /// <summary>
        /// Filters passed in array to only contain customers of the passed in id.
        /// </summary>
        public static Customer[] FilterByCustomerId(Customer[] custArray, int CustomerId)
        {
            Customer[] filteredArray = new Customer[custArray.Length];
            int filteredArrayPos = 0;

            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i] != null && custArray[i].Id == CustomerId)
                {
                    filteredArray[filteredArrayPos++] = custArray[i];
                }
            }
            return TrimArray(filteredArray);
        }

        /// <summary>
        /// Filters passed in array to only contain customers not of the passed in id.
        /// </summary>
        public static Customer[] DeleteByCustomerId(Customer[] custArray, int CustomerId)
        {
            Customer[] filteredArray = new Customer[custArray.Length];
            int filteredArrayPos = 0;

            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i] != null && custArray[i].Id != CustomerId)
                {
                    filteredArray[filteredArrayPos++] = custArray[i];
                }
            }
            return TrimArray(filteredArray);
        }

        /// <summary>
        /// Updates passed in array to details of passed in customer by id.
        /// </summary>
        public static Customer[] UpdateByCustomerId(Customer[] custArray, Customer customer)
        {
            Customer[] newArray = new Customer[custArray.Length];

            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i] != null && custArray[i].Id == customer.Id)
                {
                    custArray[i] = customer;
                }
            }
            return custArray;
        }


        public static int GetNextId(Customer[] custArray)
        {
            int highestID = 0;

            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i] != null && custArray[i].Id > highestID)
                {
                    highestID = custArray[i].Id;
                }
            }

            return highestID + 1;
        }

        private static Customer[] TrimArray(Customer[] custArray)
        {
            int counter = 0;
            int numberOfElemets = ArrayHelpers.NumberOfElementsInArray(custArray);
            Customer[] trimmedArray = new Customer[numberOfElemets];

            for (int i = 0; i < custArray.Length; i++)
            {
                if (custArray[i] != null)
                {
                    trimmedArray[counter++] = custArray[i];
                }
            }

            return trimmedArray;
        }


        


        /// <summary>
        /// Resizes passed in array adding 1 to the total value.
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
