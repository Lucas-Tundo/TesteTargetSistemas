using System;

class Program {
    static void Main() {

        //Exercicio 1
        int Indice = 13, Soma = 0, K = 0;

        while (K < Indice) {
            K++;
            Soma += K;
        }

        Console.WriteLine($"1) Valor de SOMA: {Soma}");
        Console.WriteLine($"------------------------");

        //Exercicio 2
        int numero = 21;
        int a = 0, b = 1;
        bool pertence = false;

        while (b <= numero) {
            if (b == numero) {
                pertence = true;
                break;
            }
            int temp = b;
            b = a + b;
            a = temp;
        }

        Console.WriteLine($"2) O número {numero} {(pertence ? "pertence" : "não pertence")} à sequência de Fibonacci.");
        Console.WriteLine($"-------------------------------------------------");
        
        //Exercicio 3
    }
}
