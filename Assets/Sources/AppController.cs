using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour
{
    [SerializeField]
    protected HandController handController;
	[SerializeField]
	protected Button changeButton;

    public void ChangeValues()
	{
		float counterPause = 0;
		float pauseAdd = 1f;
        for(int i = 0; i < handController.cardsInHand.Count; i++)
		{
			handController.cardsInHand[i].CounterPause = counterPause;
			counterPause += pauseAdd;
			int parameter = Random.Range(0, 3);//0 - health, 1 - attack, 2 - mana
			int value = Random.Range(-2, 10);
			switch(parameter)
			{
				case 0:
				default:
					Debug.Log(string.Format("Card {0} health from {1} to {2}", counterPause / pauseAdd, handController.cardsInHand[i].healthText.text, value));
					handController.cardsInHand[i].SetNewHealth(value);
					break;
				case 1:
					Debug.Log(string.Format("Card {0} attack from {1} to {2}", counterPause / 0.5f, handController.cardsInHand[i].attackText.text, value));
					handController.cardsInHand[i].SetNewAttack(value);
					break;
				case 2:
					Debug.Log(string.Format("Card {0} mana from {1} to {2}", counterPause / 0.5f, handController.cardsInHand[i].manaText.text, value));
					handController.cardsInHand[i].SetNewMana(value);
					break;
			}
		}
	}

	private void Update()
	{
		if (handController.IsHandEmpty)
		{
			changeButton.interactable = false;
			changeButton.enabled = false;
		}
	}
}
