namespace WebApiPractice.Entities
{
    public class Time
    {
        public int id { get; init; } //id времени

        public string time { get; init; } //время

        public string date { get; init; } //дата

        public int dateID { get; init; } //id даты

        public Date obj_date { get; set; } //переменная класса даты,
                                                //для получения времени
    }
}
