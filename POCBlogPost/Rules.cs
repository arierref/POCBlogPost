using System;

namespace POCBlogPost
{
    public class Rules
    {
        public static string EditTitle(string value)
        {
            string[] titleparts = value.Split(' ');
            string newtitle = titleparts[titleparts.Length - 1];
            return newtitle;
        }

        public static string EditBody(string value)
        {
            string bodyfirst15 = value.Substring(0, 15);
            string[] bodyparts = value.Split(' ');
            string newbody = bodyfirst15 + (' ') + bodyparts[bodyparts.Length - 1];
            return newbody;
        }

        public static string GetFileName(string value)
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dateAsString = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string filename = mydocpath + $"\\{value}_{dateAsString}.txt";
            return filename;
        }

    }
}
