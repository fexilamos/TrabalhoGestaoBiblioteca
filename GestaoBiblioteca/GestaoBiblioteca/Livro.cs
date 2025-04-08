using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    class Livro
    { 
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int Ano { get; set; }
        public int Exemplares {  get; set; }

    }
}
