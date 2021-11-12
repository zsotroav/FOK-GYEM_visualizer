using System;
using System.Collections;
using System.IO;

namespace FOK_GYEM_visualizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the visualized file's name or location.");
            var loc = Console.ReadLine();
            if (!File.Exists(loc))
            {
                Console.WriteLine("File not found. Aborting...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Visualizing {loc}:");
            var primary = File.ReadAllBytes(loc!);
            for (int i = 0; i < primary.Length; i++)
            {
                var t = 0;
                for (int j = 0; j < 8; j++)
                {
                    t *= 2;
                    t += primary[i] % 2;
                    primary[i] >>= 1;
                }

                primary[i] = Convert.ToByte(t);
            }

            var bits = new BitArray(primary);

            for (var i = 0; i < bits.Length; i++)
            {
                Console.Write(bits[i] ? "X" : "-");
                if ((i + 1) % 24 == 0) Console.Write(" ");
                if ((i + 1) % 168 == 0) Console.Write("\n");
            }
        }
    }
}
