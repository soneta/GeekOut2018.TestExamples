using Soneta.Tools;

namespace GeekOut2018.EnovaUnitTestExtension
{
    public static class ExtensionMethods
    {
        public static bool MoznaDodacPostfiks(this string str, string postfiks)
        {
            return !postfiks.IsNullOrEmpty() && !str.EndsWith(postfiks);
        }

        public static bool MoznaUsunacPostfiks(this string str, string postfiks)
        {
            if (!postfiks.IsNullOrEmpty() && str.EndsWith(postfiks))
            {
                return true;
            }
            return false;
        }

        public static string DodajPostfiks(this string str, string postfiks)
        {
            if (!postfiks.IsNullOrEmpty() && !str.EndsWith(postfiks))
            {
                return str + postfiks;
            }
            return str;
        }

        public static string UsunPostfiks(this string str, string postfiks)
        {
            if (!postfiks.IsNullOrEmpty() && str.EndsWith(postfiks))
            {
                return str.Substring(0, str.Length - postfiks.Length);
            }
            return str;
        }
    }
}