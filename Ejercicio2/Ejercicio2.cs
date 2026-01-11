using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Creamos la lista y almacenamos las asignaturas
        List<string> subjects = new List<string> 
        { 
            "Matemáticas", 
            "Física", 
            "Química", 
            "Historia", 
            "Lengua" 
        };

        // 2. Recorremos la lista con un bucle foreach para mostrar el mensaje
        foreach (string subject in subjects)
        {
            Console.WriteLine("Yo estudio " + subject);
        }
    }
}
