using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class TestingHelper
    {
        static double Sum(this List<double> list)
        {
            double sum = 0.0;

            foreach (var item in list)
            {
                sum += item;
            }

            return sum;
        }

        public static string GetFileNameFromFullPath(this string fullPath)
        {
            return fullPath.Split('/').Last();
        }
    }
}
