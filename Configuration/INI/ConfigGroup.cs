using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alardinal.Configuration.INI
{
    class ConfigGroup
    {
        protected Dictionary<string, string> map;

        public string Name { get; set; }

        public ConfigGroup(string name)
        {
            Name = name;
            map = new();
        }

        public Dictionary<string, string> Map()
        {
            return map;
        }

        public string? GetString(string key)
        {
            if (map.ContainsKey(key))
                return map[key];

            return null;
        }

        public int? GetInt(string key)
        {
            if (map.ContainsKey(key) && int.TryParse(map[key], out int result))
                return result;

            return null;
        }

        public long? GetLong(string key)
        {
            if (map.ContainsKey(key) && long.TryParse(map[key], out long result))
                return result;

            return null;
        }

        public bool? GetBool(string key)
        {
            if (map.ContainsKey(key) && bool.TryParse(map[key], out bool result))
                return result;

            return null;
        }

        public DateTime? GetDateTime(string key)
        {
            if (map.ContainsKey(key) && DateTime.TryParse(map[key], out DateTime result))
                return result;

            return null;
        }

        public ConfigMap? GetConfingMap(string key)
        {
            if (map.ContainsKey(key))
                return new ConfigMap(map[key].Split(','));

            return null;
        }

        public void SetString(string key, string value)
        {
            if (map.ContainsKey(key))
                map[key] = value;
            else
                map.Add(key, value);
        }

        public void SetInt(string key, int value)
        {
            if (map.ContainsKey(key))
                map[key] = value.ToString();
            else
                map.Add(key, value.ToString());
        }

        public void SetLong(string key, long value)
        {
            if (map.ContainsKey(key))
                map[key] = value.ToString();
            else
                map.Add(key, value.ToString());
        }

        public void SetBool(string key, bool value)
        {
            if (map.ContainsKey(key))
                map[key] = value.ToString();
            else
                map.Add(key, value.ToString());
        }

        public void SetDateTime(string key, DateTime value)
        {
            if (map.ContainsKey(key))
                map[key] = value.ToString();
            else
                map.Add(key, value.ToString());
        }

        public void SetConfigMap(string key, ConfigMap value)
        {
            if (map.ContainsKey(key))
                map[key] = value.ToString();
            else
                map.Add(key, value.ToString());
        }
    }
}
