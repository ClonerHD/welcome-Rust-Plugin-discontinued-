using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;


namespace Oxide.Plugins
{
    [Info("Welcome Plugin", "Cloner", "0.0.3")]
    [Description("Welcomes players to your server with completely customizable messages!")]
    internal class Welcome : CovalencePlugin
    {
        
		#region Variables
		
        private const string Permission = "debug.use";

        protected override void LoadDefaultConfig()
        {
            Config["ConnectColor"] = "#00FF00";
            Config["DisconnectColor"] = "#FF0000";

            Config["ConnectMessage"] = "{0} connected";
            Config["DisconnectMessage"] = "{0} disconnected";
        }
		
		#endregion
		
		#region Functions
		
        
        private string GetConfig(string key, string defaultValue)
        {
            if (Config[key] == null)
            {
                return defaultValue;
            }
            return Config[key].ToString();
        }

        private void PrintToChat(BasePlayer player, string message, string color) {
            player.ChatMessage("<color=" + color + ">" + string.Format(message, player.displayName));
        }
		
        void OnPlayerConnected(BasePlayer player)
        {
            PrintToChat(player, string.Format(GetConfig("ConnectMessage", "{0} connected"), player.displayName), GetConfig("ConnectColor", "#00FF00"));
        }

        void OnPlayerDisconnected(BasePlayer player, string reason)
        {
            PrintToChat(player, string.Format(GetConfig("DisconnectMessage", "{0} disconnected"), player.displayName), GetConfig("DisconnectColor", "#FF0000"));

        }   

        [Command("debug-welcome"), Permission(Permission)]
        void beleidigung(IPlayer player, string command, string[] args)
        {
            BasePlayer target = (BasePlayer)player.Object;

            PrintToChat(target, string.Format(GetConfig("ConnectMessage", "&a{0} connected"), target.displayName), GetConfig("ConnectColor", "#00FF00"));
        }
		
        #endregion
		
    }
}