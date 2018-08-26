using System;

using Neo.Lux.Cryptography;
using Neo.Lux.Core;
using Neo.Lux.Utils;
using Neo.Lux.Debugger;
using Neo.Lux.VM;

namespace NeoBlockChainChallengeTokyo
{
    class Program
    {
        static void Main(string[] args)
        {
            uint TARGET_BLOCK = 2640000;
            String KEY_NEO = "NEO";
            String ADDRESS_1 = "AXDt2hzT35knLnV3MB3dR9rAvYmadUfVdb";
            String ADDRESS_2 = "AKnbvRwL1MSPFWoS6bdD5v2SNHq2uta5tm";
            NeoRPC api = NeoRPC.ForMainNet();

            //-----------------------------------------------
            // 最新ブロック高を取得
            //-----------------------------------------------
            var blockHeightNewer = api.GetBlockHeight();
            Console.WriteLine("height: " + blockHeightNewer);

            //-----------------------------------------------
            // アドレス1の最新残高を取得
            //-----------------------------------------------
            decimal balanceNeo1 = 0;
            Console.WriteLine(ADDRESS_1);
            //var balances = api.GetBalancesOf(address1);
            var balances = api.GetAssetBalancesOf(ADDRESS_1);
            foreach (var entry in balances)
            {
                // NEO残高のみ抽出
                if (entry.Key.Equals(KEY_NEO))
                {
                    balanceNeo1 = entry.Value;
                }

                Console.WriteLine(entry.Key + " => " + entry.Value);
            }
            Console.WriteLine("NEO: " + balanceNeo1);

            //-----------------------------------------------
            // アドレス2の最新残高を取得
            //-----------------------------------------------
            decimal balanceNeo2 = 0;
            Console.WriteLine(ADDRESS_2);
            //balances = api.GetBalancesOf(address2);
            balances = api.GetAssetBalancesOf(ADDRESS_2);
            foreach (var entry in balances)
            {
                // NEO残高のみ抽出
                if (entry.Key.Equals(KEY_NEO))
                {
                    balanceNeo2 = entry.Value;
                }

                Console.WriteLine(entry.Key + " => " + entry.Value);
            }
            Console.WriteLine("NEO: " + balanceNeo2);

            Console.ReadKey();
        }
    }
}
