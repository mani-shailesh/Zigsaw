using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class frontPanel : MonoBehaviour {
	public static int level;
	string path;
	string userName;
	InputField pathBox;
	InputField nameBox;
	Slider levelBar;
	AndroidJavaClass browseClass;
	// Use this for initialization
	void Start () {
		AndroidJNI.AttachCurrentThread();
		browseClass = new AndroidJavaClass("com.IITB_CDEEP.JigsawAndroid.Browse");
		level = 2;
		userName = "";
		path = "";
		levelBar = GameObject.Find ("Level").GetComponent<Slider> ();
		nameBox = GameObject.Find ("Name").GetComponent<InputField> ();
		pathBox = GameObject.Find ("Path").GetComponent<InputField>();
		string[] settings = new string[1];
		try{
			settings = System.IO.File.ReadAllLines(Application.persistentDataPath+"/Settings.txt");
			pathBox.text = path = settings[1];
			nameBox.text = userName = settings[0];
			levelBar.value = level = int.Parse(settings[2]);
		}catch{
			pathBox.text = Application.persistentDataPath;
			print ("File not found");
		}
	}
	public void onClickCancel(){
		if(userName!="" && path!=""){
			Application.LoadLevel("splash");
		}
	}
	public void proceed(){
		if (nameBox.text!="" && pathBox.text!="") {
			level = (int)levelBar.value;
			userName = nameBox.text;
			path = pathBox.text;
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.persistentDataPath+"/Settings.txt"))
			{
				file.WriteLine(userName);
				file.WriteLine(path);
				file.WriteLine(level.ToString());
				file.Close();
			}
			Application.LoadLevel("splash");
		}
	}
	public void browseImage(){
#if UNITY_EDITOR		
		path = EditorUtility.OpenFilePanel("Select Image", "", "jpg");
		pathBox.text = path;
#endif
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
		currentActivity.Call("selectImage");
		//path = browseClass.CallStatic<string>("returnPath");
		//pathBox.text = path;
	}

	public void updatePathBox(string resultPath){
		path = resultPath;
		pathBox.text = resultPath;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
