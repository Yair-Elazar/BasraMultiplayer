using UnityEngine;
using Unity.Netcode;
public class Client : NetworkBehaviour
{
    private GameManager GM;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            ConnectServerRpc(OwnerClientId);
        }
    }
    
    [ServerRpc]
    private void ConnectServerRpc(ulong clientId)
    {
        GM = FindAnyObjectByType<GameManager>();
        GM.OnStartGame += OnStartGameClientRpc;
        GM.RegisterClient(clientId);
    }
    [ClientRpc]
    private void OnStartGameClientRpc()
    {
        if(IsOwner) new StartGameCommand().Enqueue();
    }
}
