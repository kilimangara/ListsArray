using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstrakt
{
    class Program
    {
        static void Main(string[] args)
        {
            Showmessage w = write;
            Readpar r = read;
            int pos;
            string a="Петя";
            lists l = new lists();
            int vib;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Добавить элемент\n2.Очистить список\n3.Вывести список\n4.Закончить работу");
                vib=int.Parse(Console.ReadLine());
              
                    if(vib==1)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите значение pos");
                        pos = int.Parse(Console.ReadLine());
                        l.insert(pos, w, r);
                        Console.ReadKey();
                    }
                   if(vib==2)
                   {
                        Console.Clear();
                        l.clear(w);
                        Console.ReadKey();
                   }
                    if(vib==3)
                    {
                        Console.Clear();
                        l.read(w);
                        Console.ReadKey();
                    }
                    if(vib==4)
                   {
                        Console.Clear();
                        break;
                    }
                }
                  
        }
      static void write(string message)
        {

            Console.WriteLine(message);
        }
      static string read()
      {
          return "Petya";
      }
    }

}