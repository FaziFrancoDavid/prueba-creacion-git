using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Concesionario
    {
        //SE CREA UNA VARIABLE INTEGRAL PARA ID
        int idIntegral;
        int idCamionIntegral;
        int idMotoIntegral;
        int idAutoIntegral;

        //LISTAS
        private List<Autos> ListaDeAutos = new List<Autos>();
        private List<Camiones> ListaDeCamiones = new List<Camiones>();
        private List<Ciudades> ListaDeCiudades2 = new List<Ciudades>();
        private List<Clientes> ListaDeClientes = new List<Clientes>();
        private List<Marcas> ListaDeMarcas = new List<Marcas>();
        private List<Marcas> ListaDeMarcasMotos = new List<Marcas>();
        private List<Motos> ListaDeMotos = new List<Motos>();
        private List<Ventas> ListaDeVentas = new List<Ventas>();

        private List<(int, string)> ListaDeProvincias = new List<(int, string)>();
        private List<(int, string)> ListaDeSegmentos = new List<(int, string)>();
        private List<(int, string)> ListaDeCombustibles = new List<(int, string)>();
        private List<(int, string)> ListaDeTipo = new List<(int, string)>();

        //CONTRUCTORES
        public Concesionario()
        {
            ListaDeAutos = new List<Autos>();
            ListaDeCamiones = new List<Camiones>();
            ListaDeClientes = new List<Clientes>();
            ListaDeMotos = new List<Motos>();
            ListaDeVentas = new List<Ventas>();

            //LISTA INICIALIZADA CON 5 OBJETOS PREDETERMINADOS 
            ListaDeCiudades2 = new List<Ciudades>
            {
                new Ciudades(1,"San Nicolas"),
                new Ciudades(2,"Rosario"),
                new Ciudades(3,"Pergamino"),
                new Ciudades(4,"Ramallo"),
                new Ciudades(5,"San Pedro")
                

            };

            //LISTA INICIALIZADA CON 5 OBJETOS PREDETERMINADOS 
            ListaDeMarcas = new List<Marcas>
            {
                new Marcas(1,"Peugeot"),
                new Marcas(2,"Fiat"),
                new Marcas(3,"Ford"),
                new Marcas(4,"Renault"),
                new Marcas(5,"Chevrolet")
            };

            //LISTA INICIALIZADA CON 5 OBJETOS PREDETERMINADOS 
            ListaDeMarcasMotos = new List<Marcas>
            {
                new Marcas(1,"Honda"),
                new Marcas(2,"Suzuki"),
                new Marcas(3,"Motomel"),
                new Marcas(4,"Yamaha"),
                new Marcas(5,"Gilera")
            };

            //LISTA YA ARMADAS SIN OPCION DE MODIFICAR
            ListaDeProvincias = new List<(int, string)>() { (1, " Buenos Aires"), (2, " Cordoba"), (3, " Entre Rios"), (4, " San Luis"), (5, " Santa Fe") };
            ListaDeSegmentos = new List<(int, string)>() { (1, " Sedan"), (2, " Coupe"), (3, " Suv"), (4, " Pickup"), (5, " Scooter"), (6, " Enduro"), (7, " Ruta"), (8, " Camion") };
            ListaDeCombustibles = new List<(int, string)>() { (1, " Nafta"), (2, " Diesel"), (3, " Gnc"), (4, " Electrico") };
            ListaDeTipo = new List<(int, string)>() { (1, " Auto"), (2, " Moto"), (3, " Camion") };
        }

        public void AgregarClientes()
        {
            string provincia;
            string ciudad = null;

            Console.WriteLine("");
            Console.Write("   Ingrese Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("   Ingrese Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("   Ingrese DNI: ");
            long dni = ValidarDni();
            Console.Write("   Ingrese su correo: ");
            string correo = Console.ReadLine();

            //MUESTRO LISTA DE PROVINCIAS Y PIDO NUMERO DE ID PARA BUSCAR LUEGO POR INDICE EN LA LISTA LA PROVINCIA
            Console.WriteLine("   -----------------------");
            Console.WriteLine("   ***Lista de Provincias***");
            foreach ((int, string) item in ListaDeProvincias)
            {
                Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
            }
            Console.WriteLine("   -----------------------");
            Console.Write("   Ingrese la provincia: ");
            int idProvincia = ValidarNum();
            string datoColumna2P;
            while (idProvincia < 1 || idProvincia > ListaDeProvincias.Count())
            {
                Console.WriteLine("   La provincia seleccionada no existe, vuelva a ingresar su opcion: ");
                idProvincia = ValidarNum();

            }
            datoColumna2P = ListaDeProvincias[idProvincia - 1].Item2;

            provincia = datoColumna2P;
            //---------------------------------------------------------------------------------------------------//

            //BORRO LA LISTA PREDETERMINADA Y LE CARGO LOS DATOS DEL ARCHIVO_LIST.TXT PARA ACTUALIZARLA
            ListaDeCiudades2.Clear();//VACIADO DE LISTA
            GuardarArchivoCiudades();

            //MUESTRO LISTA DE CIUDADES Y PIDO NUMERO DE ID PARA BUSCAR LUEGO POR INDICE EN LA LISTA LA CIUDADES
            Console.WriteLine("   -----------------------");
            Console.WriteLine("   ***Lista de Ciudades***");
            foreach (Ciudades item in ListaDeCiudades2)
            {
                Console.WriteLine($"   {item.Id_Ciudad} - Ciudad : {item.Nombre} ");
            }
            Console.WriteLine("   -----------------------");
            Console.WriteLine("   Si no esta su ciudad en la lista escriba: 99");
            Console.Write("   Ingrese el id de la Ciudad: ");
            int idCiudad = ValidarNum();
            // Variable para controlar si se encontró la ciudad
            bool ciudadEncontrada = false;

            while (!ciudadEncontrada)
            {
                // Utilizar el método Find para buscar una ciudad por su ID
                Ciudades ciudad2 = ListaDeCiudades2.Find(c => c.Id_Ciudad == idCiudad);

                if (ciudad2 != null)
                {
                    ciudad = ciudad2.Nombre;
                    ciudadEncontrada = true;
                }
                else if (idCiudad == 99)
                {
                    AgregarCiudad_99();
                    Console.WriteLine("   -----------------------");
                    Console.WriteLine("   ***Lista de Ciudades***");
                    foreach (Ciudades item in ListaDeCiudades2)
                    {
                        Console.WriteLine($"   {item.Id_Ciudad} - Ciudad : {item.Nombre} ");
                    }
                    Console.WriteLine("   -----------------------");
                    Console.Write($"   Ingrese el ID de la ciudad: ");
                    idCiudad = ValidarNum();
                    // Variable para controlar si se encontró la ciudad
                    ciudadEncontrada = false;
                    while (!ciudadEncontrada)
                    {
                        // Utilizar el método Find para buscar una ciudad por su ID
                        Ciudades ciudad3 = ListaDeCiudades2.Find(c => c.Id_Ciudad == idCiudad);

                        if (ciudad3 != null)
                        {
                            ciudad = ciudad3.Nombre;
                            ciudadEncontrada = true;
                        }
                        else if (idCiudad == 99)
                        {
                            AgregarCiudad_99();
                            Console.WriteLine("   -----------------------");
                            Console.WriteLine("   ***Lista de Ciudades***");
                            foreach (Ciudades item in ListaDeCiudades2)
                            {
                                Console.WriteLine($"   {item.Id_Ciudad} - Ciudad : {item.Nombre} ");
                            }
                            Console.WriteLine("   -----------------------");
                            Console.Write($"   Ingrese el ID de la ciudad: ");
                            idCiudad = ValidarNum();
                            // Variable para controlar si se encontró la ciudad
                            ciudadEncontrada = false;
                        }
                        else
                        {
                            Console.WriteLine("Ciudad no encontrada. Introduce otro ID:");
                            string entrada = Console.ReadLine();
                            if (int.TryParse(entrada, out idCiudad) == false)
                            {
                                Console.WriteLine("ID no válido. Introduce un ID numérico válido.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ciudad no encontrada. Introduce otro ID:");
                    string entrada = Console.ReadLine();
                    if (int.TryParse(entrada, out idCiudad) == false)
                    {
                        Console.WriteLine("ID no válido. Introduce un ID numérico válido.");
                    }
                }
            }
            //---------------------------------------------------------------------------------------------------//

            idIntegral = idIntegral + 1;
            ListaDeClientes.Add(new Clientes { Id_Cliente = idIntegral, Apellido = apellido, Nombre = nombre, Dni = dni, Correo = correo, Provincia = provincia, Ciudad = ciudad });
            //GRABA LA LISTA_CLIENTES EN EL ARCHIVO CLIENTE.TXT
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_CLIENTES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);

            foreach (Clientes item in ListaDeClientes)
            {
                string cadena = item.Id_Cliente + ";" + item.Apellido + ";" + item.Nombre + ";" + item.Dni + ";" + item.Correo + ";" + item.Provincia + ";" + item.Ciudad;
                Grabar.WriteLine(cadena);

            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            //LIMPIO LA LISTA DE CLIENTES Y LUEGO LA CARGO CON LO QUE CONTENGA ARCHIVO CLIENTES.TXT
            ListaDeClientes.Clear();
            GuardarArchivoClientes();
        }

        public void GuardarArchivoClientes()
        {
            FileStream Archivo;
            StreamReader leer;

            Archivo = new FileStream("ARCHIVO_CLIENTES.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                int id = int.Parse(datos[0]);
                idIntegral = id;
                string apellido = datos[1];
                string nombre = datos[2];
                long dni = long.Parse(datos[3]);
                string correo = datos[4];
                string provincia = datos[5];
                string ciudad = datos[6];

                Clientes cliente = new Clientes(id, apellido, nombre, dni, correo, provincia, ciudad);
                ListaDeClientes.Add(cliente);
            }
            leer.Close();
            Archivo.Close();

        }


        public void MostrarClientes()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CLIENTES.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("  No hay ningun cliente cargado en la lista");
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID_Cliente: {datos[0]} - Apellido: {datos[1]} - Nombre: {datos[2]} - DNI: {datos[3]} - Correo: {datos[4]} - Provincia: {datos[5]} - Ciudad: {datos[6]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }

        public void ActualizarCliente()
        {
            MostrarClientes();
            Console.Write("   Escriba el ID del cliente para actualizar: ");
            int ClienteIDActualizar = ValidarNum();

            // PREGUNTA SI EXISTE EL NUMERO DE ID PARA MODIFICAR EL CLIENTE
            Clientes clienteActualizar = ListaDeClientes.FirstOrDefault(c => c.Id_Cliente == ClienteIDActualizar);

            if (clienteActualizar != null)
            {
                // Actualizar los datos del cliente.
                clienteActualizar.Id_Cliente = ClienteIDActualizar;
                Console.WriteLine("");
                Console.Write("   Ingrese Nombre: ");
                clienteActualizar.Nombre = Console.ReadLine();
                Console.Write("   Ingrese Apellido: ");
                clienteActualizar.Apellido = Console.ReadLine();
                Console.Write("   Ingrese DNI: ");
                clienteActualizar.Dni = ValidarDni();//falta validar long
                Console.Write("   Ingrese el Correo: ");
                clienteActualizar.Correo = Console.ReadLine();
                //MUESTRO LISTA DE PROVINCIAS Y PIDO NUMERO DE ID PARA BUSCAR LUEGO POR INDICE EN LA LISTA LA PROVINCIA
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   ***Lista de Provincias***");
                foreach ((int, string) item in ListaDeProvincias)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.Write("   Ingrese la provincia: ");
                int idProvincia = ValidarNum();
                string datoColumna2P = ListaDeProvincias[idProvincia - 1].Item2;
                while (idProvincia < 0 && idProvincia > ListaDeProvincias.Count())
                {
                    Console.WriteLine("   La provincia seleccionada no existe, vuelva a ingresar su opcion: ");
                    idProvincia = ValidarNum();
                    datoColumna2P = ListaDeProvincias[idProvincia].Item2;
                }
                clienteActualizar.Provincia = datoColumna2P;
                //---------------------------------------------------------------------------------------------------//
                //BORRO LA LISTA  de CIUDADES PREDETERMINADA Y LE CARGO LOS DATOS DEL ARCHIVO_LIST.TXT PARA ACTUALIZARLA

                ListaDeCiudades2.Clear();//VACIADO DE LISTA
                GuardarArchivoCiudades();

                //MUESTRO LISTA DE CIUDADES Y PIDO NUMERO DE ID PARA BUSCAR LUEGO POR INDICE EN LA LISTA LA CIUDADES
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   ***Lista de Ciudades***");
                foreach (Ciudades item in ListaDeCiudades2)
                {
                    Console.WriteLine($"   {item.Id_Ciudad} - {item.Nombre}");
                }
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   Si no esta su ciudad en la lista escriba: 99");
                Console.Write("   Ingrese la Ciudad: ");
                int idCiudad = ValidarNum();

                if (idCiudad == 99)
                {
                    AgregarCiudad();
                    ListaDeCiudades2.Clear();//vaciamos la lista para poder agregar lo del archivo listas txt
                    GuardarArchivoCiudades();
                    Console.WriteLine("   -----------------------");
                    Console.WriteLine("   ***Lista de Ciudades***");
                    foreach (Ciudades item in ListaDeCiudades2)
                    {
                        Console.WriteLine($"   {item.Id_Ciudad} - Ciudad : {item.Nombre} ");
                    }
                    Console.WriteLine("   -----------------------");
                    Console.Write("   Ingrese el id de la Ciudad: ");
                    idCiudad = ValidarNum();
                }

                string nombre = ListaDeCiudades2[idCiudad - 1].Nombre;
                while (idCiudad < 0 && idCiudad > ListaDeCiudades2.Count())
                {
                    Console.WriteLine("   La ciudad seleccionada no existe, vuelva a ingresar su opcion: ");
                    idCiudad = ValidarNum();
                    nombre = ListaDeCiudades2[idCiudad - 1].Nombre;
                }
                clienteActualizar.Ciudad = nombre;
                //---------------------------------------------------------------------------------------------------//    
            }
            else
            {
                Console.WriteLine($"   Cliente con ID {ClienteIDActualizar} no encontrado.");
            }
            //GRABA LA LISTA DE NUEVO EN EL ARCHIVO
            FileStream Archivo;
            StreamWriter Grabar;
            if (!File.Exists("ARCHIVO_CLIENTES.txt"))
            {
                Archivo = new FileStream("ARCHIVO_CLIENTES.txt", FileMode.Create);
                Archivo.Close();
            }
            Archivo = new FileStream("ARCHIVO_CLIENTES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Clientes item in ListaDeClientes)
            {
                string cadena = item.Id_Cliente + ";" + item.Apellido + ";" + item.Nombre + ";" + item.Dni + ";" + item.Correo + ";" + item.Provincia + ";" + item.Ciudad;
                Grabar.WriteLine(cadena);

            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
        }


        public void BorrarCliente()
        {
            Console.WriteLine("");
            MostrarClientes();
            Console.WriteLine("");
            Console.Write("   Escriba el ID del cliente a borrar: ");
            int OpcionRemover = ValidarNum();

            //BUSCAR EL ID EN LA LISTA (INTERSECT)
            Clientes ObjetoEliminar = ListaDeClientes.FirstOrDefault(item => item.Id_Cliente == OpcionRemover);

            if (ObjetoEliminar != null)
            {
                ListaDeClientes.Remove(ObjetoEliminar);
            }

            FileStream Archivo;
            StreamWriter Grabar;
            if (!File.Exists("ARCHIVO_CLIENTES.txt"))
            {
                Archivo = new FileStream("ARCHIVO_CLIENTES.txt", FileMode.Create);
                Archivo.Close();
            }
            Archivo = new FileStream("ARCHIVO_CLIENTES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);

            foreach (Clientes item in ListaDeClientes)
            {
                string cadena = item.Id_Cliente + ";" + item.Apellido + ";" + item.Nombre + ";" + item.Dni + ";" + item.Correo + ";" + item.Provincia + ";" + item.Ciudad;
                Grabar.WriteLine(cadena);

            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();

        }


        public void CrearVenta()
        {
            string datoColumna2P;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   -----------------------------------");
            Console.WriteLine("   *** Lista de Tipos de Vehiculos ***");
            foreach ((int, string) item in ListaDeTipo)
            {
                Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
            }
            Console.WriteLine("   -----------------------------------");
            Console.ResetColor();
            Console.Write("   Ingrese el tipo de vehiculo: ");
            int idvehiculo = ValidarNum();

            while (idvehiculo < 1 || idvehiculo > ListaDeTipo.Count())
            {
                Console.Write("  El tipo seleccionado no existe, vuelva a ingresar su opcion: ");
                idvehiculo = ValidarNum();
            }
            datoColumna2P = ListaDeTipo[idvehiculo - 1].Item2;
            string tipo = datoColumna2P;

            if (tipo == " Auto")
            {
                int idAuto = 0;
                string patente = null;
                string marca = null;
                string modelo = null;
                int año = 0;
                string color = null;
                string nombre = null;
                string apellido = null;
                long dni = 0;
                int precio = 0;

                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                           *** Lista de Autos a la venta ***");
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                foreach (Autos item in ListaDeAutos)
                {
                    Console.WriteLine("   | ID:" + item.Id_Vehiculo + " | Marca: " + item.Id_Marca + " | Modelo: " + item.Modelo + " | Segmento: " + item.Id_Segmento + " | Km: " + item.Kilometro + " | Año: " + item.Año + " | Color " + item.Color + " | Precio: " + item.Precio_venta);
                }
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el ID del vehiculo que desea comprar :");
                int idvehiculo2 = ValidarNum();//ID DEL VEHICULO PARA BUSCAR EN EL ARCHIVO LISTAS_AUTOS.TXT
                while (idvehiculo2 < 1 || idvehiculo2 > ListaDeAutos.Count())
                {
                    Console.Write("   El auto seleccionado no existe, vuelva a ingresar su opcion: ");
                    idvehiculo2 = ValidarNum();
                }
                // Utiliza la función Find para buscar el objeto en la lista
                Autos objetoBuscado = ListaDeAutos.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (objetoBuscado != null)
                {
                    // Guarda los datos del objeto encontrado en variables
                    idAuto = objetoBuscado.Id_Vehiculo;
                    patente = objetoBuscado.Patente;
                    marca = objetoBuscado.Id_Marca;
                    modelo = objetoBuscado.Modelo;
                    año = objetoBuscado.Año;
                    color = objetoBuscado.Color;
                }

                Console.WriteLine("");
                //CARGA LA LISTA CON LOS CLIENTES DEL ARCHIVO TXT
                ListaDeClientes.Clear();
                GuardarArchivoClientes();
                bool resp = true;
                while (resp == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                                             *** Lista de Clientes *** ");
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    foreach (Clientes cliente in ListaDeClientes)
                    {
                        Console.WriteLine("   | Id: " + cliente.Id_Cliente + " | Apellido: " + cliente.Apellido + " | Nombre: " + cliente.Nombre + " | Dni: " + cliente.Dni);
                    }
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("   Si no existe el cliente en la lista escriba: 999 ");
                    Console.WriteLine("");
                    Console.Write("   Ingrese el id del cliente si es que esta cargado en el sistema: ");
                    int idcliente = ValidarNum();
                    Console.WriteLine("");
                    int op;

                    Clientes ClienteBuscado = ListaDeClientes.FirstOrDefault(item => item.Id_Cliente == idcliente);

                    // Verifica si se encontró el objeto
                    if (ClienteBuscado != null)
                    {
                        // El objeto fue encontrado, puedes acceder a sus propiedades
                        nombre = ClienteBuscado.Nombre;
                        apellido = ClienteBuscado.Apellido;
                        dni = ClienteBuscado.Dni;
                        resp = false;
                    }
                    else if (idcliente == 999)
                    {
                        AgregarClientes();

                        //SE MUESTRA LA LISTA DE CLIENTES ACTUALIZADA 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                                             *** Lista de Clientes *** ");
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("");
                        foreach (Clientes cliente in ListaDeClientes)
                        {
                            Console.WriteLine("   | Id: " + cliente.Id_Cliente + " | Apellido: " + cliente.Apellido + " | Nombre: " + cliente.Nombre + " | Dni: " + cliente.Dni);
                        }
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("   Si no existe el cliente en la lista escriba: 999 ");
                        Console.WriteLine("");
                        Console.Write("   Ingrese el id del cliente si es que esta cargado en el sistema: ");
                        Console.WriteLine("");
                        idcliente = ValidarNum();
                        Clientes ClienteBuscado2 = ListaDeClientes.FirstOrDefault(item => item.Id_Cliente == idcliente);
                        // Verifica si se encontró el objeto
                        if (ClienteBuscado != null)
                        {
                            // El objeto fue encontrado, puedes acceder a sus propiedades
                            nombre = ClienteBuscado2.Nombre;
                            apellido = ClienteBuscado2.Apellido;
                            dni = ClienteBuscado2.Dni;
                        }
                    }
                    else
                    {
                        //El objeto no fue encontrado
                        Console.WriteLine("");
                        Console.WriteLine("   El id de cliente seleccionado no fue encontrado.");
                        Console.Write("   Desea seguir intentando? 1)SI - 2)NO :");
                        op = ValidarNum();
                        Console.WriteLine("");

                        while (op < 1 || op > 2)
                        {
                            Console.WriteLine("");
                            Console.Write("   Error, vuelva ingresar su  opcion: ");
                            op = ValidarNum();
                            Console.WriteLine("");
                        }
                        if (op == 1)
                        {
                            resp = true;
                        }
                        else if (op == 2)
                        {
                            resp = false;
                        }
                        Console.WriteLine("   Para poder continuar debera crear un cliente ");
                    }
                }

                Autos AutoBuscado = ListaDeAutos.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (AutoBuscado != null)
                {
                    // El objeto fue encontrado, puedes acceder a sus propiedades
                    precio = AutoBuscado.Precio_venta;
                }
                Console.Write("   Ingrese el descuento que desee: ");
                double descuento = ValidarDouble();
                Console.Write("   Ingrese la fecha de compra: ");
                string fechacompra = Console.ReadLine();
                Console.Write("   Ingrese la fecha de entrega: ");
                string fechaentrega = Console.ReadLine();

                Ventas venta = new Ventas(apellido, nombre, dni, fechacompra, fechaentrega, descuento, precio, marca, modelo, patente, año, color);
                ListaDeVentas.Add(venta);

                //GRABAR LA VENTA EN EL ARCHIVO VENTAS.TXT
                FileStream Archivo;
                StreamWriter Grabar;
                Archivo = new FileStream("ARCHIVO_VENTAS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                foreach (Ventas item in ListaDeVentas)
                {
                    string cadena = item.Apellido + ";" + item.Nombre + ";" + item.Dni + ";" + item.Precio + ";" + item.Iva + ";" + item.Descuento + ";" + item.Total + ";" + item.MARCA + ";" + item.MODELO + ";" + item.AÑO + ";" + item.COLOR;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();

                //GRABAR EL AUTO VENDIDO EN EL ARCHIVO DE AUTOS VENDIDOS.TXT
                Archivo = new FileStream("ARCHIVO_AUTOS_VENDIDOS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                if (idvehiculo2 >= 0 && idvehiculo2 < ListaDeAutos.Count())
                {
                    Autos autoAGuardar = ListaDeAutos[idvehiculo2];
                    // Crear una cadena con los datos del auto
                    string datosAuto = $"{autoAGuardar.Id_Vehiculo};{autoAGuardar.Patente};{autoAGuardar.Kilometro};{autoAGuardar.Año};{autoAGuardar.Id_Marca};{autoAGuardar.Modelo};{autoAGuardar.Id_Segmento};{autoAGuardar.Id_Combustible};{autoAGuardar.Precio_venta};{autoAGuardar.Color};{autoAGuardar.Tipo}";
                    // Escribir los datos del auto en el archivo
                    Grabar.WriteLine(datosAuto);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();

                //LIMPIAR LA LISTA DE VENTAS Y VOLVER A CARGARLA
                ListaDeVentas.Clear();
                GuardarArchivoVentas();

                //BORRAR AUTO DEL ARCHIVO DE AUTOS PORQUE ESTE SE VENDIO
                Autos ObjetoEliminar = ListaDeAutos.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (ObjetoEliminar != null)
                {
                    ListaDeAutos.Remove(ObjetoEliminar);
                }
                // GRABA LA LISTA DE AUTOS EN EL ARCHIVO DE AUTOS PARA ACTUALIZAR Y SABER QUE AUTOS ESTAN A LA VENTA
                Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                foreach (Autos item in ListaDeAutos)
                {
                    string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();
                // SE VUELVE A CARGA LA LISTA_DE AUTOS DESDE EL ARCHIVO_AUTO_TXT
                // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
                ListaDeAutos.Clear();
                StreamReader leer;
                Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Open);//cambiar archivo
                leer = new StreamReader(Archivo);
                while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
                {
                    string cadena = leer.ReadLine();
                    string[] datos = cadena.Split(';');
                    Autos auto = new Autos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11]);
                    ListaDeAutos.Add(auto);
                }
                leer.Close();
                Archivo.Close();
                //FINAL DEL BORRADO DEL AUTO//

            }
            else if (tipo == " Moto")
            {
                int idAuto = 0;
                string patente = null;
                string marca = null;
                string modelo = null;
                int año = 0;
                string color = null;
                string nombre = null;
                string apellido = null;
                long dni = 0;
                int precio = 0;

                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                           *** Lista de Motos a la venta ***");
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                foreach (Motos item in ListaDeMotos)
                {
                    Console.WriteLine("   | ID:" + item.Id_Vehiculo + " | Marca: " + item.Id_Marca + " | Modelo: " + item.Modelo + " | Segmento: " + item.Id_Segmento + " | Km: " + item.Kilometro + " | Año: " + item.Año + " | Color " + item.Color + " | Precio: " + item.Precio_venta);
                }
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el ID del vehiculo que desea comprar :");
                int idvehiculo2 = ValidarNum();//ID DEL VEHICULO PARA BUSCAR EN EL ARCHIVO LISTAS_MOTOS.TXT
                while (idvehiculo2 < 1 || idvehiculo2 > ListaDeMotos.Count())
                {
                    Console.Write("   La moto seleccionada no existe, vuelva a ingresar su opcion: ");
                    idvehiculo2 = ValidarNum();
                }
                // Utiliza la función Find para buscar el objeto en la lista
                Motos objetoBuscado = ListaDeMotos.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (objetoBuscado != null)
                {
                    // Guarda los datos del objeto encontrado en variables
                    idAuto = objetoBuscado.Id_Vehiculo;
                    patente = objetoBuscado.Patente;
                    marca = objetoBuscado.Id_Marca;
                    modelo = objetoBuscado.Modelo;
                    año = objetoBuscado.Año;
                    color = objetoBuscado.Color;
                }
                Console.WriteLine("");
                //CARGA LA LISTA CON LOS CLIENTES DEL ARCHIVO TXT
                ListaDeClientes.Clear();
                GuardarArchivoClientes();
                bool resp = true;
                while (resp == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                                             *** Lista de Clientes *** ");
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    foreach (Clientes cliente in ListaDeClientes)
                    {
                        Console.WriteLine("   | Id: " + cliente.Id_Cliente + " | Apellido: " + cliente.Apellido + " | Nombre: " + cliente.Nombre + " | Dni: " + cliente.Dni);
                    }
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("   Si no existe el cliente en la lista escriba: 999 ");
                    Console.WriteLine("");
                    Console.Write("   Ingrese el id del cliente si es que esta cargado en el sistema: ");
                    int idcliente = ValidarNum();
                    Console.WriteLine("");
                    int op;

                    Clientes ClienteBuscado = ListaDeClientes.FirstOrDefault(item => item.Id_Cliente == idcliente);

                    // Verifica si se encontró el objeto
                    if (ClienteBuscado != null)
                    {
                        // El objeto fue encontrado, puedes acceder a sus propiedades
                        nombre = ClienteBuscado.Nombre;
                        apellido = ClienteBuscado.Apellido;
                        dni = ClienteBuscado.Dni;
                        resp = false;
                    }
                    else if (idcliente == 999)
                    {
                        AgregarClientes();

                        //SE MUESTRA LA LISTA DE CLIENTES ACTUALIZADA 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                                             *** Lista de Clientes *** ");
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("");
                        foreach (Clientes cliente in ListaDeClientes)
                        {
                            Console.WriteLine("   | Id: " + cliente.Id_Cliente + " | Apellido: " + cliente.Apellido + " | Nombre: " + cliente.Nombre + " | Dni: " + cliente.Dni);
                        }
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("   Si no existe el cliente en la lista escriba: 999 ");
                        Console.WriteLine("");
                        Console.Write("   Ingrese el id del cliente si es que esta cargado en el sistema: ");
                        Console.WriteLine("");
                        idcliente = ValidarNum();
                        Clientes ClienteBuscado2 = ListaDeClientes.FirstOrDefault(item => item.Id_Cliente == idcliente);
                        // Verifica si se encontró el objeto
                        if (ClienteBuscado != null)
                        {
                            // El objeto fue encontrado, puedes acceder a sus propiedades
                            nombre = ClienteBuscado2.Nombre;
                            apellido = ClienteBuscado2.Apellido;
                            dni = ClienteBuscado2.Dni;
                        }
                    }
                    else
                    {
                        //El cliente no fue encontrado
                        Console.WriteLine("");
                        Console.WriteLine("   El id de cliente seleccionado no fue encontrado.");
                        Console.Write("   Desea seguir intentando? 1)SI - 2)NO :");
                        op = ValidarNum();
                        Console.WriteLine("");

                        while (op < 1 || op > 2)
                        {
                            Console.WriteLine("");
                            Console.Write("   Error, vuelva ingresar su  opcion: ");
                            op = ValidarNum();
                            Console.WriteLine("");
                        }
                        if (op == 1)
                        {
                            resp = true;
                        }
                        else if (op == 2)
                        {
                            resp = false;
                        }
                        Console.WriteLine("   Para poder continuar debera crear un cliente ");
                    }
                }

                Motos MotoBuscado = ListaDeMotos.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (MotoBuscado != null)
                {
                    // El objeto fue encontrado, puedes acceder a sus propiedades
                    precio = MotoBuscado.Precio_venta;
                }
                Console.Write("   Ingrese el descuento que desee: ");
                double descuento = ValidarDouble();
                Console.Write("   Ingrese la fecha de compra: ");
                string fechacompra = Console.ReadLine();
                Console.Write("   Ingrese la fecha de entrega: ");
                string fechaentrega = Console.ReadLine();

                Ventas venta = new Ventas(apellido, nombre, dni, fechacompra, fechaentrega, descuento, precio, marca, modelo, patente, año, color);
                ListaDeVentas.Add(venta);

                //GRABAR LA VENTA EN EL ARCHIVO VENTAS.TXT
                FileStream Archivo;
                StreamWriter Grabar;
                Archivo = new FileStream("ARCHIVO_VENTAS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                foreach (Ventas item in ListaDeVentas)
                {
                    string cadena = item.Apellido + ";" + item.Nombre + ";" + item.Dni + ";" + item.Precio + ";" + item.Iva + ";" + item.Descuento + ";" + item.Total + ";" + item.MARCA + ";" + item.MODELO + ";" + item.AÑO + ";" + item.COLOR;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();

                //GRABAR LA MOTO VENDIDA EN EL ARCHIVO DE MOTOS VENDIDOS.TXT
                Archivo = new FileStream("ARCHIVO_MOTOS_VENDIDAS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                if (idvehiculo2 >= 0 && idvehiculo2 < ListaDeMotos.Count())
                {
                    Motos motoAGuardar = ListaDeMotos[idvehiculo2];
                    // Crear una cadena con los datos de la moto
                    string datosMoto = $"{motoAGuardar.Id_Vehiculo};{motoAGuardar.Patente};{motoAGuardar.Kilometro};{motoAGuardar.Año};{motoAGuardar.Id_Marca};{motoAGuardar.Modelo};{motoAGuardar.Id_Segmento};{motoAGuardar.Id_Combustible};{motoAGuardar.Precio_venta};{motoAGuardar.Color};{motoAGuardar.Cilindrada}";
                    // Escribir los datos del auto en el archivo
                    Grabar.WriteLine(datosMoto);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();

                //LIMPIAR LA LISTA DE VENTAS Y VOLVER A CARGARLA
                ListaDeVentas.Clear();
                GuardarArchivoVentas();

                //BORRAR MOTO DEL ARCHIVO.TXT DE MOTOS PORQUE ESTE SE VENDIO
                Motos ObjetoEliminar = ListaDeMotos.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (ObjetoEliminar != null)
                {
                    ListaDeMotos.Remove(ObjetoEliminar);
                }
                // GRABA LA LISTA DE MOTOS EN EL ARCHIVO.TXT DE MOTOS PARA ACTUALIZAR Y SABER QUE MOTOS ESTAN A LA VENTA
                Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                foreach (Motos item in ListaDeMotos)
                {
                    string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Cilindrada;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();
                // SE VUELVE A CARGA LA LISTA_DE AUTOS DESDE EL ARCHIVO_AUTO_TXT
                // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
                ListaDeMotos.Clear();
                StreamReader leer;
                Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Open);//cambiar archivo
                leer = new StreamReader(Archivo);
                while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
                {
                    string cadena = leer.ReadLine();
                    string[] datos = cadena.Split(';');
                    Motos moto = new Motos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], int.Parse(datos[12]));
                    ListaDeMotos.Add(moto);
                }
                leer.Close();
                Archivo.Close();
            }
            else if (tipo == " Camion") // VENTA CAMION
            {
                int idAuto = 0;
                string patente = null;
                string marca = null;
                string modelo = null;
                int año = 0;
                string color = null;
                string nombre = null;
                string apellido = null;
                long dni = 0;
                int precio = 0;

                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                           *** Lista de Camiones a la venta ***");
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                foreach (Camiones item in ListaDeCamiones)
                {
                    Console.WriteLine("   | ID:" + item.Id_Vehiculo + " | Marca: " + item.Id_Marca + " | Modelo: " + item.Modelo + " | Segmento: " + item.Id_Segmento + " | Km: " + item.Kilometro + " | Año: " + item.Año + " | Color " + item.Color + " | Precio: " + item.Precio_venta);
                }
                Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el ID del vehiculo que desea comprar :");
                int idvehiculo2 = ValidarNum();//ID DEL VEHICULO PARA BUSCAR EN EL ARCHIVO LISTAS_AUTOS.TXT
                while (idvehiculo2 < 1 || idvehiculo2 > ListaDeCamiones.Count())
                {
                    Console.Write("   El camion seleccionado no existe, vuelva a ingresar su opcion: ");
                    idvehiculo2 = ValidarNum();
                }
                // Utiliza la función Find para buscar el objeto en la lista
                Camiones objetoBuscado = ListaDeCamiones.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (objetoBuscado != null)
                {
                    // Guarda los datos del objeto encontrado en variables
                    idAuto = objetoBuscado.Id_Vehiculo;
                    patente = objetoBuscado.Patente;
                    marca = objetoBuscado.Id_Marca;
                    modelo = objetoBuscado.Modelo;
                    año = objetoBuscado.Año;
                    color = objetoBuscado.Color;
                }

                Console.WriteLine("");
                //CARGA LA LISTA CON LOS CLIENTES DEL ARCHIVO TXT
                ListaDeClientes.Clear();
                GuardarArchivoClientes();
                bool resp = true;
                while (resp == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                                             *** Lista de Clientes *** ");
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    foreach (Clientes cliente in ListaDeClientes)
                    {
                        Console.WriteLine("   | Id: " + cliente.Id_Cliente + " | Apellido: " + cliente.Apellido + " | Nombre: " + cliente.Nombre + " | Dni: " + cliente.Dni);
                    }
                    Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("   Si no existe el cliente en la lista escriba: 999 ");
                    Console.WriteLine("");
                    Console.Write("   Ingrese el id del cliente si es que esta cargado en el sistema: ");
                    int idcliente = ValidarNum();
                    Console.WriteLine("");
                    int op;

                    Clientes ClienteBuscado = ListaDeClientes.FirstOrDefault(item => item.Id_Cliente == idcliente);

                    // Verifica si se encontró el objeto
                    if (ClienteBuscado != null)
                    {
                        // El objeto fue encontrado, puedes acceder a sus propiedades
                        nombre = ClienteBuscado.Nombre;
                        apellido = ClienteBuscado.Apellido;
                        dni = ClienteBuscado.Dni;
                        resp = false;
                    }
                    else if (idcliente == 999)
                    {
                        AgregarClientes();

                        //SE MUESTRA LA LISTA DE CLIENTES ACTUALIZADA 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                                             *** Lista de Clientes *** ");
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("");
                        foreach (Clientes cliente in ListaDeClientes)
                        {
                            Console.WriteLine("   | Id: " + cliente.Id_Cliente + " | Apellido: " + cliente.Apellido + " | Nombre: " + cliente.Nombre + " | Dni: " + cliente.Dni);
                        }
                        Console.WriteLine("   ----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("   Si no existe el cliente en la lista escriba: 999 ");
                        Console.WriteLine("");
                        Console.Write("   Ingrese el id del cliente si es que esta cargado en el sistema: ");
                        Console.WriteLine("");
                        idcliente = ValidarNum();
                        Clientes ClienteBuscado2 = ListaDeClientes.FirstOrDefault(item => item.Id_Cliente == idcliente);
                        // Verifica si se encontró el objeto
                        if (ClienteBuscado != null)
                        {
                            // El objeto fue encontrado, puedes acceder a sus propiedades
                            nombre = ClienteBuscado2.Nombre;
                            apellido = ClienteBuscado2.Apellido;
                            dni = ClienteBuscado2.Dni;
                        }
                    }
                    else
                    {
                        //El objeto no fue encontrado
                        Console.WriteLine("");
                        Console.WriteLine("   El id de cliente seleccionado no fue encontrado.");
                        Console.Write("   Desea seguir intentando? 1)SI - 2)NO :");
                        op = ValidarNum();
                        Console.WriteLine("");

                        while (op < 1 || op > 2)
                        {
                            Console.WriteLine("");
                            Console.Write("   Error, vuelva ingresar su  opcion: ");
                            op = ValidarNum();
                            Console.WriteLine("");
                        }
                        if (op == 1)
                        {
                            resp = true;
                        }
                        else if (op == 2)
                        {
                            resp = false;
                        }
                        Console.WriteLine("   Para poder continuar debera crear un cliente ");
                    }
                }

                Camiones CamionBuscado = ListaDeCamiones.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (CamionBuscado != null)
                {
                    // El objeto fue encontrado, puedes acceder a sus propiedades
                    precio = CamionBuscado.Precio_venta;
                }
                Console.Write("   Ingrese el descuento que desee: ");
                double descuento = ValidarDouble();
                Console.Write("   Ingrese la fecha de compra: ");
                string fechacompra = Console.ReadLine();
                Console.Write("   Ingrese la fecha de entrega: ");
                string fechaentrega = Console.ReadLine();

                Ventas venta = new Ventas(apellido, nombre, dni, fechacompra, fechaentrega, descuento, precio, marca, modelo, patente, año, color);
                ListaDeVentas.Add(venta);

                //GRABAR LA VENTA EN EL ARCHIVO VENTAS.TXT
                FileStream Archivo;
                StreamWriter Grabar;
                Archivo = new FileStream("ARCHIVO_VENTAS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                foreach (Ventas item in ListaDeVentas)
                {
                    string cadena = item.Apellido + ";" + item.Nombre + ";" + item.Dni + ";" + item.Precio + ";" + item.Iva + ";" + item.Descuento + ";" + item.Total + ";" + item.MARCA + ";" + item.MODELO + ";" + item.AÑO + ";" + item.COLOR;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();

                //GRABAR EL CAMION ENCONTRADO POR ID (QUE FUE VENDIDO) EN EL ARCHIVO DE CAMIONES VENDIDOS.TXT
                Archivo = new FileStream("ARCHIVO_CAMIONES_VENDIDOS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                if (idvehiculo2 >= 0 && idvehiculo2 < ListaDeCamiones.Count())
                {
                    Camiones camionAGuardar = ListaDeCamiones[idvehiculo2];
                    // Crear una cadena con los datos del auto
                    string datosCamion = $"{camionAGuardar.Id_Vehiculo};{camionAGuardar.Patente};{camionAGuardar.Kilometro};{camionAGuardar.Año};{camionAGuardar.Id_Marca};{camionAGuardar.Modelo};{camionAGuardar.Id_Segmento};{camionAGuardar.Id_Combustible};{camionAGuardar.Precio_venta};{camionAGuardar.Color};{camionAGuardar.Caja_Carga};{camionAGuardar.Dimensiones_Caja};{camionAGuardar.Carga_Max}";
                    // Escribir los datos del auto en el archivo
                    Grabar.WriteLine(datosCamion);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();

                //LIMPIAR LA LISTA DE VENTAS Y VOLVER A CARGARLA
                ListaDeVentas.Clear();
                GuardarArchivoVentas();

                //BORRAR CAMION ENCONTRADO POR ID DEL ARCHIVO DE AUTOS PORQUE ESTE SE VENDIO
                Camiones ObjetoEliminar = ListaDeCamiones.FirstOrDefault(item => item.Id_Vehiculo == idvehiculo2);
                if (ObjetoEliminar != null)
                {
                    ListaDeCamiones.Remove(ObjetoEliminar);
                }
                // GRABA LA LISTA DE CAMIONES EN EL ARCHIVO DE CAMIONES PARA ACTUALIZAR Y SABER QUE CAMIONES ESTAN A LA VENTA
                Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                foreach (Camiones item in ListaDeCamiones)
                {
                    string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Caja_Carga + ";" + item.Dimensiones_Caja + ";" + item.Carga_Max;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();
                // SE VUELVE A CARGA LA LISTA_DE AUTOS DESDE EL ARCHIVO_AUTO_TXT
                // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
                ListaDeCamiones.Clear();
                StreamReader leer;
                Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Open);
                leer = new StreamReader(Archivo);
                while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
                {
                    string cadena = leer.ReadLine();
                    string[] datos = cadena.Split(';');
                    Camiones camion = new Camiones(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], datos[12], int.Parse(datos[13]), int.Parse(datos[14]));
                    ListaDeCamiones.Add(camion);
                }
                leer.Close();
                Archivo.Close();
            }

        }


        public void ListaDeVentasRealizadas()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_VENTAS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   -------------------------------");
            Console.WriteLine("   *** LISTA DE VENTAS GENERAL *** ");
            Console.WriteLine("   -------------------------------");
            Console.WriteLine("");

            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("  No hay ninguna venta cargada en la lista");
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"   | Apellido:{datos[0]}| Nombre:{datos[1]}| DNI:{datos[2]}|| Marca:{datos[7]}| Modelo:{datos[8]}| Año:{datos[9]}| Color:{datos[10]}| Precio:{datos[3]}| Descuento:{datos[5]}| Total:{datos[6]}| Color:{datos[10]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }

        public void ListaDeAutosVendidos()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_AUTOS_VENDIDOS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   -------------------------------");
            Console.WriteLine("   *** LISTA DE AUTOS VENDIDOS *** ");
            Console.WriteLine("   -------------------------------");
            Console.WriteLine("");
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("  No hay ningun auto cargado en la lista");
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID:{datos[0]} | Patente:{datos[1]} | KM:{datos[2]} | Año:{datos[3]} | Marca:{datos[4]} | Modelo:{datos[5]} | Segmento:{datos[6]} | Combustible:{datos[7]} | Precio:{datos[8]} | Color:{datos[9]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }

        public void ListaDeMotosVendidas()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MOTOS_VENDIDAS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   -------------------------------");
            Console.WriteLine("   *** LISTA DE MOTOS VENDIDAS *** ");
            Console.WriteLine("   -------------------------------");
            Console.WriteLine("");
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("  No hay ningun auto cargado en la lista");
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID:{datos[0]} | Patente:{datos[1]} | KM:{datos[2]} | Año:{datos[3]} | Marca:{datos[4]} | Modelo:{datos[5]} | Segmento:{datos[6]} | Combustible:{datos[7]} | Precio:{datos[8]} | Color:{datos[9]} | Cilindrada: {datos[11]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }
        public void ListaDeCamionesVendidos()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CAMIONES_VENDIDOS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   -------------------------------");
            Console.WriteLine("   *** LISTA DE CAMIONES VENDIDOS *** ");
            Console.WriteLine("   -------------------------------");
            Console.WriteLine("");
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("  No hay ningun auto cargado en la lista");
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID:{datos[0]} | Patente:{datos[1]} | KM:{datos[2]} | Año:{datos[3]} | Marca:{datos[4]} | Modelo:{datos[5]} | Segmento:{datos[6]} | Combustible:{datos[7]} | Precio:{datos[8]} | Color:{datos[9]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }
        public void GuardarArchivoVentas()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_VENTAS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                string apellido = datos[0];
                string nombre = datos[1];
                long dni = long.Parse(datos[2]);
                string fecom = datos[3];
                string fecent = datos[4];
                double desc = double.Parse(datos[5]);
                double prec = double.Parse(datos[6]);

                Ventas venta = new Ventas(apellido, nombre, dni, fecom, fecent, desc, prec);
                ListaDeVentas.Add(venta);
            }
            leer.Close();
            Archivo.Close();
        }

        public void AgregarVehiculo()
        {
            string patente;
            int kilometros;
            int año;
            int IDM;
            string marca;
            string modelo;
            string segmento;
            string combustible;
            int precio;
            string observaciones;
            string color;
            int cilindrada;
            string caja_carga;
            int dimensiones;
            int carmaxima;


            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("   *** Datos Del Vehiculo ***");
            Console.WriteLine("");
            //MOSTRAR LISTA DE TIPO DE VEHICULO Y PEDIR ID
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   -----------------------------------");
            Console.WriteLine("   *** Lista de Tipos de Vehiculos ***");
            foreach ((int, string) item in ListaDeTipo)
            {
                Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
            }
            Console.WriteLine("   -----------------------------------");
            Console.ResetColor();
            Console.Write("   Ingrese el tipo de vehiculo: ");
            int idvehiculo = ValidarNum();

            while (idvehiculo < 1 || idvehiculo > 3)
            {
                Console.Write("   El tipo seleccionado no existe, vuelva a ingresar su opcion: ");
                idvehiculo = ValidarNum();

            }
            string datoColumna2P = ListaDeTipo[idvehiculo - 1].Item2;
            string tipo = datoColumna2P;

            //SEGUN EL TIPO DE VEHICULO PEDIR DATOS// 
            if (tipo == " Auto") // TIPO AUTO
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   ---------------------------");
                Console.WriteLine("   | CARGA DE DATOS DEL AUTO |");
                Console.WriteLine("   ---------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese Patente: ");
                patente = Console.ReadLine();
                Console.Write("   Ingrese Kilometros: ");
                kilometros = ValidarNum();
                Console.Write("   Ingrese Año: ");
                año = ValidarNum();
                Console.ForegroundColor = ConsoleColor.Yellow;

                ListaDeMarcas.Clear();
                GuardarArchivoMarcas();

                Console.WriteLine("   -----------------------");
                Console.WriteLine("   *** Lista de Marcas ***");
                foreach (Marcas item in ListaDeMarcas)
                {
                    Console.WriteLine($"   {item.Id_Marca} - Marcas : {item.NombreMarca} ");
                }
                Console.WriteLine("   -----------------------");
                Console.ResetColor();
                Console.WriteLine("   Si no existe la marca en la lista escriba: 99");
                Console.Write("   Ingrese el id de la Marca: ");
                IDM = ValidarNum();
                if (IDM == 99)
                {
                    AgregarMarca_99();
                    //UNA VEZ YA CREADA LA NUEVA MARCA SE MUESTRA LA LISTA NUEVAMENTE
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   -----------------------");
                    Console.WriteLine("   *** Lista de Marcas ***");
                    foreach (Marcas item in ListaDeMarcas)
                    {
                        Console.WriteLine($"   {item.Id_Marca} - Marca : {item.NombreMarca} ");
                    }
                    Console.WriteLine("   -----------------------");
                    Console.ResetColor();
                    Console.Write($"   Seleccione el id de la marca: ");
                    IDM = ValidarNum();
                    while (IDM < 1 || IDM > ListaDeMarcas.Count())
                    {
                        Console.Write("   La marca seleccionada no existe, vuelva a ingresar su opcion: ");
                        IDM = ValidarNum();

                    }
                }
                while (IDM < 1 || IDM > ListaDeMarcas.Count())
                {
                    Console.Write("   La marca seleccionada no existe, vuelva a ingresar su opcion: ");
                    IDM = ValidarNum();

                }

                marca = ListaDeMarcas[IDM - 1].NombreMarca;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el Modelo: ");
                modelo = Console.ReadLine();
                // LISTA DE SEGMENTOS//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   *** Lista de Segmentos ***");
                var primerosCuatro = ListaDeSegmentos.Take(4);
                foreach ((int, string) item in primerosCuatro)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.WriteLine("   -----------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del segmento: ");
                int idsegmento = ValidarNum();
                while (idsegmento < 1 || idsegmento > 4)
                {
                    Console.Write("   El segmento seleccionado no existe, vuelva a ingresar su opcion: ");
                    idsegmento = ValidarNum();

                }

                string datonombre = ListaDeSegmentos[idsegmento - 1].Item2; //indice cero en el array
                segmento = datonombre;
                //---------------------------------------------------------------------------------------------------//
                // LISTA DE COMBUSTIBLES//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------");
                Console.WriteLine("   *** Lista de Combustibles ***");
                foreach ((int, string) item in ListaDeCombustibles)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.WriteLine("   ------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del combustible: ");
                int idcombustible = ValidarNum();
                while (idcombustible < 1 || idcombustible > 4)
                {
                    Console.Write("   El combustible seleccionado no existe, vuelva a ingresar su opcion: ");
                    idcombustible = ValidarNum();
                }
                datonombre = ListaDeCombustibles[idcombustible - 1].Item2;
                combustible = datonombre;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el precio del vehiculo: ");
                precio = ValidarNum();
                Console.Write("   Ingrese Observaciones: ");
                observaciones = Console.ReadLine();
                Console.Write("   Ingrese Color: ");
                color = Console.ReadLine().ToUpper();
                //---------------------------------------------------------------------------------------------------//
                idAutoIntegral +=1;


                ListaDeAutos.Add(new Autos { Id_Vehiculo = idAutoIntegral, Patente = patente, Kilometro = kilometros, Año = año, Id_Marca = marca, Modelo = modelo, Id_Segmento = segmento, Id_Combustible = combustible, Precio_venta = precio, Observaciones = observaciones, Color = color, Tipo = tipo });
                //GRABAR LA LISTA DE AUTOS EN EL ARCHIVO AUTOS//
                FileStream Archivo;
                StreamWriter Grabar;
                Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                foreach (Autos item in ListaDeAutos)
                {
                    string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo;
                    Grabar.WriteLine(cadena);

                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();
                //CARGAR LA LISTA DE VEHICULOS CON LOS DATOS DEL ARCHIVO.TXT DE AUTOS//
                // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
                ListaDeAutos.Clear();
                StreamReader leer;
                Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Open);//cambiar archivo
                leer = new StreamReader(Archivo);
                while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
                {

                    string cadena = leer.ReadLine();
                    string[] datos = cadena.Split(';');

                    Autos auto = new Autos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11]);
                    ListaDeAutos.Add(auto);
                }
                leer.Close();
                Archivo.Close();
                // ---------------------------------------------------------------------- //
            }// FIN TIPO AUTO
            else if (tipo == " Moto") //TIPO MOTO
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  -----------------------------");
                Console.WriteLine("  | CARGA DE DATOS DE LA MOTO |");
                Console.WriteLine("  -----------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese Patente: ");
                patente = Console.ReadLine();
                Console.Write("   Ingrese Kilometros: ");
                kilometros = ValidarNum();
                Console.Write("   Ingrese Año: ");
                año =   ValidarNum();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -------------------------------");
                Console.WriteLine("   *** Lista de Marcas de Motos***");
                foreach (Marcas item in ListaDeMarcasMotos)
                {
                    Console.WriteLine($"   {item.Id_Marca} - Marcas : {item.NombreMarca} ");
                }
                Console.WriteLine("   -------------------------------");
                Console.ResetColor();
                Console.WriteLine("   Si no existe la marca en la lista escriba: 99");
                Console.Write("   Ingrese el id de la Marca: ");
                IDM = ValidarNum();
                if (IDM == 99)
                {
                    AgregarMarcaMoto_99();
                    //UNA VEZ YA CREADA LA NUEVA MARCA SE MUESTRA LA LISTA NUEVAMENTE
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   -------------------------------");
                    Console.WriteLine("   *** Lista de Marcas de Motos***");
                    foreach (Marcas item in ListaDeMarcasMotos)
                    {
                        Console.WriteLine($"   {item.Id_Marca} - Marca : {item.NombreMarca} ");
                    }
                    Console.WriteLine("   -------------------------------");
                    Console.ResetColor();
                    Console.Write($"   Seleccione el id de la marca: ");
                    IDM = ValidarNum();
                    while (IDM < 1 || IDM > ListaDeMarcas.Count())
                    {
                        Console.Write("   La marca seleccionada no existe, vuelva a ingresar su opcion: ");
                        IDM = ValidarNum();
                    }
                }
                while (IDM < 1 || IDM > ListaDeMarcasMotos.Count())
                {
                    Console.Write("   La marca seleccionada no existe, vuelva a ingresar su opcion: ");
                    IDM = ValidarNum();
                }
                marca = ListaDeMarcasMotos[IDM - 1].NombreMarca;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el Modelo: ");
                modelo = Console.ReadLine();
                // LISTA DE SEGMENTOS//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------------");
                Console.WriteLine("   *** Lista de Segmentos de Motos ***");
                int startIndex = 4; // Índice del 4º objeto (empezando desde 0)//
                int count = 3;     // Número de objetos a mostrar (4º al 7º)
                if (startIndex >= 0 && startIndex < ListaDeSegmentos.Count)
                {
                    // Usar GetRange para obtener los elementos desde el 4º al 7º
                    List<(int, string)> segmentosSublista = ListaDeSegmentos.GetRange(startIndex, count);
                    // Mostrar los elementos
                    foreach (var segmento2 in segmentosSublista)
                    {
                        Console.WriteLine($"   ID: {segmento2.Item1 - 4} - {segmento2.Item2}");
                    }
                }
                else
                {
                    Console.WriteLine("El índice de inicio está fuera de rango.");
                }
                Console.WriteLine("   -----------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del segmento: ");
                int idsegmento = ValidarNum();
                while (idsegmento < 1 || idsegmento > 3)
                {
                    Console.Write("   El segmento seleccionado no existe, vuelva a ingresar su opcion: ");
                    idsegmento = ValidarNum();
                }
                string datonombre = ListaDeSegmentos[idsegmento + 3].Item2;
                segmento = datonombre;
                //---------------------------------------------------------------------------------------------------//
                // LISTA DE COMBUSTIBLES//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------");
                Console.WriteLine("   *** Lista de Combustibles ***");
                foreach ((int, string) item in ListaDeCombustibles)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.WriteLine("   ------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del combustible: ");
                int idcombustible = ValidarNum();
                while (idcombustible < 1 || idcombustible > 4)
                {
                    Console.Write("   El combustible seleccionado no existe, vuelva a ingresar su opcion: ");
                    idcombustible = ValidarNum();
                }
                datonombre = ListaDeCombustibles[idcombustible - 1].Item2;
                combustible = datonombre;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el precio del vehiculo: ");
                precio = ValidarNum();
                Console.Write("   Ingrese Observaciones: ");
                observaciones = Console.ReadLine();
                Console.Write("   Ingrese Color: ");
                color = Console.ReadLine().ToUpper();
                Console.Write("   Ingrese Cilindrada: ");
                cilindrada = ValidarNum();
                idMotoIntegral += 1;
                //FIN DE CARGA DE DATOS A VARIABLES//
                ListaDeMotos.Add(new Motos { Id_Vehiculo = idMotoIntegral, Patente = patente, Kilometro = kilometros, Año = año, Id_Marca = marca, Modelo = modelo, Id_Segmento = segmento, Id_Combustible = combustible, Precio_venta = precio, Observaciones = observaciones, Color = color, Tipo = tipo, Cilindrada = cilindrada });
                //GRABAR LA LISTA DE MOTOS EN EL ARCHIVO DE MOTOS//
                FileStream Archivo;
                StreamWriter Grabar;
                Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);
                foreach (Motos item in ListaDeMotos)
                {
                    string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo + ";" + item.Cilindrada;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();
                // CARGAR LA LISTA DE MOTOS CON LOS DATOS DEL ARCHIVO.TXT DE MOTOS //
                // PRIMERO SE VACIA LA LISTA DE MOTOS PARA NO VOLVER A COPIAR LO COPIADO //
                ListaDeMotos.Clear();
                StreamReader leer;
                Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Open);
                leer = new StreamReader(Archivo);
                while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
                {
                    string cadena = leer.ReadLine();
                    string[] datos = cadena.Split(';');

                    Motos moto = new Motos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], int.Parse(datos[12]));
                    ListaDeMotos.Add(moto);
                }
                leer.Close();
                Archivo.Close();
                // ---------------------------------------------------------------------- //
            }//FIN DE MOTOS
            else if (tipo == " Camion")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   ---------------------------");
                Console.WriteLine("   | CARGA DE DATOS DEL CAMION |");
                Console.WriteLine("   ---------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese Patente: ");
                patente = Console.ReadLine();
                Console.Write("   Ingrese Kilometros: ");
                kilometros = ValidarNum();
                Console.Write("   Ingrese Año: ");
                año = ValidarNum();
                // VACIADO DE LISTA Y RELLENADO CON EL ARCHIVO MARCAS.TXT
                ListaDeMarcas.Clear();
                GuardarArchivoMarcas();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   *** Lista de Marcas ***");
                foreach (Marcas item in ListaDeMarcas)
                {
                    Console.WriteLine($"   {item.Id_Marca} - Marcas : {item.NombreMarca} ");
                }
                Console.WriteLine("   -----------------------");
                Console.ResetColor();
                Console.WriteLine("   Si no existe la marca en la lista escriba: 99");
                Console.Write("   Ingrese el id de la Marca: ");
                IDM = ValidarNum();
                if (IDM == 99)
                {
                    AgregarMarca_99();
                    //UNA VEZ YA CREADA LA NUEVA MARCA SE MUESTRA LA LISTA NUEVAMENTE
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   -----------------------");
                    Console.WriteLine("   *** Lista de Marcas ***");
                    foreach (Marcas item in ListaDeMarcas)
                    {
                        Console.WriteLine($"   {item.Id_Marca} - Marca : {item.NombreMarca} ");
                    }
                    Console.WriteLine("   -----------------------");
                    Console.ResetColor();
                    Console.Write($"   Seleccione el id de la marca: ");
                    IDM = ValidarNum();
                    while (IDM < 1 || IDM > ListaDeMarcas.Count())
                    {
                        Console.Write("   La marca seleccionada no existe, vuelva a ingresar su opcion: ");
                        IDM = ValidarNum();
                    }
                }
                while (IDM < 1 || IDM > ListaDeMarcas.Count())
                {
                    Console.Write("   La marca seleccionada no existe, vuelva a ingresar su opcion: ");
                    IDM =   ValidarNum();
                }
                marca = ListaDeMarcas[IDM - 1].NombreMarca;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el Modelo: ");
                modelo = Console.ReadLine();
                segmento = " Camion";
                //---------------------------------------------------------------------------------------------------//
                // LISTA DE COMBUSTIBLES//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------");
                Console.WriteLine("   *** Lista de Combustibles ***");
                foreach ((int, string) item in ListaDeCombustibles)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.WriteLine("   ------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del combustible: ");
                int idcombustible = ValidarNum();
                while (idcombustible < 0 || idcombustible > 4)
                {
                    Console.Write("   El combustible seleccionado no existe, vuelva a ingresar su opcion: ");
                    idcombustible = ValidarNum();
                }
                string datonombre = ListaDeCombustibles[idcombustible - 1].Item2;
                combustible = datonombre;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el precio del vehiculo: ");
                precio = ValidarNum();
                Console.Write("   Ingrese Observaciones: ");
                observaciones = Console.ReadLine();
                Console.Write("   Ingrese Color: ");
                color = Console.ReadLine().ToUpper();
                Console.Write("   Ingrese Caja_Carga: ");
                caja_carga = Console.ReadLine();
                Console.WriteLine("   Ingrese Dimensiones de la Caja ");
                Console.Write("   Largo (m): ");
                int C_Largo = ValidarNum();
                Console.Write("   Ancho (m): ");
                int C_Ancho = ValidarNum();
                Console.Write("   Alto (m): ");
                int C_Alto = ValidarNum();
                dimensiones = C_Ancho * C_Largo * C_Alto;
                Console.Write("   Ingrese Carga Maxima: ");
                carmaxima = ValidarNum();
                //---------------------------------------------------------------------------------------------------//
                idCamionIntegral += 1;
                ListaDeCamiones.Add(new Camiones { Id_Vehiculo = idCamionIntegral, Patente = patente, Kilometro = kilometros, Año = año, Id_Marca = marca, Modelo = modelo, Id_Segmento = segmento, Id_Combustible = combustible, Precio_venta = precio, Observaciones = observaciones, Color = color, Tipo = tipo, Caja_Carga = caja_carga, Dimensiones_Caja = dimensiones, Carga_Max = carmaxima });
                //GRABAR LA LISTA DE CAMIONES  EN EL ARCHIVO DE CAMIONES//
                FileStream Archivo;
                StreamWriter Grabar;
                Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Create);// cambiar archivo
                Grabar = new StreamWriter(Archivo);
                foreach (Camiones item in ListaDeCamiones)
                {
                    string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo + ";" + item.Caja_Carga + ";" + item.Dimensiones_Caja + ";" + item.Carga_Max;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();
                //CARGAR LA LISTA DE CAMIONES CON LOS DATOS DEL ARCHIVO.TXT DE AUTOS//
                // PRIMERO SE VACIA LA LISTA DE CAMIONES PARA NO VOLVER A COPIAR LO COPIADO//
                ListaDeCamiones.Clear();
                StreamReader leer;
                Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Open);//cambiar archivo
                leer = new StreamReader(Archivo);
                while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
                {

                    string cadena = leer.ReadLine();
                    string[] datos = cadena.Split(';');

                    Camiones camion = new Camiones(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], datos[12], int.Parse(datos[13]), int.Parse(datos[14]));
                    ListaDeCamiones.Add(camion);
                }
                leer.Close();
                Archivo.Close();
            }//FIN CAMION

        }

        public void AgregarMarca_99()//AGREGAR UNA MARCA DESDE AUTOS/CAMION
        {
            Console.WriteLine("");
            Console.Write("   Ingrese la Marca : ");
            string nombre = Console.ReadLine();
            int idmarca = ListaDeMarcas.Count() + 1;

            Marcas marca = new Marcas(idmarca, nombre);
            ListaDeMarcas.Add(marca); // SE AGREGO A LA LISTA LA NUEVA MARCA

            // SE PROCEDE A GUARDAR LA LISTA EN EL ARCHIVO //
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Marcas item in ListaDeMarcas)
            {
                string cadena = item.Id_Marca + ";" + item.NombreMarca;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();

            // SE PROCEDE A COPIAR LO DEL ARCHIVO.TXT A LA LISTA DE MARCAS //
            // PRIMERO SE VACIA LA LISTA PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeMarcas.Clear();

            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                int id = int.Parse(datos[0]);
                string nombre2 = datos[1];

                Marcas marca2 = new Marcas(id, nombre2);
                ListaDeMarcas.Add(marca2);
            }
            leer.Close();
            Archivo.Close();
        }

        public void AgregarMarcaMoto_99()//AGREGAR UNA MARCA DESDE MOTOS
        {
            Console.WriteLine("");
            Console.Write("   Ingrese la Marca : ");
            string nombre = Console.ReadLine();
            int idmarca = ListaDeMarcasMotos.Count() + 1;

            Marcas marca = new Marcas(idmarca, nombre);
            ListaDeMarcasMotos.Add(marca); // SE AGREGO A LA LISTA LA NUEVA MARCA

            // SE PROCEDE A GUARDAR LA LISTA EN EL ARCHIVO //
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_MARCAS_MOTOS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Marcas item in ListaDeMarcasMotos)
            {
                string cadena = item.Id_Marca + ";" + item.NombreMarca;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();

            // SE PROCEDE A COPIAR LO DEL ARCHIVO.TXT A LA LISTA DE MARCAS DE MOTOS //
            // PRIMERO SE VACIA LA LISTA PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeMarcasMotos.Clear();

            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MARCAS_MOTOS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                int id = int.Parse(datos[0]);
                string nombre2 = datos[1];

                Marcas marca2 = new Marcas(id, nombre2);
                ListaDeMarcasMotos.Add(marca2);
            }
            leer.Close();
            Archivo.Close();
        }


        public void MostrarAutos()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("   No hay ningun auto cargado en la lista");
                Console.ReadKey();
                Console.Clear();
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID:{datos[0]}-Patente:{datos[1]}-KM:{datos[2]}-Año:{datos[3]}-Marca:{datos[4]}-Modelo:{datos[5]}-Segmento:{datos[6]}-Combustible:{datos[7]}-Precio:{datos[8]}-Observaciones:{datos[9]}-Color:{datos[10]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }
        public void MostrarMotos()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("   No hay ningun moto cargada en la lista");
                Console.ReadKey();
                Console.Clear();
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID:{datos[0]}-Patente:{datos[1]}-KM:{datos[2]}-Año:{datos[3]}-Marca:{datos[4]}-Modelo:{datos[5]}-Segmento:{datos[6]}-Combustible:{datos[7]}-Precio:{datos[8]}-Observaciones:{datos[9]}-Color:{datos[10]}-Cilindrada:{datos[12]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }
        public void MostrarCamiones()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("   No hay ningun camion cargado en la lista");
                Console.ReadKey();
                Console.Clear();
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID:{datos[0]}-Patente:{datos[1]}-KM:{datos[2]}-Año:{datos[3]}-Marca:{datos[4]}-Modelo:{datos[5]}-Segmento:{datos[6]}-Combustible:{datos[7]}-Precio:{datos[8]}-Observaciones:{datos[9]}-Color:{datos[10]}-Caja:{datos[12]}-Dimensiones:{datos[13]}-CargaMaxima:{datos[14]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }


        public void ActualizarAuto()
        {
            MostrarAutos();
            Console.WriteLine("");
            Console.Write("   Escriba el ID del auto para actualizar: ");
            int AutoIDActualizar = ValidarNum();

            // PREGUNTA SI EXISTE EL NUMERO DE ID PARA MODIFICAR EL AUTO
            Autos autoActualizar = ListaDeAutos.FirstOrDefault(c => c.Id_Vehiculo == AutoIDActualizar);

            if (autoActualizar != null)
            {
                // Actualizar los datos del cliente.
                autoActualizar.Id_Vehiculo = AutoIDActualizar;
                Console.WriteLine("");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   ---------------------------");
                Console.WriteLine("   | CARGA DE DATOS DEL AUTO |");
                Console.WriteLine("   ---------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese Patente: ");
                autoActualizar.Patente = Console.ReadLine();
                Console.Write("   Ingrese Kilometros: ");
                autoActualizar.Kilometro = ValidarNum();
                Console.Write("   Ingrese Año: ");
                autoActualizar.Año = ValidarNum();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   *** Lista de Marcas ***");
                foreach (Marcas item in ListaDeMarcas)
                {
                    Console.WriteLine($"   {item.Id_Marca} - Marcas : {item.NombreMarca} ");
                }
                Console.WriteLine("   -----------------------");
                Console.ResetColor();
                Console.WriteLine("   Si no existe la marca en la lista escriba: 99");
                Console.Write("   Ingrese el id de la Marca: ");
                int IDM = ValidarNum();
                if (IDM == 99)
                {
                    AgregarMarca_99();
                    //UNA VEZ YA CREADA LA NUEVA MARCA SE MUESTRA LA LISTA NUEVAMENTE
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   -----------------------");
                    Console.WriteLine("   *** Lista de Marcas ***");
                    foreach (Marcas item in ListaDeMarcas)
                    {
                        Console.WriteLine($"   {item.Id_Marca} - Marca : {item.NombreMarca} ");
                    }
                    Console.WriteLine("   -----------------------");
                    Console.ResetColor();
                    Console.Write($"   Seleccione el id de la marca: ");
                    IDM = ValidarNum();
                }
                autoActualizar.Id_Marca = ListaDeMarcas[IDM].NombreMarca;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el Modelo: ");
                autoActualizar.Modelo = Console.ReadLine();
                // LISTA DE SEGMENTOS//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   *** Lista de Segmentos ***");
                var primerosCuatro = ListaDeSegmentos.Take(4);
                foreach ((int, string) item in primerosCuatro)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.WriteLine("   -----------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del segmento: ");
                int idsegmento = ValidarNum();
                string datonombre = ListaDeSegmentos[idsegmento - 1].Item2;
                while (idsegmento < 0 && idsegmento > ListaDeSegmentos.Count())
                {
                    Console.Write("   El segmento seleccionado no existe, vuelva a ingresar su opcion: ");
                    idsegmento = ValidarNum();
                    datonombre = ListaDeSegmentos[idsegmento].Item2;
                }
                autoActualizar.Id_Segmento = datonombre;
                //---------------------------------------------------------------------------------------------------//
                // LISTA DE COMBUSTIBLES//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------");
                Console.WriteLine("   *** Lista de Combustibles ***");
                foreach ((int, string) item in ListaDeCombustibles)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.WriteLine("   ------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del combustible: ");
                int idcombustible = ValidarNum();
                datonombre = ListaDeCombustibles[idcombustible - 1].Item2;
                while (idcombustible < 0 && idcombustible > ListaDeCombustibles.Count())
                {
                    Console.Write("   El combustible seleccionado no existe, vuelva a ingresar su opcion: ");
                    idcombustible = ValidarNum();
                    datonombre = ListaDeCombustibles[idcombustible].Item2;
                }
                autoActualizar.Id_Combustible = datonombre;
                autoActualizar.Tipo = " Auto";
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el precio del vehiculo: ");
                autoActualizar.Precio_venta = ValidarNum();
                Console.Write("   Ingrese Observaciones: ");
                autoActualizar.Observaciones = Console.ReadLine();
                Console.Write("   Ingrese Color: ");
                autoActualizar.Color = Console.ReadLine().ToUpper();
            }
            else
            {
                Console.WriteLine($"   Cliente con ID {AutoIDActualizar} no encontrado.");
            }
            //GRABA LA LISTA DE AUTOS DE NUEVO EN EL ARCHIVO TXT DE AUTOS 
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Autos item in ListaDeAutos)
            {
                string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo;
                Grabar.WriteLine(cadena);

            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            //CARGAR LA LISTA DE VEHICULOS CON LOS DATOS DEL ARCHIVO.TXT DE AUTOS//
            // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeAutos.Clear();
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Open);//cambiar archivo
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {

                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Autos auto = new Autos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11]);
                ListaDeAutos.Add(auto);
            }
            leer.Close();
            Archivo.Close();
            // ---------------------------------------------------------------------- //
        }
        public void ActualizarMoto()
        {
            MostrarMotos();
            Console.WriteLine("");
            Console.Write("   Escriba el ID de la moto para actualizar: ");
            int MotoIDActualizar = ValidarNum();

            // PREGUNTA SI EXISTE EL NUMERO DE ID PARA MODIFICAR EL AUTO
            Motos motoActualizar = ListaDeMotos.FirstOrDefault(c => c.Id_Vehiculo == MotoIDActualizar);

            if (motoActualizar != null)
            {
                // Actualizar los datos del cliente.
                motoActualizar.Id_Vehiculo = MotoIDActualizar;
                Console.WriteLine("");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   ---------------------------");
                Console.WriteLine("   | CARGA DE DATOS DE LA MOTO |");
                Console.WriteLine("   ---------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese Patente: ");
                motoActualizar.Patente = Console.ReadLine();
                Console.Write("   Ingrese Kilometros: ");
                motoActualizar.Kilometro = ValidarNum();
                Console.Write("   Ingrese Año: ");
                motoActualizar.Año = ValidarNum();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   *** Lista de Marcas ***");
                foreach (Marcas item in ListaDeMarcasMotos)
                {
                    Console.WriteLine($"   {item.Id_Marca} - Marcas : {item.NombreMarca} ");
                }
                Console.WriteLine("   -----------------------");
                Console.ResetColor();
                Console.WriteLine("   Si no existe la marca en la lista escriba: 99");
                Console.Write("   Ingrese el id de la Marca: ");
                int IDM = ValidarNum();
                if (IDM == 99)
                {
                    AgregarMarcaMoto_99();
                    //UNA VEZ YA CREADA LA NUEVA MARCA SE MUESTRA LA LISTA NUEVAMENTE
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   --------------------------------");
                    Console.WriteLine("   *** Lista de Marcas de Motos ***");
                    foreach (Marcas item in ListaDeMarcasMotos)
                    {
                        Console.WriteLine($"   {item.Id_Marca} - Marca : {item.NombreMarca} ");
                    }
                    Console.WriteLine("   --------------------------------");
                    Console.ResetColor();
                    Console.Write($"   Seleccione el id de la marca: ");
                    IDM = ValidarNum();
                }
                motoActualizar.Id_Marca = ListaDeMarcasMotos[IDM - 1].NombreMarca;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el Modelo: ");
                motoActualizar.Modelo = Console.ReadLine();
                // LISTA DE SEGMENTOS DE MOTOS//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------------");
                Console.WriteLine("   *** Lista de Segmentos de Motos ***");
                int startIndex = 4; // Índice del 4º objeto (empezando desde 0)//
                int count = 3;     // Número de objetos a mostrar (4º al 7º)
                if (startIndex >= 0 && startIndex < ListaDeSegmentos.Count)
                {
                    // Usar GetRange para obtener los elementos desde el 4º al 7º
                    List<(int, string)> segmentosSublista = ListaDeSegmentos.GetRange(startIndex, count);
                    // Mostrar los elementos
                    foreach (var segmento2 in segmentosSublista)
                    {
                        Console.WriteLine($"   ID: {segmento2.Item1 - 4} - {segmento2.Item2}");
                    }
                }
                else
                {
                    Console.WriteLine("El índice de inicio está fuera de rango.");
                }
                Console.WriteLine("   -----------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del segmento: ");
                int idsegmento = ValidarNum();
                string datonombre = ListaDeSegmentos[idsegmento + 3].Item2;
                while (idsegmento < 0 && idsegmento > ListaDeSegmentos.Count())
                {
                    Console.Write("   El segmento seleccionado no existe, vuelva a ingresar su opcion: ");
                    idsegmento = ValidarNum();
                    datonombre = ListaDeSegmentos[idsegmento + 3].Item2;
                }
                motoActualizar.Id_Segmento = datonombre;
                //---------------------------------------------------------------------------------------------------//
                // LISTA DE COMBUSTIBLES//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------");
                Console.WriteLine("   *** Lista de Combustibles ***");
                foreach ((int, string) item in ListaDeCombustibles)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.WriteLine("   ------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del combustible: ");
                int idcombustible = ValidarNum();
                datonombre = ListaDeCombustibles[idcombustible - 1].Item2;
                while (idcombustible < 0 && idcombustible > ListaDeCombustibles.Count())
                {
                    Console.Write("   El combustible seleccionado no existe, vuelva a ingresar su opcion: ");
                    idcombustible = ValidarNum();
                    datonombre = ListaDeCombustibles[idcombustible].Item2;
                }
                motoActualizar.Id_Combustible = datonombre;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el precio del vehiculo: ");
                motoActualizar.Precio_venta = ValidarNum();
                Console.Write("   Ingrese Observaciones: ");
                motoActualizar.Observaciones = Console.ReadLine();
                Console.Write("   Ingrese Color: ");
                motoActualizar.Color = Console.ReadLine().ToUpper();
                Console.Write("   Ingrese Cilindrada: ");
                motoActualizar.Cilindrada = ValidarNum();
                motoActualizar.Tipo = " Moto";
            }
            else
            {
                Console.WriteLine($"   Cliente con ID {MotoIDActualizar} no encontrado.");
            }
            //GRABA LA LISTA DE MOTOS DE NUEVO EN EL ARCHIVO TXT DE MOTOS 
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Motos item in ListaDeMotos)
            {
                string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo + ";" + item.Cilindrada;
                Grabar.WriteLine(cadena);

            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            //CARGAR LA LISTA DE MOTOS CON LOS DATOS DEL ARCHIVO.TXT DE MOTOS//
            // PRIMERO SE VACIA LA LISTA DE MOTOS PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeMotos.Clear();
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Motos moto = new Motos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], int.Parse(datos[12]));
                ListaDeMotos.Add(moto);
            }
            leer.Close();
            Archivo.Close();
            // ---------------------------------------------------------------------- //
        }
        public void ActualizarUnCamion()
        {
            MostrarCamiones();
            Console.WriteLine("");
            Console.Write("   Escriba el ID del Camion para actualizar: ");
            int CamionIDActualizar = ValidarNum();

            // PREGUNTA SI EXISTE EL NUMERO DE ID PARA MODIFICAR EL CAMION
            Camiones camionActualizar = ListaDeCamiones.FirstOrDefault(c => c.Id_Vehiculo == CamionIDActualizar);

            if (camionActualizar != null)
            {
                // Actualizar los datos del camion.
                camionActualizar.Id_Vehiculo = CamionIDActualizar;
                Console.WriteLine("");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------");
                Console.WriteLine("   | CARGA DE DATOS DEL CAMION |");
                Console.WriteLine("   -----------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese Patente: ");
                camionActualizar.Patente = Console.ReadLine();
                Console.Write("   Ingrese Kilometros: ");
                camionActualizar.Kilometro = ValidarNum();
                Console.Write("   Ingrese Año: ");
                camionActualizar.Año = ValidarNum();
                //BORRAR LISTA DE MARCAS Y VOLVER A COPIARLA DESDE EL ARCHIVO
                ListaDeMarcas.Clear();
                GuardarArchivoMarcas();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------");
                Console.WriteLine("   *** Lista de Marcas ***");
                foreach (Marcas item in ListaDeMarcas)
                {
                    Console.WriteLine($"   {item.Id_Marca} - Marcas : {item.NombreMarca} ");
                }
                Console.WriteLine("   -----------------------");
                Console.ResetColor();
                Console.WriteLine("   Si no existe la marca en la lista escriba: 99");
                Console.Write("   Ingrese el id de la Marca: ");
                int IDM = ValidarNum();
                if (IDM == 99)
                {
                    AgregarMarca_99();
                    //UNA VEZ YA CREADA LA NUEVA MARCA SE MUESTRA LA LISTA NUEVAMENTE
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   -----------------------");
                    Console.WriteLine("   *** Lista de Marcas ***");
                    foreach (Marcas item in ListaDeMarcas)
                    {
                        Console.WriteLine($"   {item.Id_Marca} - Marca : {item.NombreMarca} ");
                    }
                    Console.WriteLine("   -----------------------");
                    Console.Write($"   Seleccione el id de la marca: ");
                    Console.ResetColor();
                    IDM = ValidarNum();
                }
                camionActualizar.Id_Marca = ListaDeMarcas[IDM - 1].NombreMarca;
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el Modelo: ");
                camionActualizar.Modelo = Console.ReadLine();
                // LISTA DE SEGMENTOS//

                camionActualizar.Id_Segmento = " Camion";
                //---------------------------------------------------------------------------------------------------//
                // LISTA DE COMBUSTIBLES//
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   -----------------------------");
                Console.WriteLine("   *** Lista de Combustibles ***");
                foreach ((int, string) item in ListaDeCombustibles)
                {
                    Console.WriteLine("   " + item.Item1 + " - " + item.Item2);
                }
                Console.WriteLine("   ------------------------------");
                Console.ResetColor();
                Console.Write("   Ingrese el id del combustible: ");
                int idcombustible = ValidarNum();
                string datonombre = ListaDeCombustibles[idcombustible - 1].Item2;
                while (idcombustible < 0 && idcombustible > ListaDeCombustibles.Count())
                {
                    Console.Write("   El combustible seleccionado no existe, vuelva a ingresar su opcion: ");
                    idcombustible = ValidarNum();
                    datonombre = ListaDeCombustibles[idcombustible].Item2;
                }
                camionActualizar.Id_Combustible = datonombre;
                camionActualizar.Tipo = " Camion";
                //---------------------------------------------------------------------------------------------------//
                Console.Write("   Ingrese el precio del vehiculo: ");
                camionActualizar.Precio_venta = ValidarNum();
                Console.Write("   Ingrese Observaciones: ");
                camionActualizar.Observaciones = Console.ReadLine();
                Console.Write("   Ingrese Color: ");
                camionActualizar.Color = Console.ReadLine().ToUpper();
                Console.Write("   Ingrese Caja_Carga: ");
                camionActualizar.Caja_Carga = Console.ReadLine();
                Console.Write("   Ingrese Dimensiones de la Caja: ");
                camionActualizar.Dimensiones_Caja = ValidarNum();
                Console.Write("   Ingrese Carga Maxima: ");
                camionActualizar.Carga_Max = ValidarNum();
            }
            else
            {
                Console.WriteLine($"   Cliente con ID {CamionIDActualizar} no encontrado.");
            }
            //GRABA LA LISTA DE CAMIONES DE NUEVO EN EL ARCHIVO TXT DE CAMIONES 
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Camiones item in ListaDeCamiones)
            {
                string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo + ";" + item.Caja_Carga + ";" + item.Dimensiones_Caja + ";" + item.Carga_Max;
                Grabar.WriteLine(cadena);

            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            //CARGAR LA LISTA DE CAMIONES CON LOS DATOS DEL ARCHIVO.TXT DE CAMIONES//
            // PRIMERO SE VACIA LA LISTA DE CAMIONES PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeCamiones.Clear();
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Camiones camion = new Camiones(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], datos[12], int.Parse(datos[13]), int.Parse(datos[14]));
                ListaDeCamiones.Add(camion);
            }
            leer.Close();
            Archivo.Close();
            // ---------------------------------------------------------------------- //

        }


        public void BorrarAuto()
        {

            MostrarAutos();
            Console.WriteLine("");
            Console.Write("   Escriba el ID del AUTO a borrar: ");
            int OpcionRemover = ValidarNum();

            //BUSCAR EL ID EN LA LISTA 
            Autos ObjetoEliminar = ListaDeAutos.FirstOrDefault(item => item.Id_Vehiculo == OpcionRemover);

            if (ObjetoEliminar != null)
            {
                ListaDeAutos.Remove(ObjetoEliminar);
            }
            // GRABA LA LISTA DE AUTOS EN EL ARCHIVO DE AUTOS
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);

            foreach (Autos item in ListaDeAutos)
            {
                string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeAutos.Clear();
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Open);//cambiar archivo
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {

                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Autos auto = new Autos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11]);
                ListaDeAutos.Add(auto);
            }
            leer.Close();
            Archivo.Close();
            // ---------------------------------------------------------------------- //
        }


        public void BorrarCamion()
        {

            MostrarCamiones();
            Console.WriteLine("");
            Console.Write("   Escriba el ID del CAMION a borrar: ");
            int OpcionRemover = ValidarNum();

            //BUSCAR EL ID EN LA LISTA 
            Camiones ObjetoEliminar = ListaDeCamiones.FirstOrDefault(item => item.Id_Vehiculo == OpcionRemover);

            if (ObjetoEliminar != null)
            {
                ListaDeCamiones.Remove(ObjetoEliminar);
            }
            // GRABA LA LISTA DE AUTOS EN EL ARCHIVO DE AUTOS
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);

            foreach (Camiones item in ListaDeCamiones)
            {
                string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo + ";" + item.Caja_Carga + ";" + item.Dimensiones_Caja + ";" + item.Carga_Max ;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeCamiones.Clear();
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Open);//cambiar archivo
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {

                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Camiones camion = new Camiones(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], datos[12], int.Parse(datos[13]), int.Parse(datos[14]) );
                ListaDeCamiones.Add(camion);
            }
            leer.Close();
            Archivo.Close();
            // ---------------------------------------------------------------------- //
        }

        public void BorrarMoto()
        {

            MostrarMotos();
            Console.WriteLine("");
            Console.Write("   Escriba el ID del AUTO a borrar: ");
            int OpcionRemover = ValidarNum();

            //BUSCAR EL ID EN LA LISTA 
            Motos ObjetoEliminar = ListaDeMotos.FirstOrDefault(item => item.Id_Vehiculo == OpcionRemover);

            if (ObjetoEliminar != null)
            {
                ListaDeMotos.Remove(ObjetoEliminar);
            }
            // GRABA LA LISTA DE AUTOS EN EL ARCHIVO DE AUTOS
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);

            foreach (Motos item in ListaDeMotos)
            {
                string cadena = item.Id_Vehiculo + ";" + item.Patente + ";" + item.Kilometro + ";" + item.Año + ";" + item.Id_Marca + ";" + item.Modelo + ";" + item.Id_Segmento + ";" + item.Id_Combustible + ";" + item.Precio_venta + ";" + item.Observaciones + ";" + item.Color + ";" + item.Tipo + ";" + item.Cilindrada;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeAutos.Clear();
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Open);//cambiar archivo
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {

                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Motos moto = new Motos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], int.Parse(datos[12]));
                ListaDeMotos.Add(moto);
            }
            leer.Close();
            Archivo.Close();
            // ---------------------------------------------------------------------- //
        }

        public void GrabarArchivoAutos()
        {
            //CARGAR LA LISTA DE AUTOS CON LOS DATOS DEL ARCHIVO.TXT DE AUTOS//
            // PRIMERO SE VACIA LA LISTA DE AUTOS PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeAutos.Clear();
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_AUTOS.txt", FileMode.Open);//cambiar archivo
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {

                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Autos auto = new Autos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11]);
                ListaDeAutos.Add(auto);
            }
            leer.Close();
            Archivo.Close();
        }
        public void GrabarArchivoMotos()
        {
            //CARGAR LA LISTA DE MOTOS CON LOS DATOS DEL ARCHIVO.TXT DE MOTOS//
            // PRIMERO SE VACIA LA LISTA DE MOTOS PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeMotos.Clear();
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MOTOS.txt", FileMode.Open);//cambiar archivo
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {

                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Motos moto = new Motos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], int.Parse(datos[12]));
                ListaDeMotos.Add(moto);
            }
            leer.Close();
            Archivo.Close();
        }
        public void GrabarArchivoCamiones()
        {
            //CARGAR LA LISTA DE CAMIONES CON LOS DATOS DEL ARCHIVO.TXT DE CAMIONES//
            // PRIMERO SE VACIA LA LISTA DE CAMIONES PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeCamiones.Clear();
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CAMIONES.txt", FileMode.Open);//cambiar archivo
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Camiones camion = new Camiones(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), datos[4], datos[5], datos[6], datos[7], int.Parse(datos[8]), datos[9], datos[10], datos[11], datos[12], int.Parse(datos[13]), int.Parse(datos[14]));
                ListaDeCamiones.Add(camion);
            }
            leer.Close();
            Archivo.Close();
        }


        //METODOS PARA CIUDAD - MANEJO DE LISTADECIUDADES2 - SIRVE EN PARAMETRICAS Y CLIENTES
        public void AgregarCiudad_99()
        {
            Console.WriteLine("");
            Console.Write("   Ingrese Ciudad: ");
            string nombre = Console.ReadLine();

            int idciudad = ListaDeCiudades2.Count() + 1;

            Ciudades ciudad = new Ciudades(idciudad, nombre);
            ListaDeCiudades2.Add(ciudad);
            //GRABAR LA LISTA DE CIUDADES EN EL ARCHIVO CIUDADES TXT
            FileStream Archivo;
            StreamWriter Grabar;
            Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Ciudades item in ListaDeCiudades2)
            {
                string cadena = item.Id_Ciudad + ";" + item.Nombre;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            // SE PROCEDE A COPIAR LO DEL ARCHIVO.TXT A LA LISTA DE CIUDADES //
            // PRIMERO SE VACIA LA LISTA PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeCiudades2.Clear();
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                int id = int.Parse(datos[0]);
                string nombre2 = datos[1];

                Ciudades ciudad99 = new Ciudades(id, nombre2);
                ListaDeCiudades2.Add(ciudad99);
            }
            leer.Close();
            Archivo.Close();
        }
        public void AgregarCiudad()
        {
            ListaDeCiudades2.Clear();//VACIADO DE LISTA
            GuardarArchivoCiudades();//CARGADO DE LISTA

            string nombre;
            int idciudad;

            Console.WriteLine("");
            Console.Write("   Ingrese Ciudad: ");
            nombre = Console.ReadLine();

            idciudad = ListaDeCiudades2.Count() + 1;

            Ciudades ciudad = new Ciudades(idciudad, nombre);
            ListaDeCiudades2.Add(ciudad);

            // GRABAR LA LISTA CIUDADES EN EL ARCHIVO TXT DE CIUDADES
            FileStream Archivo;
            StreamWriter Grabar;

            Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);

            foreach (Ciudades item in ListaDeCiudades2)
            {
                string cadena = item.Id_Ciudad + ";" + item.Nombre;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();

            //CARGAR LA LISTA DE CIUDADES CON LOS DATOS DEL ARCHIVO.TXT DE CIUDADES//
            // PRIMERO SE VACIA LA LISTA CIUDADES2 PARA NO VOLVER A COPIAR LO COPIADO//
            ListaDeCiudades2.Clear();
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Open);//cambiar archivo
            leer = new StreamReader(Archivo);
            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {

                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');

                Ciudades ciudade = new Ciudades(int.Parse(datos[0]), datos[1]);
                ListaDeCiudades2.Add(ciudade);
            }
            leer.Close();
            Archivo.Close();
            // ---------------------------------------------------------------------- //
        }
        public void GuardarArchivoCiudades()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Open);
            leer = new StreamReader(Archivo);

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                int id = int.Parse(datos[0]);
                string nombre = datos[1];

                Ciudades ciudad = new Ciudades(id, nombre);
                ListaDeCiudades2.Add(ciudad);
            }
            leer.Close();
            Archivo.Close();

            FileInfo fileInfo = new FileInfo("ARCHIVO_CIUDADES.txt");
            if (fileInfo.Length == 0)
            {
                ListaDeCiudades2 = new List<Ciudades>
                {
                    new Ciudades(1,"San Nicolas"),
                    new Ciudades(2,"Rosario"),
                    new Ciudades(3,"Pergamino"),
                    new Ciudades(4,"Zarate"),
                    new Ciudades(5,"San Pedro")
                };
                //GUARDAR LA LISTA EN EL ARCHIVO
                // GRABAR LA LISTA CIUDADES EN EL ARCHIVO TXT DE CIUDADES

                StreamWriter Grabar;
                Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Create);
                Grabar = new StreamWriter(Archivo);

                foreach (Ciudades item in ListaDeCiudades2)
                {
                    string cadena = item.Id_Ciudad + ";" + item.Nombre;
                    Grabar.WriteLine(cadena);
                }
                Console.WriteLine("");
                Grabar.Close();
                Archivo.Close();

            }
        }
        public void MostrarCiudades()
        {
            ListaDeCiudades2.Clear();//VACIADO DE LISTA
            GuardarArchivoCiudades();//CARGADO DE LISTA

            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔═════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("  No hay ninguna ciudad cargada en la lista");
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID_Ciudad: {datos[0]} - Ciudad: {datos[1]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠═════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚═════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }
        public void ActualizarCiudad()
        {
            ListaDeCiudades2.Clear();//VACIADO DE LISTA
            GuardarArchivoCiudades();//CARGADO DE LISTA ACTUALIZADA

            MostrarCiudades();
            Console.WriteLine("");
            Console.Write("   Escriba el ID de la ciudad para actualizar: ");
            int CiudadIDActualizar = ValidarNum();

            // PREGUNTA SI EXISTE EL NUMERO DE ID PARA MODIFICAR LA CIUDAD
            Ciudades ciudadActualizar = ListaDeCiudades2.FirstOrDefault(c => c.Id_Ciudad == CiudadIDActualizar);

            if (ciudadActualizar != null)
            {
                // Actualizar los datos de LA CIUDAD.
                ciudadActualizar.Id_Ciudad = CiudadIDActualizar;
                Console.WriteLine("");
                Console.Write("   Ingrese Nombre de la ciudad: ");
                ciudadActualizar.Nombre = Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"   Ciudad con ID {ciudadActualizar} no encontrado.");
            }

            //GUARDAR LA LISTA ENTERA ACTUALIZADA EN EL ARCHIVO
            FileStream Archivo;
            StreamWriter Grabar;
            if (!File.Exists("ARCHIVO_CIUDADES.txt"))
            {
                Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Create);
                Archivo.Close();
            }
            Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Ciudades item in ListaDeCiudades2)
            {
                string cadena = item.Id_Ciudad + ";" + item.Nombre;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();

        }
        public void BorrarCiudad()
        {
            ListaDeCiudades2.Clear();//VACIADO DE LISTA
            GuardarArchivoCiudades();//CARGADO DE LISTA ACTUALIZADA

            Console.WriteLine("");
            MostrarCiudades();
            Console.WriteLine("");
            Console.Write("   Escriba el ID de la ciudad a borrar: ");
            int OpcionRemover = ValidarNum();

            //BUSCAR EL ID EN LA LISTA PARA BORRAR EL OBJETO
            Ciudades ObjetoEliminar = ListaDeCiudades2.FirstOrDefault(item => item.Id_Ciudad == OpcionRemover);

            if (ObjetoEliminar != null)
            {
                ListaDeCiudades2.Remove(ObjetoEliminar);
            }
            //GUARDAR LA LISTA ENTERA ACTUALIZADA EN EL ARCHIVO
            FileStream Archivo;
            StreamWriter Grabar;
            if (!File.Exists("ARCHIVO_CIUDADES.txt"))
            {
                Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Create);
                Archivo.Close();
            }
            Archivo = new FileStream("ARCHIVO_CIUDADES.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Ciudades item in ListaDeCiudades2)
            {
                string cadena = item.Id_Ciudad + ";" + item.Nombre;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();

            //GRABAR LA LISTA DESDE EL ARCHIVO.TXT  A LA LISTA 


        }



        //METODOS PARA MARCAS - MANEJO DE LISTADEMARCAS - SIRVE EN PARAMETRICAS Y VEHICULOS
        public void AgregarMarca()
        {
            ListaDeMarcas.Clear();//VACIADO DE LISTA
            GuardarArchivoMarcas();//CARGADO DE LISTA

            Console.WriteLine("");
            Console.Write("   Ingrese Marca: ");
            string nombremarca = Console.ReadLine();
            int idmarca = ListaDeMarcas.Count() + 1;

            Marcas marca = new Marcas(idmarca, nombremarca);
            ListaDeMarcas.Add(marca);
            // GRABAR LA LISTA DE MARCAS EN EL ARCHIVO TXT DE MARCAS
            FileStream Archivo;
            StreamWriter Grabar;

            Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);

            foreach (Marcas item in ListaDeMarcas)
            {
                string cadena = item.Id_Marca + ";" + item.NombreMarca;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
            //GRABAR LA LISTA CON LOS DATOS DEL ARCHIVO TXT DE NUEVO ANTES DE SALIR
            ListaDeMarcas.Clear();//VACIADO DE LISTA
            GuardarArchivoMarcas();//CARGADO DE LISTA

        }
        public void GuardarArchivoMarcas()
        {
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                int id = int.Parse(datos[0]);
                string nombre = datos[1];

                Marcas marca = new Marcas(id, nombre);
                ListaDeMarcas.Add(marca);
            }
            leer.Close();
            Archivo.Close();
        }
        public void MostrarMarcas()
        {
            ListaDeMarcas.Clear();//VACIADO DE LISTA
            GuardarArchivoMarcas();//CARGADO DE LISTA

            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Open);
            leer = new StreamReader(Archivo);
            Console.ForegroundColor = ConsoleColor.Green;
            if (leer.EndOfStream == false)
            {
                Console.WriteLine("  ╔═════════════════════════════════════╗");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("  No hay ninguna marca cargada en la lista");
            }

            while (leer.EndOfStream == false) //pregunta si no se encuentra en la última linea del archivo
            {
                string cadena = leer.ReadLine();
                string[] datos = cadena.Split(';');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   ID_Marca: {datos[0]} - Marca: {datos[1]}");

                if (leer.EndOfStream == false)
                {
                    Console.WriteLine("  ╠═════════════════════════════════════╣");
                }
                else
                {
                    Console.WriteLine("  ╚═════════════════════════════════════╝");
                }
            }
            Console.ResetColor();
            leer.Close();
            Archivo.Close();
        }
        public void ActualizarMarca()
        {
            ListaDeMarcas.Clear();//VACIADO DE LISTA
            GuardarArchivoMarcas();//CARGADO DE LISTA ACTUALIZADA

            MostrarMarcas();
            Console.WriteLine("");
            Console.Write("   Escriba el ID de la marca para actualizar: ");
            int MarcaIDActualizar = ValidarNum();

            // PREGUNTA SI EXISTE EL NUMERO DE ID PARA MODIFICAR LA MARCA
            Marcas marcaActualizar = ListaDeMarcas.FirstOrDefault(c => c.Id_Marca == MarcaIDActualizar);

            if (marcaActualizar != null)
            {
                // Actualizar los datos de LA MARCA.
                marcaActualizar.Id_Marca = MarcaIDActualizar;
                Console.WriteLine("");
                Console.Write("   Ingrese Nombre de la ciudad: ");
                marcaActualizar.NombreMarca = Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"   Ciudad con ID {marcaActualizar} no encontrado.");
            }

            //GUARDAR LA LISTA ENTERA ACTUALIZADA EN EL ARCHIVO
            FileStream Archivo;
            StreamWriter Grabar;
            if (!File.Exists("ARCHIVO_MARCAS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Create);
                Archivo.Close();
            }
            Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Marcas item in ListaDeMarcas)
            {
                string cadena = item.Id_Marca + ";" + item.NombreMarca;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
        }
        public void BorrarMarca()
        {
            ListaDeMarcas.Clear();//VACIADO DE LISTA
            GuardarArchivoMarcas();//CARGADO DE LISTA ACTUALIZADA

            Console.WriteLine("");
            MostrarMarcas();
            Console.WriteLine("");
            Console.Write("   Escriba el ID de la marca a borrar: ");
            int OpcionRemover = ValidarNum();

            //BUSCAR EL ID EN LA LISTA PARA BORRAR EL OBJETO
            Marcas ObjetoEliminar = ListaDeMarcas.FirstOrDefault(item => item.Id_Marca == OpcionRemover);

            if (ObjetoEliminar != null)
            {
                ListaDeMarcas.Remove(ObjetoEliminar);
            }
            //GUARDAR LA LISTA ENTERA ACTUALIZADA EN EL ARCHIVO
            FileStream Archivo;
            StreamWriter Grabar;
            if (!File.Exists("ARCHIVO_MARCAS.txt"))
            {
                Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Create);
                Archivo.Close();
            }
            Archivo = new FileStream("ARCHIVO_MARCAS.txt", FileMode.Create);
            Grabar = new StreamWriter(Archivo);
            foreach (Marcas item in ListaDeMarcas)
            {
                string cadena = item.Id_Marca + ";" + item.NombreMarca;
                Grabar.WriteLine(cadena);
            }
            Console.WriteLine("");
            Grabar.Close();
            Archivo.Close();
        }
        public void InicializarMarcasPredeterminadas()
        {

            if (ListaDeMarcas.Count == 0)
            {
                ListaDeMarcas.Add(new Marcas(1, "Peugeot"));
                ListaDeMarcas.Add(new Marcas(2, "Fiat"));
                ListaDeMarcas.Add(new Marcas(3, "Ford"));
                ListaDeMarcas.Add(new Marcas(4, "Renault"));
                ListaDeMarcas.Add(new Marcas(5, "Chevrolet"));
            }
        }



        //METODOS DE VALIDACION Y DEMAS
        static int ValidarNum()
        {
            int nro;
            bool resp;
            resp = int.TryParse(Console.ReadLine(), out nro);
            while (!resp)
            {
                Console.Write("   ERROR! Ingrese solo números: ");
                resp = int.TryParse(Console.ReadLine(), out nro);

            }
            return nro;
        }
        static long ValidarDni()
        {

            long nro;
            bool resp;
            resp = long.TryParse(Console.ReadLine(), out nro);
            while (!resp)
            {
                Console.WriteLine("ERROR! Ingrese solo números para el dni: ");
                Console.Write("Recuerde que el DNI contiene 8 digitos numericos: ");
                resp = long.TryParse(Console.ReadLine(), out nro);
            }
            return nro;
        }
        static double ValidarDouble()
        {

            double nro;
            bool resp;
            resp = double.TryParse(Console.ReadLine(), out nro);
            while (!resp)
            {
                Console.WriteLine("ERROR! Ingrese solo números: ");
                resp = double.TryParse(Console.ReadLine(), out nro);
            }
            return nro;
        }

    }
}
