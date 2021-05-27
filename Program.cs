using System;

namespace Proyecto2
{
    class Program
    {
        ListaPlacas[] tabla;
        int size = 13;

        public int Hash(int k)
        {
            return k % size;
        }

        public void ImprimirTabla()
        {
            for(int i = 0; i < size; i++)
            {
                Console.Write("[ " + i + " ]: ");
                if (tabla[i] != null)
                {
                    tabla[i].Imprimir();
                }
                else
                {
                    Console.Write("vacío");
                }
                Console.WriteLine();
            }
        }

        public void PorcentajeTabla()
        {
            int total = 0;
            for (int i = 0; i < size; i++)
            {
                if (tabla[i] != null)
                {
                    total += 1;
                }
            }
            double porcentaje = (total * 100) / size;
            Console.WriteLine("Porcentaje de uso: " + Math.Truncate(porcentaje) + "%");
        }

        public int TransformarPlaca(string pl)
        {
            int total = 0;
            for(int i = 0; i < pl.Length; i++)
            {
                total += pl[i];
            }
            return total;
        }

        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.tabla = new ListaPlacas[pg.size];

            int op = 0;
            string linea;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Ingreso de Placa.");
                Console.WriteLine("2. Consulta de Placa.");
                Console.WriteLine("3. Porcentaje de uso de tabla Hash.");
                Console.WriteLine("4. Mostrar tabla Hash.");
                Console.WriteLine("5. Salir.");
                Console.WriteLine();

                Console.WriteLine("Ingrese su opción:");
                linea = Console.ReadLine();
                op = int.Parse(linea);

                Console.WriteLine();

                if (op == 1)
                {
                    Console.WriteLine("Ingrese placa:");
                    string pl = Console.ReadLine();
                    Console.WriteLine("Ingrese marca de vehículo:");
                    string mc = Console.ReadLine();
                    int hash = pg.Hash(pg.TransformarPlaca(pl));

                    Console.WriteLine();
                    bool encontrado = false;
                    if (pg.tabla[hash] != null)
                    {
                        Nodo nd = pg.tabla[hash].BuscarPlaca(pl);
                        if(nd != null)
                        {
                            encontrado = true;
                        }
                    }
                    if(!encontrado)
                    {
                        if(pg.tabla[hash] == null)
                        {
                            pg.tabla[hash] = new ListaPlacas();
                        }
                        pg.tabla[hash].Insertar(pl, mc);
                        Console.WriteLine("Placa ingresada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("ERROR. Esta placa ya ha sido ingresada.");
                    }
                }
                else if (op == 2)
                {
                    Console.WriteLine("Ingrese placa a buscar:");
                    string pl = Console.ReadLine();
                    int hash = pg.Hash(pg.TransformarPlaca(pl));

                    Console.WriteLine();
                    bool encontrado = false;
                    if (pg.tabla[hash] != null)
                    {
                        Nodo nd = pg.tabla[hash].BuscarPlaca(pl);
                        if (nd != null)
                        {
                            Console.WriteLine("Placa encontrada: " + nd.placa);
                            Console.WriteLine("Marca: " + nd.marca);
                            encontrado = true;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("ERROR. Esta placa no ha sido ingresada.");
                    }
                }
                else if (op == 3)
                {
                    pg.PorcentajeTabla();
                }
                else if (op == 4)
                {
                    pg.ImprimirTabla();
                }
                else
                {
                    Console.WriteLine("Desea salir o la opción no es válida");
                }
                Console.ReadKey();

            } while (op != 5);
        }
    }
}
