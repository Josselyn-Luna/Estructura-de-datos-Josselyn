using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creamos una lista de strings para almacenar las asignaturas
        List<string> asignaturas = new List<string> 
        { 
            "Matemáticas", 
            "Física", 
            "Química", 
            "Historia", 
            "Lengua" 
        };

        // Mostramos la lista por pantalla
        Console.WriteLine("Asignaturas del curso:");
        
        // Usamos un bucle para recorrer la lista e imprimir cada elemento
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine("- " + asignatura);
        }
    }
}