using UnityEngine;
using Unity.Netcode;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GameManager : NetworkBehaviour
{
    private Player p1;
    private Player p2;
    private List<Card> deck;
    
    public override void OnNetworkSpawn()
    {
        Debug.Log($"Gm: isOwnedByServer? {IsOwnedByServer} , OwnerClientId: {OwnerClientId}");
    }

    public void RegisterClient(ulong clientId)
    {
        if (p1 == null)
        {
            p1 = new Player(clientId);
        }
        else if (p2 == null)
        {
            p2 = new Player(clientId);
            StartGame();
        }
        else
        {
            throw new InvalidOperationException("Client is not registered");
        }
    }
    public Action OnStartGame;
    private void StartGame()
    {
        OnStartGame?.Invoke();
        InitDeck();
    }
    
    private void InitDeck()
    {
        deck = new();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Value value in Enum.GetValues(typeof(Value)))
            {
                deck.Add(new Card(suit, value));
            }
        }
        ShuffleDeck();
        foreach (var c in deck)
        {
            Debug.Log($"Deck contains: {c}");
        }
    }

    private void ShuffleDeck()
    {
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            (deck[k], deck[n]) = (deck[n], deck[k]);
        }
    }

    private void DealInitialHand()
    {
        for (int i = 0; i < 4; i++)
        {
            p1.DealCard(GetFirstCard());
            p2.DealCard(GetFirstCard());
            
        }
    }

    private Card GetFirstCard()
    {
        var card = deck[0];
        deck.RemoveAt(0);
        return card;
    }
    
}
