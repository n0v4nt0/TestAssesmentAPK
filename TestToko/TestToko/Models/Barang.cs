using System;
using System.Collections.Generic;

namespace TestToko.Models
{
    public partial class Barang
    {
        public string IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public int HargaBarang { get; set; }
        public decimal QtyBarang { get; set; }
        public string Operator { get; set; }
    }
}