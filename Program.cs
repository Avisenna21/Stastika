using System;
using System.Collections.Generic;

namespace StatistikPenggunaanBuku
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data buku
            var genres = new List<string>
            {
                "Fiksi", "Fiksi", "Fiksi", "Fiksi", "Fiksi",
                "Non-Fiksi", "Non-Fiksi", "Non-Fiksi", "Non-Fiksi", "Non-Fiksi"
            };

            // Analisis data peminjaman
            Statistika<string> statistika = new Statistika<string>();
            Dictionary<string, int> frekuensiBuku = statistika.HitungFrekuensi(genres);

            // Menampilkan hasil statistik
            Console.WriteLine("Statistik Penggunaan Buku:");
            foreach (var kvp in frekuensiBuku)
            {
                Console.WriteLine($"Genre '{kvp.Key}': {kvp.Value} buku.");
            }
        }
    }
}
