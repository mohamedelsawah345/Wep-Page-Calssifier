using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using Wep_Page_Calssifier.Helper;
using Wep_Page_Calssifier.Models;
using Wep_Page_Calssifier.Services;
using Wep_Page_Calssifier.Services.AlgorithmSorting;
using Wep_Page_Calssifier.Services.Home;

using Wep_Page_Calssifier.Services.Home.Implementation;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wep_Page_Calssifier.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static IFormFile _File;
        
        private static string _url;
        private static string _Text;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Begining()
        {
           


            return View();



        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost ]
        public  async Task< IActionResult> Index( UploadFile File )
        {

            ContentReaderFile contentReader = new ContentReaderFile(File.formFile);


            _Text = await contentReader.ReadContent();

            


            return RedirectToAction("ChoseTypeOfSort");
            
 
              
        }




        public IActionResult IndexURL()
        {



            return View();


        }

        [HttpPost]
        public async Task<IActionResult> IndexURL(UploadURL URLData)
        {


            ContentReaderURL contentReader = new ContentReaderURL(URLData.URL);

            _Text = await ContentReaderURL.GetWebPageTextAsync(URLData.URL);


            return RedirectToAction("ChoseTypeOfSort");
           
        }



        public IActionResult ChoseTypeOfSort()
        {
            return View();
        }


        public IActionResult TextAfterSorted_Buble()
        {
            Stopwatch stopwatch = new Stopwatch();
           
            BubleSorting result = new BubleSorting();

         DetermineCategory category = new DetermineCategory();

           
            stopwatch.Start();
            var TopResult= result.Text_after_sort_Buble(_Text);
             stopwatch.Stop();
            var Time = (stopwatch.ElapsedMilliseconds).ToString();
            ViewBag.Time = Time;

            ViewBag.TopResult = TopResult;
            
            ViewBag.Message = category.GetCategory(TopResult);
           
            return View();
        }


        public IActionResult TextAfterSorted_Insertion()
        {
            Stopwatch stopwatch = new Stopwatch();
            InsertionSort result = new InsertionSort();

            DetermineCategory category = new DetermineCategory();

            stopwatch.Start();

            var TopResult = result.Text_after_sort_Insertion(_Text);
            stopwatch.Stop();
            var Time = (stopwatch.ElapsedMilliseconds).ToString();
            ViewBag.Time = Time;
            ViewBag.TopResult = TopResult;

            ViewBag.Message = category.GetCategory(TopResult);
            return View();
        }



        public IActionResult TextAfterSorted_Quick()
        {
            Stopwatch stopwatch = new Stopwatch();
            QuickSort result = new QuickSort();
            DetermineCategory category = new DetermineCategory();


            stopwatch.Start();
            var TopResult = result.Text_after_sort_Quick(_Text);
            stopwatch.Stop();
            var Time = (stopwatch.ElapsedMilliseconds).ToString();
            ViewBag.Time = Time;
            ViewBag.TopResult = TopResult;

            ViewBag.Message = category.GetCategory(TopResult);
            return View();
        }



        public IActionResult TextAfterSorted_Merge()
        {
            Stopwatch stopwatch = new Stopwatch();
            MergeSort result = new MergeSort();

            DetermineCategory category = new DetermineCategory();


            stopwatch.Start();
            var TopResult = result.Text_after_sort_Merge(_Text);
            stopwatch.Stop();
            var Time = (stopwatch.ElapsedMilliseconds).ToString();
            ViewBag.Time = Time;

            ViewBag.TopResult = TopResult;
            ViewBag.Message = category.GetCategory(TopResult);
            return View();
        }




        public IActionResult TextAfterSorted_SelectionSort()
        {
            Stopwatch stopwatch = new Stopwatch();
            SelectionSort result = new SelectionSort();

            DetermineCategory category = new DetermineCategory();


            stopwatch.Start();
            var TopResult = result.Text_after_sort_Selection(_Text);
            stopwatch.Stop();
            var Time = (stopwatch.ElapsedMilliseconds).ToString();
            ViewBag.Time = Time;

            ViewBag.TopResult = TopResult;
            ViewBag.Message = category.GetCategory(TopResult);
            return View();
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
