using UnityEngine;
using UnhollowerRuntimeLib;

namespace Explorer
{
    public class ExplorerBehaviour : MonoBehaviour
    {
        // internal static ExplorerBehaviour Instance { get; private set; }
        public ExplorerBehaviour(System.IntPtr ptr) : base(ptr) { }

        void Awake()
        {
            Explorer.Logger.LogMessage("ExplorerBehaviour Awake");
        }

        void Start()
        {
            Explorer.Logger.LogMessage("ExplorerBehaviour Start");
        }

        /*
        internal static void Setup()
        {
            //GameObject obj = new("ExplorerBehaviour");
            //DontDestroyOnLoad(obj);
            //Instance = obj.AddComponent<ExplorerBehaviour>();
            //obj.AddComponent<UnityEngine.EventSystems.EventSystem>();
            //Instantiate(obj, Vector3.zero, Quaternion.identity);
            //obj.AddComponent<Framework.Manager.InputManager>();
        }
        */
    }
}