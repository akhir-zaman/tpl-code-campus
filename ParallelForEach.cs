using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class ParallelForEach
{
    static void Main()
    {
        // Membuat array string dan menginisialisasinya dengan kata-kata yang dipisahkan oleh spasi
        string[] localStrings = "I am doing a simple example of a Parallel foreach loop".Split(' ');

        // Melakukan parallel foreach loop pada array "localStrings", mencetak setiap kata ke konsol dengan thread yang berbeda
        Parallel.ForEach(localStrings, currentString =>
            {
                Console.WriteLine("Current word is - {0}, and the current thread is - {1}", currentString, Thread.CurrentThread.ManagedThreadId);
            }
        );

        // Menunggu input dari user sebelum menutup program
        Console.ReadLine();
    }
}
