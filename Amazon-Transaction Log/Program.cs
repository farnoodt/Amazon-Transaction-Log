using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazon_Transaction_Log
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] s = new string[] { "345366 89921 45",
                                        "029323 38239 23",
                                        "38239 345366 15",
                                        "029323 38239 77",
                                        "345366 38239 23",
                                        "029323 345366 13",
                                        "38239 38239 23"};

            var res = Transaction_Log(s, 3);
            foreach(var item in res)
                Console.WriteLine(item.Key+ " " + item.Value) ;
        }

        static Dictionary<string, int> Transaction_Log(string[] arr, int target)
        {
            Dictionary<string, int> Dic = new Dictionary<string, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                string[] TR = arr[i].Split(" ");
                HashSet<string> H = new HashSet<string>();
                for (int j = 0; j < TR.Length-1; j++)
                    H.Add(TR[j]);

                foreach (var item in H)
                {
                    if (Dic.ContainsKey(item))
                        Dic[item]++;
                    else
                        Dic.Add(item, 1);
                }
            }
            return Dic.Where(keys=>keys.Value>=target).ToDictionary(k=>k.Key,v=>v.Value);
        }
    }
}
