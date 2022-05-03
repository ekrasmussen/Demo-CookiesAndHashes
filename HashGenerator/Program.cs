// See https://aka.ms/new-console-template for more information
using CookiesAndHashes.Services;

string password = Console.ReadLine()!;

string salt = Console.ReadLine()!;

string hashed = HashAndSaltGenerator.GetHash(password, salt);

Console.WriteLine($"PasswordHash: {hashed}");
Console.WriteLine($"Salt: {salt}");
