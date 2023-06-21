using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rascunho.Entities
{
    public class Folders
    {
        public string Name { get; private set; }
        public string Way { get; private set; }
        public List<Folders> FolderList { get; private set; }
        public int Space { get; private set; }
        private ConsoleColor ColorName, ColorSpace;

        public Folders(string way, int space)
        {
            Way = way;
            Name = Path.GetFileName(way);
            ColorName = ConsoleColor.White;
            ColorSpace = ConsoleColor.White;
            FolderList = new List<Folders>();
            Space = Name.Length + space;
            Console.ForegroundColor = ConsoleColor.White;
            GetFolders();
        }


        Folders(string way, string restricted, int space)
        {
            Name = restricted;
            Way = way;
            Space = Name.Length + space;
            FolderList = new List<Folders>();
        }

        public Folders(string way, int space, ConsoleColor colorName)
        {
            Way = way;
            Name = Path.GetFileName(way);
            FolderList = new List<Folders>();
            Space = Name.Length + space;
            ColorSpace = colorName;
            Console.ForegroundColor = colorName;
            ColorName = colorPrint();
            Console.ForegroundColor = colorName;
            GetFolders();
        }

        public void GetFolders()
        {
            if (CheckFolderAccess())
            {
                List<string> list = new List<string>(Directory.EnumerateDirectories(Way, "*.*", SearchOption.TopDirectoryOnly));
                if (list.Count >= 0)
                {
                    foreach (string folder in list)
                    {
                        FolderList.Add(new Folders(folder, Space, ColorName));
                    }
                }
            }
            else
            {
                FolderList.Add(new Folders(Way, "PASTA RESTRITA", Space)); //Verificar se não vai haver erros na primeira instanciação. 
            }
        }


        bool CheckFolderAccess()
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(Way);
                _ = directory.GetDirectories();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        public void PrintFolder()
        {
            Console.ForegroundColor = ColorSpace;
            Console.Write(string.Concat(Enumerable.Repeat("-".ToString(), (Space - Name.Length))));
            Console.ForegroundColor = ColorName;
            Console.WriteLine(Name);

            if (FolderList.Count() >= 1)
            {
                foreach (Folders f in FolderList)
                {
                    f.PrintFolder();
                }
            }

            if (Directory.GetFiles(Way).Length > 0)
            {
                PrintFile();
                Console.WriteLine();
            }


            if (FolderList.Count == 0 && Directory.GetFiles(Way).Length == 0)
            {
                Console.Write(string.Concat(Enumerable.Repeat("-".ToString(), Space)));
                Console.WriteLine("Pasta vazia");
                Console.WriteLine("");
            }



        }

        void PrintFile()
        {
            Console.ForegroundColor = ColorName;
            string[] files = Directory.GetFiles(Way, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(file));
            }
            Console.WriteLine();
        }



        ConsoleColor colorPrint()
        {
            ConsoleColor[] colors =
            {
                ConsoleColor.White,
                ConsoleColor.DarkBlue,
                ConsoleColor.Gray,
                ConsoleColor.Green,
                ConsoleColor.Yellow,
                ConsoleColor.Red,
                ConsoleColor.Blue,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkGreen

            };

            for (int i = 0; i < colors.Length; i++)
            {
                if (Console.ForegroundColor == colors[i] && Console.ForegroundColor != colors[colors.Length - 1])
                {
                    return colors[i + 1];
                }
            }
            return ConsoleColor.White;
        }

        ConsoleColor printBackgournd()
        {
            ConsoleColor[] colors =
            {
                ConsoleColor.Black,
                ConsoleColor.White,
                ConsoleColor.DarkBlue,
                ConsoleColor.Gray,
                ConsoleColor.Green,
                ConsoleColor.Yellow,
                ConsoleColor.Red,
                ConsoleColor.Blue,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkGreen
            };
              
            for(int i = 0; i < colors.Length; i++)
            {
                if(Console.BackgroundColor == colors[i] && Console.BackgroundColor != colors[colors.Length -1])
                {
                    return Console.BackgroundColor = colors[i];
                }
              
            }
            return Console.BackgroundColor = colors[1];
        }

        void printColorSpace()
        {
            ConsoleColor c = Console.BackgroundColor;
            Console.BackgroundColor = printBackgournd();
            Console.Write(string.Concat(Enumerable.Repeat(" ".ToString(), Space - Name.Length)));
            Console.BackgroundColor = c;
            Console.Write(string.Concat(Enumerable.Repeat("-".ToString(), Space)));

        }
    }
}
