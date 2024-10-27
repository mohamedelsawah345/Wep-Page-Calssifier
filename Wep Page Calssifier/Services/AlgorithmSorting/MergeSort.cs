using Wep_Page_Calssifier.Services.Home;

namespace Wep_Page_Calssifier.Services.AlgorithmSorting
{
    public class MergeSort:LogicClass 
    {


        public static void Merge(List<Tuple<string, int>> items, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            var leftItems = new List<Tuple<string, int>>(n1);
            var rightItems = new List<Tuple<string, int>>(n2);

            for (int i = 0; i < n1; i++)
                leftItems.Add(items[left + i]);

            for (int j = 0; j < n2; j++)
                rightItems.Add(items[mid + 1 + j]);

            int iIndex = 0, jIndex = 0, k = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (leftItems[iIndex].Item2 >= rightItems[jIndex].Item2)
                {
                    items[k] = leftItems[iIndex];
                    iIndex++;
                }
                else
                {
                    items[k] = rightItems[jIndex];
                    jIndex++;
                }
                k++;
            }

            while (iIndex < n1)
            {
                items[k] = leftItems[iIndex];
                iIndex++;
                k++;
            }

            while (jIndex < n2)
            {
                items[k] = rightItems[jIndex];
                jIndex++;
                k++;
            }
        }

        public static void MergeSortHelper(List<Tuple<string, int>> items, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSortHelper(items, left, mid);
                MergeSortHelper(items, mid + 1, right);
                Merge(items, left, mid, right);
            }
        }

        public static List<Tuple<string, int>> MergeSortt(List<Tuple<string, int>> items)
        {
            MergeSortHelper(items, 0, items.Count - 1);
            return items;
        }





        public List<Tuple<string, int>> Text_after_sort_Merge(string Text)
        {

            return MergeSortt(WordAndGetRedundancies(Text));


        }











    }
}
