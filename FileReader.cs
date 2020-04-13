using System;
using System.Collections.Generic;
using System.IO;

namespace Words
{
    public class FileReader
    {
        public static List<string> ReadFromFile(string path, List<string> wordsRead)
        {
            // List<string> wordsRead = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String[] text = sr.ReadToEnd().Split(" ");
                    foreach (string word in text)
                    {
                        wordsRead.Add(word);
                    }
                }
            }
            catch (Exception ex)
            {
                string logFile = "log.txt";
                using (StreamWriter sw = File.AppendText(logFile))
                {
                    sw.WriteLine("New exception From FileReader: ");
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(ex);
                    sw.WriteLine();
                }
                Console.WriteLine(ex.Message);
            }
            return wordsRead;
        }
    }
}