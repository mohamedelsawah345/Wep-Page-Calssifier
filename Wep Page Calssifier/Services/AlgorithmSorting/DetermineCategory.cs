namespace Wep_Page_Calssifier.Services.AlgorithmSorting
{
    public class DetermineCategory
    {



        public string GetCategory(List<Tuple<string, int>> sortedItems)
        {
            // Get the top 3 words
            var topWords = sortedItems.Take(3).Select(item => item.Item1).ToList();

            // Check the category based on keywords
            if (topWords.Any(word => new List<string> { "football", "ball", "match" }.Contains(word)))
            {
                return "Category: Football"; 
            }
            else if (topWords.Any(word => new List<string> { "economy", "economic", "goods" }.Contains(word)))
            {
                return "Category: Economy";
            }
            else if (topWords.Any(word => new List<string> { "fashion", "latest", "outfit" }.Contains(word)))
            {
                return "Category: Fashion";
            }
            else if (topWords.Any(word => new List<string> { "poetry", "art", "music" }.Contains(word)))
            {
                return "Category: Art";
            }
            else
            {
                return "Category: Unknown";
            }
        }


    }
}