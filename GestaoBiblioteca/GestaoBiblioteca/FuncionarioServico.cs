using System;
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
                Console.WriteLine("\n--- Menu Funcionário ---");
                Console.WriteLine("[1] Registar Novo Utilizador");
                Console.WriteLine("[2] Registar Novo Funcionário");
                Console.WriteLine("[3] Listar Utilizadores");
                Console.WriteLine("[4] Listar Funcionários");
                Console.WriteLine("[5] Gestão de Livros");
                Console.WriteLine("[6] Gestão de Empréstimos");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.WriteLine("Escolha a opção que prentende: ");
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
                        Console.WriteLine("Opção inválida");
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
                        ListarLivros(bibliotecaSistema, false);// Chama o método de listar, passando 'false' para indicar que quer TODOS os livros.
                        break;
                    case 3:
                        ListarLivros(bibliotecaSistema, true);// Chama o método de listar, passando 'true' para indicar que quer APENAS os DISPONÍVEIS.
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
    }
    
}
