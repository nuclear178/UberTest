using System;
using System.Linq;
using Domain.Services;

namespace Infrastructure.Services
{
    public class SerialNumberGenerator : ISerialNumberGenerator
    {
        private const int Length = 12;
        private static readonly Random Random = new Random();

        public string Generate()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, Length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}