namespace Alardinal.Configuration.INI
{
    public class Config
    {
        public FileInfo FileConfigurationInfo { get; protected set; }

        private Dictionary<string, ConfigGroup> map;

        private List<string> startComments;

        public Config(FileInfo fileConfigurationInfo, Action<Config>? setup = null)
        {
            FileConfigurationInfo = fileConfigurationInfo;
            map = new();
            startComments = new(new[] 
            { 
                "#Alardinal INI configuration."
            });

            if (setup == null)
                Reload();
            else
            {
                setup.Invoke(this);
                Save();
            }
        }

        public void AddStartComment(string comment) 
        { 
            startComments.Add("#" + comment);
        }

        public void Reload()
        {
            map = new();
            startComments = new();

            if (!FileConfigurationInfo.Exists)
            {
                startComments.Add("#Alardinal INI configuration.");
                Save();
                return;
            }

            string[] lines = File.ReadAllLines(FileConfigurationInfo.FullName);

            string? groupName = null;
            bool startComment = true;
            foreach (string line in lines) 
            {
                string _line = line.Trim();

                if (_line.StartsWith(@"//") || _line.StartsWith('#'))
                {
                    if (startComment)
                        startComments.Add(line);

                    continue;
                }

                if (_line.StartsWith('[') && _line.EndsWith(']'))
                    groupName = _line.TrimStart('[').TrimEnd(']');

                if (groupName == null)
                {
                    if (startComment)
                        startComments.Add("#" + line);

                    continue;
                }

                string[] keyValuePair = line.Split('=');
                if (keyValuePair.Length < 2)
                {
                    if (startComment)
                        startComments.Add("#" + line);

                    continue;
                }

                startComment = false;

                string key = keyValuePair[0];
                string value = keyValuePair[1];

                SetString(groupName, key, value);
            }
        }

        public void Save()
        {
            List<string> lines = new();
            lines.AddRange(startComments);

            foreach (var group in map)
            {
                lines.Add("");
                lines.Add("[" + group.Value.Name + "]");

                foreach (var pair in group.Value.Map())
                {
                    lines.Add(pair.Key+ "=" + pair.Value);
                }
            }

            File.WriteAllLines(FileConfigurationInfo.FullName, lines.ToArray());
        }

        private ConfigGroup? GetGroup(string group)
        {
            if (map.ContainsKey(group))
                return map[group];

            return null;
        }

        public string? GetString(string group, string key)
        {
            var g = GetGroup(group);

            return g == null ? null : g.GetString(key);
        }

        public int? GetInt(string group, string key)
        {
            var g = GetGroup(group);

            return g == null ? null : g.GetInt(key);
        }

        public long? GetLong(string group, string key)
        {
            var g = GetGroup(group);

            return g == null ? null : g.GetLong(key);
        }

        public bool? GetBool(string group, string key)
        {
            var g = GetGroup(group);

            return g == null ? null : g.GetBool(key);
        }

        public DateTime? GetDateTime(string group, string key)
        {
            var g = GetGroup(group);

            return g == null ? null : g.GetDateTime(key);
        }

        public ConfigMap? GetConfingMap(string group, string key)
        {
            var g = GetGroup(group);

            return g == null ? null : g.GetConfingMap(key);
        }

        public void SetString(string group, string key, string value)
        {
            var g = GetGroup(group);
            if (g == null)
            {
                g = new ConfigGroup(group);
                map.Add(group, g);
            }

            g.SetString(key, value);
        }

        public void SetInt(string group, string key, int value)
        {
            var g = GetGroup(group);
            if (g == null)
            {
                g = new ConfigGroup(group);
                map.Add(group, g);
            }

            g.SetInt(key, value);
        }

        public void SetLong(string group, string key, long value)
        {
            var g = GetGroup(group);
            if (g == null)
            {
                g = new ConfigGroup(group);
                map.Add(group, g);
            }

            g.SetLong(key, value);
        }

        public void SetBool(string group, string key, bool value)
        {
            var g = GetGroup(group);
            if (g == null)
            {
                g = new ConfigGroup(group);
                map.Add(group, g);
            }

            g.SetBool(key, value);
        }

        public void SetDateTime(string group, string key, DateTime value)
        {
            var g = GetGroup(group);
            if (g == null)
            {
                g = new ConfigGroup(group);
                map.Add(group, g);
            }

            g.SetDateTime(key, value);
        }

        public void SetConfigMap(string group, string key, ConfigMap value)
        {
            var g = GetGroup(group);
            if (g == null)
            {
                g = new ConfigGroup(group);
                map.Add(group, g);
            }

            g.SetConfigMap(key, value);
        }
    }
}