namespace WebApiPractice.Entities
{
    public class Date
    {
        public int id { get; init; } //id даты

        public string date { get; init; } //дата

        public bool IsAvailable { get; init; } //свободно/занято
    }
}
