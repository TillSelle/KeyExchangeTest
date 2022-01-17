using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using KeyExchange;

class ClientExchangeTest
{
    public static void Main(string[] args)
    {

        // Create Clients that want to receive the message
        Client client = new Client();
        Client client2 = new Client();

        // Create and set the private keys for encryption and decryption
        client.GenerateAndSetPrivateKey(client2);
        client2.GenerateAndSetPrivateKey(client);

        // Encrypt Data
        List<byte[]> data = client.Encrypt("RandomStringToEncrypt");
        
        // Decrypt Data and print the decryypted string
        Console.WriteLine(client2.Decrypt(Encoding.Latin1.GetBytes(Encoding.Latin1.GetString(data[0])), Encoding.Latin1.GetBytes(Encoding.Latin1.GetString(data[1]))).Content);
        
        // Sleep so you can see the decrypted message
        Thread.Sleep(11000);
    }
}