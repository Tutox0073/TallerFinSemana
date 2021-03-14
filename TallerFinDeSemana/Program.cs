using System;
using System.Xml.Serialization;

namespace TallerFinDeSemana
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int Opcion;
            string opciones;
            do
            {

                bool DatoCorrecto = false;

                Console.Clear();                   
                gui.Marco(1, 110, 1, 25);
                Console.SetCursorPosition(10, 10); Console.WriteLine("1. quienes somos ");
                Console.SetCursorPosition(10, 11); Console.WriteLine("2. Menu de aplicacion ");
                Console.SetCursorPosition(10, 12); Console.WriteLine("3. Guardar / Cargar ");
                Console.SetCursorPosition(10, 13); Console.WriteLine("0. Salir ");

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
                        Console.Clear();
                        gui.Marco(1, 110, 1, 25);
                        Console.SetCursorPosition(15, 10); Console.WriteLine(" nombres ");
                        Console.SetCursorPosition(15, 12); Console.WriteLine(" Carlos Giovanny Rodriguez Triviño ");
                        break;
                    case 2:
                        menu.MenuSecundario();
                        break;
                    case 3: GuardarCargar();
                        break;
                    case 0:
                        gui.BorrarLinea(40, 20, 90);
                        Console.SetCursorPosition(40, 20); Console.WriteLine("Feliz dia...");
                        break;
                    default:
                        gui.BorrarLinea(40, 20, 90);
                        Console.SetCursorPosition(40, 20); Console.WriteLine("respuesta incorrecta");
                        break;

                }
                
                Console.SetCursorPosition(40, 21); Console.WriteLine("presione una tecla para continuar");
                Console.SetCursorPosition(40, 22); Console.ReadKey();

            } while (Opcion > 0);

            
        }
        static void GuardarCargar()
        {

            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            int opcion;
            string seleccion;
            string opciones;
            
            do
            {
                Console.Clear();
                gui.Marco(1, 110, 1, 25);
                bool DatoCorrecto = false;

                Console.SetCursorPosition(15, 10); Console.WriteLine("1. para guardar archivo ");
                Console.SetCursorPosition(15, 11); Console.WriteLine("2. para cargar archivo");
                Console.SetCursorPosition(15, 12); Console.WriteLine("3. para volver al menu principal");

                do
                {
                    gui.BorrarLinea(15, 15, 90);
                    Console.SetCursorPosition(15, 14); Console.WriteLine("seleccione una opcion");
                    Console.SetCursorPosition(15, 15); opciones = Console.ReadLine();
                    if (!Verificaciones.Vacio(opciones))
                        if (Verificaciones.TipoNumero(opciones))
                            DatoCorrecto = true;

                } while (!DatoCorrecto);

                opcion = Convert.ToInt32(opciones);

                switch (opcion)

                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            gui.Marco(1, 110, 1, 25);
                            Console.SetCursorPosition(20, 10); Console.WriteLine("¿seguro que quiere guardar el archivo? S/N");
                            Console.SetCursorPosition(20, 11); seleccion = Console.ReadLine();
                            if (!Verificaciones.SiNo(seleccion))
                            {
                                Console.SetCursorPosition(40, 22); Console.WriteLine("presione una tecla para continuar");
                                Console.SetCursorPosition(40, 23); Console.ReadKey();
                            }
                            if (Verificaciones.SiNo(seleccion))
                            {


                                if (seleccion == "s" || seleccion == "S")
                                {
                                    menu.GuardarArchivoXML();
                                    Console.SetCursorPosition(40, 20); Console.Write("Archivo guardado con exito .... ");
                                }
                                else
                                    Console.SetCursorPosition(40, 20); Console.WriteLine("no se guardara el archivo ....");
                            }

                        } while (!Verificaciones.SiNo(seleccion));
                        gui.BorrarLinea(72, 20, 109);

                        break;
                    case 2:

                        do
                        {
                            Console.Clear();
                            gui.Marco(1, 110, 1, 25);
                            Console.SetCursorPosition(20, 10); Console.WriteLine("¿seguro que quiere cargar el archivo? S/N");
                            Console.SetCursorPosition(20, 11); seleccion = Console.ReadLine();
                            if (!Verificaciones.SiNo(seleccion))
                            {
                                Console.SetCursorPosition(40, 22); Console.WriteLine("presione una tecla para continuar");
                                Console.SetCursorPosition(40, 23); Console.ReadKey();
                            }
                            if (Verificaciones.SiNo(seleccion))
                            {


                                if (seleccion == "s" || seleccion == "S")
                                {
                                    menu.CargarArchivoXML();
                                    Console.SetCursorPosition(40, 20); Console.Write("Archivo cargado con exito .... ");
                                }
                                else
                                    Console.SetCursorPosition(40, 20); Console.WriteLine("no se cargara el archivo ....");
                            }

                        } while (!Verificaciones.SiNo(seleccion));
                        gui.BorrarLinea(71, 20, 109);

                        break;
                    case 3:
                        gui.BorrarLinea(64, 20, 109);
                        Console.SetCursorPosition(40, 20); Console.WriteLine("volvera al menu anterior");
                        break;
                    default:
                        gui.BorrarLinea(57, 20, 109);
                        Console.SetCursorPosition(40, 20); Console.WriteLine("Opcion Incorrecta");
                        Console.SetCursorPosition(40, 22); Console.WriteLine("presione una tecla para continuar");
                        Console.SetCursorPosition(40, 23); Console.ReadKey();
                        break;
                }
            } while (opcion != 3);
        }

        
    }
}
