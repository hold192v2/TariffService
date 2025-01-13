using System.Diagnostics.Contracts;
using TariffService.Domain.Entities;

public class TariffCart : BaseEntity
{
    public Guid Id { get; set; }
    public Guid TempUserId { get; set; }
    public string TariffId { get; set; }
    public string NewPhone { get; set; }


    public TariffCart(Guid tempUserId, string tariffId, string newPhone) 
    {
        TempUserId = tempUserId;
        TariffId = tariffId;
        NewPhone = newPhone;
    }
    protected TariffCart() => Id = Guid.NewGuid();
    public static string GetTariffType(string id)
    {
        if (Guid.TryParse(id, out _))
        {
            return "Static";
        }
        else if (IsBase64String(id))
        {
            return "Dynamic";
        }
        else
        {
            throw new ArgumentException("Invalid tariff id format");
        }
    }

    private static bool IsBase64String(string base64)
    {
        if (string.IsNullOrWhiteSpace(base64)) 
            return false;
        if (base64.Length % 4 != 0)
            return false;
        try
        {
            Convert.FromBase64String(base64);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

}