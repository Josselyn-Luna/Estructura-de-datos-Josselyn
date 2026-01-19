using System;

public class Nodo
{
    public int Dato { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    public Nodo Cabeza { get; set; }

    // 2. Método para Invertir una lista enlazada
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = Cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            // Guardamos el siguiente nodo
            siguiente = actual.Siguiente;
            
            // Invertimos el puntero del nodo actual
            actual.Siguiente = anterior;
            
            // Movemos los punteros una posición hacia adelante
            anterior = actual;
            actual = siguiente;
        }
        // Al final, anterior queda apuntando al que era el último nodo
        Cabeza = anterior;
    }

    // 3. Método de búsqueda (retorna número de ocurrencias)
    public int Buscar(int datoBuscado)
    {
        int contador = 0;
        Nodo actual = Cabeza;

        while (actual != null)
        {
            if (actual.Dato == datoBuscado)
            {
                contador++;
            }
            actual = actual.Siguiente;
        }

        if (contador == 0)
        {
            Console.WriteLine($"El dato {datoBuscado} no fue encontrado.");
        }
        else
        {
            Console.WriteLine($"El dato {datoBuscado} se encontró {contador} veces.");
        }

        return contador;
    }

    // Método auxiliar para agregar nodos al inicio
    public void Agregar(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        nuevo.Siguiente = Cabeza;
        Cabeza = nuevo;
    }

    // Método auxiliar para imprimir la lista
    public void Mostrar()
    {
        Nodo actual = Cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}

class Program {
    static void Main() {
        ListaEnlazada miLista = new ListaEnlazada();
        miLista.Agregar(10);
        miLista.Agregar(20);
        miLista.Agregar(10);
        miLista.Agregar(30);

        Console.WriteLine("Lista original:");
        miLista.Mostrar();

        // Prueba de búsqueda
        miLista.Buscar(10); // Debería encontrar 2
        miLista.Buscar(50); // Mensaje de no encontrado

        // Prueba de invertir
        miLista.Invertir();
        Console.WriteLine("Lista invertida:");
        miLista.Mostrar();
    }
}