namespace Models
{
    public class ShoppingItem : Entity
    {
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Quantity}";
        }
    }
}
