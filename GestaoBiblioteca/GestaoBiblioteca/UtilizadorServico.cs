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
                Console.WriteLine("[2] Consultar Livros Disponiveis");
                Console.WriteLine("[3] Devolver Livros");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.WriteLine("Escolha a opção que prentende: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RegistarNovoUtilizador(bibliotecaSistema);
                        break;
                    case 2:
                        ListarLivros(bibliotecaSistema, true);
                        break;
                    case 3:
                        RegistarDevolucao(bibliotecaSistema);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
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
   