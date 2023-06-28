using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2Poo
{
    public class Mineradora
    {
        List<Motorista> Motoristas = new List<Motorista>();
        List<Caminhao> Caminhoes = new List<Caminhao>();
        List<Mina> Minas = new List<Mina>();

        void CadastrarMotorista()
        {
            Motorista motorista = new Motorista();
            Console.WriteLine("Digite o nome do motorista");
            motorista.Nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf do motorista");
            motorista.Cpf = Console.ReadLine();
            Motoristas.Add(motorista);
        }

        void CadastrarCaminhao()
        {
            Caminhao caminhao = new Caminhao();
            Console.WriteLine("Digite a placa do caminhao");
            caminhao.Placa = Console.ReadLine();
            Console.WriteLine("Digite o modelo do caminhao");
            caminhao.ModeloCaminhao = Console.ReadLine();
            Console.WriteLine("Digite o CPF do motorista que conduzirá o caminhão");
            var cpfMotorista = Console.ReadLine();
            var condutor = Motoristas.Find(e => e.Cpf == cpfMotorista);
            if(condutor == null)
            {
                Console.WriteLine("Não foi encontrado motorista com esse cpf, tente novamente");
            }
            else
            {
                caminhao.Motorista = condutor;
                Caminhoes.Add(caminhao);
            }
        }

        void CadastrarMina()
        {
            Mina mina = new Mina();
            Console.WriteLine("Digite a área da mina em metros quadrados e sem casas decimais");
            mina.Area = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da mina");
            mina.Descricao = Console.ReadLine();

   

            Minas.Add(mina); 

        }

        void CadastrarCaminhaoMina(Mina mina)
        {
            foreach (var caminhao in Caminhoes)
            {
                Console.WriteLine($"O caminhão da placa {caminhao.Placa} irá trabalhar na mina?\n");
                Console.WriteLine("1-sim\n2-nao");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                {
                    mina.ListaCaminhao.Add(caminhao);
                }
            }
        }

        void ListarCaminhaoMina(Mina mina)
        {
            foreach (var caminhao in mina.ListaCaminhao)
            {
                Console.WriteLine($"Placa: {caminhao.Placa} Motorista: {caminhao.Motorista}\n");
            }
        }

        Mina SelecionarMina()
        {
            for (int i = 0; i > Minas.Count; i++)
            {
                Console.WriteLine($"{i}- {Minas[i].Descricao}");
            }
            Console.WriteLine("Digite o numero referente a mina que deseja selecionar");
            int selecao = int.Parse(Console.ReadLine());
           
            return Minas[selecao];

        }

        public void Menu() {
            int option;

            do
            {
                Console.WriteLine("Selecione a ação que deseja fazer");
                Console.WriteLine("1 - cadastrar motorista");
                Console.WriteLine("2 - cadastrar caminhao");
                Console.WriteLine("3 - cadastrar mina");
                Console.WriteLine("4 - cadastrar caminhoes que vao trabalhar na mina");
                Console.WriteLine("5 - Listar caminhoes da mina");
                Console.WriteLine("6 - Sair");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CadastrarMotorista();
                        break;
                    case 2:
                        CadastrarCaminhao();
                        break;
                    case 3:
                        CadastrarMina();
                        break;
                    case 4:
                        var mina = SelecionarMina();
                        CadastrarCaminhaoMina(mina);
                        break;
                    case 5:
                        var mina2 = SelecionarMina();
                        ListarCaminhaoMina(mina2);
                        break;
                    case 6:
                        break;

                    default:
                        Console.WriteLine("Opcao invalida");
                        break;


                }
            } while (option != 6);


        }
        

    }
}
