using UnityEngine;
using Unity.Netcode;
public class Client : NetworkBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    private GameManager GM;
    private Transform handTransform;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            ConnectServerRpc(OwnerClientId);
            handTransform = GameObject.Find("PlayerHand").transform;
        }
        else
        {
            handTransform = GameObject.Find("EnemyHand").transform;
        }
    }
    
    [ServerRpc]
    private void ConnectServerRpc(ulong clientId)
    {
        GM = FindAnyObjectByType<GameManager>();
        GM.OnStartGame += OnStartGameClientRpc;
        GM.RegisterClient(clientId);
        Player player = GM.GetPlayer(clientId);
        player.OnCardDealt = OnCardDealtClientRpc;
    }

    [ClientRpc]
    private void OnCardDealtClientRpc(int handIndex, Card card)
    {
        new DealCardCommand(cardPrefab ,handTransform.GetChild(handIndex), card, IsOwner)
            .Enqueue();
    }
    [ClientRpc]
    private void OnStartGameClientRpc()
    {
        if(IsOwner) new StartGameCommand().Enqueue();
    }
}
