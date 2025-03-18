using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static Dictionary<string, List<int>> dicionarioDeRaca = new Dictionary<string, List<int>>();

    static void Main()
    {
        Console.Clear();
        Console.WriteLine("\n==============================");
        Console.WriteLine("   Welcome to LINEAGE ll   ");
        Console.WriteLine("==============================\n");
        Thread.Sleep(1500);
        ExibirOpcoesDoMenu();
    }

    static void ExibirLogo()
    {
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine("          𝐿𝐼𝑁𝐸𝐴𝐺𝐸 𝑙𝑙          ");
        Console.WriteLine("--------------------------------\n");
    }

    static void ExibirOpcoesDoMenu()
    {
        Console.Clear();
        ExibirLogo();

        Console.WriteLine(" 1 - Registrar uma raça");
        Console.WriteLine(" 2 - Mostrar todas as raças");
        Console.WriteLine(" 3 - Avaliar uma raça");
        Console.WriteLine(" 4 - Exibir a média de uma raça");
        Console.WriteLine("-1 - Sair\n");

        Console.Write("Digite sua opção: ");
        if (int.TryParse(Console.ReadLine(), out int opcaoEscolhida))
        {
            switch (opcaoEscolhida)
            {
                case 1: RegistrarRaca(); break;
                case 2: ExibirListaDeRacas(); break;
                case 3: AvaliarUmaRaca(); break;
                case 4: ExibirMedia(); break;
                case -1:
                    Console.WriteLine("\nTchau, até breve!\n");
                    return;
                default:
                    Console.WriteLine("\n❌ Opção inválida! Tente novamente.\n");
                    Thread.Sleep(1500);
                    ExibirOpcoesDoMenu();
                    break;
            }
        }
        else
        {
            Console.WriteLine("\n❌ Entrada inválida! Digite um número.\n");
            Thread.Sleep(1500);
            ExibirOpcoesDoMenu();
        }
    }

    static void RegistrarRaca()
    {
        Console.Clear();
        ExibirTitulo("Registrando uma Raça");

        Console.Write("Digite o nome da raça que deseja registrar: ");
        string nomeDaRaca = Console.ReadLine()!;

        if (!dicionarioDeRaca.ContainsKey(nomeDaRaca))
        {
            dicionarioDeRaca.Add(nomeDaRaca, new List<int>());
            Console.WriteLine($"\n✅ A raça '{nomeDaRaca}' foi registrada com sucesso!\n");
        }
        else
        {
            Console.WriteLine($"\n⚠️ A raça '{nomeDaRaca}' já existe!\n");
        }

        Thread.Sleep(2000);
        ExibirOpcoesDoMenu();
    }

    static void ExibirListaDeRacas()
    {
        Console.Clear();
        ExibirTitulo("Raças Registradas");

        if (dicionarioDeRaca.Count == 0)
        {
            Console.WriteLine("⚠️ Nenhuma raça registrada ainda.\n");
        }
        else
        {
            foreach (var raca in dicionarioDeRaca.Keys)
            {
                Console.WriteLine($" - {raca}");
            }
            Console.WriteLine();
        }

        Console.Write("Pressione qualquer tecla para voltar ao menu... ");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }

    static void ExibirTitulo(string titulo)
    {
        string linha = new string('=', titulo.Length);
        Console.WriteLine($"\n{linha}\n{titulo}\n{linha}\n");
    }

    static void AvaliarUmaRaca()
    {
        Console.Clear();
        ExibirTitulo("Avaliar uma Raça");

        if (dicionarioDeRaca.Count == 0)
        {
            Console.WriteLine("⚠️ Nenhuma raça registrada ainda.\n");
            Thread.Sleep(2000);
            ExibirOpcoesDoMenu();
            return;
        }

        Console.WriteLine("📜 Raças disponíveis para avaliação:");
        foreach (var raca in dicionarioDeRaca.Keys)
        {
            Console.WriteLine($" - {raca}");
        }
        
        Console.Write("\nDigite o nome da raça que deseja avaliar: ");
        string nomeDaRaca = Console.ReadLine()!;

        if (dicionarioDeRaca.ContainsKey(nomeDaRaca))
        {
            Console.Write($"\nQual nota a raça '{nomeDaRaca}' merece (0 a 10): ");
            if (int.TryParse(Console.ReadLine(), out int nota) && nota >= 0 && nota <= 10)
            {
                dicionarioDeRaca[nomeDaRaca].Add(nota);
                Console.WriteLine("\n✅ Nota registrada com sucesso!\n");
            }
            else
            {
                Console.WriteLine("\n❌ Nota inválida! Digite um número entre 0 e 10.\n");
            }
        }
        else
        {
            Console.WriteLine($"\n⚠️ A raça '{nomeDaRaca}' não foi encontrada.\n");
        }

        Thread.Sleep(2000);
        ExibirOpcoesDoMenu();
    }

    static void ExibirMedia()
    {
        Console.Clear();
        ExibirTitulo("Exibir Média das Raças");

        Console.Write("Digite o nome da raça que deseja ver a média: ");
        string nomeDaRaca = Console.ReadLine()!;

        if (dicionarioDeRaca.ContainsKey(nomeDaRaca))
        {
            var listaDeNotas = dicionarioDeRaca[nomeDaRaca];

            if (listaDeNotas.Count > 0)
            {
                double media = listaDeNotas.Average();
                Console.WriteLine($"\n📊 A média da raça '{nomeDaRaca}' é {media:F2}.\n");
            }
            else
            {
                Console.WriteLine($"\n⚠️ A raça '{nomeDaRaca}' ainda não recebeu avaliações.\n");
            }
        }
        else
        {
            Console.WriteLine($"\n⚠️ A raça '{nomeDaRaca}' não foi encontrada.\n");
        }

        Console.Write("Pressione qualquer tecla para voltar ao menu... ");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }
}