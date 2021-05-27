using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2
{
    public class Nodo
    {
        public string placa;
        public string marca;
        public Nodo sig;
    }
    public class ListaPlacas
    {
        private Nodo raiz;

        public ListaPlacas()
        {
            raiz = null;
        }

        public void Insertar(string pl, string mc)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.placa = pl;
            nuevo.marca = mc;
            if (raiz == null)
            {
                nuevo.sig = null;
                raiz = nuevo;
            }
            else
            {
                nuevo.sig = raiz;
                raiz = nuevo;
            }
        }

        public void Imprimir()
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                Console.Write(reco.placa + " -> ");
                reco = reco.sig;
            }
        }

        public Nodo BuscarPlaca(string pl)
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                if (reco.placa == pl)
                {
                    return reco;
                }
                reco = reco.sig;
            }
            return reco;
        }
    }
}
