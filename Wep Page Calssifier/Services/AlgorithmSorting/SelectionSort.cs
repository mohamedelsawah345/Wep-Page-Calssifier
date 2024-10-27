using Wep_Page_Calssifier.Services.Home;

namespace Wep_Page_Calssifier.Services.AlgorithmSorting
{
    public class SelectionSort:LogicClass
    {


        public static List<Tuple<string, int>> SelectionSortt(List<Tuple<string, int>> items)
        {
            int n = items.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (items[j].Item2 > items[maxIdx].Item2)
                    {
                        maxIdx = j;
                    }
                }

                // Swap the found maximum element with the first element
                var temp = items[i];
                items[i] = items[maxIdx];
                items[maxIdx] = temp;
            }

            return items;


        }



        public List<Tuple<string, int>> Text_after_sort_Selection(string Text)
        {

            return SelectionSortt(WordAndGetRedundancies(Text));


        }








    }
}
