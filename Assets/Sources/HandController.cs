using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    protected CardPool cardPool;

    [HideInInspector]
    public List<CardObject> cardsInHand;

    public bool IsHandEmpty { get => cardsInHand.Count == 0; }

    private int countCardInHand = 4;

    // Start is called before the first frame update
    private void Start()
    {
        countCardInHand = Random.Range(4, 7);
        for (int i = 0; i < countCardInHand; i++)
        {
            cardsInHand.Add(cardPool.GetCard());
        }
    }

    public void RemoveFromHand(CardObject card)
	{
        cardsInHand.Remove(card);
	}
}
