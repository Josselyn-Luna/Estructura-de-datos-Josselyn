using System;
using System.Collections.Generic;

class ProgramaBalanceo {
    static void Main() {
        string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        
        if (EstaBalanceada(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }

    static bool EstaBalanceada(string cadena) {
        Stack<char> pila = new Stack<char>();

        foreach (char c in cadena) {
            // Si es apertura, a la pila
            if (c == '(' || c == '[' || c == '{') {
                pila.Push(c);
            } 
            // Si es cierre, verificamos coincidencia
            else if (c == ')' || c == ']' || c == '}') {
                if (pila.Count == 0) return false; // Cierre sin apertura previa

                char apertura = pila.Pop();
                if (!SonPareja(apertura, c)) return false;
            }
        }
        return pila.Count == 0; // Si queda algo, no está balanceada
    }

    static bool SonPareja(char a, char b) {
        return (a == '(' && b == ')') || 
               (a == '[' && b == ']') || 
               (a == '{' && b == '}');
    }
}

