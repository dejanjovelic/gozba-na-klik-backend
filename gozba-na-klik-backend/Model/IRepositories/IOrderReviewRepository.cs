namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IOrderReviewRepository
    {
        Task CreateOrderReviewAsync(OrderReview orderReview);
        Task<Order?> GetOrderByIdAsync(int orderId);
    }
}
