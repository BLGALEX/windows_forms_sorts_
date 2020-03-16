using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts_interface
{
    static class Sorts
    {

        static private int N = 0;
        static private int[] array = new int[N];

       static public String set_N(String str)
        {
            N = Convert.ToInt32(str);
            array = new int[N];
            var rand = new Random();
            for(int i =0; i < N; i++)
            {
                array[i] = rand.Next() % 32768;
            }
            str = "Успех";
            return str;
        }
        

    }
}
