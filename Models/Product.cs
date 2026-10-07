using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Models
{
    public class Product : Entity
    {
        public float Price { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now; //ustalamy wartość domyślną na aktualną datę i czas

        public int Quantity { get; set; }
        public string? Description { get; set; }

        public string FullInfo => ToString();

        public override string ToString()
        {
            return $"{base.ToString()} - {Price} - {CreatedAt}";
        }
    }
}
