using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStartController : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] private NetworkRunner _runnerPrefab;
    [SerializeField] private Player _playerPrefab;

    private NetworkRunner _runnerInstance;

    public static event Action<NetworkRunner, NetworkInput> OnInputEvent = null;

    private void Start()
    {
        Connect();
    }

    private void Connect()
    {
        _runnerInstance = Instantiate( _runnerPrefab );
        _runnerInstance.AddCallbacks( this );

        _runnerInstance.StartGame(
            new StartGameArgs()
            {
                GameMode = GameMode.AutoHostOrClient,
                PlayerCount = 4,              
            }
            );
    }

    public void OnObjectExitAOI( NetworkRunner runner, NetworkObject obj, PlayerRef player )
    {
        
    }

    public void OnObjectEnterAOI( NetworkRunner runner, NetworkObject obj, PlayerRef player )
    {
        
    }

    public void OnPlayerJoined( NetworkRunner runner, PlayerRef player )
    {
        if( !runner.IsServer )
        {
            return;
        }

        runner.Spawn( _playerPrefab, inputAuthority: player );
    }

    public void OnPlayerLeft( NetworkRunner runner, PlayerRef player )
    {
        
    }

    public void OnShutdown( NetworkRunner runner, ShutdownReason shutdownReason )
    {
        
    }

    public void OnDisconnectedFromServer( NetworkRunner runner, NetDisconnectReason reason )
    {
        
    }

    public void OnConnectRequest( NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token )
    {
        
    }

    public void OnConnectFailed( NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason )
    {
        
    }

    public void OnUserSimulationMessage( NetworkRunner runner, SimulationMessagePtr message )
    {
        
    }

    public void OnReliableDataReceived( NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data )
    {
        
    }

    public void OnReliableDataProgress( NetworkRunner runner, PlayerRef player, ReliableKey key, float progress )
    {
        
    }

    public void OnInput( NetworkRunner runner, NetworkInput input )
    {
        OnInputEvent?.Invoke( runner, input );
    }

    public void OnInputMissing( NetworkRunner runner, PlayerRef player, NetworkInput input )
    {
        
    }

    public void OnConnectedToServer( NetworkRunner runner )
    {
        
    }

    public void OnSessionListUpdated( NetworkRunner runner, List<SessionInfo> sessionList )
    {
        
    }

    public void OnCustomAuthenticationResponse( NetworkRunner runner, Dictionary<string, object> data )
    {
        
    }

    public void OnHostMigration( NetworkRunner runner, HostMigrationToken hostMigrationToken )
    {
        
    }

    public void OnSceneLoadDone( NetworkRunner runner )
    {
        
    }

    public void OnSceneLoadStart( NetworkRunner runner )
    {
        
    }
}
