using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class frontPanel : MonoBehaviour {
	public static int level;
	string path;
	public static Texture2D gameImage;
	string userName;
	InputField pathBox;
	// Use this for initialization
	void Start () {
		level = 2;
		pathBox = GameObject.Find ("Path").GetComponent<InputField>();
		gameImage = new Texture2D(1000, 1000);
	}

	public void proceed(){
		level = (int)GameObject.Find ("Level").GetComponent<Slider> ().value;
		userName = GameObject.Find ("Name").GetComponentsInChildren<Text> () [1].GetComponent<Text> ().text;
		path = pathBox.text;
		if (userName!="" && path!="") {
			putImage();
			Application.LoadLevel("game");
		}
	}
	public void browseImage(){
#if UNITY_EDITOR		
		path = EditorUtility.OpenFilePanel("Select Image", "", "jpg");
		pathBox.text = path;
#endif
	}
	void putImage(){
		if (path.Length != 0) {
			WWW www = new WWW("file:///" + path);
			www.LoadImageIntoTexture(gameImage);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
