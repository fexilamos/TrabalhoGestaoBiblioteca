using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    class BibliotecaSistema
    {
        private List<Livro> livros;
        private List<Utilizador> utilizadores;
        private List<Emprestimo> emprestimos;
        private int maximoEmprestimosPorUtilizador = 3; // Definido como constante, mas pode ser alterado se necessário

        public BibliotecaSistema()
    {
        livros = new List<Livro>();
        utilizadores = new List<Utilizador>();
        emprestimos = new List<Emprestimo>();
    }
    public void AdicionarLivro(string titulo, string autor, int ano, int exemplares)
    {
        Livro livro = new Livro(titulo, autor, ano, exemplares);
        livros.Add(livro);
    }
    public void AdicionarUtilizador(string nome, string morada, string telefone)
    {
        Utilizador utilizador = new Utilizador(nome, morada, telefone);
        utilizadores.Add(utilizador);
    }
}
    }

