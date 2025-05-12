using System;
using System.Text.Json;

class Program {
    public static void Main() {

        /*Exercicio 1*/

        int Indice = 13, Soma = 0, K = 0;

        //Validando a soma e realizando a mesma
        while (K < Indice) {
            K++;
            Soma += K;
        }

        //Exibindo o resultado
        Console.WriteLine($"1) Valor de SOMA: {Soma}");
        Console.WriteLine($"------------------------");

        /*Exercicio 2*/

        //Lendo o número que o usuário colocar e armazenando ele
        Console.WriteLine("2) Digite um número inteiro para saber se ele pertence à sequência de Fibonacci ou não: ");
        int numero = int.Parse(Console.ReadLine());

        int a = 0, b = 1;
        bool pertence = false;

        //Realizando a formula de Fibonacci e definindo se pertence ou não à sequência
        while (b <= numero) {
            if (b == numero) {
                pertence = true;
                break;
            }
            int temp = b;
            b = a + b;
            a = temp;
        }

        //Exibindo o resultado
        Console.WriteLine($"2) O número {numero} {(pertence ? "pertence" : "não pertence")} à sequência de Fibonacci.");
        Console.WriteLine($"-----------------------------------------------------");

        /*Exercicio 3*/

        //Lendo o .JSON
        string json = File.ReadAllText("dados.json");
        //Convertendo o .JSON
        List<FaturamentoDia> dados = JsonSerializer.Deserialize<List<FaturamentoDia>>(json);

        //Filtrando os dias que houveram o faturamento
        var diasValidos = dados.Where(d => d.valor > 0).ToList();
        double menor = diasValidos.Min(d => d.valor);
        double maior = diasValidos.Max(d => d.valor);
        double media = diasValidos.Average(d => d.valor);
        int acimaMedia = diasValidos.Count(d => d.valor > media);

        //Exibindo o resultado
        Console.WriteLine("3) Faturamento:");
        Console.WriteLine($"   Menor: R$ {menor:F2}");
        Console.WriteLine($"   Maior: R$ {maior:F2}");
        Console.WriteLine($"   Dias acima da média: {acimaMedia}");
        Console.WriteLine($"----------------------------");

        /*Exercicio 4*/


    }
}

class FaturamentoDia {
    public int dia { get; set; } //Dia do mês
    public double valor { get; set; } //Valor de faturamento no dia
}