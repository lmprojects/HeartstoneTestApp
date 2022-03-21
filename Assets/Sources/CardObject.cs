using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    public RawImage mainImage;
    public Text healthText;
    public Text attackText;
    public Text manaText;
    public System.Action<CardObject> ReturnCard;

    public bool IsEnable { get { return gameObject.activeInHierarchy; } }

    private float counterPause = 0;
    public float CounterPause { get => counterPause; set { counterPause = value; } }

    private int health = 1;
    private int attack = 1;
    private int mana = 1;
    private float tickDuration = 1f;

    private const string picUrl = "https://picsum.photos/140/100";

    private void Start()
    {
        StartCoroutine(DownloadImage());
        SetStartParameters(Random.Range(4, 10), Random.Range(4, 10), Random.Range(4, 10));
    }

    private IEnumerator DownloadImage()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(picUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            mainImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    public void SetStartParameters(int healthV, int attackV, int manaV)
	{
        health = healthV;
        healthText.text = health.ToString();
        attack = attackV;
        attackText.text = attack.ToString();
        mana = manaV;
        manaText.text = mana.ToString();
    }

    public void SetNewHealth(int newValue)
	{
        if (health == newValue)
            return;
        StartCoroutine(UpdateUI(healthText, health, newValue));
        health = newValue;
    }

    public void SetNewAttack(int newValue)
    {
        if (attack == newValue)
            return;
        StartCoroutine(UpdateUI(attackText, attack, newValue));
        attack = newValue;
    }

    public void SetNewMana(int newValue)
    {
        if (mana == newValue)
            return;
        StartCoroutine(UpdateUI(manaText, mana, newValue));
        mana = newValue;
    }

    private IEnumerator UpdateUI(Text txt, int prevVal, int newVal)
    {
        yield return new WaitForSeconds(counterPause);
        float elapsedTime = 0;
        while (elapsedTime < tickDuration)
        {
            int i = Mathf.FloorToInt(Mathf.Lerp(prevVal, newVal, (elapsedTime / tickDuration)));
            txt.text = i.ToString();
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        txt.text = newVal.ToString();
        if (health <= 0)
            ReturnCard.Invoke(this);
    }

    public void EnableCard()
    {
        this.gameObject.SetActive(true);
    }

    public void DisableCard()
	{
        this.gameObject.SetActive(false);
	}
}
