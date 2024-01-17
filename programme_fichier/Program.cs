using System;
using System.IO;
using System.Text;

namespace programme_fichier
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pour ecrire creer un fichier dans un repertoire specifique de ta machine
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = "out";

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
           
            string filename = "monFichier.txt";
            string filename2 = "monFichier2.txt";

            string pathAndFile = Path.Combine(path, filename);
            string pathAndFile2 = Path.Combine(path, filename2);

            if (File.Exists(pathAndFile))
            {
                Console.WriteLine("le fichier existe deja, on va ecraser son contenu");
            }
            else
            {
                Console.WriteLine("le fichier n'existe pas, on va le creer");
            }
            Console.WriteLine("Fichier : " + pathAndFile);

            /*var noms = new List<string>()
            {
                "Valdez",
                "Billie",
                "Lalou",
                "Kim"
            };*/

            StringBuilder texte = new StringBuilder();

            int nbLignes = 200;

            //---------------------------

            /*  DateTime t1 = DateTime.Now;

              Console.WriteLine("Preparation des donnees....");
              for (int i = 1; i <= nbLignes; i++)
              {
                  texte.Append("Ligne " + i + "\n");
              }
              Console.WriteLine("OK");

              Console.WriteLine("Ecriture des données");
              Console.WriteLine(pathAndFile, texte.ToString());
              Console.WriteLine("OK");

              DateTime t2 = DateTime.Now;

              var dif =(int)((t2  - t1).TotalMilliseconds);
              Console.WriteLine("Durée (ms) : " + dif);*/

            //---------------------------

            //Stream : Flux

            DateTime t1 = DateTime.Now;

            //performance pour ecrire dans un fichier avce Stream
            Console.WriteLine("Ecriture des données...");
            using (var writeStream = File.CreateText(pathAndFile))
            {
                for (int i = 1; i <= nbLignes; i++)
                {
                    writeStream.Write("Ligne " + i + "\n");
                }
            }
            Console.WriteLine("OK");
            DateTime t2 = DateTime.Now;

            var dif = (int)((t2 - t1).TotalMilliseconds);
            Console.WriteLine("Durée (ms) : " + dif);

            using(var readStream = new StreamReader(File.OpenRead(pathAndFile)))
            {
                while (true)
                {
                    var line = readStream.ReadLine();
                    if(line == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(line);
                    }
                }

            }
            //File.WriteAllText("monFichier.txt", "Voici le contenu que j'ecris dans le fichier texte");

            //File.WriteAllLines(pathAndFile, noms);

            /*try
            {
                //string res = File.ReadAllText("monFichier.txt");
                var lignes = File.ReadAllLines(pathAndFile);
                foreach (var ligne in lignes)
                {
                    Console.WriteLine(ligne);
                }
               
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ERREUR : ce fichier n'existe pas (" +ex.Message + ")");
            }*/

            //File.Copy(pathAndFile, pathAndFile2);
            //File.Delete(pathAndFile2);
            //File.Move(pathAndFile, pathAndFile2);

        }

    }
}
