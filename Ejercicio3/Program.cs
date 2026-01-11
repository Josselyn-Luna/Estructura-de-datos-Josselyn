
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Definimos la lista de asignaturas
        List<string> subjects = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        
        // 2. Creamos una lista para almacenar las notas
        List<string> scores = new List<string>();

        // 3. Preguntamos la nota para cada asignatura
        foreach (string subject in subjects)
        {
            Console.Write($"¿Qué nota has sacado en {subject}? ");
            string score = Console.ReadLine();
            scores.Add(score);
        }

        Console.WriteLine("\n--- Resultados ---");

        // 4. Mostramos los mensajes finales
        for (int i = 0; i < subjects.Count; i++)
        {
            Console.WriteLine($"En {subjects[i]} has sacado {scores[i]}");
        }
    }
}