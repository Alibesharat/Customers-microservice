namespace GrpcModelFirst
{
    public interface IGrpcBaseChannel
    {
        IOrderService GetOrderService();
        ICustomerService GetCustomerService();




    }
}
