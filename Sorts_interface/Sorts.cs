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

        static public void set_N(String str)
        {
           int x = 1;
           N = 0;
           for(int i =str.Length-1; i >=0 ; i--)
            {
                if(str[i] >= '0' && str[i] <='9')
                {
                    N += ((int)str[i] - (int)'0') * x;
                    x *= 10;
                }
            }
            array = new int[N];
            var rand = new Random();
            for(int i =0; i < N; i++)
            {
                array[i] = rand.Next() % 32768;
            }
        }


    }
}
