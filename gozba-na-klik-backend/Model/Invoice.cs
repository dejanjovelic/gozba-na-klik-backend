using gozba_na_klik_backend.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gozba_na_klik_backend.Model
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public int DeliveryAddressId { get; set; }
        public string DeliveryFullAddress { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantCity { get; set; }
        public DateTime? OrderTime { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public List<OrderItemDTO> OrderedMeals { get; set; }
        public string? CourierId { get; set; }
        public string CourierName { get; set; }
        public string CourierSurname { get; set; }
        public double TotalPrice { get; set; }

    }
}
