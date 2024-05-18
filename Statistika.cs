using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace StatistikPenggunaanBuku
{
    public class Statistika<T>
    {
        private Dictionary<T, int> rules = new Dictionary<T, int>();

        public void SetRule(T item, int frequency)
        {
            rules[item] = frequency;
        }

        public Dictionary<T, int> HitungFrekuensi(List<T> data)
        {
            // Precondition: data harus tidak null
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Data tidak boleh null.");
            }

            // Inisialisasi frekuensi
            Dictionary<T, int> frekuensi = new Dictionary<T, int>();

            // Hitung frekuensi
            foreach (T item in data)
            {
                if (frekuensi.TryGetValue(item, out int count))
                {
                    frekuensi[item] = count + rules.GetValueOrDefault(item, 1);
                }
                else
                {
                    frekuensi[item] = rules.GetValueOrDefault(item, 1);
                }
            }

            // Postcondition: jumlah entri dalam hasil harus sama dengan jumlah entri dalam data
            if (frekuensi.Count != data.Count)
            {
                // Jika jumlah entri dalam hasil tidak sama dengan jumlah entri dalam data, sesuaikan hasil
                foreach (T item in data)
                {
                    if (!frekuensi.ContainsKey(item))
                    {
                        frekuensi[item] = 0;
                    }
                }
            }

            return frekuensi;
        }
    }

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
                        // Precondition: genres tidak boleh null
                        Contract.Requires(genres != null);

                        // Hitung statistik
                        Dictionary<string, int> frekuensiBuku = statistika.HitungFrekuensi(genres);

                        // Postcondition: jumlah entri dalam hasil harus sama dengan jumlah entri dalam data
                        Contract.Ensures(frekuensiBuku.Count == genres.Count);

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
