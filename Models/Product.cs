namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //ustalamy wartość domyślną na pusty string, alternatywnie można użyć: ""
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; //ustalamy wartość domyślną na aktualną datę i czas

    }
}
