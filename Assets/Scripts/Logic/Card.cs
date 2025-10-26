using Unity.Netcode;
using UnityEngine;

public class Card : INetworkSerializable
{

    public Suit suit;
    public Value value;
    public Card(){}
    public Card(Suit suit, Value value)
    {
        this.suit = suit;
        this.value = value;
    }

    public override string ToString()
    {
        return $"{this.value} of {this.suit}";
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref suit);
        serializer.SerializeValue(ref value);
    }
}
public enum Suit
{
    Club,
    Diamond,
    Heart,
    Spade
}

public enum Value
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
}