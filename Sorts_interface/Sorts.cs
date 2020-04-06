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
        public string last_sort = null;
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
                array[i] = original_array[i];
            }
            str = "Успех";
            last_sort = null;
            return str;
        }
        public void bubbleSort()
        {
            if (N == 0) return;
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
            last_sort = "Bubble sort";
        }
        public void QuickSort()
        {
            if (N == 0) return;
            Int64 time1, time2;
            for (int i = 0; i < N; i++)
            {
                array[i] = original_array[i];
            }
            time1 = DateTime.Now.Ticks;
            realQuickSort(array, 0, array.Length - 1);
            time2 = DateTime.Now.Ticks;
            time = (double)(time2 - time1) / (double)10000000;
            last_sort = "Quick sort";
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

        public void Insertion_sort()
        {
            if (N == 0) return;
                Int64 time1, time2;
                for (int i = 0; i < N; i++)
                {
                    array[i] = original_array[i];
                }
                time1 = DateTime.Now.Ticks;
                int key, j;
                for (int i = 1; i < array.Length; i++)
                {
                    key = array[i];
                    j = i - 1;
                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                    }
                    array[j + 1] = key;
                }
                time2 = DateTime.Now.Ticks;
                time = (double)(time2 - time1) / (double)10000000;
            last_sort = "Insertion sort";
        }

        public void LSD()
        {
            if (N == 0) return;
            Int64 time1, time2;
            for (int i = 0; i < N; i++)
            {
                array[i] = original_array[i];
            }
            time1 = DateTime.Now.Ticks;
            LSDSort(0, N - 1);
            time2 = DateTime.Now.Ticks;
            time = (double)(time2 - time1) / (double)10000000;
            last_sort = "LSD sort";
        }
        private int Getdigit(Int64 number, int digit)
        {
            while(digit > 1)
            {
                number /= 10;
                digit--;
            }
            number %= 32768;
            return (int)number;
        }

        private void LSDSort(int first, int last)
        {
            int x;
            int length = N;
            Int64[] buffer = new Int64[length];
            Int64[] first_u = new Int64[length];
            for (int i = 0; i < length; i++)
                first_u[i] = array[first+i] + 2147483648;
            int[] indexes_of_numbers = new int[32768];
            Int64 max = (first_u[0]);
            int digits = 0;
            for (int i = 1; i < length; i++)
                if (max < (first_u[i]))
                    max = (first_u[i]);
            while (max != 0)
            {
                digits++;
                max /= 32768;
            }
            for (int i = 1; i <= digits; i++)
            {
                for (int j = 0; j < 32768; j++)
                {
                    indexes_of_numbers[j] = 0;
                }
                for (int j = 0; j < length; j++)
                {
                    indexes_of_numbers[Getdigit(first_u[j], i)]++;
                }
                int count = 0;
                for (int j = 0, temp; j < 10; j++)
                {
                    temp = indexes_of_numbers[j];
                    indexes_of_numbers[j] = count;
                    count += temp;
                }
                for (int j = 0; j < length; j++)
                {
                    x = Getdigit(first_u[j], i);
                    buffer[indexes_of_numbers[x]] = first_u[j];
                    indexes_of_numbers[x]++;
                }
                for (int j = 0; j < length; j++)
                    first_u[j] = buffer[j];
            }
            for (int j = 0; j < length; j++)
                array[first+j] = (int)(first_u[j] - 2147483648);
        }

        public void Introsort()
        {
            if (N == 0) return;
            Int64 time1, time2;
            for (int i = 0; i < N; i++)
            {
                array[i] = original_array[i];
            }
            time1 = DateTime.Now.Ticks;
            realIntrosort(0, array.Length - 1, array.Length, 1);
            time2 = DateTime.Now.Ticks;
            time = (double)(time2 - time1) / (double)10000000;
            last_sort = "Introsort";
        }

        /**
         * Входные данные: два указателя на ячейки памяти
         *
         * Выходные данные: две ячейки памяти
         *
         * Меняет местами данные, хранящиеся в двух ячейках памяти
         *
         * @param *a - указатель на ячейку памяти
         * @param *b - указатель на ячейку памяти
         */
        unsafe private void swap(int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        /**
         * Входные данные: указатель на первый элемент участка массива и указатель на последний элемент участка миссива
         *
         * Выходные данные: часть массива приведённая к куче, где внизу самые большие числа
         *
         * Функция начиная от n/2-1 элемента начинает "просеивать" их через дерео, чтобы получить дерево сортировки
         *
         * @param *left - указатель на первый элемент участка массива
         * @param *right - указатель на последний элемент участка массива
         */
        private void HeapSetUp( int left, int right) // приводим к куче, чтобы a[i] <= a[2*i+1] && a[i] <=a[i*2+2]
        {
            int n = right -left+1;
            for (int i = n / 2 - 1; i >= 0; i--) // начинаем просеивать с n/2-1 элемента
            {
                for (int j = i; j <= n / 2 - 1;)
                {
                    if ((j * 2 + 2) > (n - 1))
                    {
                        if (array[left+ j * 2 + 1] < array[left+j])
                        {
                            swap(left+ j * 2 + 1, left+j);
                            j = j * 2 + 1;
                        }
                        else break;
                    }
                    else if (array[left+j * 2 + 1] < array[left+j * 2 + 2] && (array[left+j * 2 + 1] < array[left+j]))
                    {
                        swap(left+j * 2 + 1, left+j);
                        j = j * 2 + 1;
                    }
                    else if (array[left+j * 2 + 2] < array[left+j])
                    {
                        swap(left+j * 2 + 2, left+j);
                        j = j * 2 + 2;
                    }
                    else break;
                }
            }
        }

        /**
         * Входные данные: указатель на первый элемент участка массива и указатель на последний элемент участка миссива
         *
         * Выходные данные: отсортированная часть массива
         *
         * Функция меняет местами 1 и последний элемент текущего дерева и "просеивает" новую вершину через дерево,
         * размер которого уменьшается на один (то есть правая граница массива смещается на единицу влево).
         * Это проделываем до тех пор, пока масив не будет состоять из одного элемента
         *
         * @param *left - указатель на первый элемент участка массива
         * @param *right - указатель на последний элемент участка массива
         */
        private void HeapSort( int left, int right)
        {
            HeapSetUp( left, right);// сначала приводим к куче, где большие элементы внизу
            int n = right - left + 1;
            for (int i = n; i > 0; i--)//после каждой итерации дерево становится отсортированным с конца на ещё на один элемент
                                       //поэтому мы работаем каждый раз с деревом меньшим на 1 элемент с конца
            {
                swap((int)left, (int)(left+ i - 1)); // ставим наименьший элемент текущего дерева в конец и элемент с конца просеиваем через всё оставшееся дерево
                for (int j = 0; j < (i + 1) / 2 - 1;)
                {
                    if ((j * 2 + 2) >= (i - 1))
                    {
                        if (array[left+j * 2 + 1] < array[left+j])
                        {
                            swap(left+j * 2 + 1, left+j);
                            j = j * 2 + 1;
                        }
                        else break;
                    }
                    else if (array[left+j * 2 + 1] < array[left+j * 2 + 2] && (array[left+j * 2 + 1] < array[left+j]))
                    {
                        swap(left+j * 2 + 1, left+j);
                        j = j * 2 + 1;
                    }
                    else if (array[left+j * 2 + 2] < array[left+j])
                    {
                        swap(left+j * 2 + 2, left+j);
                        j = j * 2 + 2;
                    }
                    else break;
                }
            }
            for (int i = 0; i < n / 2; i++) //выписываем дерево с конца
                swap(left+i, left+n - i - 1);
        }

        /**
         * Входные данные: указатель на начало массива и номер элемента с которого нужно сортровать и номер элемнта до которого нужно сортировать
         * А также кольчество элементов массива при первом вызове функции и глубина рекурсии
         *
         * Выходные данные: отсортированныя часть массива
         *
         * Функция в завиимости от глубины рекурсии сортирует участок массива быстрой сортировкой и вызывает сама себя, если требуется
         * или сортирует участок массива пирамидальной сортировкой с помощью вызова соответствующей процедуры
         *
         * @param *arr - указатель на ячейку памяти
         * @param left - номер первого элемента массива в памяти
         * @param right - номер последнего элемента массива в памяти
         * @param actuall_len - изначальное количество элементов массива
         * @param deep - глубина рекурсии (изначально == 1)
         */
        private void realIntrosort(int left, int right, int actuall_len, int deep)
        {
            if (System.Math.Log(actuall_len) < deep)
            {
                HeapSort( left, right);
            }
            else
            {
                int pivot; // разрешающий элемент
                int l_hold = left; //левая граница
                int r_hold = right; // правая граница
                pivot = array[left];
                while (left < right) // пока границы не сомкнутся
                {
                    while ((array[right] >= pivot) && (left < right))
                        right--; // сдвигаем правую границу пока элемент [right] больше [pivot]
                    if (left != right) // если границы не сомкнулись
                    {
                        array[left] = array[right]; // перемещаем элемент [right] на место разрешающего
                        left++; // сдвигаем левую границу вправо
                    }
                    while ((array[left] <= pivot) && (left < right))
                        left++; // сдвигаем левую границу пока элемент [left] меньше [pivot]
                    if (left != right) // если границы не сомкнулись
                    {
                        array[right] = array[left]; // перемещаем элемент [left] на место [right]
                        right--; // сдвигаем правую границу вправо
                    }
                }
                array[left] = pivot; // ставим разрешающий элемент на место
                pivot = left;
                left = l_hold;
                right = r_hold;
                deep++;
                if (left < pivot) // Рекурсивно вызываем сортировку для левой и правой части массива
                    realIntrosort( left, pivot - 1, actuall_len, deep);
                if (right > pivot)
                    realIntrosort( pivot + 1, right, actuall_len, deep);

            }
        }
    }
}
