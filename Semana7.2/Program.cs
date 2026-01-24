using System;
using System.Collections.Generic;

class TorresHanoi {
    // Definimos las 3 torres como pilas globales para este ejemplo
    static Stack<int> torreA = new Stack<int>();
    static Stack<int> torreB = new Stack<int>();
    static Stack<int> torreC = new Stack<int>();

    static void Main() {
        int n = 3; // Número de discos

        // Llenamos la primera torre (discos más grandes abajo)
        for (int i = n; i >= 1; i--) torreA.Push(i);

        Console.WriteLine($"Estado inicial: Torre A tiene {n} discos.");
        ResolverHanoi(n, torreA, torreC, torreB, "A", "C", "B");
        Console.WriteLine("\n¡Problema resuelto!");
    }

    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, 
                               string nombreO, string nombreD, string nombreA) {
        if (n == 1) {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreO} a {nombreD}");
            return;
        }

        // Mover n-1 discos de origen a auxiliar
        ResolverHanoi(n - 1, origen, auxiliar, destino, nombreO, nombreA, nombreD);

        // Mover el disco restante de origen a destino
        int discoBase = origen.Pop();
        destino.Push(discoBase);
        Console.WriteLine($"Mover disco {discoBase} de {nombreO} a {nombreD}");

        // Mover los n-1 discos de auxiliar a destino
        ResolverHanoi(n - 1, auxiliar, destino, origen, nombreA, nombreD, nombreO);
    }
}
