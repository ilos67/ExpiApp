using System;

namespace Core.Entities
{
    public class Basket
    {
        public string Id { get; set; }
        public string BasketData { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
    }
}