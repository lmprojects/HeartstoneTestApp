using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 c = Camera.main.ScreenToWorldPoint(eventData.position);
		this.transform.position = new Vector3(c.x, c.y, 0);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}

	public void EnterDropPanel()
	{
		Debug.LogError("enter");
	}
	public void ExitDropPanel()
	{
		Debug.LogError("exit");
	}
}
