using System;
using System.Threading;

static class Program
{
    public static void Main()
    {
        Menu();//Chama o menu principal do jogo
    }
    public static void Menu()//Menu principal do jogo
    {
        while (true)//Loop infinito para manter o menu ativo
        {
            Console.WriteLine("Seja bem vindo ao jogo de advinhação");
            Console.WriteLine(" ");
            Console.WriteLine("Regras: o computador vai gerar um número aleatório, e você dará palpites até acertar o número");
            Console.WriteLine("=======================================");
            Console.WriteLine("Digite 1 - para jogar");
            Console.WriteLine("Digite 0 - para sair");

            string opcao = Console.ReadLine();//Lê a opção do usuário
            switch (opcao)//Switch para escolher a opção do menu
            {
                case "1"://Iniciar o jogo
                    Console.WriteLine("O jogo já vai começar!");
                    Thread.Sleep(3500);//Pausa de 3,5 segundos antes de iniciar o jogo
                    Jogar();
                    break;

                case "0"://Sair do jogo
                    Environment.Exit(0);
                    break;

                default://Opção inválida
                    Console.WriteLine("Função invalida");
                    break;
            }
        }
    }
    public static void Jogar()//Lógica do jogo
    {
        Console.WriteLine("escolha a dificuldade");//Escolha da dificuldade
        Console.WriteLine("--------------------");
        Console.WriteLine("1-Facil - 1-25 números");
        Console.WriteLine("2-Médio - 1-50 números");
        Console.WriteLine("3-Difícil - 1-100 números");
        var dificuldade = Console.ReadLine();//Lê a dificuldade escolhida

        Random rnd = new Random();//Gera um número aleatório    
        int numeroSecreto = 0;//Inicializa a variável do número secreto
        switch (dificuldade)//Switch para escolher a dificuldade
        {
            case "1"://Fácil
                numeroSecreto = rnd.Next(1, 26);
                break;

            case "2"://Médio
                numeroSecreto = rnd.Next(1, 51);
                break;

            case "3"://Difícil 
                numeroSecreto = rnd.Next(1, 101);
                break;

            default://Opção inválida
                Console.WriteLine("Opção inválida... Voltando ao Menu");
                Thread.Sleep(2000);
                return;//Retorna ao menu principal
        }



        Console.WriteLine("Que comecem os jogos!");

        int palpite;//Variável para armazenar o palpite do jogador
        var tentativas = 0;//Variável para contar o número de tentativas

        do//Loop para o jogo
        {
            Console.WriteLine("Digite sua aposta:");
            bool valido = int.TryParse(Console.ReadLine(), out palpite);//Lê o palpite do jogador e verifica se é válido
            if (!valido)//Se o palpite não for válido
            {
                Console.WriteLine("Digite algo válido!");
                continue;//Volta para o início do loop
            }
            tentativas++;//Incrementa o número de tentativas
            Console.WriteLine(" ");

            if (palpite < numeroSecreto)//Se o palpite for menor que o número secreto
            {
                Console.WriteLine("E...");
                Thread.Sleep(3500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Está baixo este número, meu caro jogador");
                Console.ResetColor();
            }
            else if (palpite > numeroSecreto)//Se o palpite for maior que o número secreto
            {
                Console.WriteLine("E...");
                Thread.Sleep(3500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Está alto este número, meu caro jogador");
                Console.ResetColor();
            }
            else//Se o palpite for igual ao número secreto
            {
                Console.WriteLine("E...");
                Thread.Sleep(3500);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Parabéns! Você conseguiu");
                Console.WriteLine($"Seu número de tentativas foi:{tentativas}");//Mostra o número de tentativas
                Console.ResetColor();
            }
        }
        while (palpite != numeroSecreto);//Enquanto o palpite for diferente do número secreto

        while (true)//Loop para perguntar se o jogador quer jogar novamente
        {
            Console.WriteLine(@"Deseja jogar novamente?(S/N)");
            var sn = Console.ReadLine();
            sn = sn.ToLower();


            switch (sn)//Switch para escolher a opção
            {
                case "s":
                    Jogar();
                    return;
                case "n":
                    Menu();
                    return;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }
        }
    }
}
