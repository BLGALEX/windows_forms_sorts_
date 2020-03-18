using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts_interface
{
    class Sorts
    {

        static private int N = 0;
        static private int[] original_array = new int[N];
        public int[] array = new int[N];


        public Sorts()
        {
            N = 0;
        }
        public String set_N(String str)
        {
            if (str.Length > 6 || str == "")
                return "";
            for(int i =0; i <str.Length;i++)
            {
                if (!(str[i] >= '0' && str[i] <= '9'))
                    return "";
            }
            N = Convert.ToInt32(str);
            original_array = new int[N];
            array = new int[N];
            var rand = new Random();
            for (int i = 0; i < N; i++)
            {
                original_array[i] = rand.Next() % 32768;
            }
            str = "Успех";
            return str;
        }



    }
}
