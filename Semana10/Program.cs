using System;
using System.Collections.Generic;
using System.Linq;

namespace CampanaVacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Crear el conjunto universo de 500 ciudadanos
            HashSet<string> universoCiudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                universoCiudadanos.Add($"Ciudadano {i}");
            }

            // 2. Crear conjunto de vacunados con Pfizer (75 ciudadanos)
            // Usaremos del 1 al 75
            HashSet<string> vacunadosPfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
            {
                vacunadosPfizer.Add($"Ciudadano {i}");
            }

            // 3. Crear conjunto de vacunados con AstraZeneca (75 ciudadanos)
            // Usaremos del 50 al 124 para que haya una intersección (ambas dosis)
            HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
            for (int i = 50; i <= 124; i++)
            {
                vacunadosAstraZeneca.Add($"Ciudadano {i}");
            }

            // --- OPERACIONES DE TEORÍA DE CONJUNTOS ---

            // A. Ciudadanos que NO se han vacunado (Universo - (Pfizer U AstraZeneca))
            HashSet<string> todosVacunados = new HashSet<string>(vacunadosPfizer);
            todosVacunados.UnionWith(vacunadosAstraZeneca); // Unión

            HashSet<string> noVacunados = new HashSet<string>(universoCiudadanos);
            noVacunados.ExceptWith(todosVacunados); // Diferencia

            // B. Ciudadanos que han recibido ambas dosis (Pfizer ∩ AstraZeneca)
            HashSet<string> ambasDosis = new HashSet<string>(vacunadosPfizer);
            ambasDosis.IntersectWith(vacunadosAstraZeneca); // Intersección

            // C. Ciudadanos que SOLO han recibido Pfizer (Pfizer - AstraZeneca)
            HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
            soloPfizer.ExceptWith(vacunadosAstraZeneca); // Diferencia

            // D. Ciudadanos que SOLO han recibido AstraZeneca (AstraZeneca - Pfizer)
            HashSet<string> soloAstra = new HashSet<string>(vacunadosAstraZeneca);
            soloAstra.ExceptWith(vacunadosPfizer); // Diferencia

            // --- MOSTRAR RESULTADOS ---
            MostrarResultados("1. Ciudadanos que NO se han vacunado", noVacunados);
            MostrarResultados("2. Ciudadanos que han recibido AMBAS dosis", ambasDosis);
            MostrarResultados("3. Ciudadanos que SOLO tienen Pfizer", soloPfizer);
            MostrarResultados("4. Ciudadanos que SOLO tienen AstraZeneca", soloAstra);
            
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void MostrarResultados(string titulo, HashSet<string> conjunto)
        {
            Console.WriteLine($"\n--- {titulo} ({conjunto.Count}) ---");
            // Mostramos solo los primeros 5 para no saturar la consola
            foreach (var item in conjunto.Take(5)) 
            {
                Console.WriteLine($"- {item}");
            }
            if (conjunto.Count > 5) Console.WriteLine("  ... entre otros.");
        }
    }
}