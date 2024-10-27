using Wep_Page_Calssifier.Services.Home;

namespace Wep_Page_Calssifier.Services.AlgorithmSorting
{
    public class BubleSorting :LogicClass
    {



        public static List<Tuple<string, int>> BubbleSort(List<Tuple<string, int>> items)
        {
            // تنفيذ التكرار من نهاية القائمة حتى 0
            for (int i = items.Count - 1; i > 0; i--)
            {
                bool swapped = false;

                // مقارنة العناصر المجاورة
                for (int j = 0; j < i; j++)
                {
                    if (items[j].Item2 < items[j + 1].Item2)
                    {
                        // تبديل العناصر
                        var temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        swapped = true;
                    }
                }

                // إذا لم يتم التبديل في الدورة، يتم الخروج
                if (!swapped)
                {
                    return items;
                }
            }

            return items;
        }

        public  List<Tuple<string, int>> Text_after_sort_Buble(string Text)
        {

            return BubbleSort(WordAndGetRedundancies(Text));


        }






    }
}
