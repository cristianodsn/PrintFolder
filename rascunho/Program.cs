using System;
using System.IO;
using rascunho.Exceptions;
using rascunho.Entities;

namespace rascunho
{
    class Program
    {

        static void Main(string[] args)
        
        
        {
            //C:\Users\crist\OneDrive\Área de Trabalho\Origem\summary.csv

            Status status = new Status(" ", 0 );
            bool on = true;

            while (on)
            {
                Console.WriteLine("COTAÇÃO DE ESTOQUE");
                Console.WriteLine();
                try
                {                           
                    ShearchFiles.Verification(status);



                    Console.WriteLine("Operação completa");

                }
               
                catch (DomainException e)
                {
                    Console.WriteLine("Error. " + e.Message);
                }
                
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(e.Message);

                }
                
                
                    catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);

                
                }
                
                Console.WriteLine();
                Console.WriteLine("Por favor, precisone a tecla enter para continuar...");
                Console.ReadLine();
                
                Console.Clear();
            }
           
        }
    }
}
