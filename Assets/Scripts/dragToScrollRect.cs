using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragToScrollRect : MonoBehaviour, IDropHandler {
	GameObject newPiece;
	public GameObject piece;
	int noOfCols, noOfRows;
	Vector2 cellSizeVector;
	// Use this for initialization
	void Start () {
		noOfCols = noOfRows = splashScript.level;
		Rect slotsRect = GameObject.Find ("Slots").GetComponent<RectTransform> ().rect;
		cellSizeVector = new Vector2 ((Screen.width-noOfCols)/(noOfCols+1), (slotsRect.height-noOfRows)/noOfRows);
		
	}

	#region IDropHandler implementation
	
	public void OnDrop (PointerEventData eventData)
	{
		if(dragHandler.itemBeingDragged==null){
			return;
		}
		newPiece = Instantiate<GameObject>(piece);
		newPiece.transform.SetParent(transform.GetChild(0));
		newPiece.GetComponent<GridLayoutGroup>().cellSize = cellSizeVector;
		//newPiece.GetComponentsInChildren<Image>()[1].sprite = dragHandler.itemBeingDragged.GetComponent<Image>().sprite;
		//string temp = dragHandler.itemBeingDragged.name;
		//Destroy(dragHandler.itemBeingDragged);
		dragHandler.itemBeingDragged.transform.SetParent(newPiece.transform);
		//newPiece.GetComponentsInChildren<Image>()[1].name = temp;
		//newPiece.GetComponentInChildren<CanvasGroup>().blocksRaycasts = true;
		//print ("Dragged to scrollRect");
	}
	
	#endregion
	// Update is called once per frame
	void Update () {
	
	}
}
