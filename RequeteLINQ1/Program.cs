using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequeteLINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] notes = { 19, 20, 11, 13, 7, 8, 10, 15, 17, 14 };
            // Syntax SQL like
            var listeSUP15 = from n in notes where n > 15 select n;
            var listeMoy = from n in notes where n >= 10 select n;

            Console.WriteLine("-----------------List sup 15 ----------------");

            foreach (var item in listeSUP15)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------List moyenne ----------------");
            foreach (var item in listeMoy)
            {
                Console.WriteLine(item);
            }


            // Syntax fonctionelle Utilise de LAMDAS

            var listeSUP15_2 = notes.Where(n => n > 15);
            var listeMoy_2 = notes.Where(x => x > 10); 
            Console.ReadLine(); 
        }
    }
}
