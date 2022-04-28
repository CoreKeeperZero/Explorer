using BepInEx.Configuration;
using System.IO;

namespace Explorer
{
    /// <summary>
    /// The <see cref="ConfigManager"/> to manage the settings
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// The <see cref="Config"/> containing all settings
        /// </summary>
        public static ConfigFile Config { get; private set; }

        // Settings
        /// <summary>
        /// Path to the <see cref="BaseFolder"/>
        /// </summary>
        public static ConfigEntry<string> BaseFolder;

        /// <summary>
        /// Add a setting
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="description"></param>
        public static void Add<T>(string section, string key, T defaultValue, string description)
        {
            Config.Bind(section: section, key: key, defaultValue: defaultValue, description: description);
        }

        /// <summary>
        /// Get a setting's container which also contains <see cref="ConfigEntryBase.BoxedValue"/>
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ConfigEntryBase Get(string section, string key)
        {
            return Config[section: section, key: key];
        }

        /// <summary>
        /// Initialize <see cref="ConfigManager"/>
        /// </summary>
        /// <param name="config"></param>
        public static void Init(ConfigFile config)
        {
            Config = config;
            Config.SettingChanged += (s, args) =>
            {
                ConfigEntryBase changed = args.ChangedSetting;
                Explorer.Logger.LogWarning($"Setting: [{changed.Definition.ToString()}] got changed to: [{changed.GetSerializedValue()}]");
            };
            Load();
        }

        // TODO: Modify it so that each mod will use their name instead of Explorer
        // TODO: Make custom folder creation optional and let mods use Explorer folder or a sub folder in Explorer
        /// <summary>
        /// Load all settings
        /// </summary>
        private static void Load()
        {
            var BaseFolderPath = "";
            if (Path.Combine(BepInEx.Paths.PluginPath, PluginInfo.PLUGIN_NAME) != Path.Combine(BepInEx.Paths.BepInExRootPath, Path.Combine("plugins", PluginInfo.PLUGIN_NAME)))
            {
                BaseFolderPath = Path.Combine(BepInEx.Paths.BepInExRootPath, Path.Combine("plugins", PluginInfo.PLUGIN_NAME));
                Explorer.Logger.LogWarning($"BaseFolder path mismatch. Changing to fallback {BaseFolderPath}");
            }
            else
            {
                BaseFolderPath = Path.Combine(BepInEx.Paths.PluginPath, PluginInfo.PLUGIN_NAME);
                // Explorer.Logger.LogWarning($"BaseFolder path {BaseFolderPath}");
            }
            if (!Directory.Exists(BaseFolderPath))
            {
                Directory.CreateDirectory(BaseFolderPath);
            }
            BaseFolder = Config.Bind(PluginInfo.PLUGIN_NAME, "BaseFolder", BaseFolderPath, "The default BaseFolder path");

            // Config.Bind<string>("General", "GeneralText", "GeneralTextTest", "A General Test Text");
        }

        public static object GetConfigValue(string section, string key)
        {
            return Config[new BepInEx.Configuration.ConfigDefinition(section: section, key: key)].BoxedValue;
        }

        /// <summary>
        /// Reload config from disk. Beware that unsaved changes are lost.
        /// <para/>
        /// Use <see cref="Save"/> before if you want to save changes.
        /// </summary>
        public static void Reload()
        {
            Config.Reload();
        }

        /// <summary>
        /// Remove a given item from the config
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true if success; otherwise, false</returns>
        public static bool Remove(ConfigDefinition key)
        {
            return Config.Remove(key);
        }

        /// <summary>
        /// Write config to disk
        /// </summary>
        public static void Save()
        {
            Config.Save();
        }
    }

    /*
    if (Config.TryGetEntry<string>("General", "GeneralText", out var entry))
        {
            Explorer.Logger.LogMessage(entry.Value);
        }
    */
}