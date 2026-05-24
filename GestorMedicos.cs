using System;
namespace ClinicaMedicaDeEspecialidades
{
    public static class GestorMedicos //esta clase se encarga de gestionar la información de los médicos.
    {
        public static string[] nombresMedicos = new string[9];
        public static void InicializarMedicos()
        {
            nombresMedicos[0] = "Dr. Carlos Orellana (General)";
            nombresMedicos[1] = "Dra. Ana Dinora (Ginecologa)";
            nombresMedicos[2] = "Dr. Sanchez Ceren (General)";
            nombresMedicos[3] = "Dra. Laura Mendez (General)";
            nombresMedicos[4] = "Dr. Shafick Handall (Ortopedista)";
            nombresMedicos[5] = "Dra. Claudia Ortiz (Pediatra)";
            nombresMedicos[6] = "Dra. Maria Rodriguez (Cardióloga)";
            nombresMedicos[7] = "Dr. Nayib bukele (Dermatólogo)";
            nombresMedicos[8] = "Dr. Francisco Alabi (Oftalmólogo)";
        }
    }
}