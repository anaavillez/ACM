using System;

namespace Acme.Common
{
    public static class StringHandler
    {
        /// <summary>
        /// Inserts spaces before each capital letter in a string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
       public static string InsertSpaces(this string source)
        {
            string result = string.Empty;

            if(!string.IsNullOrWhiteSpace(source))
            {
                foreach(char letter in source)
                {
                    if(char.IsUpper(letter))
                    {
                        //TRim any spaces already there so theres no extra space
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
            }
            //Gets rid of any unused whitespace
            result = result.Trim();
            return result;
        }
    }
}
