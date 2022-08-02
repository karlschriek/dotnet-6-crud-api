namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Contracts;

public interface IContractService
{
    IEnumerable<Contract> GetAll();
    Contract GetById(int id);
    void Create(ContractCreateRequest model);
    void Update(int id, ContractUpdateRequest model);
    void Delete(int id);
}

public class ContractService : IContractService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public ContractService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Contract> GetAll()
    {
        return _context.Contracts;
    }

    public Contract GetById(int id)
    {
        return getContract(id);
    }

    public void Create(ContractCreateRequest model)
    {
        // validate
        if (_context.Contracts.Any(x => x.Name == model.Name))
            throw new AppException("Contract with the name '" + model.Name + "' already exists");

        // map model to new contract object
        var contract = _mapper.Map<Contract>(model);

        // set contract Adress
        // TODO deploy contract here
        contract.Address = "foobar";

        // save contract
        _context.Contracts.Add(contract);
        _context.SaveChanges();
    }

    public void Update(int id, ContractUpdateRequest model)
    {
        var contract = getContract(id);

        // copy model to contract and save
        _mapper.Map(model, contract);
        _context.Contracts.Update(contract);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var contract = getContract(id);
        _context.Contracts.Remove(contract);
        _context.SaveChanges();
    }

    // helper methods

    private Contract getContract(int id)
    {
        var contract = _context.Contracts.Find(id);
        if (contract == null) throw new KeyNotFoundException("Contract not found");
        return contract;
    }
}