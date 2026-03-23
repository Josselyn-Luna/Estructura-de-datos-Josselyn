using System;

namespace SEMANA14
{
    // 1. CLASE NODO: La unidad básica del árbol
    public class Nodo
    {
        public int Valor;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // 2. CLASE BST: Contiene toda la lógica de gestión
    public class ArbolBinario
    {
        public Nodo Raiz;

        public ArbolBinario() { Raiz = null; }

        // INSERTAR: Para qué sirve? Para colocar un dato en su lugar correcto (menores izq, mayores der).
        public void Insertar(int valor) => Raiz = InsertarRecursivo(Raiz, valor);

        private Nodo InsertarRecursivo(Nodo actual, int valor)
        {
            if (actual == null) return new Nodo(valor);
            if (valor < actual.Valor) actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, valor);
            else if (valor > actual.Valor) actual.Derecho = InsertarRecursivo(actual.Derecho, valor);
            return actual;
        }

        // BUSCAR: Recorre el árbol comparando valores.
        public bool Buscar(Nodo actual, int valor)
        {
            if (actual == null) return false;
            if (actual.Valor == valor) return true;
            return valor < actual.Valor ? Buscar(actual.Izquierdo, valor) : Buscar(actual.Derecho, valor);
        }

        // RECORRIDOS: Formas de visitar los nodos
        public void Inorden(Nodo actual) // Izquierda -> Raíz -> Derecha (Muestra de menor a mayor)
        {
            if (actual == null) return;
            Inorden(actual.Izquierdo);
            Console.Write(actual.Valor + " ");
            Inorden(actual.Derecho);
        }

        public void Preorden(Nodo actual) // Raíz -> Izquierda -> Derecha
        {
            if (actual == null) return;
            Console.Write(actual.Valor + " ");
            Preorden(actual.Izquierdo);
            Preorden(actual.Derecho);
        }

        public void Postorden(Nodo actual) // Izquierda -> Derecha -> Raíz
        {
            if (actual == null) return;
            Postorden(actual.Izquierdo);
            Postorden(actual.Derecho);
            Console.Write(actual.Valor + " ");
        }

        // ESTADÍSTICAS: Altura y valores extremos
        public int ObtenerAltura(Nodo actual)
        {
            if (actual == null) return 0;
            return 1 + Math.Max(ObtenerAltura(actual.Izquierdo), ObtenerAltura(actual.Derecho));
        }

        public int ObtenerMaximo(Nodo actual) => actual.Derecho == null ? actual.Valor : ObtenerMaximo(actual.Derecho);
        public int ObtenerMinimo(Nodo actual) => actual.Izquierdo == null ? actual.Valor : ObtenerMinimo(actual.Izquierdo);
    }

    // 3. CLASE PRINCIPAL: El Menú
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();
            int opcion = 0;

            while (opcion != 8)
            {
                Console.WriteLine("\n--- SISTEMA DE GESTIÓN BST (SEMANA 14) ---");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Mostrar Recorridos (Pre, In, Post)");
                Console.WriteLine("4. Mostrar Altura");
                Console.WriteLine("5. Mostrar Mínimo y Máximo");
                Console.WriteLine("6. Limpiar Árbol");
                Console.WriteLine("7. Eliminar valor (Próximamente)");
                Console.WriteLine("8. Salir");
                Console.Write("Elija una opción: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor numérico: ");
                        arbol.Insertar(int.Parse(Console.ReadLine()));
                        break;
                    case 2:
                        Console.Write("Valor a buscar: ");
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine(arbol.Buscar(arbol.Raiz, b) ? "¡Encontrado!" : "No existe.");
                        break;
                    case 3:
                        Console.Write("\nInorden: "); arbol.Inorden(arbol.Raiz);
                        Console.Write("\nPreorden: "); arbol.Preorden(arbol.Raiz);
                        Console.Write("\nPostorden: "); arbol.Postorden(arbol.Raiz);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Altura del árbol: " + arbol.ObtenerAltura(arbol.Raiz));
                        break;
                    case 5:
                        if (arbol.Raiz != null) {
                            Console.WriteLine("Mínimo: " + arbol.ObtenerMinimo(arbol.Raiz));
                            Console.WriteLine("Máximo: " + arbol.ObtenerMaximo(arbol.Raiz));
                        } else Console.WriteLine("Árbol vacío.");
                        break;
                    case 6:
                        arbol.Raiz = null;
                        Console.WriteLine("Árbol limpiado.");
                        break;
                }
            }
        }
    }
}

