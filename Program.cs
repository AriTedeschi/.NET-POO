using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir uma nova série");
            Console.WriteLine("3- Alterar uma série");
            Console.WriteLine("4- Excluir uma série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opt = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opt;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repository.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.getId(), serie.getTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova Série");

            var lista = repository.Lista();

            foreach(int ge in Enum.GetValues(typeof(Genero)))
                Console.WriteLine("{0} - {1}", ge, Enum.GetName(typeof(Genero), ge));
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int genero    = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o Ano da Série: ");
            int ano       = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a descrição da Série: ");
            string desc = Console.ReadLine();

            Serie nv = new Serie(
                id        : repository.ProximoId(),
                genero    : (Genero)genero,
                titulo    : titulo,
                ano       : ano,
                descricao : desc
            );

            repository.Insere(nv);
        }
        
        static void Main(string[] args)
        {
            string opt = ObterOpcaoUsuario();

            while(opt.ToUpper() != "X")
            {
                switch(opt)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    /*case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;*/
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opt = ObterOpcaoUsuario();
            }
        }
    }
}
