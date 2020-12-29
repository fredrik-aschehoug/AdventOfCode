using System;
using System.Collections.Generic;
using System.Text;

namespace Day7
{
    class Suitcase
    {
        public string Color { get; set; }
        public int Quantity { get; set; }
        public List<Suitcase> Children { get; set; } = new List<Suitcase>();
    }
}
