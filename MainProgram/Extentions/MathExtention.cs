namespace MainProgram
{
    public static class MathExtention
    {
        public static int Round(this double dec)
        {
            return (dec + 0.5).Floor();
        }
        public static int Floor(this double dec)
        {
            return (int)dec;
        }
    }
}
