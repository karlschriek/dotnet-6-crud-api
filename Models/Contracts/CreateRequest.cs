namespace WebApi.Models.Contracts;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class ContractCreateRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string SolidityContract { get; set; }

    [Required]
    public string JsMigration { get; set; }

}