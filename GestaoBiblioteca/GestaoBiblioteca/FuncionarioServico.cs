﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestaoBiblioteca
{
    internal class FuncionarioServico
    {
        public void MenuFuncionario(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("\n--- Menu Funcionário ---");
                Console.WriteLine("[1] Registar Novo Utilizador");
                Console.WriteLine("[2] Registar Novo Funcionário");
                Console.WriteLine("[3] Listar Utilizadores");
                Console.WriteLine("[4] Listar Funcionários");
                Console.WriteLine("[5] Gestão de Livros");
                Console.WriteLine("[6] Gestão de Empréstimos");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.Write("Escolha a opção que pretende: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RegistarNovoUtilizador(bibliotecaSistema);
                        break;
                    case 2:
                        RegistarNovoFuncionario(bibliotecaSistema);
                        break;
                    case 3:
                        ListarUtilizadores(bibliotecaSistema);
                        break;
                    case 4:
                        ListarFuncionarios(bibliotecaSistema);
                        break;
                    case 5:
                        MostrarMenusLivros(bibliotecaSistema);
                        break;
                    case 6:
                        MostrarMenusEmprestimos(bibliotecaSistema);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (!voltar) PressioneParaContinuar();
            }
        }

        private void MostrarMenusLivros(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("\n--- Gestão de Livros ---");
                Console.WriteLine("1. Adicionar Novo Livro");
                Console.WriteLine("2. Listar Todos os Livros");
                Console.WriteLine("3. Listar Livros Disponíveis");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha a opção que pretende: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro(bibliotecaSistema);
                        break;
                    case 2:
                        ListarLivros(bibliotecaSistema, false);
                        break;
                    case 3:
                        ListarLivros(bibliotecaSistema, true);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (!voltar) PressioneParaContinuar();
            }
        }

        private void MostrarMenusEmprestimos(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("\n--- Gestão de Empréstimos ---");
                Console.WriteLine("1. Realizar Novo Empréstimo");
                Console.WriteLine("2. Registar Devolução");
                Console.WriteLine("3. Listar Empréstimos Ativos");
                Console.WriteLine("4. Listar Todos os Empréstimos");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha a opção que pretende: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RealizarEmprestimo(bibliotecaSistema);
                        break;
                    case 2:
                        RegistarDevolucao(bibliotecaSistema);
                        break;
                    case 3:
                        ListarEmprestimos(bibliotecaSistema, true);
                        break;
                    case 4:
                        ListarEmprestimos(bibliotecaSistema, false);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (!voltar) PressioneParaContinuar();
            }
        }

        private void PressioneParaContinuar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void RegistarNovoUtilizador(BibliotecaSistema bibliotecaSistema)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n--- Registar Novo Utilizador ---");

                // Validação do Nome
                string nome;
                do
                {
                    Console.Write("Nome: ");
                    nome = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        Console.WriteLine("O nome não pode estar vazio. Por favor, insira um nome válido.");
                    }
                } while (string.IsNullOrWhiteSpace(nome));

                // Validação da Morada
                string morada;
                do
                {
                    Console.Write("Morada: ");
                    morada = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(morada))
                    {
                        Console.WriteLine("A morada não pode estar vazia. Por favor, insira uma morada válida.");
                    }
                } while (string.IsNullOrWhiteSpace(morada));

                // Validação do Telefone
                string telefone;
                do
                {
                    Console.Write("Telefone: ");
                    telefone = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 9)
                    {
                        Console.WriteLine("O telefone deve ter pelo menos 9 caracteres. Por favor, insira um telefone válido.");
                    }
                } while (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 9);

                bibliotecaSistema.AdicionarUtilizador(nome, morada, telefone);
                Console.WriteLine("Utilizador registado com sucesso!");
                //Console.WriteLine("Vou chamar o método para gerar o ficheiro TXT...");
                var caminho = TxtHelper.GerarFichaUtilizador(nome, morada, telefone);
                Console.WriteLine("Método chamado. Caminho devolvido: " + caminho);
                Console.WriteLine("Ficha de utilizador gerada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar novo utilizador: {ex.Message}");
            }
        }

        private void RegistarNovoFuncionario(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Registar Novo Funcionário ---");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Morada: ");
            string morada = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Cargo: ");
            string cargo = Console.ReadLine();

            bibliotecaSistema.AdicionarFuncionario(nome, morada, telefone, cargo);
            Console.WriteLine("Funcionário registado com sucesso!");
        }

        private void ListarUtilizadores(BibliotecaSistema bibliotecaSistema)
        {
            Console.WriteLine("\n--- Lista de Utilizadores ---");
            var lista = bibliotecaSistema.ObterUtilizadores();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum utilizador registado.");
            }
            else
            {
                foreach (var utilizador in lista)
                {
                    Console.WriteLine(utilizador);
                }
            }
        }

        private void ListarFuncionarios(BibliotecaSistema bibliotecaSistema)
        {
            Console.WriteLine("\n--- Lista de Funcionários ---");
            var lista = bibliotecaSistema.ObterFuncionarios();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário registado.");
            }
            else
            {
                foreach (var funcionario in lista)
                {
                    Console.WriteLine(funcionario);
                }
            }
        }

        private void AdicionarLivro(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Adicionar Novo Livro ---");
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Ano de publicação: ");
            int ano = int.Parse(Console.ReadLine());
            Console.Write("Número de exemplares: ");
            int exemplares = int.Parse(Console.ReadLine());

            bibliotecaSistema.AdicionarLivro(titulo, autor, ano, exemplares);
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        private void ListarLivros(BibliotecaSistema bibliotecaSistema, bool apenasDisponiveis)
        {
            Console.Clear();

            Console.WriteLine($"\n--- {(apenasDisponiveis ? "Livros Disponíveis" : "Todos os Livros")} ---");

            var lista = apenasDisponiveis ? bibliotecaSistema.ObterLivrosDisponiveis() : bibliotecaSistema.ObterTodosLivros();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum livro encontrado.");
            }
            else
            {
                foreach (var livro in lista)
                {
                    Console.WriteLine(livro);
                }
            }
        }

        private void RealizarEmprestimo(BibliotecaSistema bibliotecaSistema)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n--- Realizar Novo Empréstimo ---");

                // Validação do ID do Utilizador
                int utilizadorID;
                do
                {
                    Console.Write("ID do Utilizador: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out utilizadorID) || utilizadorID <= 0)
                    {
                        Console.WriteLine("O ID do utilizador deve ser um número inteiro positivo. Por favor, tente novamente.");
                    }
                } while (utilizadorID <= 0);

                // Validação do ID do Livro
                int livroID;
                do
                {
                    Console.Write("ID do Livro: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out livroID) || livroID <= 0)
                    {
                        Console.WriteLine("O ID do livro deve ser um número inteiro positivo. Por favor, tente novamente.");
                    }
                } while (livroID <= 0);

                bool sucesso = bibliotecaSistema.FazerEmprestimo(livroID, utilizadorID);

                if (sucesso)
                {
                    Console.WriteLine("Empréstimo realizado com sucesso!");

                    // Buscar dados do utilizador e do livro:
                    var utilizador = bibliotecaSistema.ObterUtilizadores().FirstOrDefault(u => u.ID == utilizadorID);
                    var livro = bibliotecaSistema.ObterTodosLivros().FirstOrDefault(l => l.ID == livroID);

                    if (utilizador != null && livro != null)
                    {
                        TxtHelper.GerarReciboEmprestimo(utilizador.Nome, livro.Titulo, DateTime.Now);
                        Console.WriteLine("Recibo em TXT gerado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível gerar o recibo em TXT (dados não encontrados).");
                    }
                }
                else
                {
                    Console.WriteLine("Não foi possível realizar o empréstimo. Verifique a disponibilidade ou o limite de empréstimos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar empréstimo: {ex.Message}");
            }
        }
        private void RegistarDevolucao(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            Console.WriteLine("\n--- Registar Devolução de Livro ---");

            Console.Write("ID do Utilizador: ");
            int utilizadorID = int.Parse(Console.ReadLine());

            Console.Write("ID do Livro: ");
            int livroID = int.Parse(Console.ReadLine());

            bool sucesso = bibliotecaSistema.RegistarDevolucao(livroID, utilizadorID);

            if (sucesso)
                Console.WriteLine("Devolução registada com sucesso!");
            else
                Console.WriteLine("Não foi possível registar a devolução. Verifique os dados introduzidos.");
        }

        private void ListarEmprestimos(BibliotecaSistema bibliotecaSistema, bool apenasAtivos)
        {
            Console.Clear();

            Console.WriteLine($"\n--- {(apenasAtivos ? "Empréstimos Ativos" : "Todos os Empréstimos")} ---");

            var lista = bibliotecaSistema.ObterEmprestimos(apenasAtivos);

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo encontrado.");
            }
            else
            {
                foreach (var emprestimo in lista)
                {
                    Console.WriteLine(emprestimo);
                }
            }
        }
    }
}
