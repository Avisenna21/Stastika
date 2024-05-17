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

            // Runtime Configuration
            statistika.SetRule("Fiksi", 2); // Menetapkan aturan frekuensi untuk genre Fiksi
            statistika.SetRule("Non-Fiksi", 1); // Menetapkan aturan frekuensi untuk genre Non-Fiksi

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Lihat Statistik Penggunaan Buku");
                Console.WriteLine("2. Keluar");
                Console.Write("Pilih menu: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Dictionary<string, int> frekuensiBuku = statistika.HitungFrekuensi(genres);
                        // Menampilkan hasil statistik
                        Console.WriteLine("Statistik Penggunaan Buku:");
                        foreach (var kvp in frekuensiBuku)
                        {
                            Console.WriteLine($"Genre '{kvp.Key}': {kvp.Value} buku.");
                        }
                        break;
                    case "2":
                        exit = true;
                        Console.WriteLine("Program berakhir.");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan pilih menu yang benar.");
                        break;
                }

                Console.WriteLine(); // Tambahkan baris kosong untuk memisahkan antar menu
            }
        }
    }
}

