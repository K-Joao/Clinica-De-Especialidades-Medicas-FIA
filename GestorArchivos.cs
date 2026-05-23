using System;
using System.IO;
namespace ClinicaMedicaDeEspecialidades
{
    public static class GestorArchivos
    {
        private const string RUTA_ARCHIVO = "pacientes_registrados.txt";
        public static void GuardarDatos()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(RUTA_ARCHIVO))
                {
                    sw.WriteLine(GestorPacientes.contadorPacientes);

                    for (int i = 0; i < GestorPacientes.contadorPacientes; i++)
                    {
                        string linea = $"{GestorPacientes.nombresPacientes[i]}|" +
                                       $"{GestorPacientes.codigosCitas[i]}|" +
                                       $"{GestorPacientes.fechasCitas[i]}|" +
                                       $"{GestorPacientes.edades[i]}|" +
                                       $"{GestorPacientes.especialidades[i]}|" +
                                       $"{(int)GestorPacientes.triages[i]}|" +
                                       $"{GestorPacientes.costos[i]}|" +
                                       $"{GestorPacientes.estados[i]}|" +
                                       $"{GestorPacientes.descuentosTotales[i]}|" +
                                       $"{GestorPacientes.medicosAtencion[i]}|" +
                                       $"{MainMenu.formasPago[i]}|" +
                                       $"{MainMenu.calificaciones[i]}|" +
                                       $"{GestorPacientes.registroDePacientes[i]}";
                        sw.WriteLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los datos: {ex.Message}");
            }
        }
        public static void CargarDatos()
        {
            if (!File.Exists(RUTA_ARCHIVO)) return; 
            try
            {
                using (StreamReader sr = new StreamReader(RUTA_ARCHIVO))
                {
                    if (int.TryParse(sr.ReadLine(), out int cantidad))
                    {
                        GestorPacientes.contadorPacientes = cantidad;
                        
                        for (int i = 0; i < cantidad; i++)
                        {
                            string? linea = sr.ReadLine();
                            if (linea != null)
                            {
                                string[] partes = linea.Split('|');
                                GestorPacientes.nombresPacientes[i] = partes[0];
                                GestorPacientes.codigosCitas[i] = partes[1];
                                GestorPacientes.fechasCitas[i] = partes[2];
                                GestorPacientes.edades[i] = int.Parse(partes[3]);
                                GestorPacientes.especialidades[i] = int.Parse(partes[4]);
                                GestorPacientes.triages[i] = (TipoTriage)int.Parse(partes[5]);
                                GestorPacientes.costos[i] = double.Parse(partes[6]);
                                GestorPacientes.estados[i] = char.Parse(partes[7]);
                                GestorPacientes.descuentosTotales[i] = double.Parse(partes[8]);
                                GestorPacientes.medicosAtencion[i] = partes[9];
                                MainMenu.formasPago[i] = int.Parse(partes[10]);
                                MainMenu.calificaciones[i] = int.Parse(partes[11]);
                                GestorPacientes.registroDePacientes[i] = partes[12];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los datos: {ex.Message}");
            }
        }
    }
}
