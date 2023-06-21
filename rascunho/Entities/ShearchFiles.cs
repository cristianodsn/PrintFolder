using System;
using System.Collections.Generic;
using System.IO;

namespace rascunho.Entities
{
    public static class ShearchFiles
    {
        static private string Way;

        public static void Verification(Status status)
        {
            Way = findWay();
            showFiles();
        }

        static string findWay()
        {
            Console.Write("Entre com o caminho do arquivo: ");
            return Console.ReadLine();
        }

        static void showFiles()
        {
            Folders folders = new Folders(Way, 0); // fazer com que não de erro caso o caminho seja privado.
            Console.ReadKey();
            folders.PrintFolder();
        }     
    }
}
