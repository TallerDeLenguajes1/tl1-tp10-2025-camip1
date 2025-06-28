namespace EspacioTareas
{
    public class Tarea
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

        public void MostrarDatos()
        {
            string estado;
            if (completed)
            {
                estado = "Completada";
            }
            else
            {
                estado = "Pendiente";
            }
            Console.WriteLine($"Titulo: {title} | Estado: {estado}\n");
        }
    }
}

