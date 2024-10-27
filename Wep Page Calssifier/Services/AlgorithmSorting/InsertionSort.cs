using Wep_Page_Calssifier.Services.Home;

namespace Wep_Page_Calssifier.Services.AlgorithmSorting
{
    public class InsertionSort :LogicClass
    {

        public static List<Tuple<string, int>> InsertionSortt(List<Tuple<string, int>> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int pos = i;
                var value = list[i];

                while (pos > 0 && list[pos - 1].Item2 < value.Item2)
                {
                    list[pos] = list[pos - 1];
                    pos--;
                }

                list[pos] = value;
            }

            return list;
        }
        public List<Tuple<string, int>> Text_after_sort_Insertion(string Text)
        {

            return InsertionSortt(WordAndGetRedundancies(Text));


        }

    }
}
