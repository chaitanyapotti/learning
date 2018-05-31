using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Accounts;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using System;

namespace Web3DeployInteractor
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddressUtil util = new AddressUtil();
            //Nethereum.ABI.Model.ContractABI abi = new Nethereum.ABI.Model.ContractABI();


            //Nethereum.Contracts.ContractBuilder build = new Nethereum.Contracts.ContractBuilder();


            //Nethereum.Contracts.DeployContractTransactionBuilder builder = new Nethereum.Contracts.DeployContractTransactionBuilder();
            //builder.BuildTransaction();

            //Nethereum.Contracts.DeployContract deployContract = new Nethereum.Contracts.DeployContract();

            //Nethereum.Contracts.
            //UriBuilder uri = new UriBuilder();
            //uri.Host = "127.0.0.1";
            //uri.Port = 7545;
            //Nethereum.JsonRpc.Client.RpcClient client = new Nethereum.JsonRpc.Client.RpcClient(uri.Uri);
            //Nethereum.RPC.EthApiService service = new Nethereum.RPC.EthApiService(client);
            //var account = service.Accounts.BuildRequest();
            //var param = account.RawParameters[0];

            //Nethereum.Contracts.Contract contract = new Nethereum.Contracts.Contract(service, )
            SendEther();
        }

        private static async void SendEther()
        {
            //var password = "Aayushi987654#";
            //var accountFilePath = @"C:\Users\Potti\source\repos\EthereumTesting\UTC--2018-03-24T09-49-04.273Z--74768c5bbd459d56dbd47b63e14b8bfe81565538";
            ////var fileText = @"{"version":3,"id":"89dbcc81 - 1ba4 - 48cb - 8ed6 - c27eaa63b72d","address":"74768c5bbd459d56dbd47b63e14b8bfe81565538","Crypto":{"ciphertext":"c2f381c1329e09288035a9b4fcaf957eb7146b0b7b9c4c106c0890334c76275a","cipherparams":{"iv":"461e7ac49c838e7798295aca58372194"},"cipher":"aes - 128 - ctr","kdf":"scrypt","kdfparams":{"dklen":32,"salt":"a6592e2949780092a492610dc4614fe801321683d687d6356bbc45c8f89fe7ce","n":8192,"r":8,"p":1},"mac":"1cf5fef371ef6f60cb0809ec2479bfdf997cdf26e5f6f257d8f0eb245d0f44ae"}}";
            //var account = Nethereum.Web3.Accounts.Account.LoadFromKeyStore(accountFilePath, password);
            var account = new ManagedAccount("0x627306090abaB3A6e1400e9345bC60c78a8BEf57", "c87509a1c067bbde78beb793e6fa76530b6382a4c0241e5e4a9ec0a0f44dc0d3");
            UriBuilder uri = new UriBuilder();
            uri.Host = "127.0.0.1";
            uri.Port = 7545;
            var client = new RpcClient(uri.Uri);
            var web3 = new Nethereum.Web3.Web3(account, client);

            var addressTo = "0xf17f52151EbEF6C7334FAD080c5704D77216b732";
            string sucess = (await web3.TransactionManager.SendTransactionAsync(account.Address, addressTo, new HexBigInteger(10000000000000000)));
            Console.ReadLine();
        }
    }
}
