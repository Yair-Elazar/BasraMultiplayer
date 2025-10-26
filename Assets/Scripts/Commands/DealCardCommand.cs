using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DealCardCommand : Command
{
    GameObject cardPrefab;
    Transform handCardSlot;
    Card card;
    bool isOwner;
    
    public DealCardCommand(GameObject cardPrefab, Transform handCardSlot, Card card, bool isOwner)
    {
        this.cardPrefab = cardPrefab;
        this.handCardSlot = handCardSlot;
        this.card = card;
        this.isOwner = isOwner;
    }
    public override void Execute()
    {
        var go = GameObject.Instantiate(cardPrefab, handCardSlot);
        go.transform.position = GameObject.Find("Deck").transform.position;
        if (isOwner)
        {
            go.GetComponent<Image>().sprite = SpritesDatabase.instance.GetCardSprite(card);   
        }

        go.transform.DOMove(handCardSlot.position, 0.5f)
            .OnComplete(ExecuteComplete);
        ;
    }
}
