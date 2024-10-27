using Wep_Page_Calssifier.Services.Home;

namespace Wep_Page_Calssifier.Services.AlgorithmSorting
{
    public class QuickSort:LogicClass 
    {
        public static int Partition(List<Tuple<string, int>> list, int first, int last)
        {
            var pivotValue = list[first];
            int leftMark = first + 1;
            int rightMark = last;
            bool done = false;

            while (!done)
            {
                while (leftMark <= rightMark && list[leftMark].Item2 >= pivotValue.Item2)
                {
                    leftMark++;
                }

                while (rightMark >= leftMark && list[rightMark].Item2 <= pivotValue.Item2)
                {
                    rightMark--;
                }

                if (rightMark < leftMark)
                {
                    done = true;
                }
                else
                {
                    var temp = list[leftMark];
                    list[leftMark] = list[rightMark];
                    list[rightMark] = temp;
                }
            }

            list[first] = list[rightMark];
            list[rightMark] = pivotValue;

            return rightMark;
        }


        public static void QuickSortHelper(List<Tuple<string, int>> list, int first, int last)
        {
            if (first < last)
            {
                int splitPoint = Partition(list, first, last);
                QuickSortHelper(list, first, splitPoint - 1);
                QuickSortHelper(list, splitPoint + 1, last);
            }
        }
        public static List<Tuple<string, int>> QuickSortt(List<Tuple<string, int>> list)
        {
            QuickSortHelper(list, 0, list.Count - 1);
            return list;
        }


        public List<Tuple<string, int>> Text_after_sort_Quick(string Text)
        {

            return QuickSortt(WordAndGetRedundancies(Text));


        }


    }
}
