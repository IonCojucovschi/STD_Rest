namespace Core.Models.DAL
{
    public interface IOrderContent
    {
        int Id { get; set; }
        int IdProduct { get; set; }
        string ImagePath { get; set; }
        string OrderName { get; set; }
        double Price { get; set; }
        string Quantity { get; set; }

        double PriceBar { get; set; }
    }

    public class OrderContent : IOrderContent
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string ImagePath { get; set; }
        public string OrderName { get; set; }
        public string Quantity { get; set; }
        public double Price { get; set; }

        public double PriceBar { get; set; }
    }
}
