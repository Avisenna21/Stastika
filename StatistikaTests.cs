using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatistikPenggunaanBuku;
using System.Collections.Generic;

namespace StatistikPenggunaanBuku.Tests
{
    [TestClass()]
    public class StatistikaTests
    {
        [TestMethod()]
        public void HitungFrekuensiTest()
        {
            // Arrange
            var statistika = new Statistika<string>();
            var data = new List<string> { "A", "B", "A", "C", "B", "A", "D", "D" };
            var expected = new Dictionary<string, int>
            {
                { "A", 3 },
                { "B", 2 },
                { "C", 1 },
                { "D", 2 }
            };

            // Act
            var result = statistika.HitungFrekuensi(data);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
