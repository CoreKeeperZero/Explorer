namespace Explorer.Framework.Input
{
    public static class FocusFix
    {
        /// <summary>
        /// Disable Input. Input will be automatically enabled again if window gets focused again.
        /// </summary>
        public static void DisableInput()
        {
            CoreLib.GameManagers.GetMainManager()._uiManager.controlMapper.rewiredInputManager.OnApplicationFocus(false);

            // alternatively use static classes
            // Rewired.ReInput.rewiredInputManager.OnApplicationFocus(false);
            // another static InputManager_Base
            // Rewired.ReInput.KoNwuyPtmpyEKdMAFOeFizOoaqe.OnApplicationFocus(false);
            // ikZvCKSkRDXFvERZNZvsPFExyfg
            // Rewired.ReInput.ikZvCKSkRDXFvERZNZvsPFExyfg(false);
            // fREyTrMGGVRZjInYRNHttNqecBB (probably) maps to 'isFocused'
            // bool _isFocused = Rewired.ReInput.fREyTrMGGVRZjInYRNHttNqecBB;
        }

        public static void EnableInput()
        {
            Rewired.ReInput.ikZvCKSkRDXFvERZNZvsPFExyfg(true);
        }

        public static Rewired.Player GetPlayer()
        {
            // CoreLib.GameManagers.GetManager<InputManager>().system;
            // CoreLib.GameManagers.GetMainManager()._inputManager.system;
            // CoreLib.GameManagers.GetMainManager()._inputManager.singleplayerInputModule.rewiredPlayer;
            // CoreLib.Players.GetCurrentPlayer().inputModule.rewiredPlayer;
            // CoreLib.Players.GetCurrentPlayer().currentMultiplayerInputModule.rewiredPlayer;
            // CoreLib.GameManagers.GetMainManager().player.inputModule.rewiredPlayer;
            // CoreLib.GameManagers.GetMainManager().player.currentMultiplayerInputModule.rewiredPlayer;

            // static alternatives
            // Rewired.ReInput.PlayerHelper playerHelper = Rewired.ReInput.players;
            // playerHelper.GetPlayer(0);
            // playerHelper.GetSystemPlayer();

            return CoreLib.GameManagers.GetMainManager()._uiManager.controlMapper.currentPlayer;
        }

        public static Rewired.ReInput.ControllerHelper GetControllerHelper()
        {
            // GetPlayer().controllers; // type mismatch
            // Rewired.ReInput.PFTNqayYRwxYGnzXDNcrdRGtWUo;
            return Rewired.ReInput.controllers;
        }

        // BUG: doesn't work somehow
        public static Rewired.Player.ControllerHelper GetControllerHelper(Rewired.Player player)
        {
            return player.controllers;
        }

        public static Rewired.Keyboard GetKeyboard()
        {
            return GetControllerHelper().Keyboard;
        }

        public static Rewired.Keyboard GetKeyboard(Rewired.Player player)
        {
            return GetControllerHelper(player).Keyboard;
        }

        // BUG: wrong player? 
        /// <summary>
        /// Enable or Disable Keyboard for a given player depending on given boolean
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enable"></param>
        public static void EnableKeyboard(Rewired.Player player, bool enable = true)
        {
            player.controllers.hasKeyboard = enable;
        }

        // BUG: wrong player?
        /// <summary>
        /// Enable or Disable Mouse for a given player depending on given boolean
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enable"></param>
        public static void EnableMouse(Rewired.Player player, bool enable = true)
        {
            player.controllers.hasMouse = enable;
        }
    }
}