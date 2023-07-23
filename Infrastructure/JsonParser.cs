using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class JsonParser
    {
        private string _path { get; }

        public JsonParser(string path)
        {
            _path = path;
        }

        public IEnumerable<Player> ParseJson()
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException($"File not found at path: {_path}");
            }

            string jsonData = File.ReadAllText(_path);

            try
            {
                TennisData tennisData = JsonConvert.DeserializeObject<TennisData>(jsonData);
                return tennisData.Players;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while parsing JSON data: {ex.Message}", ex);
            }
        }
        public class TennisData
        {
            public List<Player> Players { get; set; }
        }
    }
}
