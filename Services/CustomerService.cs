using Common;

namespace Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository customersRepository;
    public CustomerService(ICustomerRepository customersRepository)
    {
        this.customersRepository = customersRepository;
    }
    public void Create(CustomerModel model)
    {
        // var entity = model.MapTo<CustomerEntity>();
        var entity = new CustomerEntity()
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Level = model.Level,
            Password = model.Password.ToSHA512(),
        };

        this.customersRepository.Add(entity);

    }

    public List<CustomerModel> GetAll()
    {
        var list = this.customersRepository.GetAll();
        list.ForEach(s => s.Password = string.Empty);
        return list.MapToList<CustomerModel>();
    }

    public CustomerModel? Login(LoginRequest request)
    {
        var entity = this.customersRepository.GetByNameAndPass(request.Name, request.Password.ToSHA512());
        if (entity != null)
        {
            return new CustomerModel() { Name = entity.Name };
        }
        return null;
    }
}
