using HarmonyLib;
using System.Runtime.InteropServices;

namespace Explorer.Patches
{

    [HarmonyPatch]
    internal class ExperimentalPatch
    {
        /*
        [HarmonyPatch(typeof(NetworkCommSystem), nameof(NetworkCommSystem.SendChatMessage))]
        class Patch_SendChatMessage
        {
            static void Postfix(ref string message, NetworkCommSystem __instance)
            {
                Explorer.Logger.LogMessage("Patch_SendChatMessage Post");
                Explorer.Logger.LogWarning($"message: {message}");
                Explorer.Logger.LogWarning($"__instance: {__instance}");
                Explorer.Logger.LogWarning($"__instance.messageRpcArchetype.Archetype: {__instance.messageRpcArchetype.Archetype}");

                if (message.Contains("test"))
                {
                    Explorer.Logger.LogWarning("triggered test command.");
                }
            }
        }
        */

        [HarmonyPatch(typeof(UnityEngine.Debug), nameof(UnityEngine.Debug.isDebugBuild), MethodType.Getter)]
        class Patch_isDebugBuild
        {
            static void Postfix(ref bool __result)
            {
                Explorer.Logger.LogMessage("Patch_isDebugBuild Post");
                __result = true;
                Explorer.Logger.LogWarning($"Changed isDebugBuild to __result: {__result}");
            }
        }

        /*
        [HarmonyPatch(typeof(Steamworks.ISteamMatchmaking), nameof(Steamworks.ISteamMatchmaking.CreateLobby))]
        class Patch_Steamworks_ISteamMatchmaking_CreateLobby
        {
            static void Postfix(ref Steamworks.CallResult<Steamworks.Data.LobbyCreated_t> __result)
            {
                Explorer.Logger.LogMessage("Patch_Steamworks_ISteamMatchmaking_CreateLobby Post");
                Explorer.Logger.LogWarning($"__result: {__result}");
                Explorer.Logger.LogWarning($"__result.call: {__result.call}");
                Explorer.Logger.LogWarning($"__result.server: {__result.server}");
            }
        }
        */

        /*
        [HarmonyPatch(typeof(Steamworks.ISteamMatchmaking), nameof(Steamworks.ISteamMatchmaking._CreateLobby))]
        class Patch_Steamworks_ISteamMatchmaking__CreateLobby
        {
            static void Postfix(ref Steamworks.Data.SteamAPICall_t __result)
            {
                Explorer.Logger.LogMessage("Patch_Steamworks_ISteamMatchmaking__CreateLobby Post");
                Explorer.Logger.LogWarning($"__result: {__result}");
            }
        }

        [HarmonyPatch(typeof(Steamworks.SteamMatchmaking), nameof(Steamworks.SteamMatchmaking.CreateLobbyAsync))]
        class Patch_Steamworks_SteamMatchmaking_CreateLobbyAsync
        {
            static void Postfix(ref Il2CppSystem.Threading.Tasks.Task<Il2CppSystem.Nullable<Steamworks.Data.Lobby>> __result)
            {
                Explorer.Logger.LogMessage("Patch_Steamworks_SteamMatchmaking_CreateLobbyAsync Post");
                Explorer.Logger.LogWarning($"__result: {__result}");
            }
        }

        [HarmonyPatch(typeof(Steamworks.SteamMatchmaking._CreateLobbyAsync_d__45), nameof(Steamworks.SteamMatchmaking._CreateLobbyAsync_d__45.MoveNext))]
        class Patch_Steamworks_SteamMatchmaking__CreateLobbyAsync_d__45_MoveNext
        {
            static void Postfix(Steamworks.SteamMatchmaking._CreateLobbyAsync_d__45 __instance)
            {
                Explorer.Logger.LogMessage("Patch_Steamworks_SteamMatchmaking__CreateLobbyAsync_d__45_MoveNext Post");
                Explorer.Logger.LogWarning($"__instance: {__instance}");
                Explorer.Logger.LogWarning($"__instance.__1__state: {__instance.__1__state}");
                Explorer.Logger.LogWarning($"__instance.lobbyType: {__instance.lobbyType}");
                Explorer.Logger.LogWarning($"__instance.maxMembers: {__instance.maxMembers}");
                Explorer.Logger.LogWarning($"__instance.__t__builder: {__instance.__t__builder}");
                Explorer.Logger.LogWarning($"__instance.__u__1: {__instance.__u__1}");
            }
        }
        */

