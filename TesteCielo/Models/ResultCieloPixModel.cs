namespace TesteCielo.Models
{
    public class ResultCieloPixCustomer
    {
        public string Name { get; set; }
    }

    public class ResultCieloPixPayment
    {
        public string PaymentId { get; set; }
        public string Type { get; set; }
        public string AcquirerTransactionId { get; set; }
        public string ProofOfSale { get; set; }
        public string QrcodeBase64Image { get; set; }
        public string QrCodeString { get; set; }
        public int Amount { get; set; }
        public string ReceivedDate { get; set; }
        public int Status { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
    }


    public class ResultCieloPixModel
    {
        public string MerchantOrderId { get; set; }
        public ResultCieloPixCustomer Customer { get; set; }
        public ResultCieloPixPayment Payment { get; set; }
    }
}
