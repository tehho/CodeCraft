namespace MainProgram
{
    public static class System
    {
        public static string ToCapitalize(this string str)
        {
            if (str == "")
                return "";

            string temp = "";

            temp += str.Substring(0,1).ToUpper();
            temp += str.Substring(1).ToLower();
            
            return temp;
        }
    }
}
