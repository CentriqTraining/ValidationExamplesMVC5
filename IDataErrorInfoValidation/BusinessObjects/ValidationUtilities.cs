using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public static class ValidationUtilities
    {

        public static string GetErrorMessage(string key)
        {
            return BusinessObjects.ResourceManager.GetString(key);
        }
    }
}
