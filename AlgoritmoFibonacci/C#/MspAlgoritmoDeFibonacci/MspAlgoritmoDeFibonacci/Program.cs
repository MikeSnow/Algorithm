using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MspAlgoritmoDeFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programa principal 
            int opcion;
            //Declaramos la variable opcion del menu;
            do
            {
                //llamamos al menu , si nos devuelve un 1 entramos en el algoritmo si nos devuelve un 2 salimos
                //cualquier otro valor repite el bucle
                opcion = Menu();
                if (opcion == 1)
                {
                    AlgoritmoDeFibonacci();
                }
            } while (opcion!=2);
        }
        static int IntroducirTeclado()
        {
            //Metodo para introducir por teclado 
            String teclado = Console.ReadLine();
            int n;
            //comprobamos si es un numero si no es los damos error al usuario
            Boolean correcto = int.TryParse(teclado, out n);
            //devolvemos un -1 si no es numero
            if (!correcto)
            {
                n = -1;
                Console.WriteLine("ERROR:El valor introducido no es un numero");
            }
            return n;
        }
        static int Menu()
        {
            //Menu de la interfaz de consola
            Console.WriteLine("Pulse una Opcion");
            Console.WriteLine("1-- Introducir numero y ejecutar algoritmo");
            Console.WriteLine("2-- Salir");
            int opcion = IntroducirTeclado();
            //comprobamos si es una opcion valida , si no lo es damos error al usuario
            if (opcion>2 || opcion < 1)
            {
                Console.WriteLine("ERROR: Introduzca una opcion correcta");
                opcion = -1;
            }
            return opcion;
        }
        static void AlgoritmoDeFibonacci()
        {
            //Este codigo es el algoritmo de fibonacci , para mostrar toda la sucesion de numeros
            int n;
            Console.WriteLine("Introduzca un numero positivo");
            n=IntroducirTeclado();
            //Si el numero introducido no es positivo o es un numero damos error 
            if (n < 0)
            {
                Console.WriteLine("ERROR: Valor Introducido incorrecto");
            }
            else
            {
                /*con Stopwatch calculamos el tiempo de ejecucion del algoritmo
                El algoritmo usado , puesto que se pide la sucession es de complejidad O(N), es un bucle for 
                en el que vamos sumando el ultimo numero y el anterior exceptuando las dos excepciones que son cuando n es 0 
                que la sucession es 0 y cuando n es 1 que la succesion es 1 ,los siguientes son
                n=2 -> 1+0 = 1
                n=3 -> 1+1 = 2;
                n=4 -> 1+2 = 3;
                n=5 -> 2+3 = 5;
                n=6 -> 3+5 = 8;
                */
                Stopwatch tiempo = Stopwatch.StartNew();
                Double ant_1 = 0;
                Double ant_2 = 1;
                Double suma=0;
                for(int i=0;i<=n;i++)
                {
                    switch (i)
                    {
                        case 0 : suma = +0;
                                break;
                        case 1: suma = +1;
                            break;
                        default:
                            suma = ant_1 + ant_2;
                            ant_1 = ant_2;
                            ant_2 = suma;
                            break;
                    }
                    Console.Write("->" +suma);
                }
                //Mostramos los valores y el tiempo de ejecuccion
                Console.WriteLine();
                Console.WriteLine("TIEMPO: " + tiempo.ElapsedMilliseconds.ToString()+" Milliseconds");
            }
        }

    }
}
