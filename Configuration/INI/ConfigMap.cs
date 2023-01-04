using System.Collections;

namespace Alardinal.Configuration.INI
{
    public class ConfigMap : IEnumerable<string>
    {
        protected List<string> map;

        public int Lenght => map.Count;

        public ConfigMap()
        {
            map = new();
        }

        public ConfigMap(string[] values)
        {
            map = new();
            AddRange(values);
        }

        public string[] Values()
        {
            return map.ToArray();
        }

        public void AddRange(string[] values)
        {
            map.AddRange(values);
        }

        public void RemoveAt(int index)
        {
            if (Lenght > index)
            {
                map.RemoveAt(index);
            }
        }

        public string? Get(int index)
        {
            if (Lenght > index)
                return map[index];

            return null;
        }

        public int? GetInt(int index)
        {
            if (Lenght > index && int.TryParse(map[index], out int result))
                return result;

            return null;
        }

        public long? GetLong(int index)
        {
            if (Lenght > index && long.TryParse(map[index], out long result))
                return result;

            return null;
        }

        public bool? GetBool(int index)
        {
            if (Lenght > index && bool.TryParse(map[index], out bool result))
                return result;

            return null;
        }

        public DateTime? GetDateTime(int index)
        {
            if (Lenght > index && DateTime.TryParse(map[index], out DateTime result))
                return result;

            return null;
        }

        public void Add(string value)
        {
            map.Add(value);
        }

        public void AddInt(int value)
        {
            map.Add(value.ToString());
        }

        public void AddLong(long value)
        {
            map.Add(value.ToString());
        }

        public void AddBool(bool value)
        {
            map.Add(value.ToString());
        }

        public void AddDateTime(DateTime value)
        {
            map.Add(value.ToString());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return map.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(',', map);
        }
    }
}
