namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Contracts;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class ContractsController : ControllerBase
{
    private IContractService _contractService;
    private IMapper _mapper;

    public ContractsController(
        IContractService contractService,
        IMapper mapper)
    {
        _contractService = contractService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var contracts = _contractService.GetAll();
        return Ok(contracts);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var contract = _contractService.GetById(id);
        return Ok(contract);
    }

    [HttpPost]
    public IActionResult Create(ContractCreateRequest model)
    {
        _contractService.Create(model);
        return Ok(new { message = "Contract created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ContractUpdateRequest model)
    {
        _contractService.Update(id, model);
        return Ok(new { message = "Contract updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _contractService.Delete(id);
        return Ok(new { message = "Contract deleted" });
    }
}