using System;
using Int.Core.Data.Repository.Akavache.Contract;

namespace Core.Models.DAL
{
    public interface IBeerContent : IBaseEntity
    {
        string ImagePath { get; set; }
        string NameBeer { get; set; }
        string Volume { get; set; }
        double Price { get; set; }

        double PriceBar { get; set; }

        int CountOrder { get; set; }

        int Quantity { get; set; }
    }

    public class BeerContent : IBeerContent
    {
        public string ImagePath { get; set; }
        public string NameBeer { get; set; }
        public string Volume { get; set; }
        public double Price { get; set; }

        public double PriceBar { get; set; }

        public int Id { get; set; }

        public int CountOrder { get; set; }

        public int Quantity { get; set; }
    }
}
