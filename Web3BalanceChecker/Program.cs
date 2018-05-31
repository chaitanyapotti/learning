using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;

namespace Web3BalanceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            ContractTest();
            //SendEther();
            //TestSendEther();
        }

        private static void ContractTest()
        {
            
        }

        private static void SendEther()
        {
            var password = "Aayushi987654#";
            var accountFilePath = @"C:\Users\Potti\source\repos\EthereumTesting\UTC--2018-03-24T09-49-04.273Z--74768c5bbd459d56dbd47b63e14b8bfe81565538";
            var account = Nethereum.Web3.Accounts.Account.LoadFromKeyStoreFile(accountFilePath, password);
            var web3 = new Web3("https://mainnet.infura.io");
            var balance = web3.Eth.GetBalance.SendRequestAsync(account.Address).Result;
            var toAddress = "0x5CC494843e3f4AC175A5e730c300b011FAbF2cEa";
            TransactionInput transactionInput = new TransactionInput();
            transactionInput.From = account.Address;
            transactionInput.Gas = new HexBigInteger(25000);
            transactionInput.GasPrice = new HexBigInteger(10^10);
            transactionInput.To = toAddress;
            transactionInput.Value = new HexBigInteger(10000000000000000);
            transactionInput.Nonce = web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(account.Address).Result;
            var txSigned = new Nethereum.Signer.TransactionSigner();
            var signedTx = txSigned.SignTransaction(account.PrivateKey, transactionInput.To, transactionInput.Value, transactionInput.Nonce);
            var transaction = new Nethereum.RPC.Eth.Transactions.EthSendRawTransaction(web3.Client);
            var result = transaction.SendRequestAsync(signedTx).Result;
        }

        private static void TestSendEther()
        {
            //var account = new ManagedAccount("0x627306090abaB3A6e1400e9345bC60c78a8BEf57", "c87509a1c067bbde78beb793e6fa76530b6382a4c0241e5e4a9ec0a0f44dc0d3");
            var account = new Nethereum.Web3.Accounts.Account("c87509a1c067bbde78beb793e6fa76530b6382a4c0241e5e4a9ec0a0f44dc0d3");

            UriBuilder uri = new UriBuilder();
            uri.Host = "127.0.0.1";
            uri.Port = 7545;
            var client = new RpcClient(uri.Uri);
            var web3 = new Nethereum.Web3.Web3(account, client);
            
            //Nethereum.Util.UnitConversion.Convert.FromWeiToBigDecimal()

            var addressTo = "0xf17f52151EbEF6C7334FAD080c5704D77216b732";
            string sucess = web3.TransactionManager.SendTransactionAsync(account.Address, addressTo, new HexBigInteger(10000000000000000000)).Result;
            Console.ReadLine();
        }
    }
}
