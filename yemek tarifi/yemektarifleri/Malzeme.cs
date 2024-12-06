using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yemektarifleri
{
    internal class Malzeme
    {
        public string Ad { get; set; }
        public string Miktar { get; set; }
        public string Birim { get; set; }

         public override string ToString()
    {
        return $"{Ad} - {Miktar} - {Birim}"; // bu şekilde görüncek
    }
    }
}
