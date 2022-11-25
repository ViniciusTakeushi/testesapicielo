namespace TesteCielo.Models
{
    public class CieloPixCustomer
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string IdentityType { get; set; }
    }

    public class CieloPixPayment
    {
        public string Type { get; set; }
        public int Amount { get; set; }
    }

    public class CieloPixModel
    {
        public string MerchantOrderId { get; set; }
        public CieloPixCustomer Customer { get; set; }
        public CieloPixPayment Payment { get; set; }
    }
}
