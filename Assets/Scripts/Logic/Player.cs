using System;
using UnityEngine;

public class Player 
{
    public ulong clientId {get; private set;}
    private Card[] hand = new Card[4];
    public Player(ulong clientId)
    {
        this.clientId = clientId;
    }

    public void DealCard(Card card)
    {
        for (int i = 0; i < 4; i++)
        {
            if (hand[i] == null)
                {
                hand[i] = card;
                return; 
                }
        }
        throw new InvalidOperationException($"player {clientId} hand was full");
    }
}
