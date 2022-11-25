using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using TesteCielo.Models;

namespace TesteCielo.Services
{
    public class CieloSaleService
    {
        private readonly string _urlRequest = "https://apisandbox.cieloecommerce.cielo.com.br/1/sales";
        private string _merchantId = "SEU ID";
        private string _merchantKey = "SUA CHAVE";

        public Dictionary<bool, string> CreateTransactionCreditCard(CieloCreditCardModel cieloCreditCard)
        {
            var resultCreateTransactionCreditCard = new Dictionary<bool, string>();

            var client = new RestClient(_urlRequest);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("MerchantId", _merchantId);
            request.AddHeader("MerchantKey", _merchantKey);
            request.AddJsonBody(cieloCreditCard);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.Created)
            {
                var objResponse = JsonConvert.DeserializeObject<ResultCreditCardModel>(response.Content);

                resultCreateTransactionCreditCard.Add(true, "");
            }
            else
                resultCreateTransactionCreditCard.Add(false, response.Content);

            return resultCreateTransactionCreditCard;
        }

        public Dictionary<bool, string> CreateTransactionPixQrCode(CieloPixModel cieloPix)
        {
            var resultCreateTransactionPix= new Dictionary<bool, string>();

            var client = new RestClient(_urlRequest);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("MerchantId", _merchantId);
            request.AddHeader("MerchantKey", _merchantKey);
            request.AddJsonBody(cieloPix);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var resultCreatePix = JsonConvert.DeserializeObject<ResultCieloPixModel>(response.Content);

                resultCreateTransactionPix.Add(true, "");
            }
            else
                resultCreateTransactionPix.Add(false, response.Content);

            return resultCreateTransactionPix;
        }

        public Dictionary<bool, string> CreateTransactionBillet(CieloBilletModel cieloBillet)
        {
            var resultCreateTransactionBillet = new Dictionary<bool, string>();

            var client = new RestClient(_urlRequest);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("MerchantId", _merchantId);
            request.AddHeader("MerchantKey", _merchantKey);
            request.AddJsonBody(cieloBillet);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var resultCreateBillet = JsonConvert.DeserializeObject<ResultCieloBilletModel>(response.Content);

                resultCreateTransactionBillet.Add(true, "");
            }
            else
                resultCreateTransactionBillet.Add(false, response.Content);

            return resultCreateTransactionBillet;
        }
    }
}
