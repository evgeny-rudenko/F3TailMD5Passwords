using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


namespace MD5Search
{
    class Program
    {
        static void Main(string[] args)
        {
            //string userName = "";
            string password = "";
            
            List<string>  Users = File.ReadAllLines("users.txt").ToList();
            List<string> Hashes = File.ReadAllLines("hash.txt").ToList();


            string str;
            for (long i=0;i<999999;i++)
            {
                foreach (string userName in Users)
                {
                    password = i.ToString();
                    str = Base64Hash(string.Concat(userName, password));

                    if (Hashes.Contains(str))
                    {

                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine(userName);
                        Console.WriteLine(password);
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }

                Console.WriteLine(i);
                
            }
            
        }

        public static string Base64Hash(string val)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(val);
            return Convert.ToBase64String(MD5.Create().ComputeHash(bytes));
        }


    }
}
