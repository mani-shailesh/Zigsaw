using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class dragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startParent = transform.parent;
		startPosition = transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{	GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		}
		itemBeingDragged = null;
	}

	#endregion
}
