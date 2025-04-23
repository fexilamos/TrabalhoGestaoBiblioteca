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
                string input = Console.ReadLine();
                int opcao;

                if (int.TryParse(input, out opcao))
                {
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
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número da lista apresentada.");
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
            string nome;
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("[ERRO] O nome não pode estar vazio. Insira um nome válido.");
                }
            } while (string.IsNullOrWhiteSpace(nome));

            string morada;
            do
            {
                Console.Write("Morada: ");
                morada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(morada))
                {
                    Console.WriteLine("[ERRO] A morada não pode estar vazia. Insira uma morada válida.");
                }
            } while (string.IsNullOrWhiteSpace(morada));

            string telefone;
            bool telefoneValido = false;
            do
            {
                Console.Write("Telefone: ");
                telefone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(telefone))
                {
                    Console.WriteLine("[ERRO] O numero de telefone náo pode estar vazio. Insira um telefone válido.");
                    telefoneValido = false;
                }
                else if (telefone.Length != 9)
                {
                    Console.WriteLine("[ERRO] O numero de telefone deve conter 9 digitos. Insira um numero de telefone válido");
                    telefoneValido = false;
                }
                else
                {
                    if (telefone.All(char.IsDigit))
                    {
                        telefoneValido = true;
                    }
                    else
                    {
                        Console.WriteLine("[ERRO] O numero de telefone so pode conter digitos");
                        telefoneValido = false;
                    }
                }
            } while (!telefoneValido);

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
            int utilizadorID;
            bool utilizadorEncontrado = false;
            do 
            { 
            Console.Write("ID do Utilizador: ");
            string input = Console.ReadLine();
                if (int.TryParse(input, out utilizadorID))
                {
                    object utilizador = bibliotecaSistema.GetUtilizadorByID(utilizadorID);
                    if (utilizador != null) 
                    {
                        utilizadorEncontrado = true; 
                    }
                    else
                    {
                        Console.WriteLine($"Erro: Utilizador com ID {utilizadorID} não encontrado no sistema. Por favor, verifique o ID.");
                        utilizadorEncontrado = false; 
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um ID de utilizador numérico.");
                    utilizadorEncontrado = false; 
                }
                
            } while (!utilizadorEncontrado);


            Console.Write("ID do Livro: ");
            int livroID = int.Parse(Console.ReadLine());

            bool sucesso = bibliotecaSistema.RegistarDevolucao(livroID, utilizadorID);

            if (sucesso)
            {
                Console.WriteLine("Livro devolvido com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao devolver. Verifique os dados inseridos ou se o empréstimo está ativo.");
            }
        }
    }
}
