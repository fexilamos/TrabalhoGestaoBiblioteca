using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    class BibliotecaSistema
    {
        public List<Livro> Livros {  get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Utilizador> Utilizadores { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }
    }
}
