namespace Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //ustalamy wartość domyślną na pusty string, alternatywnie można użyć: ""

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
