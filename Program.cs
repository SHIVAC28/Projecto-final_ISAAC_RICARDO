using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projecto_final_ISAAC_RICARDO
{
    internal class Program
    {
        static void Main()
        {

            //VARIBLES UTILIZADAS EN EL PROGRAMA.

            //ALMACENAR LOS DATOS EN LA MATRIZ CON UN VALOR VACIO.
            double[,] Matriz1 = null;
            double[,] Matriz2 = null;

            //VALIDAR LAS FILAS Y COLUMNAS DE LA PRIMERA MATRIZ
            int filas = 0;
            int columnas = 0;
            bool datomal_filas;
            bool datomal_columnas;

            //VALIDAR LAS FILAS Y LAS COLUMNAS DE LA SEGUNDA MATRIZ
            int filas2 = 0;
            int columnas2 = 0;
            bool datomal_filas2;
            bool datomal_columnas2;

            //ALMACENAR EL ULTIMO RESULTADO
            string ultimaOperacion = string.Empty;
            double[,] resultadoOperacion = null;

            //NOMBRE DEL ARCHIVO
            string archivoResultado = "matriz_resultado.txt";

            //ELEGIR UNA OPCION
            int opcion = 0;

            //REPETIR MIENTRAS ESTE MAL
            bool eleccion;
            bool eleccion2;

            //REPETIR TODO EL MENU
            string repetir = "N";

            //ESTE WHILE VA A REPETIR TODO EL MENU UNA VEZ QUE SE TERMINE
            while (repetir.ToUpper() != "S")
            {
                //MENU DE OPCIONES.
                Console.Clear();
                Console.WriteLine("Bienvenido a mi programa de operaciones con matrivces: \n");
                Console.WriteLine("Selecciona una opcion (Seleccione el numero de la opcion que desee): \n");
                Console.WriteLine("1.-Suma de matrices.");
                Console.WriteLine("2.- Resta de matrices.");
                Console.WriteLine("3.-Multiplicacion de matrices.");
                Console.WriteLine("4.-Mostrar los datos ingresados. ");
                Console.WriteLine("5.-Salir. ");

                //VA A REPETIR EL CODIGO DENTRO DEL DO-WHILE MIENTRAS NO SE ACEPTE EL NUMERO INGRESADO.
                do
                {
                    //EL TRY VA A INTENTAR HACER LO QUE SE ENCUENTRA DENTRO. SI NO LO LOGRA HACER EL CATCH MANDARA UN MENSAJE DE ERROR.
                    try
                    {
                        //SI SE INGRESA UN VALOR QUE NO ES UN NUMERO NO SE VALIDARA.
                        Console.WriteLine("\nIntroducir el numero deseado de la operacion que desea realizar: ");
                        opcion = int.Parse(Console.ReadLine());
                        //SI EL NUMERO SE ENCUENTRA FUERA DE LAS OPCIONES NO SE VALIDARA. 
                        if (opcion <= 0 || opcion >= 6)
                        {
                            Console.WriteLine("\n¡ERROR! El valor numerico no se encuentra dentro de las opciones. ");
                            eleccion = true;
                        }
                        //SI SE INGRESA UN VALOR ACEPTABLE EL VALOR DE ELECCION CAMBIA A FALSO, ROMPIENDO EL CICLO DE WHILE.
                        else
                        {
                            eleccion = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nDato Incorrecto");
                        Console.WriteLine(ex.ToString());
                        eleccion = true;

                    }

                }
                while (eleccion == true);

                Console.Clear();


                //SE PONE ESTE AL PRINCIPIO POR QUE SI LA OPCION SE SELECCIONA AL PRINCIPIO DE INICIAR EL PROGRAMA Y NO TIENE VALORES, APAREZCA UN MENSAJE DE ERROR.
                if (opcion == 4)
                {

                    //ESTE IF DENTRO DEL IF HACE QUE SI LA VARIABLE "ULTIMAOPERACION" TIENE UN VALOR Y QUE TAMBIEN EL RESULTADO DE LA OPERACION SEA DIFERENTE A NO TENER UN VALOR, IMPRIMA EL TITULO DE LA ULTIMA OPERACION Y LA ULTIMA OPERACION.
                    if (!string.IsNullOrEmpty(ultimaOperacion) && resultadoOperacion != null)
                    {
                        //IMPRIMIR EL TITULO DE LA ULTIMA OPERACION PARA SABER QUE ES LO QUE SE REALIZO.
                        Console.WriteLine($"\nÚltima operación realizada: {ultimaOperacion}");
                        //IMPRIMIR EL RESULTADO DE LA ULTIMA OPERCAION. 
                        ImprimirresultadodeMatriz(resultadoOperacion);
                        //MENSAJE PARA REGRESAR AL MENU
                        Console.WriteLine("Presiona cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        continue;
                    }
                    //SI NO SE CUMPLE LA CONDICION ENTONCES SE MANDARA UN MENSAJE Y REGRRESARA AL MENU.
                    else
                    {
                        Console.WriteLine("No se ha realizado ninguna operación aún.");
                        Console.WriteLine("Presiona cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        continue;
                    }
                }

                //TAMBIEN SE PONE ESTE AL PRINCIPIO POR SI SE ESCIGE ESTA OPCION YA NO PIDA LOS VALORES DE LAS MATRICES Y SE CIERRE EL PROGRAMA. 
                if (opcion == 5)
                {
                    Console.WriteLine("Muchas gracias por usar nuestro programa. Vuelva pronto!");
                    Thread.Sleep(2000);
                    Console.Beep();
                    break;
                }

                //SI SE SELECCIONA DE LA OPCION 1 A LA OPCION 3 ENTONCES VA A PEDIR LOS DATOS PARA LAS MATRICES.

                do
                {
                    //PRIMERO VA A PEDIR QUE SE DIGA EL NUMERO DE FILAS QUE TENDRA LA PRIMERA MATRIZ
                    try
                    {
                        //VA A INTENTAR PASAR EL VALOR INGRESADO A NUMERO Y SI NO SE ACEPTA LO VA A VOLVER A PEDIR. 
                        Console.WriteLine("\nEscribe el numero de filas que tendra la primera matriz: ");
                        //EL VALOR SE VA A ALMACENAR EN LA VARIABLE FILAS.
                        filas = int.Parse(Console.ReadLine());
                        //SI EL VALOR ES MENOR A CERO VA A VOLVER A PEDIR OTRO NUMERO YA QUE NO SE PUEDE TENER UN VALOR 0
                        if (filas <= 0)
                        {
                            Console.WriteLine("\n¡ERROR! El valor numerico no se puede contabilizar. ");
                            datomal_filas = true;
                        }
                        else
                        {
                            datomal_filas = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nDato Incorrecto");
                        Console.WriteLine(ex.ToString());
                        datomal_filas = true;
                    }

                }
                while (datomal_filas == true);

                //DESPUES VA A PEDIR QUE EL USUARIO INGRESE CUANTAS COLUMNAS VA A TENER LA PRIMERA MATRIZ.
                do
                {
                    try
                    {
                        //VA A INTENTAR PASAR EL VALOR INGRESADO A NUMERO Y SI NO SE ACEPTA LO VA A VOLVER A PEDIR
                        Console.WriteLine("\nEscribe el numero de columnas que tendra la primera matriz: ");
                        //EL VALOR SE VA A ALMACENAR EN LA VARIABLE COLUMNAS.
                        columnas = int.Parse(Console.ReadLine());
                        //SI EL VALOR ES MENOR A CERO VA A VOLVER A PEDIR OTRO NUMERO YA QUE NO SE PUEDE TENER UN VALOR 0
                        if (columnas <= 0)
                        {
                            Console.WriteLine("\n¡ERROR! El valor numerico no se puede contabilizar. ");
                            datomal_columnas = true;
                        }
                        else
                        {
                            datomal_columnas = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nDato Incorrecto");
                        Console.WriteLine(ex.ToString());
                        datomal_columnas = true;
                    }



                }
                while (datomal_columnas == true);

                //EL VALOR INGRESADO EN LAS VARIABLES FILAS Y COLUMNAS SE VA A MANDAR AL TAMAÑO DE LA MATRIZ UNO. 

                Matriz1 = new double[filas, columnas];



                Console.Clear();

                ////DESPUES DE LA TERMINAR CON LA PRIMERA MATRI AHORA VA A PEDIR QUE SE DIGA EL NUMERO DE FILAS QUE TENDRA LA SEGUNDA MATRIZ.

                do
                {
                    try
                    {
                        //VA A INTENTAR PASAR EL VALOR INGRESADO A NUMERO Y SI NO SE ACEPTA LO VA A VOLVER A PEDIR. 
                        Console.WriteLine("\nEscribe el numero de filas que tendra la segunda" + " matriz: ");
                        //EL VALOR SE VA A ALMACENAR EN LA VARIABLE FILAS2.
                        filas2 = int.Parse(Console.ReadLine());
                        //SI EL VALOR ES MENOR A CERO VA A VOLVER A PEDIR OTRO NUMERO YA QUE NO SE PUEDE TENER UN VALOR 0
                        if (filas2 <= 0)
                        {
                            Console.WriteLine("\n¡ERROR! El valor numerico no se puede contabilizar. ");
                            datomal_filas2 = true;
                        }
                        else
                        {
                            datomal_filas2 = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nDato Incorrecto");
                        Console.WriteLine(ex.ToString());
                        datomal_filas2 = true;
                    }

                }
                while (datomal_filas2 == true);

                //DESPUES VA A PEDIR QUE EL USUARIO INGRESE CUANTAS COLUMNAS VA A TENER LA SEGUNDA MATRIZ.
                do
                {
                    try
                    {
                        //VA A INTENTAR PASAR EL VALOR INGRESADO A NUMERO Y SI NO SE ACEPTA LO VA A VOLVER A PEDIR.
                        Console.WriteLine("\nEscribe el numero de columnas que tendra la primera matriz: ");
                        //EL VALOR SE VA A ALMACENAR EN LA VARIABLE COLUMNAS2.
                        columnas2 = int.Parse(Console.ReadLine());
                        //SI EL VALOR ES MENOR A CERO VA A VOLVER A PEDIR OTRO NUMERO YA QUE NO SE PUEDE TENER UN VALOR 0.
                        if (columnas2 <= 0)
                        {
                            Console.WriteLine("\n¡ERROR! El valor numerico no se puede contabilizar. ");
                            datomal_columnas2 = true;
                        }
                        else
                        {
                            datomal_columnas2 = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nDato Incorrecto");
                        Console.WriteLine(ex.ToString());
                        datomal_columnas2 = true;
                    }



                }
                while (datomal_columnas2 == true);

                //EL VALOR INGRESADO EN LAS VARIABLES FILAS2 Y COLUMNAS2 SE VA A MANDAR AL TAMAÑO DE LA MATRIZ DOS.
                Matriz2 = new double[filas2, columnas2];

                Console.Clear();

                //SE VA A MANDAR A LLAMAR LA FUNCION PERSONALIZADA "LLENARMATRIZ" EN LA MATRIZ UNO, PERO ASIGNANDOLE LOS ARGUMENTOS DE LAS FILAS Y COLUMNAS. Y SE ALMACENA EN LA VARIABLE MATRIZ1
                Console.WriteLine("Introduce los valores de la primera:");
                Matriz1 = llenarMatriz(filas, columnas);
                Console.Clear();

                //SE VA A MANDAR A LLAMAR LA FUNCION PERSONALIZADA "LLENARMATRIZ" EN LA MATRIZ DOS, PERO ASIGNANDOLE LOS ARGUMENTOS DE LAS FILAS2 Y COLUMNAS2. Y SE ALMACENA EN LA VARIABLE MATRIZ2 
                Console.WriteLine("Introduce los valores de la segunda matriz");
                Matriz2 = llenarMatriz(filas2, columnas2);
                Console.Clear();

                //MANDAMOS A LLAMAR LA FUNCION IMPRIMIRMATRIZ, PARA IMPRIMIR LOS DATOS INTRODUCIOS EN LA MATRIZ UNO, ASIGNANDOLE LOS ARGUMENTOS PARA QUE LA FUNCION PERSONALIZADA PUEDA TRABAJAR CORRECTAMENTE. 
                Console.WriteLine("Valores introducidos en la matriz uno:");
                ImprimirMatriz(Matriz1, filas, columnas);

                //MANDAMOS A LLAMAR LA FUNCION IMPRIMIRMATRIZ, PARA IMPRIMIR LOS DATOS INTRODUCIOS EN LA MATRIZ DOS, ASIGNANDOLE LOS ARGUMENTOS PARA QUE LA FUNCION PERSONALIZADA PUEDA TRABAJAR CORRECTAMENTE.
                Console.WriteLine("Valores introducidos en la matriz dos:");
                ImprimirMatriz(Matriz2, filas2, columnas2);

                //SE HACE UNA PAUSA PARA QUE EL USUARIO PUEDA VISUALIZAR LOS DATOS Y DESPUES CONTINUAR CON LA OPERACION. 
                Console.WriteLine("Presiona cualquier tecla para continuar con la operacion.");
                Console.ReadKey();

                //SE AGREGA UN SWITCH, PARA FACILITAR EL MANEJO DEL MENU EN LAS OPCIONES DEL UNO AL TRES.

                switch (opcion)
                {
                    case 1:
                        //EL PRIMER CASO ES LA SUMA DE MATRICES. 
                        Console.WriteLine("\nSUMA DE MATRICES");
                        //SE MANDA A LLAMAR LA FUNCION PERSONALIZADA DE SUMA Y SE LE ASIGNAS LOS ARGUMENTOS DE MATRIZ1 Y MATRIZ2 PARA QUE LA FUNCION REALICE EL CALCULO. Y LA MATRIZ QUE NOS RETORNE LA VA A ALMACENAR EN LA VARIABLE DE RESULTADO DE LA OPERACION. 
                        resultadoOperacion = Suma(Matriz1, Matriz2);
                       // SE MANDA LLAMAR LA FUNCION DE IMPRIMIRRESULTADODEMATRIZ QUE FUNCIONA IGUAL QUE DE IMPRIMIR MATRIZ PERO CON LAS FILAS Y LAS COLUMNAS NUEVAS DEL RESULTADO. 
                        ImprimirresultadodeMatriz(resultadoOperacion);
                        //SE ALMACENA EL TITULO DE LA OPERACION EN LA VARIABLE PARA QUE ESTE SE PRESENTE CUANDO SE QUIERA MOSTRAR LOS RESULTADOS EN LA OPCION 4 DEL MENU DE OPCIONES. 
                        ultimaOperacion = "Suma de matrices";
                        //DESPUES DE TERMINAR LA OPERCACION SE VA A MANDAR A LLAMAR LA FUNCION GUARDARMATRIZARCHIVO PARA QUE EL RESULTADO SE GUARDE EN UN DOCUMENTO TXT. ASIGANDOLE ARGUMENTOS. 
                        GuardarMatrizEnArchivo(resultadoOperacion, archivoResultado, ultimaOperacion);
                        //DA UN MENSAJE DE QUE YA SE GUARDO Y QUE PUEDE REGRESAR AL MENU PAR SABER QUE VA A REALIZAR AHORA. 
                        Console.WriteLine("La Matriz Resultante del Calculo Elegido fue almacenada en el archivo.");
                        Console.WriteLine("Presiona cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        break;

                    case 2:
                        //EL SEGUNDO CASO ES LA RESTA DE MATRICES.
                        Console.WriteLine("\nRESTA DE MATRICES");
                        //SE MANDA A LLAMAR LA FUNCION PERSONALIZADA DE RESTA Y SE LE ASIGNAS LOS ARGUMENTOS DE MATRIZ1 Y MATRIZ2 PARA QUE LA FUNCION REALICE EL CALCULO. Y LA MATRIZ QUE NOS RETORNE LA VA A ALMACENAR EN LA VARIABLE DE RESULTADO DE LA OPERACION. 
                        resultadoOperacion = Resta(Matriz1, Matriz2);
                        // SE MANDA LLAMAR LA FUNCION DE IMPRIMIRRESULTADODEMATRIZ QUE FUNCIONA IGUAL QUE DE IMPRIMIR MATRIZ PERO CON LAS FILAS Y LAS COLUMNAS NUEVAS DEL RESULTADO. 
                        ImprimirresultadodeMatriz(resultadoOperacion);
                        //SE ALMACENA EL TITULO DE LA OPERACION EN LA VARIABLE PARA QUE ESTE SE PRESENTE CUANDO SE QUIERA MOSTRAR LOS RESULTADOS EN LA OPCION 4 DEL MENU DE OPCIONES. 
                        ultimaOperacion = "Resta de matrices";
                        //DESPUES DE TERMINAR LA OPERCACION SE VA A MANDAR A LLAMAR LA FUNCION GUARDARMATRIZARCHIVO PARA QUE EL RESULTADO SE GUARDE EN UN DOCUMENTO TXT. ASIGANDOLE ARGUMENTOS. 
                        GuardarMatrizEnArchivo(resultadoOperacion, archivoResultado, ultimaOperacion);
                        //DA UN MENSAJE DE QUE YA SE GUARDO Y QUE PUEDE REGRESAR AL MENU PAR SABER QUE VA A REALIZAR AHORA. 
                        Console.WriteLine("La Matriz Resultante del Calculo Elegido fue almacenada en el archivo.");
                        Console.WriteLine("Presiona cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        break;

                    case 3:
                        //EN ESTE CASO SE AGREGA UN IF PARA COMPROBAR QUE LOS DATOS INTRODUCIDOS TENGAN LAS MISMAS DIMENSIONES SI NO, NO SE PODRA REALIZAR LA MULTPLICACION
                        if (filas == filas2 && columnas == columnas2)
                        {
                            //EL TERCER CASO ES LA MULTIPLICACION DE MATRICES.
                            Console.WriteLine("\nMULTIPLICACION DE MATRICES");
                            //SE MANDA A LLAMAR LA FUNCION PERSONALIZADA DE MULTPLICACION Y SE LE ASIGNAS LOS ARGUMENTOS DE MATRIZ1 Y MATRIZ2 PARA QUE LA FUNCION REALICE EL CALCULO. Y LA MATRIZ QUE NOS RETORNE LA VA A ALMACENAR EN LA VARIABLE DE RESULTADO DE LA OPERACION. 
                            resultadoOperacion = Multiplicacion(Matriz1, Matriz2);
                            // SE MANDA LLAMAR LA FUNCION DE IMPRIMIRRESULTADODEMATRIZ QUE FUNCIONA IGUAL QUE DE IMPRIMIR MATRIZ PERO CON LAS FILAS Y LAS COLUMNAS NUEVAS DEL RESULTADO. 
                            ImprimirresultadodeMatriz(resultadoOperacion);
                            //SE ALMACENA EL TITULO DE LA OPERACION EN LA VARIABLE PARA QUE ESTE SE PRESENTE CUANDO SE QUIERA MOSTRAR LOS RESULTADOS EN LA OPCION 4 DEL MENU DE OPCIONES. 
                            ultimaOperacion = "Multiplicacion de matrices";
                            //DESPUES DE TERMINAR LA OPERCACION SE VA A MANDAR A LLAMAR LA FUNCION GUARDARMATRIZARCHIVO PARA QUE EL RESULTADO SE GUARDE EN UN DOCUMENTO TXT. ASIGANDOLE ARGUMENTOS. 
                            GuardarMatrizEnArchivo(resultadoOperacion, archivoResultado, ultimaOperacion);
                            //DA UN MENSAJE DE QUE YA SE GUARDO Y QUE PUEDE REGRESAR AL MENU PAR SABER QUE VA A REALIZAR AHORA. 
                            Console.WriteLine("La Matriz Resultante del Calculo Elegido fue almacenada en el archivo.");
                            Console.WriteLine("Presiona cualquier tecla para regresar al menu.");
                            Console.ReadKey();
                        }
                        //EN CASO DE QUE NO SE PUEDA REALIZAR LA OPERACION, DIRA EL POR QUE Y LO DEVOLVERA AL MENU. 
                        else
                        {
                            Console.WriteLine("El numero de columnas de la primera matriz debe ser igual al numero de filas de la segunda matriz para multiplicarlas.");
                            Console.WriteLine("Presiona cualquier tecla para regresar al menu.");
                        }
                        Console.ReadKey();
                        break;


                }
            }

        }




        //LA PRIMERA FUNCION ES LA DE LLENAR LA MATRIZ. 
        static double[,] llenarMatriz(int fila, int columna)
        {
            //SE LE ASIGNAN LOS VALORES DE MATRIZ, DE LA FILA Y LA COLUMNA QUE SE LE ASIGNEN EN LOS ARGUMENTOS. 
            double[,] matrizllena = new double[fila, columna];
            //PRIMERO EL FOR DE LAS FILAS.
            for (int x = 0; x < matrizllena.GetLength(0); x++)//Filas
            {
                //DESPUES EL FOR DE LAS COLUMNAS.
                for (int y = 0; y < matrizllena.GetLength(1); y++)//Columnas
                {
                    //COMIENZA A PEDIR LOS VALORES DE LA FILA.
                    Console.Write($"Introduce un valor (fila{x + 1}): ");
                    matrizllena[x, y] = double.Parse(Console.ReadLine());
                }
            }
            return matrizllena;
        }

        //LA SEGUNDA FUNCION ES LA DE LA SUMA DE LAS MATRICES.
        static double[,] Suma(double[,] Mat1, double[,] Mat2)
        {
            //VA A ALMACENAR LOS VALORES DE LA OPERACION REALIZADA (NUMERO MAYOR) EN LAS FILAS DE LA MATRIZ UNO Y DOS. EN LA VARIABLE FILAS.
            int filas = Math.Max(Mat1.GetLength(0), Mat2.GetLength(0));
            //VA A ALMACENAR LOS VALORES DE LA OPERACION REALIZADA (NUMERO MAYOR) EN LAS COLUMNAS DE LA MATRIZ UNO Y DOS. EN LA VARIABLE COLUMNAS.
            int columnas = Math.Max(Mat1.GetLength(1), Mat2.GetLength(1));
            //SE CREA UNA MATRIZ Y SE LE ASIGNA EL NUMERO DE FILAS Y COLUMNAS DADAS ANTERIORMENTE. 
            double[,] MatResultante = new double[filas, columnas];

            //EL PRIMER FOR VA A SER PARA LAS FILAS
            for (int x = 0; x < filas; x++)
            {
                //EL SEGUNDO FOR VA A REALIZAR LAS COLUMNAS
                for (int y = 0; y < columnas; y++)
                {
                    //LOS VALORES SE VAN AGREGAR EN UNA VARIABLE PARA SU SUMA. EN CASO DE QUE EL SEA LA MATRIZ DE DIMENSIONES DIFERENTES LOS LUGARES VACIOS SE VAN A LLENAR CON CEROS. 
                    double valor1 = (x < Mat1.GetLength(0) && y < Mat1.GetLength(1)) ? Mat1[x, y] : 0;
                    double valor2 = (x < Mat2.GetLength(0) && y < Mat2.GetLength(1)) ? Mat2[x, y] : 0;

                    //SE LLENA LA MATRIZ CON LOS VALORES DE LA SUMA. 
                    MatResultante[x, y] = valor1 + valor2;
                }
            }

            return MatResultante;
        }

        //LA TERCERA FUNCION ES LA DE LA RESTA DE LAS MATRICES.
        static double[,] Resta(double[,] Mat1, double[,] Mat2)
        {
            //VA A ALMACENAR LOS VALORES DE LA OPERACION REALIZADA (NUMERO MAYOR) EN LAS FILAS DE LA MATRIZ UNO Y DOS. EN LA VARIABLE FILAS.
            int filas = Math.Max(Mat1.GetLength(0), Mat2.GetLength(0));
            //VA A ALMACENAR LOS VALORES DE LA OPERACION REALIZADA (NUMERO MAYOR) EN LAS COLUMNAS DE LA MATRIZ UNO Y DOS. EN LA VARIABLE COLUMNAS.
            int columnas = Math.Max(Mat1.GetLength(1), Mat2.GetLength(1));
            //SE CREA UNA MATRIZ Y SE LE ASIGNA EL NUMERO DE FILAS Y COLUMNAS DADAS ANTERIORMENTE. 
            double[,] MatResultante = new double[filas, columnas];

            //EL PRIMER FOR VA A SER PARA LAS FILAS
            for (int x = 0; x < filas; x++)
            {
                //EL SEGUNDO FOR VA A REALIZAR LAS COLUMNAS
                for (int y = 0; y < columnas; y++)
                {
                    //LOS VALORES SE VAN AGREGAR EN UNA VARIABLE PARA SU RESTA. EN CASO DE QUE EL SEA LA MATRIZ DE DIMENSIONES DIFERENTES LOS LUGARES VACIOS SE VAN A LLENAR CON CEROS. 
                    double valor1 = (x < Mat1.GetLength(0) && y < Mat1.GetLength(1)) ? Mat1[x, y] : 0;
                    double valor2 = (x < Mat2.GetLength(0) && y < Mat2.GetLength(1)) ? Mat2[x, y] : 0;

                    //SE LLENA LA MATRIZ CON LOS VALORES DE LA RESTA. 
                    MatResultante[x, y] = valor1 - valor2;
                }
            }

            return MatResultante;
        }

        //LA CUARTA FUNCION FUNCIONA PARA IMPRIMIR LAS MATRICES. 
        static void ImprimirMatriz(double[,] matrizparaimprimir, int fila, int columna)
        {
            //SE CREA UNA VARIBALE DE UNA MATRIZ Y QUE SE TRAEN DESDE EL ARGUMENTO DE LA LLAMADA DE LA FUNCION. 
            double[,] Matriz = new double[fila, columna];
            //SE IMPRIMEN EL NUMERO DE FILAS Y DE COLUMNAS QUE LA MATRIZ TIENE EN TOTAL. 
            Console.WriteLine("\nNumero de Filas de la Matriz: " + Matriz.GetLength(0));
            Console.WriteLine("Numero de Columnas de la Matriz: " + Matriz.GetLength(1) + "\n");

            //EL PRIMER FOR ES PARA LAS FILAS.
            for (int x = 0; x < matrizparaimprimir.GetLength(0); x++)
            {
                //EL SEGUNDO FOR ES PARA IMPRIMIR LAS COLUMNAS.
                for (int y = 0; y < matrizparaimprimir.GetLength(1); y++)
                {
                    Console.WriteLine("Valor Almacenado en la Posicion[{0},{1}] = {2}", x, y, matrizparaimprimir[x, y]);
                }
            }
            //LOS VALORES ALMACENADOS EN MATRIZ PARA IMPRIMIR LOS VA A PASAR A OTRA VARIABLE Y ESTE LOS VA A LEER UNO POR UNO Y LO VA A IMPRIMIR PARA QUE LOS IMPRIMA.  
            Console.WriteLine("Valores Almacenados en la Matriz");
            foreach (var valorMat in matrizparaimprimir)
            {
                Console.WriteLine(valorMat);
            }
        }

        //LA CUARTA FUNCION PERSONALIZADA ES DE MULTPLICACION. 
        static double[,] Multiplicacion(double[,] Mat1, double[,] Mat2)
        {

            int filas = Mat1.GetLength(0);
            int columnas = Mat2.GetLength(1);
            int kDimension = Mat1.GetLength(1);

            double[,] MatResultante = new double[filas, columnas];
            //EL PRIMER FOR ES PARA LAS FILAS.
            for (int x = 0; x < filas; x++)
            {
                //EL SEGUNDO ES PARA LAS COLUMNAS.
                for (int y = 0; y < columnas; y++)
                {
                    MatResultante[x, y] = 0;
                    //EL TERCER FOR ES PARA LAS DIMENSIONES DE LAS COLUMNAS.
                    for (int k = 0; k < kDimension; k++)
                    {
                        MatResultante[x, y] += Mat1[x, k] * Mat2[k, y];
                    }
                }
            }
            return MatResultante;
        }

        //LA QUINTA FUNCION FUNCIONA PARA IMPRIMIR LAS MATRICES. 
        static void ImprimirresultadodeMatriz(double[,] matrizIMPRIMIR)
        {
            //EL PRIMER FOR VA A SER PARA LAS FILAS
            for (int x = 0; x < matrizIMPRIMIR.GetLength(0); x++)
            {
                //DESPUES EL FOR DE LAS COLUMNAS.
                for (int y = 0; y < matrizIMPRIMIR.GetLength(1); y++)
                {
                    Console.WriteLine("Valor Almacenado en la Posicion[{0},{1}] = {2}", x, y, matrizIMPRIMIR[x, y]);
                }
            }

            //LOS VALORES ALMACENADOS EN MATRIZ PARA IMPRIMIR LOS VA A PASAR A OTRA VARIABLE Y ESTE LOS VA A LEER UNO POR UNO Y LO VA A IMPRIMIR PARA QUE LOS IMPRIMA.  
            Console.WriteLine("Valores Almacenados en la Matriz");
            foreach (var valorMat in matrizIMPRIMIR)
            {
                Console.WriteLine(valorMat);
            }

        }

        //LA ULTIMA FUNCION ES PARA GUARDAR EL ARCHIVO EN UN TXT.
        static void GuardarMatrizEnArchivo(double[,] matriz, string nombreArchivo, string nombreoperacion)
        {
            // ABRE EL ARCHIVO
            using (StreamWriter archivo = new StreamWriter(nombreArchivo, true))
            {
                // ESCRIBE UN SALTRO DE LINEA DESPUES DE LA OPERACION
                archivo.WriteLine();
                // EESCRIBE EL NOMBRE DE LA OPERACION
                archivo.WriteLine(nombreoperacion); 
                //  IMPRIMIR LAS FILAS
                for (int x = 0; x < matriz.GetLength(0); x++)
                {
                    //IMPRIMIR LAS COLUMNAS
                    for (int y = 0; y < matriz.GetLength(1); y++)
                    {
                        archivo.Write(matriz[x, y] + "\t"); 
                    }
                    //SALTO DE LINEA
                    archivo.WriteLine(); 
                }
            }
        }
    }
}
