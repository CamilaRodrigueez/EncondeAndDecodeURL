using ConsolePruebaTecnica.Domain;
using System;
using System.Web;

namespace ConsolePruebaTecnica
{
    internal class Program
    {
      
        static void Main(string[] args)
        {

            TonyUrl url= new TonyUrl("https://raddarstudios.com/problems/design-tinyurl");
            string tiny;
            string ans;
            

            if (url.Url.Length <= 1 && url.Url.Length <= 250)
            {
                Console.WriteLine("No se puede codificar");
            }
            else
            {
                tiny = url.Enconde(url.Url);
                ans = url.Deconde("http://tinyurl.com/2p9x6vky");

                Console.WriteLine("Url Codificada: " + tiny);
                Console.WriteLine("Url Decoficada: " + ans);
            }
        
            Console.ReadKey();

        }
            

        
    }
}