        /*
        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.Connect))]
        class Patch_SteamNetworking_Connect
        {
            static void Postfix(ref string session)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_Connect Post");
                Explorer.Logger.LogWarning($"session: {session}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.Deinitialize))]
        class Patch_SteamNetworking_Deinitialize
        {
            static void Postfix()
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_Deinitialize Post");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.Disconnect))]
        class Patch_SteamNetworking_Disconnect
        {
            static void Postfix()
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_Disconnect Post");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.EndPointFromSteamId))]
        class Patch_SteamNetworking_EndPointFromSteamId
        {
            static void Postfix(ref ulong connectionId)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_EndPointFromSteamId Post");
                Explorer.Logger.LogWarning($"connectionId: {connectionId}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.EndPointFromSteamId2))]
        class Patch_SteamNetworking_EndPointFromSteamId2
        {
            static void Postfix(ref ulong connectionId)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_EndPointFromSteamId2 Post");
                Explorer.Logger.LogWarning($"connectionId: {connectionId}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.GetLocalEndpoint))]
        class Patch_SteamNetworking_GetLocalEndpoint
        {
            static void Postfix()
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_GetLocalEndpoint Post");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.Initialize))]
        class Patch_SteamNetworking_Initialize
        {
            static void Postfix()
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_Initialize Post");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.LobbyIdFromSession))]
        class Patch_SteamNetworking_LobbyIdFromSession
        {
            static void Postfix(ref string session)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_LobbyIdFromSession Post");
                Explorer.Logger.LogWarning($"session: {session}");
            }
        }
        */
        /*
        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.OnConnected), new System.Type[] { typeof(Steamworks.Data.ConnectionInfo) })]
        class Patch_SteamNetworking_OnConnected__1
        {
            static void Postfix(ref Steamworks.Data.ConnectionInfo info)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnConnected__1 Post");
                Explorer.Logger.LogWarning($"info: {info}");
                Explorer.Logger.LogWarning($"info.address: {info.address}");
                Explorer.Logger.LogWarning($"info.address.ip: {info.address.ip} || info.address.port {info.address.port}");
                Explorer.Logger.LogWarning($"info.connectionDescription: {info.connectionDescription}");
                Explorer.Logger.LogWarning($"info.endDebug: {info.endDebug}");
                Explorer.Logger.LogWarning($"info.endReason: {info.endReason}");
                Explorer.Logger.LogWarning($"info.identity: {info.identity}");
                Explorer.Logger.LogWarning($"info.identity.netaddess: {info.identity.netaddress}");
                Explorer.Logger.LogWarning($"info.identity.netaddress.ip: {info.identity.netaddress.ip} || info.identity.netaddress.port: {info.identity.netaddress.port}");
                Explorer.Logger.LogWarning($"info.identity.size: {info.identity.size}");
                Explorer.Logger.LogWarning($"info.identity.steamid: {info.identity.steamid}");
                Explorer.Logger.LogWarning($"info.identity.Steamid: {info.identity.SteamId}");
                Explorer.Logger.LogWarning($"info.identity.type: {info.identity.type}");
                Explorer.Logger.LogWarning($"info.Identity: {info.Identity}");
                Explorer.Logger.LogWarning($"info.listenSocket: {info.listenSocket}");
                Explorer.Logger.LogWarning($"info.listenSocket.Id: {info.listenSocket.Id}");
                Explorer.Logger.LogWarning($"info.pad: {info.pad}");
                Explorer.Logger.LogWarning($"info.popRelay: {info.popRelay}");
                Explorer.Logger.LogWarning($"info.popRelay.Value: {info.popRelay.Value}");
                Explorer.Logger.LogWarning($"info.popRemote: {info.popRemote}");
                Explorer.Logger.LogWarning($"info.popRemote.Value: {info.popRemote.Value}");
                Explorer.Logger.LogWarning($"info.state: {info.state}");
                Explorer.Logger.LogWarning($"info.state.ToString: {info.state.ToString()}");
                Explorer.Logger.LogWarning($"info.State: {info.State}");
                Explorer.Logger.LogWarning($"info.userData: {info.userData}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.OnConnected), new System.Type[] { typeof(Steamworks.Data.Connection), typeof(Steamworks.Data.ConnectionInfo) })]
        class Patch_SteamNetworking_OnConnected__2
        {
            static void Postfix(ref Steamworks.Data.Connection connection, ref Steamworks.Data.ConnectionInfo info)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnConnected__2 Post");
                Explorer.Logger.LogWarning($"info: {info}");
                Explorer.Logger.LogWarning($"info.address: {info.address}");
                Explorer.Logger.LogWarning($"info.address.ip: {info.address.ip} || info.address.port {info.address.port}");
                Explorer.Logger.LogWarning($"info.connectionDescription: {info.connectionDescription}");
                Explorer.Logger.LogWarning($"info.endDebug: {info.endDebug}");
                Explorer.Logger.LogWarning($"info.endReason: {info.endReason}");
                Explorer.Logger.LogWarning($"info.identity: {info.identity}");
                Explorer.Logger.LogWarning($"info.identity.netaddess: {info.identity.netaddress}");
                Explorer.Logger.LogWarning($"info.identity.netaddress.ip: {info.identity.netaddress.ip} || info.identity.netaddress.port: {info.identity.netaddress.port}");
                Explorer.Logger.LogWarning($"info.identity.size: {info.identity.size}");
                Explorer.Logger.LogWarning($"info.identity.steamid: {info.identity.steamid}");
                Explorer.Logger.LogWarning($"info.identity.Steamid: {info.identity.SteamId}");
                Explorer.Logger.LogWarning($"info.identity.type: {info.identity.type}");
                Explorer.Logger.LogWarning($"info.Identity: {info.Identity}");
                Explorer.Logger.LogWarning($"info.listenSocket: {info.listenSocket}");
                Explorer.Logger.LogWarning($"info.listenSocket.Id: {info.listenSocket.Id}");
                Explorer.Logger.LogWarning($"info.pad: {info.pad}");
                Explorer.Logger.LogWarning($"info.popRelay: {info.popRelay}");
                Explorer.Logger.LogWarning($"info.popRelay.Value: {info.popRelay.Value}");
                Explorer.Logger.LogWarning($"info.popRemote: {info.popRemote}");
                Explorer.Logger.LogWarning($"info.popRemote.Value: {info.popRemote.Value}");
                Explorer.Logger.LogWarning($"info.state: {info.state}");
                Explorer.Logger.LogWarning($"info.state.ToString: {info.state.ToString()}");
                Explorer.Logger.LogWarning($"info.State: {info.State}");
                Explorer.Logger.LogWarning($"info.userData: {info.userData}");
                Explorer.Logger.LogWarning($"connection: {connection}");
                Explorer.Logger.LogWarning($"connection._Id_k__BackingField: {connection._Id_k__BackingField}");
                Explorer.Logger.LogWarning($"connection.Id: {connection.Id}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.OnConnecting), new System.Type[] { typeof(Steamworks.Data.Connection), typeof(Steamworks.Data.ConnectionInfo) })]
        class Patch_SteamNetworking_OnConnecting__2
        {
            static void Postfix(ref Steamworks.Data.Connection connection, ref Steamworks.Data.ConnectionInfo info)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnConnecting__2 Post");
                Explorer.Logger.LogWarning($"info: {info}");
                Explorer.Logger.LogWarning($"info.address: {info.address}");
                Explorer.Logger.LogWarning($"info.address.ip: {info.address.ip} || info.address.port {info.address.port}");
                Explorer.Logger.LogWarning($"info.connectionDescription: {info.connectionDescription}");
                Explorer.Logger.LogWarning($"info.endDebug: {info.endDebug}");
                Explorer.Logger.LogWarning($"info.endReason: {info.endReason}");
                Explorer.Logger.LogWarning($"info.identity: {info.identity}");
                Explorer.Logger.LogWarning($"info.identity.netaddess: {info.identity.netaddress}");
                Explorer.Logger.LogWarning($"info.identity.netaddress.ip: {info.identity.netaddress.ip} || info.identity.netaddress.port: {info.identity.netaddress.port}");
                Explorer.Logger.LogWarning($"info.identity.size: {info.identity.size}");
                Explorer.Logger.LogWarning($"info.identity.steamid: {info.identity.steamid}");
                Explorer.Logger.LogWarning($"info.identity.Steamid: {info.identity.SteamId}");
                Explorer.Logger.LogWarning($"info.identity.type: {info.identity.type}");
                Explorer.Logger.LogWarning($"info.Identity: {info.Identity}");
                Explorer.Logger.LogWarning($"info.listenSocket: {info.listenSocket}");
                Explorer.Logger.LogWarning($"info.listenSocket.Id: {info.listenSocket.Id}");
                Explorer.Logger.LogWarning($"info.pad: {info.pad}");
                Explorer.Logger.LogWarning($"info.popRelay: {info.popRelay}");
                Explorer.Logger.LogWarning($"info.popRelay.Value: {info.popRelay.Value}");
                Explorer.Logger.LogWarning($"info.popRemote: {info.popRemote}");
                Explorer.Logger.LogWarning($"info.popRemote.Value: {info.popRemote.Value}");
                Explorer.Logger.LogWarning($"info.state: {info.state}");
                Explorer.Logger.LogWarning($"info.state.ToString: {info.state.ToString()}");
                Explorer.Logger.LogWarning($"info.State: {info.State}");
                Explorer.Logger.LogWarning($"info.userData: {info.userData}");
                Explorer.Logger.LogWarning($"connection: {connection}");
                Explorer.Logger.LogWarning($"connection._Id_k__BackingField: {connection._Id_k__BackingField}");
                Explorer.Logger.LogWarning($"connection.Id: {connection.Id}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.OnConnecting), new System.Type[] { typeof(Steamworks.Data.ConnectionInfo) })]
        class Patch_SteamNetworking_OnConnecting__1
        {
            static void Postfix(ref Steamworks.Data.ConnectionInfo info)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnConnecting__1 Post");
                Explorer.Logger.LogWarning($"info: {info}");
                Explorer.Logger.LogWarning($"info.address: {info.address}");
                Explorer.Logger.LogWarning($"info.address.ip: {info.address.ip} || info.address.port {info.address.port}");
                Explorer.Logger.LogWarning($"info.connectionDescription: {info.connectionDescription}");
                Explorer.Logger.LogWarning($"info.endDebug: {info.endDebug}");
                Explorer.Logger.LogWarning($"info.endReason: {info.endReason}");
                Explorer.Logger.LogWarning($"info.identity: {info.identity}");
                Explorer.Logger.LogWarning($"info.identity.netaddess: {info.identity.netaddress}");
                Explorer.Logger.LogWarning($"info.identity.netaddress.ip: {info.identity.netaddress.ip} || info.identity.netaddress.port: {info.identity.netaddress.port}");
                Explorer.Logger.LogWarning($"info.identity.size: {info.identity.size}");
                Explorer.Logger.LogWarning($"info.identity.steamid: {info.identity.steamid}");
                Explorer.Logger.LogWarning($"info.identity.Steamid: {info.identity.SteamId}");
                Explorer.Logger.LogWarning($"info.identity.type: {info.identity.type}");
                Explorer.Logger.LogWarning($"info.Identity: {info.Identity}");
                Explorer.Logger.LogWarning($"info.listenSocket: {info.listenSocket}");
                Explorer.Logger.LogWarning($"info.listenSocket.Id: {info.listenSocket.Id}");
                Explorer.Logger.LogWarning($"info.pad: {info.pad}");
                Explorer.Logger.LogWarning($"info.popRelay: {info.popRelay}");
                Explorer.Logger.LogWarning($"info.popRelay.Value: {info.popRelay.Value}");
                Explorer.Logger.LogWarning($"info.popRemote: {info.popRemote}");
                Explorer.Logger.LogWarning($"info.popRemote.Value: {info.popRemote.Value}");
                Explorer.Logger.LogWarning($"info.state: {info.state}");
                Explorer.Logger.LogWarning($"info.state.ToString: {info.state.ToString()}");
                Explorer.Logger.LogWarning($"info.State: {info.State}");
                Explorer.Logger.LogWarning($"info.userData: {info.userData}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.OnDisconnected), new System.Type[] { typeof(Steamworks.Data.ConnectionInfo) })]
        class Patch_SteamNetworking_OnDisconnected__1
        {
            static void Postfix(ref Steamworks.Data.ConnectionInfo info)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnDisconnected__1 Post");
                Explorer.Logger.LogWarning($"info: {info}");
                Explorer.Logger.LogWarning($"info.address: {info.address}");
                Explorer.Logger.LogWarning($"info.address.ip: {info.address.ip} || info.address.port {info.address.port}");
                Explorer.Logger.LogWarning($"info.connectionDescription: {info.connectionDescription}");
                Explorer.Logger.LogWarning($"info.endDebug: {info.endDebug}");
                Explorer.Logger.LogWarning($"info.endReason: {info.endReason}");
                Explorer.Logger.LogWarning($"info.identity: {info.identity}");
                Explorer.Logger.LogWarning($"info.identity.netaddess: {info.identity.netaddress}");
                Explorer.Logger.LogWarning($"info.identity.netaddress.ip: {info.identity.netaddress.ip} || info.identity.netaddress.port: {info.identity.netaddress.port}");
                Explorer.Logger.LogWarning($"info.identity.size: {info.identity.size}");
                Explorer.Logger.LogWarning($"info.identity.steamid: {info.identity.steamid}");
                Explorer.Logger.LogWarning($"info.identity.Steamid: {info.identity.SteamId}");
                Explorer.Logger.LogWarning($"info.identity.type: {info.identity.type}");
                Explorer.Logger.LogWarning($"info.Identity: {info.Identity}");
                Explorer.Logger.LogWarning($"info.listenSocket: {info.listenSocket}");
                Explorer.Logger.LogWarning($"info.listenSocket.Id: {info.listenSocket.Id}");
                Explorer.Logger.LogWarning($"info.pad: {info.pad}");
                Explorer.Logger.LogWarning($"info.popRelay: {info.popRelay}");
                Explorer.Logger.LogWarning($"info.popRelay.Value: {info.popRelay.Value}");
                Explorer.Logger.LogWarning($"info.popRemote: {info.popRemote}");
                Explorer.Logger.LogWarning($"info.popRemote.Value: {info.popRemote.Value}");
                Explorer.Logger.LogWarning($"info.state: {info.state}");
                Explorer.Logger.LogWarning($"info.state.ToString: {info.state.ToString()}");
                Explorer.Logger.LogWarning($"info.State: {info.State}");
                Explorer.Logger.LogWarning($"info.userData: {info.userData}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.OnDisconnected), new System.Type[] { typeof(Steamworks.Data.Connection), typeof(Steamworks.Data.ConnectionInfo) })]
        class Patch_SteamNetworking_OnDisconnected__2
        {
            static void Postfix(ref Steamworks.Data.Connection connection, ref Steamworks.Data.ConnectionInfo info)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnDisconnected__2 Post");
                Explorer.Logger.LogWarning($"info: {info}");
                Explorer.Logger.LogWarning($"info.address: {info.address}");
                Explorer.Logger.LogWarning($"info.address.ip: {info.address.ip} || info.address.port {info.address.port}");
                Explorer.Logger.LogWarning($"info.connectionDescription: {info.connectionDescription}");
                Explorer.Logger.LogWarning($"info.endDebug: {info.endDebug}");
                Explorer.Logger.LogWarning($"info.endReason: {info.endReason}");
                Explorer.Logger.LogWarning($"info.identity: {info.identity}");
                Explorer.Logger.LogWarning($"info.identity.netaddess: {info.identity.netaddress}");
                Explorer.Logger.LogWarning($"info.identity.netaddress.ip: {info.identity.netaddress.ip} || info.identity.netaddress.port: {info.identity.netaddress.port}");
                Explorer.Logger.LogWarning($"info.identity.size: {info.identity.size}");
                Explorer.Logger.LogWarning($"info.identity.steamid: {info.identity.steamid}");
                Explorer.Logger.LogWarning($"info.identity.Steamid: {info.identity.SteamId}");
                Explorer.Logger.LogWarning($"info.identity.type: {info.identity.type}");
                Explorer.Logger.LogWarning($"info.Identity: {info.Identity}");
                Explorer.Logger.LogWarning($"info.listenSocket: {info.listenSocket}");
                Explorer.Logger.LogWarning($"info.listenSocket.Id: {info.listenSocket.Id}");
                Explorer.Logger.LogWarning($"info.pad: {info.pad}");
                Explorer.Logger.LogWarning($"info.popRelay: {info.popRelay}");
                Explorer.Logger.LogWarning($"info.popRelay.Value: {info.popRelay.Value}");
                Explorer.Logger.LogWarning($"info.popRemote: {info.popRemote}");
                Explorer.Logger.LogWarning($"info.popRemote.Value: {info.popRemote.Value}");
                Explorer.Logger.LogWarning($"info.state: {info.state}");
                Explorer.Logger.LogWarning($"info.state.ToString: {info.state.ToString()}");
                Explorer.Logger.LogWarning($"info.State: {info.State}");
                Explorer.Logger.LogWarning($"info.userData: {info.userData}");
                Explorer.Logger.LogWarning($"connection: {connection}");
                Explorer.Logger.LogWarning($"connection._Id_k__BackingField: {connection._Id_k__BackingField}");
                Explorer.Logger.LogWarning($"connection.Id: {connection.Id}");
            }
        }
        */
        /*
        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.OnMessage), new System.Type[] { typeof(Steamworks.Data.Connection), typeof(Steamworks.Data.NetIdentity), typeof(System.IntPtr), typeof(int), typeof(long), typeof(long), typeof(int) })]
        class Patch_SteamNetworking_OnMessage__2_AsHost
        {
            static void Postfix(ref System.IntPtr data)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnMessage__2_AsHost Post");
                Explorer.Logger.LogWarning($"data: {data}");
                Explorer.Logger.LogWarning($"Marshal.PtrToStringUni(data): {Marshal.PtrToStringUni(data)}");
                Explorer.Logger.LogWarning($"Marshal.PtrToStringAuto(data): {Marshal.PtrToStringAuto(data)}");
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnMessage__2_AsHost Post End");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.OnMessage), new System.Type[] { typeof(System.IntPtr), typeof(int), typeof(long), typeof(long), typeof(int) })]
        class Patch_SteamNetworking_OnMessage__1_AsClient
        {
            static void Postfix(ref System.IntPtr data, ref int size, ref long messageNum, ref long recvTime, ref int lane)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnMessage__1_AsClient Post");
                Explorer.Logger.LogWarning($"data: {data}");
                Explorer.Logger.LogWarning($"Marshal.PtrToStringUni(data): {Marshal.PtrToStringUni(data)}");
                Explorer.Logger.LogWarning($"Marshal.PtrToStringAuto(data): {Marshal.PtrToStringAuto(data)}");
                Explorer.Logger.LogMessage("Patch_SteamNetworking_OnMessage__1_AsClient Post End");
                //Explorer.Logger.LogWarning($"data.ToString: {data.ToString()}");
                //Explorer.Logger.LogWarning($"Marshal.ReadIntPtr(data): {Marshal.ReadIntPtr(data)}");
                //Explorer.Logger.LogWarning($"Marshal.ReadByte(data): {Marshal.ReadByte(data)}");
                //Explorer.Logger.LogWarning($"size: {size}");
                //Explorer.Logger.LogWarning($"messageNum: {messageNum}");
                //Explorer.Logger.LogWarning($"recvTime: {recvTime}");
                //Explorer.Logger.LogWarning($"lane: {lane}");
            }
        }
        */

