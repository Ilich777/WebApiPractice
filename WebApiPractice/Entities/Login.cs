namespace WebApiPractice.Entities
{
    public class Login
    {
        public int id { get; init; } //id записи
        public string login { get; init; }
        public string password { get; set; }
        public string FIO { get; init; }
        public string email { get; init; }
        public string phone { get; set; }
        public string rights { get; set; }
    }
}
