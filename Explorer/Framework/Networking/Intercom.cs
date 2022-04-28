using System.Runtime.InteropServices;

namespace Explorer.Framework.Networking
{
    public static class Intercom
    {
        public static Steamworks.Result SendTestMessageUni(Steamworks.Data.Connection conn, string message)
        {
            return conn.SendMessage(Marshal.StringToHGlobalUni(message), message.Length * 2 + 1);
        }

        public static System.Collections.Generic.List<Steamworks.Friend> GetLobbyMembers(SteamNetworking _steam)
        {
            System.Collections.Generic.List<Steamworks.Friend> ret = new System.Collections.Generic.List<Steamworks.Friend>();
            for (int i = 0; i < _steam._lobby.MemberCount; i++)
            {
                ret.Add(new Steamworks.Friend(Steamworks.SteamMatchmaking.Internal.GetLobbyMemberByIndex(_steam._lobby.Id, i)));
            }
            return ret;
        }
    }
}