        /*
        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.SendMessages))]
        class Patch_SteamNetworking_SendMessages
        {
            static void Postfix(ref Unity.Collections.NativeQueue<Unity.Networking.Transport.QueuedSendMessage> messages)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_SendMessages Post");
                //Explorer.Logger.LogWarning($"messages: {messages}");
                //Explorer.Logger.LogWarning($"messages.Count: {messages.Count}");
            }
        }

        [HarmonyPatch(typeof(SteamNetworking), nameof(SteamNetworking.ReceiveMessages))]
        class Patch_SteamNetworking_ReceiveMessages
        {
            static void Postfix(ref Unity.Collections.NativeQueue<Unity.Networking.Transport.QueuedSendMessage> messages)
            {
                Explorer.Logger.LogMessage("Patch_SteamNetworking_SendMessages Post");
                //Explorer.Logger.LogWarning($"messages: {messages}");
                //Explorer.Logger.LogWarning($"messages.Count: {messages.Count}");
            }
        }
        */

        /*
        [HarmonyPatch(typeof(Steamworks.Data.Connection), nameof(Steamworks.Data.Connection.SendMessage))]
        class Patch_Steamworks_Data_Connection_SendMessage
        {
            static void Postfix()
            {
                Explorer.Logger.LogMessage("Patch_Steamworks_Data_Connection_SendMessage Post");
            }
        }
        */
    }
}