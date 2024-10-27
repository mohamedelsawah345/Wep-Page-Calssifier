using Wep_Page_Calssifier.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NuGet.Packaging.Signing;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;


namespace Wep_Page_Calssifier.Services.Home
{
    public class LogicClass
    {


        public static HashSet<string> LoadWordsFromFile(string Text)
        {
            // قراءة محتويات الملف
            string wordsString = Text;

            // تقسيم النص إلى قائمة باستخدام الفاصلة كفاصل
            List<string> wordsList = wordsString.Split(',').ToList();

            // إنشاء مجموعة من الكلمات بعد إزالة المسافات الزائدة
            HashSet<string> stopWords = new HashSet<string>(wordsList.Select(word => word.Trim()));
            return stopWords;
        }


        public static HashSet<string> Stoping_Words()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "TextFile", "common-english-words.txt");


            // طريقة الاستخدام
            HashSet<string> stopWords = LoadWordsFromFile(filePath);
            return stopWords;

        }


        public static List<string> CleaningWebText(string Text)
        {
            // قراءة علامات الترقيم الشائعة من الملف
            string commonPunctuation = "1234567890?!()[]{}';:`~/,.?@#$%^&*<>";


            // استبدال كل علامة ترقيم بمسافة
            foreach (var punctuation in commonPunctuation)
            {
                Text = Text.Replace(punctuation.ToString(), " ");
            }

            // استبدال السطر الجديد والرجوع بمسافات
            Text = Text.Replace("\n", " ");
            Text = Text.Replace("\r", " ");

            // تقسيم النص إلى مصفوفة كلمات بناءً على المسافات
            List<string> words = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            return words;
        }// To Remove punctuation  and  split with " "



        public static List<string> RemoveStopWords(List<string> text, HashSet<string> stopWords)
        {
            // تحويل جميع الكلمات إلى حروف صغيرة
            List<string> words = text.Select(x => x.ToLower()).ToList();

            // إزالة الكلمات التي تكون موجودة في قائمة stopWords
            List<string> filteredWords = words.Where(word => !stopWords.Contains(word)).ToList();

            // إزالة الكلمات القصيرة (طولها أقل من أو يساوي 1)
            for (int i = filteredWords.Count - 1; i >= 0; i--)
            {
                if (filteredWords[i].Length <= 1)
                {
                    filteredWords.RemoveAt(i);
                }
            }

            return filteredWords;
        }




        public static HashSet<string> GetUniqueElements(List<string> cleanedText)
        {
            // استخدام HashSet للحصول على العناصر الفريدة
            return new HashSet<string>(cleanedText);
        }


        public static List<Tuple<string, int>> GetRedundancies(List<string> cleanedText)
        {
            // الحصول على العناصر الفريدة
            HashSet<string> uniqueElements = GetUniqueElements(cleanedText);

            // إنشاء قائمة تحتوي على العنصر وعدد مرات ظهوره
            List<Tuple<string, int>> redundancies = new List<Tuple<string, int>>();

            foreach (var item in uniqueElements)
            {
                // حساب عدد مرات الظهور لكل عنصر في القائمة الأصلية
                int count = cleanedText.Count(x => x == item);
                redundancies.Add(new Tuple<string, int>(item, count));
            }

            return redundancies;
        }

        public  List<Tuple<string, int>> WordAndGetRedundancies(string Text)
        {
            string wordsString = Text;
            var TextAfterRemovingPunct = CleaningWebText(wordsString);
            var TextAfterRemovingStopWording = RemoveStopWords(TextAfterRemovingPunct, Stoping_Words());

            var cleanText = RemoveStopWords(TextAfterRemovingStopWording, Stoping_Words());
            return GetRedundancies(cleanText);
        }












    }















}














