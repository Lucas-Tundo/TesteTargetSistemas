using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

class Program {
    public static void Main() {

        /* Exercicio 1 */

        int Indice = 13, Soma = 0, K = 0;

        // Validando a soma e realizando a mesma
        while (K < Indice) {
            K++;
            Soma += K;
        }

        // Exibindo o resultado
        Console.WriteLine($"1) Valor de SOMA: {Soma}");
        Console.WriteLine($"------------------------");

        /* Exercicio 2 */

        // Lendo o número que o usuário colocar e armazenando ele
        Console.Write("Digite um número inteiro para saber se ele pertence à sequência de Fibonacci ou não: ");
        int numero = int.Parse(Console.ReadLine());

        int a = 0, b = 1;
        bool pertence = false;

        // Realizando a formula de Fibonacci e definindo se pertence ou não à sequência
        while (b <= numero) {
            if (b == numero) {
                pertence = true;
                break;
            }
            int temp = b;
            b = a + b;
            a = temp;
        }

        // Exibindo o resultado
        Console.WriteLine($"2) O número {numero} {(pertence ? "pertence" : "não pertence")} à sequência de Fibonacci.");
        Console.WriteLine($"-----------------------------------------------------");

        /* Exercicio 3 */

        // Lendo o .JSON
        string json = File.ReadAllText("dados.json");
        // Convertendo o .JSON
        List<FaturamentoDia> dados = JsonSerializer.Deserialize<List<FaturamentoDia>>(json);

        // Filtrando os dias que houveram o faturamento e ignorando finais de semana e feriados
        var diasValidos = dados.Where(d => d.valor > 0).ToList();
        double menor = diasValidos.Min(d => d.valor);
        double maior = diasValidos.Max(d => d.valor);
        double media = diasValidos.Average(d => d.valor);
        int acimaMedia = diasValidos.Count(d => d.valor > media);

        // Exibindo o resultado
        Console.WriteLine("3) Faturamento:");
        Console.WriteLine($"   Menor: R$ {menor:F2}");
        Console.WriteLine($"   Maior: R$ {maior:F2}");
        Console.WriteLine($"   Dias acima da média: {acimaMedia}");
        Console.WriteLine($"----------------------------");

        /* Exercicio 4 */

        // Dicionário que armazena os valores de faturamento por estado
        Dictionary<string, double> estados = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        // Somando todos os valores
        double total = estados.Values.Sum();

        Console.WriteLine("4) Percentual por estado: ");

        // Procura nos itens do dicionário
        foreach (var estado in estados) {
            double percentual = (estado.Value / total) * 100;

            // Exibindo o resultado (Com no maximo 2 casas decimais no final)
            Console.WriteLine($"   {estado.Key}: {percentual:F2}%");
        }
        Console.WriteLine("-----------------------------");

        /* Exercicio 5 */

        Console.Write("Digite uma frase: ");
        // Lendo a string que o usuário colocar e armazenando ela
        string texto = Console.ReadLine();

        bool executar = true;

        while ( executar ) {
            Console.WriteLine("Tem certeza de sua escolha de frase? ");
            Console.WriteLine("1 - Sim ");
            Console.WriteLine("2 - Não ");
            // Lendo a opção que o usuário escolheu e armazenando ela
            int op = int.Parse(Console.ReadLine());
            
            switch (op) {
                case 1:
                    // Criando um array de letras do mesmo tamanho da string original
                    char[] invertido = new char[texto.Length];

                    // Uma "for" que percorre a string original de trás para frente
                    for (int i = 0; i < texto.Length; i++) {
                        // Colocando cada letra correspondente no array invertido
                        invertido[i] = texto[texto.Length - 1 - i];
                    }

                    // Convertendo o array de letras, invertidendo de volta para uma string
                    string resultado = new string(invertido);

                    // Exibindo o resultado
                    Console.WriteLine($"5) String invertida: {resultado}");
                    Console.WriteLine("---------------------------------------");
                    executar = false;
                    break;
                case 2:
                    Console.Write("Digite outra frase: ");
                    // Lendo a string que o usuário colocar e armazenando ela
                    string texto2 = Console.ReadLine();

                    // Criando um array de letras do mesmo tamanho da string original
                    char[] invertido2 = new char[texto2.Length];

                    // Uma "for" que percorre a string original de trás para frente
                    for (int i = 0; i < texto2.Length; i++) {
                        // Colocando cada letra correspondente no array invertido
                        invertido2[i] = texto2[texto2.Length - 1 - i];
                    }

                    // Convertendo o array de letras, invertidendo de volta para uma string
                    string resultado2 = new string(invertido2);

                    // Exibindo o resultado
                    Console.WriteLine($"5) String invertida: {resultado2}");
                    Console.WriteLine("---------------------------------------");
                    executar = false;
                    break;
                default:
                    Console.WriteLine("Por favor escolha uma opção valida");
                    break;
            }
        }
    }
}

class FaturamentoDia {
    public int dia { get; set; } //Dia do mês
    public double valor { get; set; } //Valor de faturamento no dia
}