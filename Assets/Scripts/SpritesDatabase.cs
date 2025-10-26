using System;
using System.Collections.Generic;
using UnityEngine;

public class SpritesDatabase : MonoBehaviour
{
    private Dictionary<string, Sprite> cardSprites = new();
    public static SpritesDatabase instance;

     private void Awake()
     {
          instance = this;
          int i = 0;
          var sprites = Resources.LoadAll<Sprite>("CardSprites");
          foreach (Suit suit in Enum.GetValues(typeof(Suit)))
          {
               foreach (Value value in Enum.GetValues(typeof(Value)))
               {
                    cardSprites[new Card(suit, value).ToString()] = sprites[i];
                    i++;
               }
          }
          Debug.Log($"Loaded {cardSprites.Count}");
     }

     public Sprite GetCardSprite(Card card)
     {
          return cardSprites[card.ToString()];
     }
}
