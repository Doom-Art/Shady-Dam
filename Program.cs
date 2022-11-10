using System.Runtime.CompilerServices;
using System.Text;

namespace Shady_Dam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> map1 = new List<string>();
            List<string> map2 = new List<string>();
            List<string> map3 = new List<string>();
            List<string> map4 = new List<string>();
            List<string> map5 = new List<string>();
            if (File.Exists(@"mapTest.txt")){
                int count = 0;
                int water = 0;
                int flooded = 0;
                int columns; ///number of items in each line
                int rows = 0; /// number of lines in the grid
                foreach(string i in File.ReadLines(@"mapTest.txt", Encoding.UTF8))
                {
                    if (count == 0){
                        Int32.TryParse(i, out water);
                        count = 1;
                        Console.WriteLine(i);
                    }
                    else if (count == 1){
                        Int32.TryParse(i, out columns);
                        count = 2;
                    }
                    else if (count == 2){
                        Int32.TryParse(i, out rows);
                        count = 3;
                    }
                    else if (count < (rows+ 3)){
                        map1.Add(i + '#');
                        count += 1;
                    }
                    else{
                        map1.Add("###########");
                        int locX = 0; int locY = 0;
                        while (water != 0)
                        {
                            if (map1[locY + 1][locX] != '#'){
                                locY+=1; 
                            }
                            else if (map1[locY][locX + 1] != '#'){
                                locX+=1; 
                            }
                            else if (map1[locY][locX + 1] == '#'){
                                water -= 1;
                                if (map1[locY][locX] == 'A'){
                                    flooded += 1;
                                }
                                string temp = "";
                                for(int c = 0; c < map1[locY].Length; c++)
                                {
                                    if (c == locX){
                                        temp += '#';
                                    }
                                    else
                                        temp += map1[locY][c];
                                }
                                map1[locY] = temp;
                                locX = 0; locY = 0;
                            }
                        }
                        Console.WriteLine(flooded);
                        count = 0;
                        flooded = 0;
                        map1 = new List<string>();
                    }

                }
            }
        }
    }
}