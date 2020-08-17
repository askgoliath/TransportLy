using System;
using System.IO;

namespace TransportLy.Service
{
    public class JsonDataService : IDataService
    {
        protected static string LoadJsonData(string fromFile)
        {
            var path = Path.Combine(Environment.CurrentDirectory, @"Data", fromFile); ;
            var json = File.ReadAllText(path);
            return json;
        }
    }
}
