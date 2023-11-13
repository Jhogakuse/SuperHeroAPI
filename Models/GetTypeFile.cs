namespace Models
{
    public class GetTypeFile
    {
        public int IdTypeFile { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estatus { get; set; }
        public string Created { get; set; } = string.Empty;
    }
}
