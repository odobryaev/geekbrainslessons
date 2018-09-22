using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ThreadApp
{
    class ThreadCSVParser
    {
        private object lockObject = new object();
        private string _path;
        private List<string[]> output = new List<string[]>();

        public ThreadCSVParser (string path)
        {
            _path = path;
        }

        public void Parse()
        {
            lock (lockObject)
            {
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(_path))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Thread.Sleep(1);
                        output.Add(ParseLine(line));
                    }
                }
                Console.WriteLine("Файл успешно прочитан");
            }
        }

        private string[] ParseLine(string line)
        {
            return line.Split(';');
        }

        public void WriteToTXT()
        {
            lock (lockObject)
            {
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenWrite(_path.Replace(".csv", ".txt")))
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8, BufferSize, false))
                {
                    foreach (string[] line in output)
                    {
                        foreach (string value in line)
                            streamWriter.Write(value + " ");
                        streamWriter.WriteLine();
                    }
                }
                Console.WriteLine("Файл успешно записан");
            }
        }
    }
}
