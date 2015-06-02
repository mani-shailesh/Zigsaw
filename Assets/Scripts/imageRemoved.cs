using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class imageRemoved : MonoBehaviour {
	int noOfImagesLast;
	// Use this for initialization
	void Start () {
		noOfImagesLast = GetComponentsInChildren<Image>().Length;
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponentsInChildren<Image>().Length<noOfImagesLast){
			Destroy(gameObject);
		}
		noOfImagesLast = GetComponentsInChildren<Image>().Length;
	}
}
