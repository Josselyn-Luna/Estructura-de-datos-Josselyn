using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Creamos una lista para almacenar los números
        List<int> ganadores = new List<int>();

        // 2. Pedimos los 6 números de la lotería primitiva
        for (int i = 0; i < 6; i++)
        {
            Console.Write("Introduce un número ganador: ");
            
            // Leemos la entrada y la convertimos a entero
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                ganadores.Add(numero);
            }
            else
            {
                Console.WriteLine("Por favor, introduce un número válido.");
                i--; // Restamos 1 al índice para repetir este intento
            }
        }

        // 3. Ordenamos la lista de menor a mayor
        ganadores.Sort();

        // 4. Mostramos el resultado por pantalla
        Console.WriteLine("\nLos números ganadores son:");
        Console.WriteLine(string.Join(", ", ganadores));
    }
}