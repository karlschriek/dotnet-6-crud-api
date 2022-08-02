namespace WebApi.Entities;

public class Contract
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SolidityContract { get; set; }
    public string JsonContract { get; set; }
    public string JsMigration { get; set; }
    public string Address { get; set; }
}