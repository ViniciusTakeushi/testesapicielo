namespace TesteCielo.Models
{
    public class CieloBilletAddress
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class CieloBilletBilling
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

    public class CieloBilletCustomer
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public CieloBilletAddress Address { get; set; }
        public CieloBilletBilling Billing { get; set; }
    }

    public class CieloBilletPayment
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public string Provider { get; set; }
        public string Address { get; set; }
        public string BoletoNumber { get; set; }
        public string Assignor { get; set; }
        public string Demonstrative { get; set; }
        public string ExpirationDate { get; set; }
        public string Identification { get; set; }
        public string Instructions { get; set; }
    }


    public class CieloBilletModel
    {
        public string MerchantOrderId { get; set; }
        public CieloBilletCustomer Customer { get; set; }
        public CieloBilletPayment Payment { get; set; }
    }
}
