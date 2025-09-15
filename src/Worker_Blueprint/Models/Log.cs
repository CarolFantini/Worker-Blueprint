namespace Worker.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public int HttpCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime LastCheck { get; set; }
    }
}
