using CustomerControl.Routes;

namespace CustomerControl.Models;

public class CostumerModel
{
    public CostumerModel(string name, string address, string phone)
    {
        Name = name;
        Address = address;
        Phone = phone;
        Id = Guid.NewGuid();
    }
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }

    public void ChangePerson(string name, string address, string phone)
    {
        Name = name;
        Address = address;
        Phone = phone;
    }

    public void SetInactive()
    {
        Name = "desativado";
    }
}