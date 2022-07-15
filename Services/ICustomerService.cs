namespace Services
{
    public interface ICustomerService
    {
        public void Create(CustomerModel model);
        List<CustomerModel> GetAll();
        CustomerModel Login(LoginRequest request);
        CustomerModel GetById(Guid id);
    }
}
