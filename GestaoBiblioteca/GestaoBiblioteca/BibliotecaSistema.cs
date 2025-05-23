﻿using System;
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
        private int maximoEmprestimosPorUtilizador = 3;

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

        public void AdicionarFuncionario(string nome, string morada, string telefone, string cargo)
        {
            Funcionario funcionario = new Funcionario(nome, morada, telefone, cargo);
            utilizadores.Add(funcionario);
        }

        public List<Livro> ObterTodosLivros()
        {
            return livros;
        }

        public List<Livro> ObterLivrosDisponiveis()
        {
            return livros.Where(l => l.EstaDisponivel()).ToList();
        }

        public List<Utilizador> ObterUtilizadores()
        {
            return utilizadores.Where(u => u is not Funcionario).ToList();
        }

        public List<Funcionario> ObterFuncionarios()
        {
            return utilizadores.OfType<Funcionario>().ToList();
        }

        public bool FazerEmprestimo(int livroID, int utilizadorID)
        {
            Livro livro = livros.FirstOrDefault(l => l.ID == livroID);
            Utilizador utilizador = utilizadores.FirstOrDefault(u => u.ID == utilizadorID);

            if (livro == null || utilizador == null || !livro.EstaDisponivel())
                return false;

            int emprestimosAtivos = emprestimos
                .Count(e => e.UtilizadorID == utilizadorID && e.Estado == EstadoEmprestimo.Ativo);

            if (emprestimosAtivos >= maximoEmprestimosPorUtilizador)
                return false;

            Emprestimo novo = new Emprestimo(livroID, utilizadorID);
            emprestimos.Add(novo);
            livro.DecrementarDisponiveis();
            return true;
        }

        public bool RegistarDevolucao(int livroID, int utilizadorID)
        {
            var emprestimo = emprestimos.FirstOrDefault(e =>
                e.LivroID == livroID &&
                e.UtilizadorID == utilizadorID &&
                e.Estado == EstadoEmprestimo.Ativo);

            if (emprestimo == null)
                return false;

            emprestimo.Estado = EstadoEmprestimo.Devolvido;

            Livro livro = livros.FirstOrDefault(l => l.ID == livroID);
            if (livro != null)
                livro.IncrementarDisponiveis();

            return true;
        }

        public List<Emprestimo> ObterEmprestimos(bool apenasAtivos)
        {
            if (apenasAtivos)
                return emprestimos.Where(e => e.Estado == EstadoEmprestimo.Ativo).ToList();
            else
                return emprestimos;
        }
    }
}
