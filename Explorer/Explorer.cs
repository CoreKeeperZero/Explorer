using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using CustomInputManager = Explorer.Framework.Manager.InputManager;

namespace Explorer
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.le4fless.corelib")]
    public class Explorer : BasePlugin
    {
        internal static ManualLogSource Logger { get; private set; }
        public override void Load()
        {
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Logger = base.Log;
            ConfigManager.Init(Config);

            var harmony = new Harmony("com.theidel.Explorer");
            harmony.PatchAll();

            Logger.LogInfo($"{PluginInfo.PLUGIN_NAME} is patched!");

            //base.AddComponent<ExplorerBehaviour>();
            base.AddComponent<CustomInputManager>();
            /*
            // deactivate feedback button
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Title")
            {
                UnityEngine.GameObject.Find("feedback").SetActive(false);
            } else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main")
            {
                UnityEngine.GameObject.Find("Feedback Option").SetActive(false);
            }
            */
        }
    }
}
