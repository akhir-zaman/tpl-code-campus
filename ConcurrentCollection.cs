using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class ConcurrentCollection
{
    static void Main()
    {
        // Membuat ConcurrentQueue yang aman digunakan oleh beberapa thread
        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        // Variabel untuk menyimpan hasil penjumlahan angka dari satu thread
        int SingleThreadSum = 0;

        // Mengisi antrian dengan angka dari 0 sampai 4999 dan menghitung hasil penjumlahannya pada satu thread
        for (int i = 0; i < 5000; i++)
        {
            SingleThreadSum += i;
            queue.Enqueue(i);
        }

        // Menampilkan hasil penjumlahan pada satu thread
        Console.WriteLine("Jumlah pada satu thread = {0}", SingleThreadSum);

        // Variabel untuk menyimpan hasil penjumlahan angka dari beberapa thread
        int MultiThreadSum = 0;

        // Membuat delegasi Action untuk mengambil item dari antrian dan menjumlahkannya
        Action localAction = () =>
        {
            int localSum = 0;
            int localValue;
            while (queue.TryDequeue(out localValue)) 
            {
                localSum += localValue;
            }
            Interlocked.Add(ref MultiThreadSum, localSum);
        };

        // Menjalankan 3 tugas secara bersamaan untuk menjumlahkan angka
        Parallel.Invoke(localAction, localAction, localAction);

        // Menampilkan hasil penjumlahan dari beberapa thread
        Console.WriteLine("Jumlah dari beberapa thread = {0}", MultiThreadSum);
        Console.ReadLine();
    }
}
