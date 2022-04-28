using Steamworks;
using Steamworks.Data;

namespace Explorer.Framework.Manager
{
    // XXX: Steam Only for now!!!
    public class NetworkManager
    {
        public bool isHost { get; set; }
        public NetworkingManager _CKNetworkingManager { get; set; }
        public PugNetworkInterface _PugNetworkInterfaceClient { get; set; }
        public PugNetworkInterface _PugNetworkInterfaceHost { get; set; }
        public SteamNetworking _SteamNetworking { get; set; }
        public SocketManager _SocketManager { get; set; }
        public ConnectionManager _ConnectionManager { get; set; }
        public Connection[] _ConnectedPeers { get; set; }
        public Connection[] _ConnectingPeers { get; set; }
        public bool isConnected { get; set; }



    }
    /*
    as Client
    SteamNetworking
    SteamNetworking._clientInitialized = true
    SteamNetworking._connectionManager = Steamworks.ConnectionManager
    SteamNetworking._endpoints = List<SteamNetworking.EndPoint> // each EndPoint contains Connection and steamId
    SteamNetworking._isInitialized = true
    SteamNetworking._lobby = Steamworks.Data.Lobby
    SteamNetworking._serverInitialized = false
    SteamNetworking._socketManager = null
    SteamNetworking.isInitialized = true

    PugNetworkInterface (clientNetIf)
    PugNetworkInterface._listening_k__BackingField = true
    PugNetworkInterface.IsCreated = true
    PugNetworkInterface.listening = true

    PugNetworkInterface (serverNetIf)
    PugNetworkInterface._listening_k__BackingField = false
    PugNetworkInterface.IsCreated = false
    PugNetworkInterface.listening = false

    NetworkingManager
    NetworkingManager._connectionFailed_k__BackingField = false
    NetworkingManager._internalAddress_k__BackingField = null
    NetworkingManager._isConnected_k__BackingField = true
    NetworkingManager._natType_k__BackingField = null
    NetworkingManager._NetworkId_k__BackingField = 2
    NetworkingManager.connectionFailed = false
    NetworkingManager.isConnected = true

    ConnectionManager
    ConnectionManager._ConnectionInfo_k__BackingField = Steamworks.Data.ConnectionInfo
    ConnectionManager._Interface_k__BackingField = SteamNetworking
    ConnectionManager.Connected = true
    ConnectionManager.Connecting = false
    ConnectionManager.Connection = Steamworks.Data.Connection
    */
}