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
                if(serie.getExcluir())
                    Console.WriteLine("#ID {0}: - X {1}", serie.getId(), serie.getTitulo());
                else    
                    Console.WriteLine("#ID {0}: - {1}", serie.getId(), serie.getTitulo());
            }
        }

        private static Serie novaSerie(int indRepo)
        {
            foreach(int ge in Enum.GetValues(typeof(Genero)))
                Console.WriteLine("{0} - {1}", ge, Enum.GetName(typeof(Genero), ge));
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int genero    = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o Ano da Série: ");
            int anoEnt    = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a descrição da Série: ");
            string desc = Console.ReadLine();

            Serie nv = new Serie(
                id        : indRepo,
                genero    : (Genero)genero,
                titulo    : titulo,
                ano       : anoEnt,
                descricao : desc
            );

            return nv;
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova Série");

            repository.Insere(novaSerie(repository.ProximoId()));
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indRepo   = int.Parse(Console.ReadLine());

            repository.Atualiza(indRepo, novaSerie(indRepo));
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indRepo   = int.Parse(Console.ReadLine());
            string re;
            do{
                Console.Write("Deseja mesmo excluir essa série? ");
                re = Console.ReadLine().ToUpper();
            }while(re != "N" || re != "NÂO" || re != "NAO" || re != "S" || re != "SIM");

            if(re == "N" || re == "NÂO" || re == "NAO")
            {
                Console.WriteLine("Exclusão cancelada!");
                return;
            }
            repository.Excluir(indRepo);
        }

        private static void VisualizarSerie()
        {
            if(repository.Lista().Count > 0)
            {
                int indRepo;
                do{
                    Console.Write("Digite o id da série: ");
                    indRepo = int.Parse(Console.ReadLine());
                }while(indRepo < 0 || indRepo > repository.Lista().Count);

                var serie   = repository.RetornaPorId(indRepo);

                Console.WriteLine(serie);
            }
            else
            {
                Console.Write("Nenhuma série cadastrada!");
            }
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
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
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
