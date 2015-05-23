using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class dropHandler : MonoBehaviour, IDropHandler{
	public GameObject item{
		get {
			if(transform.childCount>0){
				return transform.GetChild(0).gameObject;
			}
			return null;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {
			dragHandler.itemBeingDragged.transform.SetParent(transform);
		}
	}

	#endregion
}
