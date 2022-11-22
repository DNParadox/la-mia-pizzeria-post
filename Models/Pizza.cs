

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public Pizza ()
        {

        }
        public Pizza(string title, string description, string image, float price)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Price = price;
        }
    }
}
