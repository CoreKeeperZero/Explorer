using UnityEngine;

namespace Explorer.Framework.Manager
{
    public class InputManager : MonoBehaviour
    {
        public InputManager(System.IntPtr ptr) : base(ptr) { }

        private void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                Explorer.Logger.LogMessage("Input LShift");
                if (UnityEngine.Input.GetKeyDown(KeyCode.U))
                {
                    Explorer.Logger.LogMessage("Input LShift + U detected!");
                }
            }
        }
    }
}