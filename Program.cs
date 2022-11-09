namespace Shady_Dam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> map = new List<string>();
            if (File.Exists(@"mapTest.txt"))
            {
                foreach(string i in File.ReadLines(@"mapTest.txt"))
                {

                }
            }
        }
    }
}