using System;
using System.Collections.Generic;

namespace EstructuraDatosCompleta
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== PARTE 1: GRAFOS ===");

            int numNodos = 5;
            Grafo grafo = new Grafo(numNodos);
            grafo.AgregarArista(0, 1);
            grafo.AgregarArista(0, 4);
            grafo.AgregarArista(1, 2);
            grafo.AgregarArista(1, 3);
            grafo.AgregarArista(1, 4);
            grafo.AgregarArista(2, 3);
            grafo.AgregarArista(3, 4);
            Console.WriteLine("Representación del Grafo:");
            grafo.ImprimirGrafo();
            Console.WriteLine("\n-----------------------------------\n");


            Console.WriteLine("=== PARTE 2: ÁRBOL BINARIO ===");

            ArbolBinario arbol = new ArbolBinario();
            int[] valores = { 50, 30, 70, 20, 40, 60, 80 };

            foreach (int valor in valores)
            {
                arbol.Insertar(valor);
            }
            Console.WriteLine("Árbol original:");
            arbol.Imprimir();
            Console.WriteLine();
            int valorBuscar = 40;
            if (arbol.Buscar(valorBuscar) != null)
            {
                Console.WriteLine($"\n{valorBuscar} encontrado en el árbol.");
            }
            else
            {
                Console.WriteLine($"\n{valorBuscar} no encontrado en el árbol.");
            }
            int valorEliminar = 30;
            arbol.Eliminar(valorEliminar);
            Console.WriteLine($"\nÁrbol después de eliminar {valorEliminar}:");
            arbol.Imprimir();

            Console.WriteLine("\n\nPresiona Enter para finalizar...");
            Console.ReadLine();
        }
    }
    class Grafo
    {
        private int numNodos;
        private Dictionary<int, List<int>> listaAdyacencia;

        public Grafo(int numNodos)
        {
            this.numNodos = numNodos;
            listaAdyacencia = new Dictionary<int, List<int>>();
            for (int i = 0; i < numNodos; i++)
            {
                listaAdyacencia.Add(i, new List<int>());
            }
        }
        public void AgregarArista(int nodoOrigen, int nodoDestino)
        {
            listaAdyacencia[nodoOrigen].Add(nodoDestino);
            listaAdyacencia[nodoDestino].Add(nodoOrigen);
        }
        public void ImprimirGrafo()
        {
            foreach (var nodo in listaAdyacencia)
            {
                Console.Write($"Nodo {nodo.Key}: ");
                foreach (var vecino in nodo.Value)
                {
                    Console.Write($"{vecino} ");
                }
                Console.WriteLine();
            }
        }
    }
    class Nodo
    {
        public int Valor;
        public Nodo Izquierda, Derecha;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierda = Derecha = null;
        }
    }
    class ArbolBinario
    {
        private Nodo raiz;
        public void Insertar(int valor)
        {
            raiz = InsertarRec(raiz, valor);
        }
        private Nodo InsertarRec(Nodo raiz, int valor)
        {
            if (raiz == null)
            {
                return new Nodo(valor);
            }
            if (valor < raiz.Valor)
            {
                raiz.Izquierda = InsertarRec(raiz.Izquierda, valor);
            }
            else if (valor > raiz.Valor)
            {
                raiz.Derecha = InsertarRec(raiz.Derecha, valor);
            }
            return raiz;
        }
        public Nodo Buscar(int valor)
        {
            return BuscarRec(raiz, valor);
        }
        private Nodo BuscarRec(Nodo raiz, int valor)
        {
            if (raiz == null || raiz.Valor == valor)
            {
                return raiz;
            }
            if (valor < raiz.Valor)
            {
                return BuscarRec(raiz.Izquierda, valor);
            }
            return BuscarRec(raiz.Derecha, valor);
        }
        public void Eliminar(int valor)
        {
            raiz = EliminarRec(raiz, valor);
        }
        private Nodo EliminarRec(Nodo raiz, int valor)
        {
            if (raiz == null) return raiz;

            if (valor < raiz.Valor)
            {
                raiz.Izquierda = EliminarRec(raiz.Izquierda, valor);
            }
            else if (valor > raiz.Valor)
            {
                raiz.Derecha = EliminarRec(raiz.Derecha, valor);
            }
            else
            {
                if (raiz.Izquierda == null) return raiz.Derecha;
                if (raiz.Derecha == null) return raiz.Izquierda;
                raiz.Valor = MinValor(raiz.Derecha);
                raiz.Derecha = EliminarRec(raiz.Derecha, raiz.Valor);
            }
            return raiz;
        }
        private int MinValor(Nodo raiz)
        {
            int minv = raiz.Valor;
            while (raiz.Izquierda != null)
            {
                minv = raiz.Izquierda.Valor;
                raiz = raiz.Izquierda;
            }
            return minv;
        }
        public void Imprimir()
        {
            ImprimirRec(raiz);
        }
        private void ImprimirRec(Nodo raiz)
        {
            if (raiz != null)
            {
                ImprimirRec(raiz.Izquierda);
                Console.Write(raiz.Valor + " ");
                ImprimirRec(raiz.Derecha);
            }
        }
    }
}