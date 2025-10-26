using UnityEngine;

public class Card
{

    public Suit suit;
    public Value value;

    public Card(Suit suit, Value value)
    {
        this.suit = suit;
        this.value = value;
    }

    public override string ToString()
    {
        return $"{this.value} of {this.suit}";
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