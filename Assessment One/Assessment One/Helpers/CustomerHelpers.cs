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


        public static Customer[] Add(Customer[] custArray, Customer customer)
        {
            int nextFreeSpot = ArrayHelpers.GetNextFreeSpotInArray(custArray);
            custArray[nextFreeSpot] = customer;
            return custArray;
        }



        public static Customer[] Clone(Customer[] custArray)
        {
            Customer[] clonedArray = new Customer[custArray.Length];
            for (int i = 0; i < custArray.Length; i++)
            {
                clonedArray[i] = custArray[i];
            }
            return clonedArray;
        }






    }
}
