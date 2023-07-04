﻿using System;

class Program
{
    static int rodadas;

    public static void Main(string[] args)
    {
        start();
    }

    public static void start()
    {
        DesenhaCabecalho(3);
        Console.WriteLine("Digite \"1\" para começar");

        int iniciar;
        iniciar = Int32.Parse(Console.ReadLine());

        while (iniciar != 1)
        {

            DesenhaCabecalho(3);
            Console.WriteLine("Opçao Invalida! Digite 1 para começar");
            iniciar = Int32.Parse(Console.ReadLine());

        }

        DefineRodadas();
    }
    public static void DesenhaCabecalho(int linhasExtras)
    {
        Console.Clear();
        Console.WriteLine("*******************************");
        Console.WriteLine("*   Pedra, Papel ou Tesoura   *");
        Console.WriteLine("*******************************");
        for (int i = 0; i < linhasExtras; i++)
        {
            Console.WriteLine("\n");

        }

    }

    public static void DefineRodadas()
    {

        DesenhaCabecalho(3);
        Console.WriteLine("quantas rodadas voce quer jogar? 3, 5, ou7?");
        rodadas = Int32.Parse(Console.ReadLine());

        while (rodadas != 3 && rodadas != 5 && rodadas != 7)
        {
            DesenhaCabecalho(3);

            Console.WriteLine("Voce digitou um valor invalido.Escolha entre os numeros 3, 5, 7:");
            rodadas = Int32.Parse(Console.ReadLine());
        }

        ControleRodadas();
    }
    public static void ControleRodadas()
    {
        int rodadaAtual = 1;
        int pontosUsuario = 0;
        int pontosComputador = 0;
        bool fimDeJogo = false;

        while (fimDeJogo != true)
        {
            DesenhaCabecalho(0);
            Console.WriteLine("           rodada" + rodadaAtual.ToString() + "/" + rodadas.ToString() + "   ");
            Console.WriteLine();
            Console.WriteLine("User; " + pontosUsuario.ToString() + " pontos | CPU:" + pontosComputador.ToString() + " pontos");


            switch (ExibeRodada())
            {
                case 0:
                    break;
                case 1:
                    pontosUsuario++;
                    rodadaAtual++;
                    if (pontosUsuario > rodadas / 2)
                    {
                        Console.WriteLine("Usuario venceu");
                        fimDeJogo = true;
                    }
                    break;
                case 2:
                    pontosComputador++;
                    rodadaAtual++;
                    if (pontosComputador > rodadas / 2)
                    {
                        Console.WriteLine("Computador venceu");
                        fimDeJogo = true;
                    }
                    break;
            }
            if (fimDeJogo == true)
            {
                DesenhaCabecalho(3);
                if (pontosUsuario > pontosComputador)
                {
                    Console.WriteLine("Parabens!!! Vc Venceu!!!");
                }
                else
                {
                    Console.WriteLine("Nao foi dessa vez");
                }
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite qualquer tecla para continuar");
                Console.ReadLine();
                start();


            }
            else
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite 1 para continuar ou 0 para sair");
                if (Int32.Parse(Console.ReadLine()) == 0)
                {
                    start();
                }

            }
            Console.ReadLine();
        }
    }
    public static int ExibeRodada()
    {
        //Algumas variáveis já estão criadas
        string escolhaDoUsuario; //armazena qual das opções o usuário escolheu
        string escolhaDoPrograma; //armazena qual da opções o computador sorteou
        string[] opcoes =  {
      "PEDRA",
      "PAPEL",
      "TESOURA"
    };
        //O Usuário deve escolher uma das opções. Lembrar de deixar claro quais são as opções

        Console.WriteLine("Escolha uma das opções: Pedra, Papel ou Tesoura?");
        escolhaDoUsuario = Console.ReadLine().ToUpper();
        while (escolhaDoUsuario != "PEDRA" && escolhaDoUsuario != "PAPEL" && escolhaDoUsuario != "TESOURA")
        {
            Console.WriteLine("Você fez uma escolha inválida. Digite novamente: Pedra, Papel ou Tesoura?");
            escolhaDoUsuario = Console.ReadLine().ToUpper();
        }
        //O Computador deve escolher uma das opções e o programa deve exibir qual foi essa escolha
        Random rand = new Random();
        int sorteio = rand.Next(opcoes.Length);
        escolhaDoPrograma = opcoes[sorteio];
        Console.WriteLine("A escolha do computador foi: " + escolhaDoPrograma);

        //O programa deve exibir quem ganhou, lembrando que Papel ganha de Pedra, Pedra ganha de Tesoura e Tesoura ganha de Papel
        if (escolhaDoUsuario == escolhaDoPrograma)
        {
            Console.WriteLine("Deu empate");
            return 0;
        }
        else if (escolhaDoUsuario == "PEDRA" && escolhaDoPrograma == "TESOURA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "TESOURA" && escolhaDoPrograma == "PAPEL")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "PAPEL" && escolhaDoPrograma == "PEDRA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else
        {
            Console.WriteLine("Que pena! Quem venceu foi o computador!");
            return 2;
        }
    }


}
