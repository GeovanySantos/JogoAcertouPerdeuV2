using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Geração automática do número neutro
        Random random = new Random();
        int numeroNeutro = random.Next(1, 101); // Gera um número entre 1 e 100

        Console.WriteLine("Número neutro escolhido pelo sistema. Tente adivinhar!");

        // Solicita a quantidade de jogadores
        int quantidadeJogadores;
        while (true)
        {
            Console.Write("Digite a quantidade de jogadores: ");
            if (int.TryParse(Console.ReadLine(), out quantidadeJogadores) && quantidadeJogadores > 0)
            {
                break;
            }
            Console.WriteLine("Número de jogadores inválido. Por favor, digite um número positivo.");
        }

        // Solicita os nomes dos jogadores
        List<string> nomesJogadores = new List<string>();
        for (int i = 1; i <= quantidadeJogadores; i++)
        {
            Console.Write($"Digite o nome do jogador {i}: ");
            nomesJogadores.Add(Console.ReadLine());
        }

        // Inicializa os intervalos para a busca
        int menor = 1;
        int maior = 100;

        // Jogadores tentam adivinhar o número
        bool acertou = false;
        while (!acertou)
        {
            for (int i = 0; i < quantidadeJogadores; i++)
            {
                acertou = TentarAdivinhar(nomesJogadores[i], ref menor, ref maior, numeroNeutro);
                if (acertou)
                {
                    Console.WriteLine($"Parabéns, você perdeu, {nomesJogadores[i]}!");
                    break;
                }
            }
        }
    }

    static bool TentarAdivinhar(string nomeJogador, ref int menor, ref int maior, int numeroNeutro)
    {
        Console.Write($"\n{nomeJogador}, tente adivinhar o número: ");
        int palpite;
        if (!int.TryParse(Console.ReadLine(), out palpite) || palpite < menor || palpite > maior)
        {
            Console.WriteLine($"Seu palpite deve estar entre {menor} e {maior}. Tente novamente.");
            return false;
        }

        if (palpite > numeroNeutro)
        {
            maior = palpite - 1;
            Console.WriteLine($"O número é menor que {palpite}. O número está entre {menor} e {maior}.");
        }
        else if (palpite < numeroNeutro)
        {
            menor = palpite + 1;
            Console.WriteLine($"O número é maior que {palpite}. O número está entre {menor} e {maior}.");
        }
        else
        {
            return true;
        }

        return false;
    }
}
