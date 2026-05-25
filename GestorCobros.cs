using System;
namespace ClinicaMedicaDeEspecialidades
{
    public static class GestorCobros //variable publica para que se pueda acceder desde el menu principal
    {
        public static void ProcesarCobro()
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE COBROS / CANCELAR CITA / REFERIR PACIENTE ===");
            if (GestorPacientes.contadorPacientes == 0)
            {
                Console.WriteLine("Aun noo hay pacientes registrados en el sistema.");
                Console.WriteLine("\nPresione cualquier tecla para regresar...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Citas Pendientes:");
            bool hayPendientes = false;
            for (int i = 0; i < GestorPacientes.contadorPacientes; i++)
            {
                if (GestorPacientes.estados[i] == 'P')
                {
                    Console.Write($"[{i}] {GestorPacientes.codigosCitas[i]} - {GestorPacientes.nombresPacientes[i]} ");
                    if (GestorPacientes.triages[i] == TipoTriage.Rojo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(REQUIERE REFERENCIA - TRIAGE ROJO)");
                        Console.ResetColor();
                    }
                    Console.WriteLine($" - Costo Base: ${GestorPacientes.costos[i]}");
                    hayPendientes = true;
                }
            }
            if (!hayPendientes)
            {
                Console.WriteLine("No hay citas en estado Pendiente en este momento.");
                Console.WriteLine("\nPresione cualquier tecla para regresar...");
                Console.ReadKey();
                return;
            }
            Console.Write("\nIngrese el número de índice (ej. [0], [1], [2]) del paciente a gestionar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < GestorPacientes.contadorPacientes && GestorPacientes.estados[indice] == 'P')
            {
                Console.WriteLine("\n¿Qué acción desea realizar?");
                Console.WriteLine("1. Procesar Pago (Atender Cita)");
                Console.WriteLine("2. Cancelar Cita / Referir Paciente"); 
                Console.Write("Seleccione una opción: ");
                string? accion = Console.ReadLine();
                switch (accion)//este switch es para elegir entre procesar el pago o cancelar la cita
                {   
                    case "1":
                    if (GestorPacientes.triages[indice] == TipoTriage.Rojo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nADVERTENCIA: Este paciente tiene Triage Rojo. Se recomendaba referirlo (Opción 2).");
                        Console.ResetColor();
                    }
                    double costoBase = GestorPacientes.costos[indice];
                    double descuentoEdad = 0;
                    double descuentoSeguro = 0;
                    if (GestorPacientes.edades[indice] > 60)
                    {
                        descuentoEdad = costoBase * 0.10;
                    }
                    Console.WriteLine("\nFormas de Pago:"); //Esto es para mostrar las formas de pago que se pueden elegir
                    Console.WriteLine("1. Efectivo");
                    Console.WriteLine("2. Tarjeta");
                    Console.WriteLine("3. Seguro Médico");
                    Console.Write("Seleccione la forma de pago (1-3): ");
                    int formaPago;
                    while (!int.TryParse(Console.ReadLine(), out formaPago) || formaPago < 1 || formaPago > 3)
                    {
                        Console.Write("Opción inválida. Ingrese 1, 2 o 3: ");
                    }
                    MainMenu.formasPago[indice] = formaPago;
                    if (formaPago == 3)
                    {
                        descuentoSeguro = costoBase * 0.15; //operacion del descuento del seguro medico que es del 15% del costo base
                    }
                    double totalDescuento = descuentoEdad + descuentoSeguro;
                    double totalAPagar = costoBase - totalDescuento;
                    Console.WriteLine("\n=========================================");
                    Console.WriteLine("                RESUMEN DE COBRO            ");//Esta es la factura que se muestra en la consola.
                    Console.WriteLine("============================================");
                    Console.WriteLine($"Paciente: {GestorPacientes.nombresPacientes[indice]}");
                    Console.WriteLine($"Costo Base:         ${costoBase:F2}");
                    if (descuentoEdad > 0) Console.WriteLine($"Desc. Edad (>60):  -${descuentoEdad:F2}");
                    if (descuentoSeguro > 0) Console.WriteLine($"Desc. Seguro (15%):-${descuentoSeguro:F2}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"TOTAL A PAGAR:      ${totalAPagar:F2}");
                    Console.ResetColor();
                    Console.Write("\n¿Confirmar pago y marcar cita como Atendida (A)? (S/N): ");
                    if (Console.ReadLine()?.Trim().ToUpper() == "S")
                    {
                        GestorPacientes.descuentosTotales[indice] = totalDescuento;//los descuentos se aplican despues de confirmar el pago, para que se pueda mostrar el resumen de cobro sin afectar el costo base hasta que se confirme el pago.
                        GestorPacientes.costos[indice] = totalAPagar; //el total a pagar se guarda en el arreglo de costos después de confirmar el pago, para que se pueda mostrar el resumen de cobro sin afectar el costo base hasta que se confirme el pago.
                        GestorPacientes.estados[indice] = 'A'; 
                        GestorArchivos.GuardarDatos(); // busca y guarda los datos en el archivo
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n¡Pago registrado! La cita ha sido marcada como Atendida.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("\nOperación cancelada. La cita sigue Pendiente.");
                    }
                        break;
                    case "2":
                    GestorPacientes.estados[indice] = 'C'; 
                    GestorPacientes.costos[indice] = 0.0;  
                    GestorArchivos.GuardarDatos(); //guarda los datos en un Txt que esta dentro de la carpeta temporal bin
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nCita Cancelada/Referida exitosamente. No se generarán cobros.");
                    Console.ResetColor();
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.WriteLine("\nPresione cualquier tecla para regresar...");
                        Console.ReadKey();
                        return;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nÍndice incorrecto o la cita no está en estado Pendiente.");
                Console.ResetColor();
            }
            Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }
    }
}