//Screen Sound
using System.Runtime.InteropServices;

String menssagemDeBoasVindas = "\nWelcome to LINEAGE ll\n";
Console.WriteLine(menssagemDeBoasVindas);

// List<string> listaDaRaca = new List<string>{
//     "Orc Fighter",
//     "Elf Fighter"
// };

Dictionary<string, List<int>> dicionarioDeRaca = new Dictionary<string, List<int>>();
dicionarioDeRaca.Add("Orc Fighter", new List<int>{10, 9, 6});
dicionarioDeRaca.Add("Orc Mystic", new List<int>());

void ExibirLogo(){
    Console.WriteLine(@"𝐿𝐼𝑁𝐸𝐴𝐺𝐸 𝑙𝑙");
}

void ExibirOpcoesDoMenu(){
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um raça: ");
    Console.WriteLine("Digite 2 para mostrar uma Raça: ");
    Console.WriteLine("Digite 3 para avaliar uma raça um Raça: ");
    Console.WriteLine("Digite 4 para exibir a média de um raca: ");
    Console.WriteLine("Digite -1 para sair: ");

    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1 : RegistrarRaca();
            break;
        case 2 : ExbibirListaDeRaca();
            break;
        case 3 : AvaliarUmaRaca();
            break;
        case 4 : ExibirMedia();
            break;
        case -1 : Console.WriteLine($"Tchau até breve!");
            break;
        default: Console.WriteLine($"Opção invalida!");
            break;
    }
}

void RegistrarRaca(){
    Console.Clear();
    ExibirLogo();
    ExibirTitulo("Registrando uma raça");
    Console.Write("Digite o nome da raça que deseja resgistrar: ");
    string nomeDaRaca = Console.ReadLine()!;
    dicionarioDeRaca.Add(nomeDaRaca, new List<int>());


    Console.WriteLine($"A raça {nomeDaRaca} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExbibirListaDeRaca(){
    Console.Clear();
    ExibirLogo();
    ExibirTitulo("Exibindo todas as raças registradas");

    foreach(string raca in dicionarioDeRaca.Keys){


        Console.WriteLine($"Raça: {raca}!");
    }

    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal!");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTitulo(string titulo){
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine($"{asteriscos}\n");
}

void AvaliarUmaRaca(){
    Console.Clear();
    ExibirTitulo("Avaliar uma raça");
    Console.Write("Digite o nome da raça que deseja avaliar: ");
    string nomeDaRaca = Console.ReadLine()!;

    if(dicionarioDeRaca.ContainsKey(nomeDaRaca)){

        Console.Write($"Qual nota a raça {nomeDaRaca} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        dicionarioDeRaca[nomeDaRaca].Add(nota);
        Console.WriteLine("Nota registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    }else{

        Console.WriteLine($"A raça {nomeDaRaca} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal!");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }

}

void ExibirMedia(){
    Console.Clear();
    ExibirTitulo("Exibindo uma média!");
    Console.Write("Digite a raça que deseja ver a média: ");
    string nomeDaRaca = Console.ReadLine()!;

    if(dicionarioDeRaca.ContainsKey(nomeDaRaca)){

        double media = dicionarioDeRaca[nomeDaRaca].Average();
        Console.WriteLine($"A média da raça {nomeDaRaca} é {media:F2}!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    }else{

        Console.WriteLine($"A raça {nomeDaRaca} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal!");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();