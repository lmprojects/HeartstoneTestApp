using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject cardPref;
    [SerializeField]
    protected HandController hand;

    private List<CardObject> cardsPool;

    private void Start()
    {
        cardsPool = GetComponentsInChildren<CardObject>().ToList();
        foreach (CardObject card in cardsPool)
            card.ReturnCard += ReturnCard;
    }

    private void CreateNewCard()
	{
        GameObject go = Instantiate(cardPref, transform);
        CardObject card = go.GetComponent<CardObject>();
        card.ReturnCard += ReturnCard;
        cardsPool.Add(card);
	}

    public CardObject GetCard()
	{
        if (cardsPool.Count == 0)
            CreateNewCard();
        CardObject card = cardsPool[0];
        cardsPool.RemoveAt(0);
        card.transform.parent = hand.transform;
        card.EnableCard();
        hand.transform.localPosition = new Vector3(hand.transform.localPosition.x - 66.5f, hand.transform.localPosition.y, hand.transform.localPosition.z);
        return card;
	}

    public void ReturnCard(CardObject card)
	{
        hand.RemoveFromHand(card);
        cardsPool.Add(card);
        card.StopAllCoroutines();
        card.transform.parent = transform;
        card.DisableCard();
        hand.transform.localPosition = new Vector3(hand.transform.localPosition.x + 66.5f, hand.transform.localPosition.y, hand.transform.localPosition.z);
    }
}
