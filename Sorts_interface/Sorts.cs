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
        public Double time = 0;

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
        public void bubbleSort()
        {
            int temp;
            Int64 time1, time2;
            for (int i =0; i<N;i++)
            {
                array[i] = original_array[i];
            }
            time1 = DateTime.Now.Ticks;
            for (int i=0; i<N;i++)
                for(int j =0; j<N-i-1;j++)
                    if(array[j]>array[j+1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
            time2 = DateTime.Now.Ticks;
            time = (double)(time2 - time1) / (double)10000000;
        }
        public void QuickSort()
        {
            Int64 time1, time2;
            for (int i = 0; i < N; i++)
            {
                array[i] = original_array[i];
            }
            time1 = DateTime.Now.Ticks;
            realQuickSort(array, 0, array.Length - 1);
            time2 = DateTime.Now.Ticks;
            time = (double)(time2 - time1) / (double)10000000;
        }
        private void realQuickSort(int[] arr, int left, int right)
        {
                int pivot; // разрешающий элемент
                int l_hold = left; //левая граница
                int r_hold = right; // правая граница
                pivot = arr[left];
                while (left < right) // пока границы не сомкнутся
                {
                    while ((arr[right] >= pivot) && (left < right))
                        right--; // сдвигаем правую границу пока элемент [right] больше [pivot]
                    if (left != right) // если границы не сомкнулись
                    {
                        arr[left] = arr[right]; // перемещаем элемент [right] на место разрешающего
                        left++; // сдвигаем левую границу вправо
                    }
                    while ((arr[left] <= pivot) && (left < right))
                        left++; // сдвигаем левую границу пока элемент [left] меньше [pivot]
                    if (left != right) // если границы не сомкнулись
                    {
                        arr[right] = arr[left]; // перемещаем элемент [left] на место [right]
                        right--; // сдвигаем правую границу вправо
                    }
                }
                arr[left] = pivot; // ставим разрешающий элемент на место
                pivot = left;
                left = l_hold;
                right = r_hold;
                if (left < pivot) // Рекурсивно вызываем сортировку для левой и правой части массива
                    realQuickSort(arr, left, pivot - 1);
                if (right > pivot)
                    realQuickSort(arr, pivot + 1, right);
        }
    }
}
