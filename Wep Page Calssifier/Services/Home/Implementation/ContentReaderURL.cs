using System.Security.Policy;


namespace Wep_Page_Calssifier.Services.Home.Implementation
{
    public class ContentReaderURL 
    {

        string _url;

        public ContentReaderURL(string url)
        {
            _url = url;   
        }


        public static async Task<string> GetWebPageTextAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // جلب محتوى الصفحة
                    HttpResponseMessage response = await client.GetAsync(url);

                    // التأكد من أن الطلب ناجح
                    response.EnsureSuccessStatusCode();

                    // قراءة محتوى الصفحة كنص
                    string pageContent = await response.Content.ReadAsStringAsync();

                    // استخراج النص من HTML (إذا كنت ترغب في تجاهل أكواد HTML)
                    string textContent = await StripHTML(pageContent);

                    return textContent;
                }
                catch (HttpRequestException e)
                {
                    // في حالة حدوث خطأ في الطلب
                    Console.WriteLine($"Error fetching webpage: {e.Message}");
                    return null;
                }
            }
        }

        public static async Task<string> StripHTML(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", string.Empty);
        }

        



       
    }
}
