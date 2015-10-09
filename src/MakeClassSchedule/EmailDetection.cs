using System;
using System.Text.RegularExpressions;

namespace MakeClassSchedule
{
    public static class EmailDetection
    {
        public static bool ValidateEmail(this string vString)
        {
            Regex exp = new Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            
            return exp.IsMatch(vString.ToString());
        }
    }
}
