using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using TesteCielo.Models;
using TesteCielo.Services;

namespace TesteCielo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a opção: (1-Cartão de crédito 2-Pix 3-Boleto)");
            var opcao = Console.ReadLine();

            var cieloService = new CieloSaleService();

            switch(opcao)
            {
                case "1":
                    var objResultCreditCard = GetObjectCreditCard();

                    var resultCreditCard = cieloService.CreateTransactionCreditCard(objResultCreditCard);

                    if (resultCreditCard.First().Key)
                        Console.WriteLine("Transação de cartão de crédito feita com sucesso");
                    else
                        Console.WriteLine("Erro: " + resultCreditCard.First().Value);
                    break;
                case "2":
                    var objResultPix = GetObjectPix();

                    var resultPix = cieloService.CreateTransactionPixQrCode(objResultPix);

                    if (resultPix.First().Key)
                        Console.WriteLine("Transação de cartão de crédito feita com sucesso");
                    else
                        Console.WriteLine("Erro: " + resultPix.First().Value);
                    break;
                case "3":
                    var objResultBillet = GetObjectBillet();

                    var resultBillet = cieloService.CreateTransactionBillet(objResultBillet);

                    if (resultBillet.First().Key)
                        Console.WriteLine("Transação de boleto feita com sucesso");
                    else
                        Console.WriteLine("Erro: " + resultBillet.First().Value);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.ReadKey();
        }

        private static CieloCreditCardModel GetObjectCreditCard()
        {
            var objResult = new CieloCreditCardModel();
            objResult.MerchantOrderId = "P10";

            objResult.Customer = new CieloCreditCardCustomer();
            objResult.Customer.Name = "Comprador crédito completo";
            objResult.Customer.Identity = "11225468954";
            objResult.Customer.IdentityType = "CPF";
            objResult.Customer.Email = "compradorteste@teste.com";
            objResult.Customer.Birthdate = "1991-01-02";

            objResult.Customer.DeliveryAddress = new CieloCreditCardDeliveryAddress();
            objResult.Customer.DeliveryAddress.Street = "Rua Teste";
            objResult.Customer.DeliveryAddress.Number = "123";
            objResult.Customer.DeliveryAddress.Complement = "AP 123";
            objResult.Customer.DeliveryAddress.ZipCode = "12345987";
            objResult.Customer.DeliveryAddress.City = "Rio de Janeiro";
            objResult.Customer.DeliveryAddress.State = "RJ";
            objResult.Customer.DeliveryAddress.Country = "BRA";

            objResult.Customer.Billing = new CieloCreditCardBilling();
            objResult.Customer.Billing.Street = "Rua Neturno";
            objResult.Customer.Billing.Number = "12345";
            objResult.Customer.Billing.Complement = "Sala 123";
            objResult.Customer.Billing.Neighborhood = "Centro";
            objResult.Customer.Billing.City = "Rio de Janeiro";
            objResult.Customer.Billing.State = "RJ";
            objResult.Customer.Billing.Country = "BR";
            objResult.Customer.Billing.ZipCode = "20080123";

            objResult.Payment = new CieloCreditCardPayment();
            objResult.Payment.ServiceTaxAmount = 0;
            objResult.Payment.Installments = 1;
            objResult.Payment.Interest = "ByMerchant";
            objResult.Payment.Capture = true;
            objResult.Payment.Authenticate = false;
            objResult.Payment.Recurrent = "false";
            objResult.Payment.SoftDescriptor = "123456789ABCD";

            objResult.Payment.CreditCard = new CieloCreditCard();
            objResult.Payment.CreditCard.CardNumber = "4551870000000183";
            objResult.Payment.CreditCard.Holder = "Teste Holder";
            objResult.Payment.CreditCard.ExpirationDate = "12/2030";
            objResult.Payment.CreditCard.SecurityCode = "123";
            objResult.Payment.CreditCard.SaveCard = "false";
            objResult.Payment.CreditCard.Brand = "Visa";

            objResult.Payment.CreditCard.CardOnFile = new CieloCreditCardCardOnFile();
            objResult.Payment.CreditCard.CardOnFile.Usage = "Used";
            objResult.Payment.CreditCard.CardOnFile.Reason = "Unscheduled";

            objResult.Payment.Type = "CreditCard";
            objResult.Payment.Amount = 100;

            return objResult;
        }

        private static CieloPixModel GetObjectPix()
        {
            var objResult = new CieloPixModel();
            objResult.MerchantOrderId = "P11";

            objResult.Customer = new CieloPixCustomer();
            objResult.Customer.Name = "Nome do Pagador";
            objResult.Customer.Identity = "CPF";
            objResult.Customer.IdentityType = "12345678909";

            objResult.Payment = new CieloPixPayment();
            objResult.Payment.Type = "Pix";
            objResult.Payment.Amount = 100;

            return objResult;
        }

        private static CieloBilletModel GetObjectBillet()
        {
            var objResult = new CieloBilletModel();
            objResult.MerchantOrderId = "P13";

            objResult.Customer = new CieloBilletCustomer();
            objResult.Customer.Name = "Comprador Teste Boleto";
            objResult.Customer.Identity = "1234567890";

            objResult.Customer.Address = new CieloBilletAddress();
            objResult.Customer.Address.Street = "Avenida Marechal Câmara";
            objResult.Customer.Address.Number = "160";
            objResult.Customer.Address.Complement = "Sala 934";
            objResult.Customer.Address.ZipCode = "22750012";
            objResult.Customer.Address.District = "Centro";
            objResult.Customer.Address.City = "Rio de Janeiro";
            objResult.Customer.Address.State = "RJ";
            objResult.Customer.Address.Country = "BRA";

            objResult.Customer.Billing = new CieloBilletBilling();
            objResult.Customer.Billing.Street = "Avenida Marechal Câmara";
            objResult.Customer.Billing.Number = "160";
            objResult.Customer.Billing.Complement = "Sala 934";
            objResult.Customer.Billing.Neighborhood = "Centro";
            objResult.Customer.Billing.City = "Rio de Janeiro";
            objResult.Customer.Billing.State = "RJ";
            objResult.Customer.Billing.Country = "BR";
            objResult.Customer.Billing.ZipCode = "22750012";

            objResult.Payment = new CieloBilletPayment();
            objResult.Payment.Type = "Boleto";
            objResult.Payment.Amount = 15700;
            objResult.Payment.Provider = "Bradesco2";
            objResult.Payment.Address = "Rua Teste";
            objResult.Payment.BoletoNumber = "123";
            objResult.Payment.Assignor = "Empresa Teste";
            objResult.Payment.Demonstrative = "Desmonstrative Teste";
            objResult.Payment.ExpirationDate = "2022-12-31";
            objResult.Payment.Identification = "123465";
            objResult.Payment.Instructions = "Aceitar somente até a data de vencimento, após essa data juros de 1% dia.";

            return objResult;
        }
    }
}
