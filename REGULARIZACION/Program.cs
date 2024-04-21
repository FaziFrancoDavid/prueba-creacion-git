using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Program
    {

        //MENU PRINCIPAL CLIENTE VENTA VEHICULO PARAMETRICOS.
        static void MenuPrincipal()          //SOLO MENU PRINCIPAL
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n   ***** MENU *****\n");
            Console.WriteLine("(C)lientes\n(V)entas\nVehicu(L)os\n(P)arametricos\n(S)alir\n");
            Console.ResetColor();
            Console.Write("INGRESE SU OPCION: ");
        }

        static void MenuCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n   ***** MENU CLIENTE *****");
            Console.WriteLine("\n(A)GREGAR CLIENTE\n(L)ISTA DE CLIENTES\nACTUALI(Z)AR CLIENTE\n(B)ORRAR CLIENTE\n(V)OLVER AL MENU PRINCIPAL\n(S)ALIR DEL SISTEM");
            Console.ResetColor();
            Console.Write("\nINGRESE SU OPCION :");
        }

        static void MenuVenta()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n   ***** MENU VENTA *****");
            Console.WriteLine("\n(C)REAR VENTA\nLISTA DE (V)ENTAS\nLISTA DE (A)UTOS VENDIDOS\nLISTA DE (M)OTOS VENDIDAS\nLISTA DE CAMION(E)S VENDIDOS\n(S)ALIR\n");
            Console.ResetColor();
            Console.Write("INGRESE SU OPCION : ");
        }

        static void MenuVehiculo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n   ***** MENU VEHICULOS *****");
            Console.WriteLine("\n(A)GREGAR VEHICULO\n(L)ISTA DE VEHICULOS\nACTUALI(Z)AR VEHICULO\n(B)ORRAR VEHICULO\n(S)ALIR\n ");
            Console.ResetColor();
            Console.Write("INGRESE SU OPCION : ");
        }

        static void ListaVehiculo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n   --------------------------");
            Console.WriteLine("   ***  VEHICULOS *** ");
            Console.WriteLine("\n(A)UTOS\n(M)OTOS\n(C)AMIONES\n(V)OLVER ATRAS\n");
            Console.WriteLine("   --------------------------");
            Console.ResetColor();
            Console.Write("   Ingrese su opcion: ");
        }

        static void MenuParametrica()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n   ***** MENU PARAMETRICA *****");
            Console.WriteLine("\n(M)ARCAS\n(L)OCALIDADES\n(S)ALIR");// mls
            Console.ResetColor();
            Console.Write("\nINGRESE SU OPCION :");
        }

        static void VolverOsalirMenuVehiculos()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\nDesea continuar en la seccion Vehiculos o prefiere volver al Menu Principal ?\n");
            Console.ResetColor();
            Console.WriteLine("\n(S)I - (Vuelve a la seccion Vehiculos)");
            Console.WriteLine("\n(N)O - (Sale de la seccion hacia el Menu Principal)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nIngrese su opcion: ");
            Console.ResetColor();

        }

        static void MenuMarcas()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   ***** MENU MARCAS *****");
            Console.WriteLine("(A)GREGAR MARCA\n(L)ISTA DE MARCAS\nA(C)TUALIZAR MARCA\n(B)ORRAR MARCA\n(S)ALIR ");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("   INGRESE SU OPCION :");
        }

        static void MenuCiudades()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   ***** MENU CIUDADES *****");
            Console.WriteLine("(A)GREGAR CIUDAD\n(L)ISTA DE CIUDADES\nACTUALI(Z)AR CIUDAD\n(B)ORRAR CIUDAD\n(S)ALIR ");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("   INGRESE SU OPCION :");
        }


        //validar letra. o char 
        static char ValidarCHAR()
        {
            char letra;
            bool resp;
            resp = char.TryParse(Console.ReadLine(), out letra);
            while (!resp)
            {
                Console.Write(" ERROR! Ingrese solo números: ");
                resp = char.TryParse(Console.ReadLine(), out letra);
            }
            return char.ToUpper(letra);
        }

        static void Main(string[] args)
        {
            char opcion;
            FileStream Archivo;
            if (!File.Exists("ARCHIVO_CLIENTES.txt"))
            {
                Archivo = new FileStream("ARCHIVO_CLIENTES.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_MARCAS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_MARCAS_MOTOS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_MARCAS_MOTOS.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_CIUDADES.txt"))
            {
                Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_VEHICULOS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_VEHICULOS.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_AUTOS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_MOTOS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_CAMIONES.txt"))
            {
                Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_VENTAS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_VENTAS.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_CAMIONES_VENDIDOS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_CAMIONES_VENDIDOS.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_AUTOS_VENDIDOS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_AUTOS_VENDIDOS.txt", FileMode.Create);
                Archivo.Close();
            }
            if (!File.Exists("ARCHIVO_MOTOS_VENDIDAS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_MOTOS_VENDIDAS.txt", FileMode.Create);
                Archivo.Close();
            }

            MenuPrincipal();       //MENU PRINCIPAL
            opcion = ValidarCHAR();

            Menu(opcion);    //MENU SWITCH 

            Console.ReadKey();

        }

        static void Menu(char opcion)   //CLIENTES - VENTAS - Vehiculos - Parametricas - 5)SALIR
        {

            //INSTANCIA CONCESIONARIO//
            Concesionario concesionario = new Concesionario();

            //HACER LOS GUARDADOS DE LISTA AQUI//
            concesionario.GrabarArchivoAutos();
            concesionario.GrabarArchivoMotos();
            concesionario.GrabarArchivoCamiones();


            //CONTROLAR LIMPIAR LISTAS ANTES
            concesionario.GuardarArchivoClientes();
            concesionario.GuardarArchivoCiudades();
            concesionario.GuardarArchivoMarcas();
            concesionario.GuardarArchivoVentas();

            //------------------------------//



            while (opcion != 'C' && opcion != 'V' && opcion != 'L' && opcion != 'P' && opcion != 'S')
            {
                Console.WriteLine("   ERROR, el caracter ingresado es erroneo");
                Console.WriteLine("   Por favor vuelva a ingresar su opcion");
                opcion = ValidarCHAR();
            }

            bool inicio = true;
            while (inicio == true)
            {
                switch (opcion)
                {
                    case 'C':

                        Console.WriteLine("estas ingresando al menu Clientes...");

                        char op;
                        char opcion1;
                        bool opcion2 = true;
                        while (opcion2 == true)
                        {
                            MenuCliente();
                            op = ValidarCHAR();

                            while (op != 'A' && op != 'L' && op != 'Z' && op != 'B' && op != 'V' && op != 'S')
                            {
                                Console.WriteLine("   ERROR, el numero ingresado es incorrecto");
                                Console.WriteLine("   Por favor vuelva a ingresar su opcion");
                                op = ValidarCHAR();
                            }


                            switch (op)
                            {
                                case 'A': // AGREGAR CLIENTE
                                    {
                                        concesionario.AgregarClientes();
                                      
                                        break;
                                    }
                                case 'L': // LISTA DE CLIENTES
                                    {
                                        concesionario.MostrarClientes();
                                       
                                        break;
                                    }
                                case 'Z': // ACTUALIZAR CLIENTES
                                    {
                                     
                                        concesionario.ActualizarCliente();
                                        break;
                                    }
                                case 'B': // BORRAR CLIENTE 
                                    {
                                        concesionario.BorrarCliente();
                                       
                                        break;
                                    }
                                case 'V': // VOlVER AL MENU PRINCIPAL
                                    {
                                        Console.Clear();
                                        MenuPrincipal();
                                        char opAux = ValidarCHAR();
                                        Menu(opAux);
                                        break;
                                    }
                                case 'S': // SALIR
                                    {
                                        Console.Write("saliendo.");
                                        Thread.Sleep(300);
                                        Console.Write(".");
                                        Thread.Sleep(300);
                                        Console.Write(".");
                                        Thread.Sleep(300);
                                        Environment.Exit(1);
                                        //DEBERIA GUARDAR EL ARCHIVO CON LOS DATOS DE LA LISTA
                                        break;
                                    }
                            }

                            Console.WriteLine("");
                            Console.Write("   Desea continuar en el menu clientes? (S)I (N)O : ");
                            opcion1 = ValidarCHAR();
                            if (opcion1 == 'S')
                            {
                                Console.WriteLine("hola estoy porobando algo..");
                                Thread.Sleep(300);
                                opcion2 = true;
                            }
                            else
                            {
                                opcion2 = false;
                            }
                        }
                        break;
                    case 'V':

                        Console.WriteLine("estas ingresando al menu Ventass...");

                        char opVentas;
                        char opcion1Ventas;
                        bool opcion2Ventas = true;
                        while (opcion2Ventas == true)
                        {

                            MenuVenta();
                            opVentas = ValidarCHAR();
                            while (opVentas != 'C' && opVentas != 'L' && opVentas != 'A' && opVentas != 'M' && opVentas != 'E')
                            {
                                Console.WriteLine("   ERROR, el numero ingresado es incorrecto");
                                Console.Write("   Por favor vuelva a ingresar su opcion : ");
                                opVentas = ValidarCHAR();
                            }
                            switch (opVentas)
                            {
                                case 'C': // CREAR VENTA
                                    {
                                        concesionario.CrearVenta();
                                        break;
                                    }
                                case 'L': // LISTA DE VENTAS
                                    {
                                        concesionario.ListaDeVentasRealizadas();
                                        break;
                                    }
                                case 'A': // LISTA DE AUTOS VENDIDOS
                                    {
                                        concesionario.ListaDeAutosVendidos();
                                        break;
                                    }
                                case 'M':  // LISTA DE MOTOS VENDIDAS
                                    {
                                        concesionario.ListaDeMotosVendidas();
                                        break;
                                    }
                                case 'E': // LISTA DE CAMIONES VENDIDOS
                                    {
                                        concesionario.ListaDeCamionesVendidos();
                                        break;
                                    }
                                case 'S':
                                    {
                                        break;
                                    }
                            }
                            Console.WriteLine("");
                            Console.Write("   Desea continuar en el menu VENTAS? (S)SI (N)NO : ");
                            opcion1Ventas = ValidarCHAR();
                            if (opcion1Ventas == 'S')
                            {
                                Console.WriteLine("hola estoy porobando alho..");
                                Thread.Sleep(300);
                                opcion2Ventas = true;
                            }
                            else
                            {
                                opcion2Ventas = false;

                            }
                        }
                        break;
                    case 'L': //vehiculos

                        MenuVehiculo();
                        bool opcion20 = false;
                        do
                        {
                            op = ValidarCHAR();
                        while (op != 'I' && op != 'L' && op != 'Z' && op != 'B' && op != 'S')
                        {
                            Console.WriteLine("   ERROR, el numero ingresado es incorrecto");
                            Console.Write("   Por favor vuelva a ingresar su opcion : ");
                            op = ValidarCHAR();
                        }
                        switch (op)
                        {
                            case 'A': // CREAR VEHICULO
                                {
                                    //Console.WriteLine("Agregando vehiculo...");
                                    concesionario.AgregarVehiculo();
                                    break;
                                }
                            case 'L': // LISTA DE VEHICULOS
                                {
                                    char ope;
                                    char resp4 = 's';
                                    while (resp4 == 's')
                                    {
                                        ListaVehiculo();

                                        ope = ValidarCHAR();
                                        while (ope != 'A' && ope != 'M' && ope != 'C' && ope != 'S')
                                        {
                                            Console.WriteLine("   ERROR, el numero ingresado es incorrecto");
                                            Console.Write("   Por favor vuelva a ingresar su opcion: ");
                                            ope = ValidarCHAR();

                                        }
                                        switch (ope)
                                        {
                                            case 'A':
                                                {
                                                    concesionario.MostrarAutos();
                                                    break;
                                                }
                                            case 'M':
                                                {
                                                    concesionario.MostrarMotos();
                                                    break;
                                                }
                                            case 'C':
                                                { 
                                                    concesionario.MostrarCamiones();
                                                    break;
                                                }
                                            case 'S':
                                                {
                                                    Console.Clear();
                                                    MenuPrincipal();
                                                    opcion = ValidarCHAR();
                                                    Menu(opcion); //MENU SWITCH 
                                                    break;
                                                }
                                        }
                                        Console.WriteLine("");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("");
                                        Console.Write("   Desea continuar en el menu clientes? (S)SI (N)NO : ");
                                        opcion1 = ValidarCHAR();
                                        if (opcion1 == 'S')
                                        {
                                            Console.WriteLine("hola estoy porobando alho..");
                                            Thread.Sleep(300);
                                            opcion20 = true;
                                        }
                                        else
                                        {
                                            opcion20 = false;
                                        }
                                        resp4 = ValidarCHAR();
                                        Console.Clear();
                                        while (resp4 != 'S' && resp4 != 'N')
                                        {
                                            Console.WriteLine("   ERROR, el caracter ingresado es incorrecto");
                                            Console.Write("   Por favor vuelva a ingresar su opcion");
                                            resp4 = ValidarCHAR();
                                            Console.Clear();
                                        }
                                    }
                                    break;
                                }
                            case 'Z': // ACTUALIZAR VEHICULO
                                {
                                    char ope;
                                    char resp2 = 's';
                                    while (resp2 == 's')
                                    {
                                        ListaVehiculo();
                                        ope = ValidarCHAR();
                                        while (ope != 'A' && ope != 'M' && ope != 'C' && ope != 'S')
                                        {
                                            Console.WriteLine("   ERROR, el caracter ingresado es incorrecto");
                                            Console.Write("   Por favor vuelva a ingresar su opcion: ");
                                            ope = ValidarCHAR();
                                        }
                                        switch (ope)
                                        {
                                            case 'A':
                                                {
                                                    concesionario.ActualizarAuto();
                                                    break;
                                                }
                                            case 'M':
                                                {
                                                    concesionario.ActualizarMoto();
                                                    break;
                                                }
                                            case 'C':
                                                {
                                                    concesionario.ActualizarUnCamion();
                                                    break;
                                                }
                                            case 'S':
                                                {
                                                    Console.Clear();
                                                    MenuPrincipal();
                                                    opcion = ValidarCHAR();
                                                    Menu(opcion); //MENU SWITCH 
                                                    break;
                                                }
                                        }
                                        Console.WriteLine("");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("   Desea continuar en este Menu? ");
                                        Console.WriteLine("");
                                        Console.WriteLine("(S)I");
                                        Console.WriteLine("(N)O");
                                        Console.WriteLine("");
                                        Console.ResetColor();
                                        Console.Write("   Ingrese su opcion: ");
                                        resp2 = ValidarCHAR();
                                        Console.Clear();

                                        while (resp2 != 'S' && resp2 != 'N')
                                        {
                                            Console.WriteLine("   ERROR, el caracter ingresado es incorrecto");
                                            Console.Write("   Por favor vuelva a ingresar su opcion");
                                            resp2 = ValidarCHAR();
                                            Console.Clear();
                                        }
                                    }
                                    break;
                                }
                            case 'B': // BORRAR VEHICULO 
                                {
                                    char ope;
                                    char resp3 = 's';
                                    while (resp3 == 's')
                                    {
                                        ListaVehiculo();

                                        ope = ValidarCHAR();

                                            while (ope != 'A' && ope != 'M' && ope!='C' && ope !='V')
                                        {
                                            Console.WriteLine("   ERROR, el caracter ingresado es incorrecto");
                                            Console.Write("   Por favor vuelva a ingresar su opcion: ");
                                            ope = ValidarCHAR();
                                        }
                                        switch (ope)
                                        {
                                            case 'A':
                                                {
                                                    concesionario.BorrarAuto();
                                                    break;
                                                }
                                            case 'M':
                                                {
                                                    concesionario.BorrarMoto();
                                                    break;
                                                }
                                            case 'C':
                                                {
                                                    concesionario.BorrarCamion();
                                                    break;
                                                }
                                            case 'V':
                                                {

                                                    Console.Clear();
                                                    MenuPrincipal();
                                                    opcion = ValidarCHAR();
                                                    Menu(opcion); //MENU 
                                                    break;
                                                }
                                        }
                                       
                                        Console.WriteLine("");
                                        Console.Write("   Desea continuar en el menu clientes? (S)SI (N)NO : ");
                                        opcion1 = ValidarCHAR();
                                        if (opcion1 == 'S')
                                        {
                                            Console.WriteLine("hola estoy porobando alho..");
                                            Thread.Sleep(300);
                                            opcion2 = true;
                                        }
                                        else
                                        {
                                            opcion2 = false;
                                        }
                                    }

                                    break;
                                }
                            case 'S': // SALIR O VOLVER AL MENU VEHICULO
                                {
                                    break;
                                }
                        }
                        VolverOsalirMenuVehiculos();
                        opcion1 = ValidarCHAR();
                        if (opcion1 == 1)
                        {
                            opcion2 = true;
                        }
                        else if (opcion1 == 2)
                        {

                            Console.Clear();
                            MenuPrincipal();
                            opcion = ValidarCHAR();
                            Menu(opcion); //MENU SWITCH 
                        }
                } while (opcion20 == true) ;

                break;
                    case 'P':
                        Console.WriteLine("estas ingresando al menu Parametricos...");

                        char op10bis;
                        char opcion10;
                        bool opcion5;

                        do
                        {
                            MenuParametrica();
                            op10bis = ValidarCHAR();
                            while (op10bis != 'M' && op10bis != 'L' && op10bis != 'S')
                            {
                                Console.WriteLine("   ERROR, el numero ingresado es incorrecto");
                                Console.WriteLine("   Por favor vuelva a ingresar su opcion");
                                op10bis = ValidarCHAR();
                            }
                            switch (op10bis)
                            {
                                case 'M': // MARCAS
                                    {
                                        char op3 = 's';
                                        while (op3 == 's')
                                        {
                                            char op2;

                                            MenuMarcas();
                                            
                                            op2 = ValidarCHAR();
                                            switch (op2)
                                            {
                                                case 'A': //AGREGAR MARCA
                                                    {
                                                        concesionario.AgregarMarca();
                                                        break;
                                                    }
                                                case 'L': //LISTA DE MARCAS
                                                    {
                                                        concesionario.MostrarMarcas();
                                                        break;
                                                    }
                                                case 'C': //ACTUALIZAR MARCA
                                                    {
                                                        concesionario.ActualizarMarca();
                                                        break;
                                                    }
                                                case 'B': //BORRAR MARCA
                                                    {
                                                        concesionario.BorrarMarca();
                                                        break;
                                                    }
                                                case 'S': //SALIR
                                                    {
                                                        break;
                                                    }
                                            }
                                            Console.WriteLine("");
                                            Console.Write("   Desea continuar en marcas? 1)SI 2)NO : ");
                                            op3 = ValidarCHAR();
                                        }
                                        break;
                                    }
                                case 'L': // Localidad
                                    {
                                       
                                        char op3 = 's';
                                        while (op3 == 's')
                                        {
                                            char op2;
                                            MenuCiudades();
                                            op2 = ValidarCHAR();
                                            switch (op2)
                                            {
                                                case 'A': //AGREGAR CIUDAD
                                                    {

                                                        concesionario.AgregarCiudad();
                                                        break;
                                                    }
                                                case 'L': //LISTA DE CIUDADES
                                                    {
                                                        concesionario.MostrarCiudades();
                                                        break;
                                                    }
                                                case 'Z': //ACTUALIZAR CIUDAD
                                                    {
                                                        concesionario.ActualizarCiudad();
                                                        break;
                                                    }
                                                case 'B': //BORRAR CIUDAD
                                                    {
                                                        concesionario.BorrarCiudad();
                                                        break;
                                                    }
                                                case 'S': //SALIR
                                                    {
                                                        break;
                                                    }
                                            }
                                            //Console.WriteLine("");
                                            Console.Write("\nDesea continuar en ciudades? (S)I (N)O : ");
                                            op3 = ValidarCHAR();
                                        }
                                        break;
                                    }
                                case 'V': // VOlVER
                                    {
                                        Console.Clear();
                                        MenuPrincipal();
                                        char op3 = ValidarCHAR();
                                        Menu(op3);
                                        break;
                                    }
                                case 'S':// SALIR
                                    {
                                        Environment.Exit(1);
                                        break;
                                    }
                            }
                            
                            Console.Write("\n   Desea volver al menu principal ? (S)I (N)O : ");
                            opcion10 = ValidarCHAR();
                            if (opcion10 == 'S')
                            {
                                opcion5 = true;
                            }
                            else
                            {
                                opcion5 = false;
                            }
                        } while (opcion5 == true);
                        // break;

                        break;
                }

                Console.WriteLine("");
                Console.Write("   Desea continuar en el sistema? (S)I - (N)O : ");
                int RESp = ValidarCHAR();
                while (RESp != 'S' && RESp != 'N')
                {
                    Console.Write("   Error Ingrese la opcion de nuevo: ");
                    RESp = ValidarCHAR();
                }
                if (RESp == 'S')
                {
                    inicio = true;
                    Console.Clear();
                    MenuPrincipal();
                    opcion = ValidarCHAR();
                }
                else
                {
                    inicio = false;
                }

            }
        }
    }
}

