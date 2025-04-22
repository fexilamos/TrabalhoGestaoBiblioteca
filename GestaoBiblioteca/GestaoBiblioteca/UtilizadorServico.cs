using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    internal class UtilizadorServico
    {
        public void MenuUtilizador(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.WriteLine("\n--- Menu Utilizador ---");
                Console.WriteLine("[1] Registar-se como Novo Utilizador");
                Console.WriteLine("[2] Consultar Livros Disponíveis");
                Console.WriteLine("[3] Devolver Livros");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.Write("Escolha a opção que pretende: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RegistarNovoUtilizador(bibliotecaSistema);
                        break;
                    case 2:
                        ListarLivrosDisponiveis(bibliotecaSistema);
                        break;
                    case 3:
                        RegistarDevolucao(bibliotecaSistema);
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
            Console.WriteLine("\n--- Registar-se como Novo Utilizador ---");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Morada: ");
            string morada = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            bibliotecaSistema.AdicionarUtilizador(nome, morada, telefone);
            Console.WriteLine("Utilizador registado com sucesso!");
        }

        private void ListarLivrosDisponiveis(BibliotecaSistema bibliotecaSistema)
        {
            Console.WriteLine("\n--- Livros Disponíveis ---");
            var lista = bibliotecaSistema.ObterLivrosDisponiveis();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não há livros disponíveis no momento.");
            }
            else
            {
                foreach (var livro in lista)
                {
                    Console.WriteLine(livro);
                }
            }
        }

        private void RegistarDevolucao(BibliotecaSistema bibliotecaSistema)
        {
            Console.WriteLine("\n--- Devolver Livro ---");

            Console.Write("ID do Utilizador: ");
            int utilizadorID = int.Parse(Console.ReadLine());

            Console.Write("ID do Livro: ");
            int livroID = int.Parse(Console.ReadLine());

            bool sucesso = bibliotecaSistema.RegistarDevolucao(livroID, utilizadorID);

            if (sucesso)
                Console.WriteLine("Livro devolvido com sucesso!");
            else
                Console.WriteLine("Erro ao devolver. Verifique os dados inseridos ou se o empréstimo está ativo.");
        }
    }
}
