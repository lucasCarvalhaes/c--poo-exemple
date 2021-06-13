using System;

namespace poo_exemple
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = getUserOption();


            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1": ListSeries(); break;
                    case "2": AddSerie(); break;
                    case "3": UpdateSerie(); break;
                    case "4": DeleteSerie(); break;
                    case "5": getSerie(); break;
                    case "C": Console.Clear(); break;
                    default: throw new ArgumentOutOfRangeException();
                }

                userOption = getUserOption();
            }
        }

        private static void getSerie()
        {
            Console.WriteLine("Inform a serie's id: ");
            int index = int.Parse(Console.ReadLine());

            var serie = repository.getById(index);

            Console.WriteLine(serie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Inform the id to delete: ");
            int index = int.Parse(Console.ReadLine());
            repository.delete(index);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Indicate the id to update: ");
            int index = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Types)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Types), i));
            }
            Console.WriteLine("Choose the type among the options above");
            int type = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Choose the genre among the options above: ");
            int gen = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose the series' title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Tell the year: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Give a description: ");
            string desc = Console.ReadLine();

            Serie upDatedSerie = new Serie(id: index, type: type, genero: (Genero)gen, titulo: title, descricao: desc, ano: year);
            repository.update(index, upDatedSerie);
        }

        private static void AddSerie()
        {
            Console.WriteLine("Add new serie");

            foreach (int i in Enum.GetValues(typeof(Types)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Types), i));
            }
            Console.WriteLine("Choose the type among the options above");
            int type = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Choose the genre among the options above: ");
            int gen = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose the series' title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Tell the year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Give a description: ");
            string desc = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.nextId(), type: type, genero: (Genero)gen, titulo: title, descricao: desc, ano: year);
            repository.save(newSerie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("List of Series");

            var list = repository.List();
            if (list.Count == 0)
            {
                Console.WriteLine("There is nothing here...");
                return;
            }

            foreach (var serie in list)
            {
                bool removed = serie.getRemoved();
                if (!removed)
                {
                    Console.WriteLine($"{Enum.GetName(typeof(Types), serie.getType())} - #ID {serie.getId()}: - {serie.getTitulo()}");
                }
            }
        }

        private static string getUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Informe as opcção desejada!!!");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
