using System;
using System.Net;
using System.Threading;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            //TimerCallback tm = new TimerCallback(P);           //попытка обновлять  метод.
            //Timer timer = new Timer(tm, 0, 0, 5000);        //Попытка обновлять  метод.
            //Console.WriteLine(Parser(GetHTML()));
            Parser(GetHTML());
            //SaveBD(Parser(GetHTML()));                         //В этом методе логика добавления данных в БД.
        }
        static string GetHTML()
        {
            WebClient client = new WebClient();
            string htmlCode = client.DownloadString("https://hh.ru/search/vacancy?area=1&fromSearchLine=true&st=searchVacancy&text=C%23+junior&from=suggest_post");
            return htmlCode;
        }
        public static void P(object d)
        {
            Parser(GetHTML());
        }
        public static string Parser(string HTML)
        {
            string BD = "";
            int count = 0;
            while (count != -1)
            {
                count = HTML.IndexOf("a class=\"bloko-link\" data-qa");
                if (count != -1)
                {
                    HTML = HTML.Substring(count);
                    count = HTML.IndexOf("a>");
                    BD = BD + "\n" + HTML.Substring(1, count-3).Substring(HTML.IndexOf(">"));
                    HTML = HTML.Substring(count);
                }
                
            }
            Console.WriteLine(BD);
            return BD;
        }
        static void SaveBD(string STR)
        { 
            //Save in BD
        }
    }
}
