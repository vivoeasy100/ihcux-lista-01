/*
Projeto: ihcux-lista-01

Heurísticas aplicadas:
#1 - Visibilidade do Status
#3 - Controle e Liberdade
#9 - Ajuda e Tratamento de Erros
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var produtos = new Dictionary<int, string>()
        {
            {1, "Pizza Calabresa"},
            {2, "Pizza Mussarela"},
            {3, "Hamburguer"},
            {4, "Cachorro-Quente"},
            {5, "Refrigerante"},
            {6, "Suco Natural"},
            {7, "Salgado"},
            {8, "Batata Frita"},
            {9, "Água"},
            {10, "Açaí"}
        };

        int codigoProduto = 0;
        int quantidade = 0;

        while (true)
        {
            // PASSO 1
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Passo 1 de 3] - Seleção do Produto\n");

                Console.WriteLine("📋 Cardápio:");
                foreach (var item in produtos)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }

                Console.WriteLine("\nDigite o código do produto:");
                Console.WriteLine("Ou digite 'cancelar' para sair.");

                string input = Console.ReadLine().ToLower();

                if (input == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (!int.TryParse(input, out codigoProduto))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.ReadKey();
                    continue;
                }

                if (!produtos.ContainsKey(codigoProduto))
                {
                    Console.WriteLine($"Código {codigoProduto} não encontrado. Escolha entre 1 e 10.");
                    Console.ReadKey();
                    continue;
                }

                break;
            }

            // PASSO 2
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Passo 2 de 3] - Quantidade");
                Console.WriteLine($"Produto: {produtos[codigoProduto]}");

                Console.WriteLine("Digite a quantidade:");
                Console.WriteLine("Ou digite 'voltar' ou 'cancelar'.");

                string input = Console.ReadLine().ToLower();

                if (input == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (input == "voltar")
                {
                    break;
                }

                if (!int.TryParse(input, out quantidade))
                {
                    Console.WriteLine("Digite um número válido.");
                    Console.ReadKey();
                    continue;
                }

                if (quantidade <= 0)
                {
                    Console.WriteLine("Quantidade deve ser maior que zero.");
                    Console.ReadKey();
                    continue;
                }

                // PASSO 3
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("[Passo 3 de 3] - Confirmação\n");

                    Console.WriteLine($"Produto: {produtos[codigoProduto]}");
                    Console.WriteLine($"Quantidade: {quantidade}");

                    Console.WriteLine("\nConfirmar pedido? (s/n)");
                    Console.WriteLine("Ou digite 'voltar' ou 'cancelar'.");

                    string confirmacao = Console.ReadLine().ToLower();

                    if (confirmacao == "cancelar")
                    {
                        Console.WriteLine("Pedido cancelado.");
                        return;
                    }

                    if (confirmacao == "voltar")
                    {
                        break;
                    }

                    if (confirmacao == "s")
                    {
                        Console.WriteLine("Pedido realizado com sucesso! 🎉");
                        Console.ReadKey();
                        return;
                    }

                    if (confirmacao == "n")
                    {
                        break;
                    }
                }
            }
        }
    }
}