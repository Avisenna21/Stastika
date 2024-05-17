using System;
using System.Collections.Generic;

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
}

