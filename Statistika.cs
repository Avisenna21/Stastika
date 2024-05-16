using System;
using System.Collections.Generic;

namespace StatistikPenggunaanBuku
{
    public class Statistika<T>
    {
        public Dictionary<T, int> HitungFrekuensi(List<T> data)
        {
            Dictionary<T, int> frekuensi = new Dictionary<T, int>();

            foreach (T item in data)
            {
                if (frekuensi.TryGetValue(item, out int count))
                {
                    frekuensi[item] = count + 1;
                }
                else
                {
                    frekuensi[item] = 1;
                }
            }

            return frekuensi;
        }
    }
}
