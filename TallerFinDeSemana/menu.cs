using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TallerFinDeSemana
{
    class menu
    {
        public static List<string> ListaNombres = new List<string>();
        public static void MenuSecundario()
        {
            string opciones;
            int Opcion;
            do
            {
                bool DatoCorrecto = false;

                Console.Clear();
                gui.Marco(1, 110, 1, 25);
                Console.SetCursorPosition(10, 10); Console.WriteLine("1. agregar nombre");
                Console.SetCursorPosition(10, 11); Console.WriteLine("2. listar nombres");
                Console.SetCursorPosition(10, 12); Console.WriteLine("3. buscar nombres");
                Console.SetCursorPosition(10, 13); Console.WriteLine("4. menu principal");

                do
                {
                    gui.BorrarLinea(10, 15, 90);
                    Console.SetCursorPosition(10, 14); Console.WriteLine("Seleccione una opcion");
                    Console.SetCursorPosition(10, 15); opciones = Console.ReadLine();

                    if (!Verificaciones.Vacio(opciones))
                        if (Verificaciones.TipoNumero(opciones))
                            DatoCorrecto = true;

                } while (!DatoCorrecto);


                Opcion = Convert.ToInt32(opciones);

                switch (Opcion)
                {
                    case 1:
                        menu.AgregarNombre();
                        break;
                    case 2:
                        menu.ListarNombre();
                        break;
                    case 3:
                        menu.BuscarNombre();
                        break;
                    case 4:
                        gui.BorrarLinea(64, 20, 109);
                        Console.SetCursorPosition(40, 20); Console.WriteLine("volvera al menu anterior");
                        break;
                    default:
                        gui.BorrarLinea(57, 20, 109);
                        Console.SetCursorPosition(40, 20); Console.WriteLine("Opcion incorrecta");
                        Console.SetCursorPosition(40, 22); Console.WriteLine("presione una tecla para continuar");
                        Console.SetCursorPosition(40, 23); Console.ReadKey();
                        break;
                }



            } while (Opcion != 4);

        }

        static void AgregarNombre()
        {
            bool DatoValido = false;
            Console.Clear();
            string nombre;

            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(10, 10); Console.WriteLine("Agrega los nombres");
            do
            {
                Console.SetCursorPosition(10, 11); Console.WriteLine("Digite el nombre");
                Console.SetCursorPosition(10, 12); nombre = Console.ReadLine();

                if (Verificaciones.Existe(nombre.ToLower()))
                {
                    Console.SetCursorPosition(40, 20); Console.WriteLine("el nombre ya existe");

                }
                else
                {
                    if (!Verificaciones.Vacio(nombre))
                        if (Verificaciones.TipoLetra(nombre))
                            DatoValido = true;
                }
                gui.BorrarLinea(10, 12, 90);
                Console.SetCursorPosition(40, 21); Console.WriteLine("presione una tecla para continuar");
                Console.SetCursorPosition(40, 22); Console.ReadKey();
                gui.BorrarLinea(40, 20, 90);
                gui.BorrarLinea(40, 21, 90);

            } while (!DatoValido);
            gui.BorrarLinea(40, 20, 90);
            ListaNombres.Add(nombre.ToLower());
        }

        static void ListarNombre()
        {
            int altura = 7;
            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(20, 5); Console.WriteLine("lista de nombres");
            foreach (string personaje in ListaNombres)
            {
                Console.SetCursorPosition(20, altura); Console.WriteLine(personaje);
                altura++;
            }
            Console.SetCursorPosition(40, 21); Console.WriteLine("presione una tecla para continuar");
            Console.SetCursorPosition(40, 22); Console.ReadKey();
        }

        static void BuscarNombre()
        {
            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            string NombreABuscar;
            bool DatoValido = false;
            do
            {
                Console.SetCursorPosition(10, 11); Console.WriteLine("Digite el nombre que desea buscar");
                Console.SetCursorPosition(10, 12); NombreABuscar = Console.ReadLine();
                if (!Verificaciones.Vacio(NombreABuscar))
                    if (Verificaciones.TipoLetra(NombreABuscar))
                        DatoValido = true;
                gui.BorrarLinea(10, 12, 90);
            } while (!DatoValido);
            gui.BorrarLinea(40, 20, 90);
            if (Verificaciones.Existe(NombreABuscar.ToLower()))
            {
                Console.SetCursorPosition(10, 15); Console.WriteLine("el nombre " + NombreABuscar + " existe en la base de datos");
            }
            else
            {
                Console.SetCursorPosition(10, 15); Console.WriteLine("el nombre " + NombreABuscar + " no existe en la base de datos");
            }
            Console.SetCursorPosition(40, 21); Console.WriteLine("presione una tecla para continuar");
            Console.SetCursorPosition(40, 22); Console.ReadKey();

        }
        public static void GuardarArchivoXML()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<string>));
            TextWriter escribirXml = new StreamWriter("D:/RealizarDiseñoOrientadoObjetosLenguajedeProgramaciónI.NET/datos/ArchivoNombres.xml");
            codificador.Serialize(escribirXml, ListaNombres);
            escribirXml.Close();

            
            
        }

        public static void CargarArchivoXML()
        {
            if (File.Exists("D:/RealizarDiseñoOrientadoObjetosLenguajedeProgramaciónI.NET/datos/ArchivoNombres.xml"))
            {
                ListaNombres.Clear();
                XmlSerializer codificador = new XmlSerializer(typeof(List<string>));
                FileStream leerXml = File.OpenRead("D:/RealizarDiseñoOrientadoObjetosLenguajedeProgramaciónI.NET/datos/ArchivoNombres.xml");
                ListaNombres = (List<string>)codificador.Deserialize(leerXml);
                leerXml.Close();
            }
        }
    }
}
