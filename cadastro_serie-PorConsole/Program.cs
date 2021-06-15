using System;
using DIO.series.Classes;
using DIO.series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {   
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarSerie();
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
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado pro escolher nossos serviços!!");
            Console.ReadLine();
        }
        private static void ListarSerie()
        {
            Console.WriteLine("Listar series: ");

            var lista = repositorio.Lista();

            if(lista.Count < 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }
            foreach(var serie in lista){
                var excluido = serie.retornoExcluido();

                Console.WriteLine("#ID{0}: {1} - {2}",serie.retornoId(),serie.retornoTitulo(), (excluido ? "Excluido" : ""));
            }
            Console.ReadLine();
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Serie");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de Inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie: ");
            string entradaDescricao= Console.ReadLine();

            Serie novaSerie = new Serie(
                id:repositorio.ProximoId(),
                genero:(Genero)entradaGenero,
                titulo:entradaTitulo,
                ano:entradaAno,
                descricao: entradaDescricao
            );
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie que irá alterar: ");
            int indiceSerie = int.Parse(Console.ReadLine());

             foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de Inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie: ");
            string entradaDescricao= Console.ReadLine();

            Serie atualizarSerie = new Serie(
                id:indiceSerie,
                genero:(Genero)entradaGenero,
                titulo:entradaTitulo,
                ano:entradaAno,
                descricao: entradaDescricao
            );
            repositorio.Atualiza(indiceSerie,atualizarSerie);
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
            Console.Write("Excluido!");
            Console.ReadLine();
        }
         private static void VisualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorID(indiceSerie);
            Console.WriteLine(serie);
            Console.ReadLine();
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Menu de series");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar a Serie");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
