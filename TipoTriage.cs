namespace ClinicaMedicaDeEspecialidades
{
    public enum TipoTriage //variable de tipo enumerada para el triage del paciente, dependiendo de su estado de salud.
    {
        Verde,
        Amarillo,
        Rojo
    }

    public static class TipoTriages
    {
        public static string ObtenerNombreEspecialidad(int codigo)
        {
            int indice = codigo - 1;
            return (indice >= 0 && indice < MainMenu.EspecialidadesValidas.Count)
                ? MainMenu.EspecialidadesValidas[indice]
                : "Desconocida";
        }
    }
}
