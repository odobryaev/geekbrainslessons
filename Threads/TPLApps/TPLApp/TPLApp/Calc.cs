using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace TPLApp
{
    class Calc
    {
        const Int32 BufferSize = 128;

        public void GenerateFiles(string path, int n)
        {
            
            int operation;
            double number1;
            double number2;
            Random rand = new Random();
            for (int i=0; i<n; i++)
            {
                operation = rand.Next(1, 2);
                number1 = rand.NextDouble() * 1000;
                number2 = rand.NextDouble() * 1000;
                using (var fileStream = File.OpenWrite(path + "\\source_"+ i +".txt"))
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8, BufferSize, false))
                {
                    streamWriter.Write($"{operation} {number1} {number2}");
                }
            }
        }

        public async void ReadFilesAsync(string path)
        {
            await ReadFiles(path);
        }

        public Task ReadFiles(string path)
        {
            return Task.Run(() =>
            {
                string path_out = "result.dat";

                Console.WriteLine("Calculate task started");

                var resultFileStream = File.OpenWrite(path_out);
                Task[] tasks = new Task[Directory.GetFiles(path,"*.txt").Length];
                int i = 0;
                foreach (string file in Directory.EnumerateFiles(path, "*.txt"))
                {
                    tasks[i] = Task.Run(() => ExecuteFile(file, resultFileStream));
                    i++;
                }
                Task.WaitAll(tasks);
                resultFileStream.Close();

                Console.WriteLine("All files finished");
                Process.Start("notepad.exe", path_out);
            }
            );
        }

        private void ExecuteFile(string file, FileStream resultFileStream)
        {
            Thread.Sleep(100);
            using (var fileStream = File.OpenRead(file))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                if ((line = streamReader.ReadLine()) != null)
                {
                    using (var streamWriter = new StreamWriter(resultFileStream, Encoding.UTF8, BufferSize, true))
                        streamWriter.WriteLine(Path.GetFileName(file) + " " + Calculate(line));
                }
            }
        }

        private double Calculate(string s)
        {
            int operation = Convert.ToInt32(s.Split(' ')[0]);
            double number1 = Convert.ToDouble(s.Split(' ')[1]);
            double number2 = Convert.ToDouble(s.Split(' ')[1]);
            switch (operation)
            {
                case 1: return number1 * number2;
                case 2: return number1 / number2;
                default: return 0;
            }
        }
    }
}
