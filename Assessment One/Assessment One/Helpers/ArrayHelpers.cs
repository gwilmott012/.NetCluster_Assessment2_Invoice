using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_One.Helpers
{
    public static class ArrayHelpers
    {

        /// <summary>
        /// Returns the first position of the first null value in objArray.
        /// If the array is full returns -1.
        /// </summary>
        public static int GetNextFreeSpotInArray(object[] objArray)
        {
            for (int i = 0; i < objArray.Length; i++)
            {
                if (objArray[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
