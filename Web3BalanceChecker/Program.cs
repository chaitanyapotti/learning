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
    }
}
